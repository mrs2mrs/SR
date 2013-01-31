namespace RicartAgrawala2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.SponsorButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sponsorPortTextBox = new System.Windows.Forms.TextBox();
            this.sponsorIPTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.csReqButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.uniqueNameTextBox = new System.Windows.Forms.TextBox();
            this.setNameButton = new System.Windows.Forms.Button();
            this.deadButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.delayTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.csTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ForceIdle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(16, 184);
            this.messageTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageTextBox.Size = new System.Drawing.Size(332, 321);
            this.messageTextBox.TabIndex = 0;
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(7, 83);
            this.IPTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(135, 20);
            this.IPTextBox.TabIndex = 1;
            this.IPTextBox.Text = "127.0.0.1";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(165, 83);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(74, 20);
            this.portTextBox.TabIndex = 2;
            this.portTextBox.Text = "50000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "port";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(255, 79);
            this.connectButton.Margin = new System.Windows.Forms.Padding(2);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(65, 24);
            this.connectButton.TabIndex = 5;
            this.connectButton.Text = "connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SponsorButton
            // 
            this.SponsorButton.Location = new System.Drawing.Point(255, 237);
            this.SponsorButton.Margin = new System.Windows.Forms.Padding(2);
            this.SponsorButton.Name = "SponsorButton";
            this.SponsorButton.Size = new System.Drawing.Size(64, 24);
            this.SponsorButton.TabIndex = 10;
            this.SponsorButton.Text = "establish";
            this.SponsorButton.UseVisualStyleBackColor = true;
            this.SponsorButton.Click += new System.EventHandler(this.SponsorButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 221);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 221);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "IP address";
            // 
            // sponsorPortTextBox
            // 
            this.sponsorPortTextBox.Location = new System.Drawing.Point(166, 237);
            this.sponsorPortTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.sponsorPortTextBox.Name = "sponsorPortTextBox";
            this.sponsorPortTextBox.Size = new System.Drawing.Size(74, 20);
            this.sponsorPortTextBox.TabIndex = 7;
            this.sponsorPortTextBox.Text = "50001";
            // 
            // sponsorIPTextBox
            // 
            this.sponsorIPTextBox.Location = new System.Drawing.Point(7, 237);
            this.sponsorIPTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.sponsorIPTextBox.Name = "sponsorIPTextBox";
            this.sponsorIPTextBox.Size = new System.Drawing.Size(135, 20);
            this.sponsorIPTextBox.TabIndex = 6;
            this.sponsorIPTextBox.Text = "127.0.0.1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(4, 188);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "sponsor";
            // 
            // csReqButton
            // 
            this.csReqButton.Location = new System.Drawing.Point(16, 49);
            this.csReqButton.Margin = new System.Windows.Forms.Padding(2);
            this.csReqButton.Name = "csReqButton";
            this.csReqButton.Size = new System.Drawing.Size(332, 22);
            this.csReqButton.TabIndex = 12;
            this.csReqButton.Text = "request critical section";
            this.csReqButton.UseVisualStyleBackColor = true;
            this.csReqButton.Click += new System.EventHandler(this.csReqButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(3, 119);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "unique name";
            // 
            // uniqueNameTextBox
            // 
            this.uniqueNameTextBox.Location = new System.Drawing.Point(7, 148);
            this.uniqueNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.uniqueNameTextBox.Name = "uniqueNameTextBox";
            this.uniqueNameTextBox.Size = new System.Drawing.Size(135, 20);
            this.uniqueNameTextBox.TabIndex = 14;
            this.uniqueNameTextBox.Text = "Maria";
            // 
            // setNameButton
            // 
            this.setNameButton.Location = new System.Drawing.Point(255, 148);
            this.setNameButton.Margin = new System.Windows.Forms.Padding(2);
            this.setNameButton.Name = "setNameButton";
            this.setNameButton.Size = new System.Drawing.Size(65, 26);
            this.setNameButton.TabIndex = 15;
            this.setNameButton.Text = "set name";
            this.setNameButton.UseVisualStyleBackColor = true;
            this.setNameButton.Click += new System.EventHandler(this.setNameButton_Click);
            // 
            // deadButton
            // 
            this.deadButton.Location = new System.Drawing.Point(16, 95);
            this.deadButton.Margin = new System.Windows.Forms.Padding(2);
            this.deadButton.Name = "deadButton";
            this.deadButton.Size = new System.Drawing.Size(332, 22);
            this.deadButton.TabIndex = 16;
            this.deadButton.Text = "play dead";
            this.deadButton.UseVisualStyleBackColor = true;
            this.deadButton.Click += new System.EventHandler(this.deadButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ForceIdle);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.delayTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.csTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.setNameButton);
            this.splitContainer1.Panel1.Controls.Add(this.SponsorButton);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.IPTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.uniqueNameTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.sponsorPortTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.portTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.sponsorIPTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.connectButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.disconnectButton);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.messageTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.deadButton);
            this.splitContainer1.Panel2.Controls.Add(this.csReqButton);
            this.splitContainer1.Size = new System.Drawing.Size(763, 507);
            this.splitContainer1.SplitterDistance = 363;
            this.splitContainer1.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(255, 412);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 24);
            this.button2.TabIndex = 23;
            this.button2.Text = "set";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(72, 423);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "seconds";
            // 
            // delayTextBox
            // 
            this.delayTextBox.Location = new System.Drawing.Point(6, 420);
            this.delayTextBox.Name = "delayTextBox";
            this.delayTextBox.Size = new System.Drawing.Size(60, 20);
            this.delayTextBox.TabIndex = 21;
            this.delayTextBox.Text = "1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(4, 390);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "network delay";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 24);
            this.button1.TabIndex = 19;
            this.button1.Text = "set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(73, 353);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "seconds";
            // 
            // csTextBox
            // 
            this.csTextBox.Location = new System.Drawing.Point(7, 350);
            this.csTextBox.Name = "csTextBox";
            this.csTextBox.Size = new System.Drawing.Size(60, 20);
            this.csTextBox.TabIndex = 17;
            this.csTextBox.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(4, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "critical section time slot";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(3, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "server";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(3, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "presets";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(16, 143);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(2);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(332, 22);
            this.disconnectButton.TabIndex = 17;
            this.disconnectButton.Text = "disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(3, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "operations";
            // 
            // ForceIdle
            // 
            this.ForceIdle.Location = new System.Drawing.Point(11, 475);
            this.ForceIdle.Name = "ForceIdle";
            this.ForceIdle.Size = new System.Drawing.Size(75, 23);
            this.ForceIdle.TabIndex = 26;
            this.ForceIdle.Text = "ForceIdle";
            this.ForceIdle.UseVisualStyleBackColor = true;
            this.ForceIdle.Click += new System.EventHandler(this.ForceIdle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 565);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "RA Mutex";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button SponsorButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sponsorPortTextBox;
        private System.Windows.Forms.TextBox sponsorIPTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button csReqButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uniqueNameTextBox;
        private System.Windows.Forms.Button setNameButton;
        private System.Windows.Forms.Button deadButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox delayTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox csTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button ForceIdle;
    }
}

