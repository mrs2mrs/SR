using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace RicartAgrawala2
{
    class Peer
    {
        public String name;
        public Client client;
        
        public Peer(String stringIP, int port, String _name)
        {
            client = new Client(stringIP, port);
            name = _name;
        }

        public void SendMessage(Message msg)
        {
            client.SendMessage(msg.toJson());
            Console.WriteLine("sent from " + msg.FROM.UNIQUENAME + " type " + msg.TYPE);
            
        }
    }

    public class Message
    {
        public enum messageType { INIT, REPLY, REQUEST, ARE_YOU_THERE, YES_I_AM_HERE, DEAD, HIGHEST_SEQ_NUM }
        public enum roleType { NEW, SPONSOR, NODE}
        public enum statusType { NOT_UNIQUE, OK, REMOVE, GET, RESPONSE, RE_INIT }
        
        public struct From
        {
            public string UNIQUENAME;
            public string IP;
            public int PORT;

            public From(string _name, int _port, string _ip)
            {
                this.UNIQUENAME = _name;
                this.PORT = _port;
                this.IP = _ip;
            }
        }

        public struct Content
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public roleType ROLE;
            [JsonConverter(typeof(StringEnumConverter))]
            public statusType STATUS;
            public int VALUE;
            public string NODE;

            public int SEQNUM;

            public From NEWDATA;
            public From[] NODESDATA;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public messageType TYPE;
        public From FROM;
        public Content CONTENT;

        public Message(messageType _msgType, From _from )
        {
            TYPE = _msgType;
            FROM = _from;
            CONTENT = new Content();
        }

        public Message() { }

        public string toJson ()
        {
            string msg_str = JsonConvert.SerializeObject(this);
            //Console.WriteLine(msg_str);
            return msg_str;
        }

        static public Message fromJson(string str)
        {
            return JsonConvert.DeserializeObject<Message>(str);
        }
    }
}
