using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RicartAgrawala2
{
    class Logic
    {
        public states currentState = states.NOT_CONNECTED;
        public states savedState;
        public enum states {NOT_CONNECTED, INITIALIZATION, IDLE, REQUESTING, BUSY, RE_INIT}
        Dictionary<string, Peer> peers = new Dictionary<string, Peer>();
        List<Peer> awaitingPeers = new List<Peer>();
        List<string> replies = new List<string>();
        List<Message> highestSNawaiting = new List<Message>();
        int sequenceNumber = 0;
        int initialIntro = 0;
        DateTime endCriticalSection;
        DateTime endInitialization;
        TimeSpan criticalSectionHandling = new TimeSpan(0, 0, 5);
        TimeSpan networkDelay = new TimeSpan(0, 0, 5);
        public Message.From itIsI;
        List<Message> csRequestsToBeHandled = new List<Message>();
        public bool canRequestCS = false;
        string tempSponsor = "______Sponsor";
        struct TimeoutData
        {
            public Peer peer;
            public Message.messageType type;
            public DateTime timeout;
        };
        List<TimeoutData> replayTimeout = new List<TimeoutData>();
        
        public void setCriticalSectTimespan(int sec)
        {
            criticalSectionHandling = new TimeSpan(0, 0, sec);
        }

        public void playDead()
        {
            savedState = currentState;
            currentState = states.NOT_CONNECTED;
        }

        public void respawn()
        {
            currentState = savedState;
        }

        public void setNetworkDelay(int sec)
        {
            networkDelay = new TimeSpan(0, 0, sec);
        }

        void setCanRequestCS()
        {
            if (currentState == states.IDLE)
            {
                canRequestCS = true;
            }
            else
            {
                canRequestCS = false;
            }
        }

        void ErrorLog(string str)
        {
            Console.WriteLine(str);
        }

        void Log(string str)
        {
            Console.WriteLine(str);
        }

        public void requestSponsor(string _IP, int _port)
        {
            AddPeer(new Peer(_IP, _port, tempSponsor));
            Message msg = new Message(Message.messageType.INIT, itIsI);
            msg.CONTENT.ROLE = Message.roleType.NEW;
            peers[tempSponsor].SendMessage(msg);
            Log("requestSponsor");
        }

        void OnImportantMessageSent(Peer peer, Message msg, Message.messageType typeToRemove)
        {
            RemoveTimeoutByPeerAndType(peer, typeToRemove);

            TimeoutData data = new TimeoutData();
            data.type = msg.TYPE;
            data.peer = peer;
            data.timeout = DateTime.Now + new TimeSpan(0, 0, Math.Max(peers.Count, 1) * (int)(networkDelay.TotalSeconds + criticalSectionHandling.TotalSeconds) );
            replayTimeout.Add(data);
            // CHECK IF ALWAYS THE SAME TIMEOUT
        }

        void AddPeer(string _uniqueName, string _ip, int _port)
        {
            Peer new_peer = new Peer(_ip, _port, _uniqueName);
            AddPeer(new_peer);
        }

        void AddPeer(Peer new_peer)
        {
            if (peers.Keys.Contains(new_peer.name))
            {
                ErrorLog("AddPeer not unique name");
                return;
            }
            peers[new_peer.name] = new_peer;
        }

        void RemovePeer(Peer peer)
        {
            peers.Remove(peer.name);
            for (int i = 0; i < replayTimeout.Count; )
            {
                if (replayTimeout[i].peer == peer)
                {
                    replayTimeout.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            replies.Remove(peer.name);
            if (currentState == states.REQUESTING)
            {
                tryEnterCriticalSection();
            }
        }

        public Logic(int _port, string _ip, string _name)
        {
            itIsI = new Message.From(_name, _port, _ip);
            Log("Logic!!!");
        }

        bool isUniqueName(String _newName)
        {
            if (_newName == itIsI.UNIQUENAME)
            {
                return false;
            }
            foreach (string peer_name in peers.Keys)
            {
                if (peer_name == _newName)
                    return false;
            }
            /*
            foreach (Peer peer in awaitingPeers)
            {
                if (peer.name == _newName)
                    return false;
            }
             */
            return true;
        }

        void CheckTimeouts()
        {
            DateTime current_time = DateTime.Now;
            List<Peer> dead = new List<Peer>();
            for (int i = 0; i < replayTimeout.Count; i++)
            {
                DateTime time = replayTimeout[i].timeout;
                Message.messageType type = replayTimeout[i].type;
                Peer peer = replayTimeout[i].peer;
                if (time <= current_time)
                {
                    switch (type)
                    {
                        case Message.messageType.ARE_YOU_THERE:
                            Message mss = new Message(Message.messageType.DEAD, itIsI);
                            mss.CONTENT.NODE = peer.name;
                            dead.Add(peer);
                            foreach (Peer p in peers.Values)
                            {
                                if (!dead.Contains(p))
                                    p.SendMessage(mss);
                            }
                            break;
                        case Message.messageType.REQUEST:
                            Message mms = new Message(Message.messageType.ARE_YOU_THERE, itIsI);
                            peer.SendMessage(mms);
                            OnImportantMessageSent(peer, mms, Message.messageType.REQUEST);
                            break;
                    }
                }
            }
            foreach (Peer dead_peer in dead)
            {
                RemovePeer(dead_peer);
            }
        }

        public void release()
        {
            ErrorLog("LEAVE CRITICAL SECTION");
        }

        public void Tick()
        {
            if (currentState == states.BUSY && DateTime.Now >= endCriticalSection)
            {
                release();
                if (currentState == states.NOT_CONNECTED)
                {
                    Log("Tick: currentState == states.NOT_CONNECTED");
                    return;
                }
                foreach (Message msg in highestSNawaiting)
                {
                    SendHighestSeqNr(msg);
                }
                highestSNawaiting.Clear();
                if (awaitingPeers.Count > 0)
                {
                    currentState = states.REQUESTING;
                    RequestForCS();
                }
                else
                {
                    currentState = states.IDLE;
                }
                AnswerUnresponsedRequests();

            }
            if (currentState == states.NOT_CONNECTED)
            {
                Log("Tick: currentState == states.NOT_CONNECTED");
                return;
            }
            CheckTimeouts();
            if (currentState == states.INITIALIZATION && initialIntro > 0)
            {
                if (DateTime.Now >= this.endInitialization)
                {
                    currentState = states.IDLE;
                    Console.WriteLine("init done");
                }
            }
            setCanRequestCS();
        }

        public void dispose()
        {
            Message msg = new Message(Message.messageType.DEAD, itIsI);
            msg.CONTENT.STATUS = Message.statusType.REMOVE;
            msg.CONTENT.NODE = itIsI.UNIQUENAME;
            foreach (Peer peer in peers.Values)
            {
                peer.SendMessage(msg);
            }
        }

        void AnswerUnresponsedRequests()
        {
            for ( int i = 0; i < csRequestsToBeHandled.Count;)
            {
                Message msg = csRequestsToBeHandled[i];
                if (isSequenceLower(msg))
                {
                    generateREPLY(msg);
                    csRequestsToBeHandled.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        public void OnReceive(Message msg)
        {
            ErrorLog("received from " + msg.FROM.UNIQUENAME + " type " + msg.TYPE + " current_state: " + currentState.ToString());

            if (currentState == states.NOT_CONNECTED)
            {
                return;
            }

            if (msg.TYPE != Message.messageType.INIT && !peers.Keys.Contains(msg.FROM.UNIQUENAME))
            {
                Message rsp = new Message(Message.messageType.DEAD, itIsI);
                rsp.CONTENT.STATUS = Message.statusType.RE_INIT;
                Peer temp = new Peer(msg.FROM.IP, msg.FROM.PORT, msg.FROM.UNIQUENAME);
                temp.SendMessage(rsp);
                return;
            }

            switch (msg.TYPE)
            {
                case Message.messageType.INIT:
                    HandleIntroduction(msg);
                    break;
                case Message.messageType.HIGHEST_SEQ_NUM:
                    HandleHighestSeqNr(msg);
                    break;
                case Message.messageType.REQUEST:
                    HandleRequestCriticalSection(msg);
                    break;
                case Message.messageType.REPLY:
                    HandleReply(msg);
                    break;
                case Message.messageType.YES_I_AM_HERE:
                    HandleYes(msg);
                    break;
                case Message.messageType.ARE_YOU_THERE:
                    HandleAreUThere(msg);
                    break;
                case Message.messageType.DEAD:
                    HandleDead(msg);
                    break;
                default:
                    break;
            }
        }

        void RemoveTimeoutByPeerAndType(Peer peer, Message.messageType type)
        {
            for (int i = 0; i < replayTimeout.Count; )
            {
                if (replayTimeout[i].peer == peer && replayTimeout[i].type == type)
                {
                    replayTimeout.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        void OnImportantMessageReply(Peer peer, Message msg)
        {
            if (null == peer || null == msg)
            {
                ErrorLog("error OnImportantMessageReply null == peer || null == msg");
            }
            switch (msg.TYPE)
            {
                case Message.messageType.YES_I_AM_HERE:
                    RemoveTimeoutByPeerAndType(peer, Message.messageType.ARE_YOU_THERE);
                    break;
                case Message.messageType.REPLY:
                    RemoveTimeoutByPeerAndType(peer, Message.messageType.REQUEST);
                    break;
                case Message.messageType.HIGHEST_SEQ_NUM:
                    RemoveTimeoutByPeerAndType(peer, Message.messageType.HIGHEST_SEQ_NUM);
                    break;
            }
        }

        void HandleDead(Message msg)
        {
            switch(msg.CONTENT.STATUS)
            {
                case Message.statusType.REMOVE:
                    RemovePeer(peers[msg.CONTENT.NODE]);
                    break;
                case Message.statusType.RE_INIT:
                    ErrorLog("RE INIT");
                    break;
            }
        }

        void HandleAreUThere(Message msg)
        {
            Message rsp = new Message(Message.messageType.YES_I_AM_HERE, itIsI);
            peers[msg.FROM.UNIQUENAME].SendMessage(rsp);
        }

        void HandleYes(Message msg)
        {
            //@todo: what with critical section?
            OnImportantMessageReply(peers[msg.FROM.UNIQUENAME], msg);
        }

        void HandleReply(Message msg)
        {
            if (currentState != states.REQUESTING)
            {
                ErrorLog("protocol error HandleReply");
                return;
            }
            replies.Add(msg.FROM.UNIQUENAME);
            tryEnterCriticalSection();
            OnImportantMessageReply(peers[msg.FROM.UNIQUENAME], msg);
        }
  
        void tryEnterCriticalSection()
        {
            if (replies.Count < peers.Count)
            {
                return;
            }
            currentState = states.BUSY;
            ErrorLog("ENTER CRITICAL SECTION");
            replies.Clear();
            if (awaitingPeers.Count > 0) // introduce
            {
                introduceAsSponsor(awaitingPeers[0]);
                awaitingPeers.RemoveAt(0);
            }
            else // czy timeout za każdym razem ??
            {
                this.endCriticalSection = DateTime.Now + this.criticalSectionHandling;
            }
        }

        void introduceAsSponsor(Peer newPeer)
        {
            if (!isUniqueName(newPeer.name))
            {
                Message new_msg = new Message(Message.messageType.INIT, itIsI);
                new_msg.CONTENT.ROLE = Message.roleType.SPONSOR;
                new_msg.CONTENT.STATUS = Message.statusType.NOT_UNIQUE;
                newPeer.SendMessage(new_msg);
                Log("introduceAsSponsor NOT_UNIQUE");
            }
            else
            {
                {
                    Message msg = new Message(Message.messageType.INIT, itIsI);

                    msg.CONTENT.ROLE = Message.roleType.NODE;

                    msg.CONTENT.NEWDATA.UNIQUENAME = newPeer.name;
                    msg.CONTENT.NEWDATA.IP = newPeer.client.IPaddr;
                    msg.CONTENT.NEWDATA.PORT = newPeer.client.port;
                    foreach (Peer peer in peers.Values)
                    {
                        peer.SendMessage(msg);
                    }
                }

                {
                    Message msg = new Message(Message.messageType.INIT, itIsI);
                    msg.CONTENT.ROLE = Message.roleType.SPONSOR;
                    msg.CONTENT.STATUS = Message.statusType.OK;
                    if (peers.Values.Count > 1)
                    {
                        msg.CONTENT.NODESDATA = new Message.From[peers.Values.Count - 1];
                        int i = 0;
                        foreach (Peer peer in peers.Values)
                        {
                            msg.CONTENT.NODESDATA[i] = new Message.From(peer.name, peer.client.port, peer.client.IPaddr);
                            i++;
                        }
                    }
                    newPeer.SendMessage(msg);
                }
                AddPeer(newPeer);

                Log("introduceAsSponsor NODE");
            }
        }

        void HandleHighestSeqNr(Message msg)
        {
            switch (msg.CONTENT.STATUS)
            {
                case Message.statusType.GET:
                    if (currentState == states.NOT_CONNECTED || currentState == states.INITIALIZATION)
                    {
                        ErrorLog("protocol error HandleHighestSeqNr statusType.GET");
                        return;
                    }
                    if (currentState == states.IDLE)
                    {
                        SendHighestSeqNr(msg);
                    }
                    else
                    {
                        highestSNawaiting.Add(msg);
                    }
                    break;
                case Message.statusType.RESPONSE:
                    if (currentState != states.INITIALIZATION)
                    {
                        ErrorLog("protocol error HandleHighestSeqNr statusType.RESPONSE");
                    }
                    initialIntro--;
                    int tmp_seq = msg.CONTENT.VALUE;
                    if (tmp_seq > this.sequenceNumber)
                    {
                        this.sequenceNumber = tmp_seq;
                    }
                    if (initialIntro <= 0)
                    {
                        currentState = states.IDLE;
                        Console.WriteLine("init done");
                    }
                    if (!peers.ContainsKey(msg.FROM.UNIQUENAME))
                    {
                        ErrorLog("!peers.ContainsKey(msg.FROM.UniqueName)");
                        return;
                    }
                    OnImportantMessageReply(peers[msg.FROM.UNIQUENAME], msg);
                    break;
            }
        }

        void SendHighestSeqNr(Message msg)
        {
            Message rsp = new Message(Message.messageType.HIGHEST_SEQ_NUM, itIsI);
            rsp.CONTENT.STATUS = Message.statusType.RESPONSE;
            rsp.CONTENT.VALUE = this.sequenceNumber;

            if (peers.ContainsKey(msg.FROM.UNIQUENAME))
            {
                peers[msg.FROM.UNIQUENAME].SendMessage(rsp);
            }
            else
            {
                ErrorLog("protocol error SendHighestSeqNr");
            }
        }

        void HandleIntroduction(Message msg)
        {
            Message.roleType role = msg.CONTENT.ROLE;
            switch (role)
            {
                case Message.roleType.NEW:
                    if (currentState == states.NOT_CONNECTED || currentState == states.INITIALIZATION)
                    {
                        ErrorLog("protocol error HandleIntroduction roleType.New");
                        return;
                    }
                    awaitingPeers.Add(new Peer(msg.FROM.IP, msg.FROM.PORT, msg.FROM.UNIQUENAME));
                    if (currentState != states.BUSY)
                    {
                        RequestForCS();
                    }
                    Log("HandleIntroduction isUniqueName");
                    break;
                case Message.roleType.SPONSOR:
                    if (currentState != states.INITIALIZATION)
                    {
                        ErrorLog("protocol error HandleIntroduction roleType.Sponsor");
                        return;
                    }
                    if (msg.CONTENT.STATUS == Message.statusType.OK)
                    {
                        initialIntro = 0;
                        if (null != msg.CONTENT.NODESDATA)
                        {
                            foreach (Message.From peer in msg.CONTENT.NODESDATA)
                            {
                                Peer new_peer = new Peer(peer.IP, peer.PORT, peer.UNIQUENAME);
                                AddPeer(new_peer);
                            }
                        }
                        RemovePeer(peers[tempSponsor]);
                        AddPeer(new Peer(msg.FROM.IP, msg.FROM.PORT, msg.FROM.UNIQUENAME));
                        foreach (Peer peer in peers.Values)
                        {
                            this.initialIntro++;
                            Message rsp = new Message(Message.messageType.HIGHEST_SEQ_NUM, itIsI);
                            rsp.CONTENT.STATUS = Message.statusType.GET;
                            peer.SendMessage(rsp);
                         //   OnImportantMessageSent(peer, rsp);
                        }
                        
                        //@todo: according to protocol?
                        endInitialization = DateTime.Now + new TimeSpan(0, 0, 10);
                    }
                    if (msg.CONTENT.STATUS == Message.statusType.NOT_UNIQUE)
                    {
                        Console.WriteLine("Generate new Unique Name");
                        currentState = states.INITIALIZATION;
                    }
                    break;

                case Message.roleType.NODE:
                    if (currentState == states.NOT_CONNECTED || currentState == states.INITIALIZATION || msg.CONTENT.NEWDATA.UNIQUENAME == "")
                    {
                        ErrorLog("protocol error HandleIntroduction roleType.Node");
                        return;
                    }
                    AddPeer(msg.CONTENT.NEWDATA.UNIQUENAME, msg.CONTENT.NEWDATA.IP, msg.CONTENT.NEWDATA.PORT);
                    break;
            }
        }

        public void RequestForCS()
        {
            currentState = states.REQUESTING;
            sequenceNumber++;
            Message msg = new Message(Message.messageType.REQUEST, itIsI);
            msg.CONTENT.SEQNUM = sequenceNumber;
            Log("RequestForCS " + sequenceNumber);
            foreach (Peer peer in peers.Values)
            {
                peer.SendMessage(msg);
                OnImportantMessageSent(peer, msg, Message.messageType.REQUEST);
            }
            if (0 == peers.Count)
            {
                tryEnterCriticalSection();
            }
            
        }

        public void HandleRequestCriticalSection(Message msg)
        {
            if (currentState == states.INITIALIZATION || currentState == states.NOT_CONNECTED)
            {
                ErrorLog("protocol error OnRequestCriticalSection");
                return;
            }
            sequenceNumber++;
            switch (currentState)
            {
                case states.BUSY:
                    csRequestsToBeHandled.Add(msg);
                    break;
                case states.REQUESTING:
                    if (isSequenceLower(msg))
                    {
                        generateREPLY(msg);
                    }
                    else
                    {
                        csRequestsToBeHandled.Add(msg);
                    }
                    break;
                case states.IDLE:
                    generateREPLY(msg);
                    break;
                default:
                    break;
            }
        }

        bool isSequenceLower(Message msg)
        {
            int herSeq = msg.CONTENT.SEQNUM;
            if (herSeq < sequenceNumber || (sequenceNumber == herSeq && String.Compare(itIsI.UNIQUENAME, msg.FROM.UNIQUENAME, false) > 0))
            {
                return true;
            }
            return false;
        }

        public void generateREPLY(Message orginate)
        {
            if (peers.ContainsKey(orginate.FROM.UNIQUENAME))
            {
                peers[orginate.FROM.UNIQUENAME].SendMessage(new Message(Message.messageType.REPLY, this.itIsI));
                return;
            }
            ErrorLog("protocol error generateREPLY");
            return;
        }
    }
}
