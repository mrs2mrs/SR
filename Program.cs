using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RicartAgrawala2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            string str = "{\"TYPE\":\"DEAD\",\"FROM\":{\"UniqueName\":\"Marynioszek\",},\"CONTENT\":{\"Role\":\"Sponsor\",\"SiepNr\":0,\"SeqNum\":3,\"NewData\":{\"Ip\":null,\"Port\":0}}}";
            Message test = Message.fromJson(str);
            test.toJson();

            /*
            Message test = new Message(Message.messageType.DEAD, new Message.From("Marynioszek", 666, "6.6.6.6.6"));
            test.CONTENT.Role = Message.roleType.Sponsor;
            test.CONTENT.SeqNum = 3;
            test.toJson();
             */


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(TCP.SearchIPs()));
        }
    }
}
