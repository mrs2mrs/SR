using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Collections;

namespace RicartAgrawala2
{
    class TCP
    {
        public static String SearchIPs()
        {
            String ret;
            IPAddress[] ipAddrList = Dns.GetHostAddresses(Dns.GetHostName());
            ret = "List of host's IPs" + System.Environment.NewLine;
            foreach (IPAddress ip in ipAddrList)
            {
                ret += ip.ToString() + System.Environment.NewLine;
            }
            Console.WriteLine(ret);
            return ret;
        }

    }

    class MessageBuffer
    {
        static MessageBuffer instance = new MessageBuffer();

        public static MessageBuffer get()
        {
            return instance;
        }

        IList synchronizedList;

        public MessageBuffer()
        {
            synchronizedList = ArrayList.Synchronized(new List<string>());
            Console.WriteLine("Kazio mial racje");
        }

        public void PushForward(string v)
        {
            synchronizedList.Add(v);
        }

        public bool HasElement()
        {
            return 0 != synchronizedList.Count;
        }

        public string PopBack()
        {
            if (HasElement())
            {
                int last_index = synchronizedList.Count - 1;
                string result = (string)synchronizedList[last_index];
                synchronizedList.RemoveAt(last_index);
                return result;
            }
            return null;
        }
    }

    class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;

        public Server(String stringIP, int port)
        {
            try
            {
                this.tcpListener = new TcpListener(IPAddress.Parse(stringIP), port);
                this.listenThread = new Thread(new ThreadStart(ListenForClients));
                this.listenThread.Start();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: ", e);
            }
            
        }

        private void ListenForClients()
        {
            try
            {
                this.tcpListener.Start();

                while (true)
                {
                    //blocks until a client has connected to the server
                    TcpClient client = this.tcpListener.AcceptTcpClient();

                    //create a thread to handle communication 
                    //with connected client
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: ", e);
            }
            finally
            {
                // Stop listening for new clients.
                tcpListener.Stop();
            }
        }

        public void Dispose()
        {
            if (listenThread != null)
            {
                listenThread.Abort();
                listenThread = null;
            }
            if (null != tcpListener)
            {
                tcpListener.Stop();
                tcpListener = null;
            }
        }




        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
                String s = encoder.GetString(message, 0, bytesRead);
                //Console.WriteLine("push to msg buff");
                MessageBuffer.get().PushForward(s);
            }

            tcpClient.Close();
        }

    }

    class Client
    {
        private TcpClient client;
        private IPEndPoint serverEndPoint;

        public int port { get { return serverEndPoint.Port; } }
        public string IPaddr { get { return serverEndPoint.Address.ToString() ; } }

        public Client(String stringIP, int port)
        {
            try
            {
                client = new TcpClient();

                serverEndPoint = new IPEndPoint(IPAddress.Parse(stringIP), port);

                client.Connect(serverEndPoint);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: ", e);
            }

        }

        public void SendMessage(String msg)
        {
            NetworkStream clientStream = client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(msg);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }


  }
}
    

