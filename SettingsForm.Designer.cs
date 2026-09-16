namespace GsmPanel
{
    partial class SettingsForm
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
            groupBox1 = new GroupBox();
            StopBitsCombo = new ComboBox();
            label6 = new Label();
            ParityCombo = new ComboBox();
            label5 = new Label();
            DataBitsCombo = new ComboBox();
            label4 = new Label();
            BaudRateCombo = new ComboBox();
            label3 = new Label();
            PortCombo = new ComboBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            AddGroupTypeBtn = new Button();
            GroupTypeTxt = new TextBox();
            label11 = new Label();
            PasswordTxt = new TextBox();
            label1 = new Label();
            groupBox3 = new GroupBox();
            AutoReconnectCheckBox = new CheckBox();
            label9 = new Label();
            WriteTimeoutNumeric = new NumericUpDown();
            label8 = new Label();
            ReadTimeoutNumeric = new NumericUpDown();
            label7 = new Label();
            SaveBtn = new Button();
            groupBox4 = new GroupBox();
            btnSend = new Button();
            btnConnect = new Button();
            label10 = new Label();
            txtCommand = new TextBox();
            txtLog = new RichTextBox();
            Defaultbtn = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WriteTimeoutNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReadTimeoutNumeric).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(StopBitsCombo);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(ParityCombo);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(DataBitsCombo);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(BaudRateCombo);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(PortCombo);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 140);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(886, 71);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "تنظیمات سخت‌افزاری پورت";
            // 
            // StopBitsCombo
            // 
            StopBitsCombo.FlatStyle = FlatStyle.Popup;
            StopBitsCombo.FormattingEnabled = true;
            StopBitsCombo.Location = new Point(105, 31);
            StopBitsCombo.Name = "StopBitsCombo";
            StopBitsCombo.Size = new Size(106, 23);
            StopBitsCombo.TabIndex = 9;
            StopBitsCombo.Text = "انتخاب کنید";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(217, 34);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 8;
            label6.Text = "بیت پایان :";
            // 
            // ParityCombo
            // 
            ParityCombo.FlatStyle = FlatStyle.Popup;
            ParityCombo.FormattingEnabled = true;
            ParityCombo.Items.AddRange(new object[] { "Space", "Mark", "Even", "Odd", "None" });
            ParityCombo.Location = new Point(284, 31);
            ParityCombo.Name = "ParityCombo";
            ParityCombo.Size = new Size(79, 23);
            ParityCombo.TabIndex = 7;
            ParityCombo.Text = "انتخاب کنید";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(369, 34);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 6;
            label5.Text = "بیت توازن :";
            // 
            // DataBitsCombo
            // 
            DataBitsCombo.FlatStyle = FlatStyle.Popup;
            DataBitsCombo.FormattingEnabled = true;
            DataBitsCombo.Items.AddRange(new object[] { "7", "8" });
            DataBitsCombo.Location = new Point(440, 31);
            DataBitsCombo.Name = "DataBitsCombo";
            DataBitsCombo.Size = new Size(79, 23);
            DataBitsCombo.TabIndex = 5;
            DataBitsCombo.Text = "انتخاب کنید";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(525, 34);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 4;
            label4.Text = "طول داده :";
            // 
            // BaudRateCombo
            // 
            BaudRateCombo.FlatStyle = FlatStyle.Popup;
            BaudRateCombo.FormattingEnabled = true;
            BaudRateCombo.Items.AddRange(new object[] { "38400", "19200", "9600", "115200", "57600" });
            BaudRateCombo.Location = new Point(599, 31);
            BaudRateCombo.Name = "BaudRateCombo";
            BaudRateCombo.Size = new Size(79, 23);
            BaudRateCombo.TabIndex = 3;
            BaudRateCombo.Text = "انتخاب کنید";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(684, 34);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 2;
            label3.Text = "نرخ تبادل :";
            // 
            // PortCombo
            // 
            PortCombo.FlatStyle = FlatStyle.Popup;
            PortCombo.FormattingEnabled = true;
            PortCombo.Location = new Point(752, 31);
            PortCombo.Name = "PortCombo";
            PortCombo.Size = new Size(79, 23);
            PortCombo.TabIndex = 1;
            PortCombo.Text = "انتخاب کنید";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(837, 34);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 0;
            label2.Text = "پورت :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(AddGroupTypeBtn);
            groupBox2.Controls.Add(GroupTypeTxt);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(PasswordTxt);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(12, 63);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(886, 71);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "تنظیمات داخلی برنامه";
            // 
            // AddGroupTypeBtn
            // 
            AddGroupTypeBtn.BackgroundImageLayout = ImageLayout.Center;
            AddGroupTypeBtn.Image = Properties.Resources.Add_Square__Streamline_Ultimate;
            AddGroupTypeBtn.Location = new Point(445, 31);
            AddGroupTypeBtn.Name = "AddGroupTypeBtn";
            AddGroupTypeBtn.Size = new Size(29, 30);
            AddGroupTypeBtn.TabIndex = 4;
            AddGroupTypeBtn.UseVisualStyleBackColor = true;
            AddGroupTypeBtn.Click += AddGroupTypeBtn_Click;
            // 
            // GroupTypeTxt
            // 
            GroupTypeTxt.ForeColor = Color.LimeGreen;
            GroupTypeTxt.Location = new Point(477, 34);
            GroupTypeTxt.MaxLength = 35;
            GroupTypeTxt.Name = "GroupTypeTxt";
            GroupTypeTxt.Size = new Size(108, 23);
            GroupTypeTxt.TabIndex = 3;
            GroupTypeTxt.TextAlign = HorizontalAlignment.Center;
            GroupTypeTxt.WordWrap = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(591, 37);
            label11.Name = "label11";
            label11.Size = new Size(102, 15);
            label11.TabIndex = 2;
            label11.Text = "گروه مخاطب جدید :";
            // 
            // PasswordTxt
            // 
            PasswordTxt.ForeColor = Color.LimeGreen;
            PasswordTxt.Location = new Point(707, 32);
            PasswordTxt.MaxLength = 24;
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.PasswordChar = '*';
            PasswordTxt.Size = new Size(108, 23);
            PasswordTxt.TabIndex = 1;
            PasswordTxt.TextAlign = HorizontalAlignment.Center;
            PasswordTxt.UseSystemPasswordChar = true;
            PasswordTxt.WordWrap = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(816, 35);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "رمز عبور :";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(AutoReconnectCheckBox);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(WriteTimeoutNumeric);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(ReadTimeoutNumeric);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(12, 217);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(886, 71);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "تنظیمات ارتباطی و پایداری";
            // 
            // AutoReconnectCheckBox
            // 
            AutoReconnectCheckBox.AutoSize = true;
            AutoReconnectCheckBox.Location = new Point(427, 37);
            AutoReconnectCheckBox.Name = "AutoReconnectCheckBox";
            AutoReconnectCheckBox.Size = new Size(15, 14);
            AutoReconnectCheckBox.TabIndex = 15;
            AutoReconnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(445, 34);
            label9.Name = "label9";
            label9.Size = new Size(108, 15);
            label9.TabIndex = 14;
            label9.Text = "اتصال مجدد خودکار :";
            // 
            // WriteTimeoutNumeric
            // 
            WriteTimeoutNumeric.Location = new Point(571, 31);
            WriteTimeoutNumeric.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            WriteTimeoutNumeric.Name = "WriteTimeoutNumeric";
            WriteTimeoutNumeric.Size = new Size(66, 23);
            WriteTimeoutNumeric.TabIndex = 13;
            WriteTimeoutNumeric.TextAlign = HorizontalAlignment.Center;
            WriteTimeoutNumeric.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(643, 33);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 12;
            label8.Text = "مهلت نوشتن :";
            // 
            // ReadTimeoutNumeric
            // 
            ReadTimeoutNumeric.Location = new Point(727, 31);
            ReadTimeoutNumeric.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            ReadTimeoutNumeric.Name = "ReadTimeoutNumeric";
            ReadTimeoutNumeric.Size = new Size(66, 23);
            ReadTimeoutNumeric.TabIndex = 11;
            ReadTimeoutNumeric.TextAlign = HorizontalAlignment.Center;
            ReadTimeoutNumeric.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(799, 33);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 10;
            label7.Text = "مهلت خواندن :";
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = Color.PowderBlue;
            SaveBtn.Image = Properties.Resources.Download_Menu__Streamline_Ultimate;
            SaveBtn.ImageAlign = ContentAlignment.MiddleRight;
            SaveBtn.Location = new Point(791, 504);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(107, 23);
            SaveBtn.TabIndex = 3;
            SaveBtn.Text = "ذخیره تنظیمات";
            SaveBtn.TextAlign = ContentAlignment.MiddleLeft;
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnSend);
            groupBox4.Controls.Add(btnConnect);
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(txtCommand);
            groupBox4.Controls.Add(txtLog);
            groupBox4.Location = new Point(12, 294);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(886, 100);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "تست اتصال";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(561, 39);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(95, 23);
            btnSend.TabIndex = 4;
            btnSend.Text = "ارسال دستور";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(346, 39);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(84, 23);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "اتصال پورت ";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(806, 39);
            label10.Name = "label10";
            label10.Size = new Size(69, 15);
            label10.TabIndex = 2;
            label10.Text = "متن دستور : ";
            // 
            // txtCommand
            // 
            txtCommand.Location = new Point(662, 36);
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(138, 23);
            txtCommand.TabIndex = 1;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(6, 16);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(334, 78);
            txtLog.TabIndex = 0;
            txtLog.Text = "";
            // 
            // Defaultbtn
            // 
            Defaultbtn.BackColor = Color.PowderBlue;
            Defaultbtn.Image = Properties.Resources.Move_Left_Right__Streamline_Ultimate;
            Defaultbtn.ImageAlign = ContentAlignment.MiddleRight;
            Defaultbtn.Location = new Point(660, 504);
            Defaultbtn.Name = "Defaultbtn";
            Defaultbtn.Size = new Size(125, 23);
            Defaultbtn.TabIndex = 5;
            Defaultbtn.Text = "تنظیمات پیشفرض";
            Defaultbtn.TextAlign = ContentAlignment.MiddleLeft;
            Defaultbtn.UseVisualStyleBackColor = false;
            Defaultbtn.Click += Defaultbtn_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(921, 550);
            Controls.Add(Defaultbtn);
            Controls.Add(groupBox4);
            Controls.Add(SaveBtn);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "SettingsForm";
            Resizable = false;
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowInTaskbar = false;
            Style = MetroFramework.MetroColorStyle.Lime;
            Text = "تنظیمات برنامه";
            Load += SettingsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)WriteTimeoutNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)ReadTimeoutNumeric).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox PasswordTxt;
        private Label label1;
        private ComboBox PortCombo;
        private Label label2;
        private ComboBox ParityCombo;
        private Label label5;
        private ComboBox DataBitsCombo;
        private Label label4;
        private ComboBox BaudRateCombo;
        private Label label3;
        private ComboBox StopBitsCombo;
        private Label label6;
        private NumericUpDown ReadTimeoutNumeric;
        private Label label7;
        private Label label9;
        private NumericUpDown WriteTimeoutNumeric;
        private Label label8;
        private CheckBox AutoReconnectCheckBox;
        private Button SaveBtn;
        private GroupBox groupBox4;
        private RichTextBox txtLog;
        private Button btnSend;
        private Button btnConnect;
        private Label label10;
        private TextBox txtCommand;
        private Button Defaultbtn;
        private TextBox GroupTypeTxt;
        private Label label11;
        private Button AddGroupTypeBtn;
    }
}