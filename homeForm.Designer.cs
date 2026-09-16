namespace GsmPanel
{
    partial class homeForm
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
            RefreshBtn = new Button();
            lblNetwork = new Label();
            label6 = new Label();
            lblSignal = new Label();
            label4 = new Label();
            lblSimStatus = new Label();
            label1 = new Label();
            panel1 = new Panel();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            button3 = new Button();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            button4 = new Button();
            pictureBox3 = new PictureBox();
            panel4 = new Panel();
            button5 = new Button();
            pictureBox4 = new PictureBox();
            panel5 = new Panel();
            button6 = new Button();
            pictureBox5 = new PictureBox();
            panel6 = new Panel();
            button1 = new Button();
            pictureBox6 = new PictureBox();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RefreshBtn);
            groupBox1.Controls.Add(lblNetwork);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lblSignal);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lblSimStatus);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(88, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 58);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "اطلاعات پایه";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // RefreshBtn
            // 
            RefreshBtn.Location = new Point(6, 24);
            RefreshBtn.Name = "RefreshBtn";
            RefreshBtn.Size = new Size(103, 23);
            RefreshBtn.TabIndex = 6;
            RefreshBtn.Text = "به روزرسانی";
            RefreshBtn.UseVisualStyleBackColor = true;
            RefreshBtn.Click += RefreshBtn_Click;
            // 
            // lblNetwork
            // 
            lblNetwork.AutoSize = true;
            lblNetwork.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNetwork.ForeColor = Color.FromArgb(0, 192, 0);
            lblNetwork.Location = new Point(195, 29);
            lblNetwork.Name = "lblNetwork";
            lblNetwork.Size = new Size(54, 15);
            lblNetwork.TabIndex = 5;
            lblNetwork.Text = "نامشخص";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(329, 29);
            label6.Name = "label6";
            label6.Size = new Size(82, 15);
            label6.TabIndex = 4;
            label6.Text = "وضعیت شبکه :";
            // 
            // lblSignal
            // 
            lblSignal.AutoSize = true;
            lblSignal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSignal.ForeColor = Color.FromArgb(0, 192, 0);
            lblSignal.Location = new Point(444, 29);
            lblSignal.Name = "lblSignal";
            lblSignal.Size = new Size(54, 15);
            lblSignal.TabIndex = 3;
            lblSignal.Text = "نامشخص";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(498, 28);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 2;
            label4.Text = "آتن دهی :";
            // 
            // lblSimStatus
            // 
            lblSimStatus.AutoSize = true;
            lblSimStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSimStatus.ForeColor = Color.FromArgb(0, 192, 0);
            lblSimStatus.Location = new Point(591, 28);
            lblSimStatus.Name = "lblSimStatus";
            lblSimStatus.Size = new Size(54, 15);
            lblSimStatus.TabIndex = 1;
            lblSimStatus.Text = "نامشخص";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(667, 28);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 0;
            label1.Text = "وضعیت سیمکارت :";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuBar;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(88, 127);
            panel1.Name = "panel1";
            panel1.Size = new Size(109, 109);
            panel1.TabIndex = 2;
            // 
            // button2
            // 
            button2.BackColor = Color.PowderBlue;
            button2.Location = new Point(3, 78);
            button2.Name = "button2";
            button2.Size = new Size(101, 23);
            button2.TabIndex = 3;
            button2.Text = "دفترچه تلفن";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Image = Properties.Resources.contact_icon_png_4068;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(101, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.MenuBar;
            panel2.Controls.Add(button3);
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(223, 127);
            panel2.Name = "panel2";
            panel2.Size = new Size(109, 109);
            panel2.TabIndex = 4;
            // 
            // button3
            // 
            button3.BackColor = Color.PowderBlue;
            button3.Location = new Point(3, 78);
            button3.Name = "button3";
            button3.Size = new Size(101, 23);
            button3.TabIndex = 3;
            button3.Text = "ارسال پیامک";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.sms_icon_5460;
            pictureBox2.Location = new Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(101, 69);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.MenuBar;
            panel3.Controls.Add(button4);
            panel3.Controls.Add(pictureBox3);
            panel3.Location = new Point(358, 127);
            panel3.Name = "panel3";
            panel3.Size = new Size(109, 109);
            panel3.TabIndex = 5;
            // 
            // button4
            // 
            button4.BackColor = Color.PowderBlue;
            button4.Location = new Point(3, 78);
            button4.Name = "button4";
            button4.Size = new Size(101, 23);
            button4.TabIndex = 3;
            button4.Text = "دریافتی ها";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Download_Button__Streamline_Ultimate;
            pictureBox3.Location = new Point(3, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(101, 69);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.MenuBar;
            panel4.Controls.Add(button5);
            panel4.Controls.Add(pictureBox4);
            panel4.Location = new Point(492, 127);
            panel4.Name = "panel4";
            panel4.Size = new Size(109, 109);
            panel4.TabIndex = 6;
            // 
            // button5
            // 
            button5.BackColor = Color.PowderBlue;
            button5.Location = new Point(3, 78);
            button5.Name = "button5";
            button5.Size = new Size(101, 23);
            button5.TabIndex = 3;
            button5.Text = "درباره ";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.Information_Circle__Streamline_Ultimate;
            pictureBox4.Location = new Point(3, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(101, 69);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.MenuBar;
            panel5.Controls.Add(button6);
            panel5.Controls.Add(pictureBox5);
            panel5.Location = new Point(625, 127);
            panel5.Name = "panel5";
            panel5.Size = new Size(109, 109);
            panel5.TabIndex = 7;
            // 
            // button6
            // 
            button6.BackColor = Color.PowderBlue;
            button6.Location = new Point(3, 78);
            button6.Name = "button6";
            button6.Size = new Size(101, 23);
            button6.TabIndex = 3;
            button6.Text = "تنظیمات";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.Settings_Vertical_1__Streamline_Ultimate;
            pictureBox5.Location = new Point(3, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(101, 69);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 3;
            pictureBox5.TabStop = false;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.MenuBar;
            panel6.Controls.Add(button1);
            panel6.Controls.Add(pictureBox6);
            panel6.Location = new Point(755, 127);
            panel6.Name = "panel6";
            panel6.Size = new Size(109, 109);
            panel6.TabIndex = 8;
            // 
            // button1
            // 
            button1.BackColor = Color.PowderBlue;
            button1.Location = new Point(3, 78);
            button1.Name = "button1";
            button1.Size = new Size(101, 23);
            button1.TabIndex = 3;
            button1.Text = "راهنما";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.Question_Help_Message__Streamline_Ultimate;
            pictureBox6.Location = new Point(3, 3);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(101, 69);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 3;
            pictureBox6.TabStop = false;
            // 
            // homeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 550);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "homeForm";
            Resizable = false;
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            SizeGripStyle = SizeGripStyle.Hide;
            Style = MetroFramework.MetroColorStyle.Lime;
            Text = "صفحه اصلی";
            Load += homeForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Label lblSimStatus;
        private Label label1;
        private Label lblNetwork;
        private Label label6;
        private Label lblSignal;
        private Label label4;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Button button2;
        private Panel panel2;
        private Button button3;
        private PictureBox pictureBox2;
        private Panel panel3;
        private Button button4;
        private PictureBox pictureBox3;
        private Panel panel4;
        private Button button5;
        private PictureBox pictureBox4;
        private Panel panel5;
        private Button button6;
        private PictureBox pictureBox5;
        private Panel panel6;
        private Button button1;
        private PictureBox pictureBox6;
        private Button RefreshBtn;
    }
}
