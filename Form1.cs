using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;


namespace RicartAgrawala2
{
    public partial class Form1 : Form
    {
        Server server;
        Logic logic;
        bool isKill = false;
        string iplist;

        public Form1(String listOfIP)
        {
            InitializeComponent();
            iplist = listOfIP;
            printIPlist(iplist);
        }

        public void printIPlist(String IPlist)
        {
            this.messageTextBox.Text = IPlist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int _port = 50000;
            try
            {
                IPAddress ip = IPAddress.Parse(IPTextBox.Text);
                _port = int.Parse(portTextBox.Text);
                server = new Server(IPTextBox.Text, _port);
                logic = new Logic(_port, IPTextBox.Text, uniqueNameTextBox.Text);
                connectButton.Enabled = false;
                printLog("connected ip: " + IPTextBox.Text);
            }
            catch (FormatException)
            {
                printLog("Wrong data format: ");
            }
        }

        private void SponsorButton_Click(object sender, EventArgs e)
        {
            if (null != logic)
            {
                int _port = 50001;
                try
                {
                    IPAddress ip = IPAddress.Parse(IPTextBox.Text);
                    _port = int.Parse(portTextBox.Text);
                    logic.currentState = Logic.states.INITIALIZATION;
                    logic.requestSponsor(sponsorIPTextBox.Text, _port);
                }
                catch (FormatException)
                {
                    printLog("Wrong data format");
                }              
            }
        }

        private void csReqButton_Click(object sender, EventArgs e)
        {
            if (null != logic)
            {
                logic.RequestForCS();
                printLog("Request for critical section");
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (null != logic)
            {
                if (MessageBuffer.get().HasElement())
                {
                    String str = MessageBuffer.get().PopBack();
                    Message rm = Message.fromJson(str);
                    logic.OnReceive(rm);
                }
                logic.Tick();
                if (logic.canRequestCS)
                {
                    csReqButton.Enabled = true;
                }
                else
                {
                    csReqButton.Enabled = false;
                }
            }
        }

        private void setNameButton_Click(object sender, EventArgs e)
        {
            if (null != logic)
            {
                if (uniqueNameTextBox.Text == "")
                {
                    logic.itIsI.UNIQUENAME = "Maria";
                    uniqueNameTextBox.Text = "Maria";
                }
                else
                {
                    logic.itIsI.UNIQUENAME = uniqueNameTextBox.Text;
                }
                printLog("Unique name set to " + uniqueNameTextBox.Text);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int sec = Int32.Parse(this.csTextBox.Text);
                logic.setCriticalSectTimespan(sec);
            }
            catch (FormatException)
            {
                printLog("Wrong data format: critical section timespan");
            }
        }

        public void printLog(string str)
        {
            this.messageTextBox.Text += str;
            this.messageTextBox.Text += System.Environment.NewLine;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (null != logic)
            {
                try
                {
                    int sec = Int32.Parse(this.csTextBox.Text);
                    logic.setNetworkDelay(sec);
                }
                catch (FormatException)
                {
                    printLog("Wrong data format: network delay");
                }
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (null != server && null != logic)
            {
                logic.dispose();
                logic = null;
                server.Dispose();
                server = null;
                printIPlist(iplist);
                connectButton.Enabled = true;
            }
        }

        private void deadButton_Click(object sender, EventArgs e)
        {
            if (null != logic)
            {
                if (isKill)
                {
                    logic.respawn();
                    deadButton.Text = "play dead";
                    isKill = false;
                }
                else
                {
                    logic.playDead();
                    deadButton.Text = "connect";
                    isKill = true;
                }
            }          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void ForceIdle_Click(object sender, EventArgs e)
        {
            if (logic != null)
                logic.currentState = Logic.states.IDLE;
        }

       

       

        
    }
}
