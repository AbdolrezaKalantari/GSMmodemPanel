namespace GsmPanel
{
    partial class ContactForm
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            ImportExelBtn = new Button();
            RemoveAllBtn = new Button();
            label8 = new Label();
            ResetBtn = new Button();
            SaveBtn = new Button();
            NameTxtbox = new TextBox();
            DescriptionTxtbox = new TextBox();
            label7 = new Label();
            PhoneNumberTxtbox = new TextBox();
            label6 = new Label();
            BirthdayTxtbox = new TextBox();
            label5 = new Label();
            LastnameTxtbox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            GenderCombo = new ComboBox();
            label2 = new Label();
            GroupCombo = new ComboBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            btnEditColumn = new DataGridViewButtonColumn();
            btnDeleteColumn = new DataGridViewButtonColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ImportExelBtn);
            groupBox1.Controls.Add(RemoveAllBtn);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(ResetBtn);
            groupBox1.Controls.Add(SaveBtn);
            groupBox1.Controls.Add(NameTxtbox);
            groupBox1.Controls.Add(DescriptionTxtbox);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(PhoneNumberTxtbox);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(BirthdayTxtbox);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(LastnameTxtbox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(GenderCombo);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(GroupCombo);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(6, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(892, 130);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "اطلاعات شخص";
            // 
            // ImportExelBtn
            // 
            ImportExelBtn.BackColor = Color.MediumAquamarine;
            ImportExelBtn.Location = new Point(339, 101);
            ImportExelBtn.Name = "ImportExelBtn";
            ImportExelBtn.Size = new Size(105, 23);
            ImportExelBtn.TabIndex = 18;
            ImportExelBtn.Text = "دریافت از اکسل";
            ImportExelBtn.UseVisualStyleBackColor = false;
            ImportExelBtn.Click += ImportExelBtn_Click;
            // 
            // RemoveAllBtn
            // 
            RemoveAllBtn.BackColor = Color.LightPink;
            RemoveAllBtn.Location = new Point(228, 101);
            RemoveAllBtn.Name = "RemoveAllBtn";
            RemoveAllBtn.Size = new Size(105, 23);
            RemoveAllBtn.TabIndex = 17;
            RemoveAllBtn.Text = "حذف همه کاربران";
            RemoveAllBtn.UseVisualStyleBackColor = false;
            RemoveAllBtn.Click += RemoveAllBtn_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.DarkGreen;
            label8.Location = new Point(583, 105);
            label8.Name = "label8";
            label8.Size = new Size(0, 15);
            label8.TabIndex = 16;
            // 
            // ResetBtn
            // 
            ResetBtn.BackColor = Color.LightYellow;
            ResetBtn.Location = new Point(117, 101);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(105, 23);
            ResetBtn.TabIndex = 15;
            ResetBtn.Text = "پاک کردن اطلاعات";
            ResetBtn.UseVisualStyleBackColor = false;
            ResetBtn.Click += ResetBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = Color.PowderBlue;
            SaveBtn.Location = new Point(6, 101);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(105, 23);
            SaveBtn.TabIndex = 14;
            SaveBtn.Text = "ذخیره اطلاعات";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // NameTxtbox
            // 
            NameTxtbox.AccessibleRole = AccessibleRole.Text;
            NameTxtbox.Location = new Point(279, 26);
            NameTxtbox.MaxLength = 100;
            NameTxtbox.Name = "NameTxtbox";
            NameTxtbox.Size = new Size(186, 23);
            NameTxtbox.TabIndex = 5;
            NameTxtbox.TextAlign = HorizontalAlignment.Center;
            NameTxtbox.TextChanged += NameTxtbox_TextChanged;
            // 
            // DescriptionTxtbox
            // 
            DescriptionTxtbox.Location = new Point(6, 67);
            DescriptionTxtbox.MaxLength = 150;
            DescriptionTxtbox.Name = "DescriptionTxtbox";
            DescriptionTxtbox.PlaceholderText = "متنی برای توضیح ...";
            DescriptionTxtbox.Size = new Size(387, 23);
            DescriptionTxtbox.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(399, 75);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 12;
            label7.Text = "توضیحات :";
            // 
            // PhoneNumberTxtbox
            // 
            PhoneNumberTxtbox.Location = new Point(471, 67);
            PhoneNumberTxtbox.MaxLength = 12;
            PhoneNumberTxtbox.Name = "PhoneNumberTxtbox";
            PhoneNumberTxtbox.PlaceholderText = "+989876543210";
            PhoneNumberTxtbox.Size = new Size(151, 23);
            PhoneNumberTxtbox.TabIndex = 11;
            PhoneNumberTxtbox.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(628, 70);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 10;
            label6.Text = "تلفن همراه :";
            // 
            // BirthdayTxtbox
            // 
            BirthdayTxtbox.Location = new Point(713, 67);
            BirthdayTxtbox.MaxLength = 12;
            BirthdayTxtbox.Name = "BirthdayTxtbox";
            BirthdayTxtbox.Size = new Size(96, 23);
            BirthdayTxtbox.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(815, 70);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 8;
            label5.Text = "تاریخ تولد :";
            // 
            // LastnameTxtbox
            // 
            LastnameTxtbox.Location = new Point(6, 26);
            LastnameTxtbox.MaxLength = 100;
            LastnameTxtbox.Name = "LastnameTxtbox";
            LastnameTxtbox.Size = new Size(186, 23);
            LastnameTxtbox.TabIndex = 7;
            LastnameTxtbox.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(198, 29);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 6;
            label4.Text = "نام خانوادگی :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(471, 29);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 4;
            label3.Text = "نام :";
            // 
            // GenderCombo
            // 
            GenderCombo.FlatStyle = FlatStyle.Popup;
            GenderCombo.FormattingEnabled = true;
            GenderCombo.Items.AddRange(new object[] { "آقا", "خانم ", "عدم ثبت" });
            GenderCombo.Location = new Point(512, 26);
            GenderCombo.Name = "GenderCombo";
            GenderCombo.RightToLeft = RightToLeft.Yes;
            GenderCombo.Size = new Size(121, 23);
            GenderCombo.TabIndex = 3;
            GenderCombo.Text = "انتخاب کنید";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(639, 29);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 2;
            label2.Text = "جنسیت :";
            // 
            // GroupCombo
            // 
            GroupCombo.FlatStyle = FlatStyle.Popup;
            GroupCombo.FormattingEnabled = true;
            GroupCombo.Location = new Point(713, 26);
            GroupCombo.Name = "GroupCombo";
            GroupCombo.RightToLeft = RightToLeft.Yes;
            GroupCombo.Size = new Size(121, 23);
            GroupCombo.TabIndex = 1;
            GroupCombo.Text = "انتخاب کنید";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(840, 29);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 0;
            label1.Text = "گروه :";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, btnEditColumn, btnDeleteColumn });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.GridColor = SystemColors.GradientActiveCaption;
            dataGridView1.Location = new Point(6, 199);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(892, 342);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.DataPropertyName = "GroupType";
            Column1.HeaderText = "گروه";
            Column1.MaxInputLength = 25;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "Gender";
            Column2.HeaderText = "جنسیت";
            Column2.MaxInputLength = 25;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Resizable = DataGridViewTriState.False;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.DataPropertyName = "Name";
            Column3.HeaderText = "نام";
            Column3.MaxInputLength = 100;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.DataPropertyName = "LastName";
            Column4.HeaderText = "نام خانوادگی";
            Column4.MaxInputLength = 100;
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.DataPropertyName = "BirthDay";
            Column5.HeaderText = "تاریخ تولد";
            Column5.MaxInputLength = 25;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Resizable = DataGridViewTriState.False;
            // 
            // Column6
            // 
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column6.DataPropertyName = "PhoneNumber";
            Column6.HeaderText = "شماره همراه";
            Column6.MaxInputLength = 15;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // btnEditColumn
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Wheat;
            dataGridViewCellStyle1.SelectionBackColor = Color.Wheat;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(64, 64, 64);
            btnEditColumn.DefaultCellStyle = dataGridViewCellStyle1;
            btnEditColumn.HeaderText = "ویرایش";
            btnEditColumn.Name = "btnEditColumn";
            btnEditColumn.Text = "ویرایش کاربر";
            btnEditColumn.UseColumnTextForButtonValue = true;
            // 
            // btnDeleteColumn
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.MistyRose;
            dataGridViewCellStyle2.SelectionBackColor = Color.MistyRose;
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(64, 64, 64);
            btnDeleteColumn.DefaultCellStyle = dataGridViewCellStyle2;
            btnDeleteColumn.HeaderText = "حذف";
            btnDeleteColumn.Name = "btnDeleteColumn";
            btnDeleteColumn.Text = "حذف کاربر";
            btnDeleteColumn.UseColumnTextForButtonValue = true;
            // 
            // ContactForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 550);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "ContactForm";
            Resizable = false;
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Style = MetroFramework.MetroColorStyle.Lime;
            Text = "مدیریت کاربران";
            Load += ContactForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        //private TextBox textBox2;
        private Label label4;
        //private TextBox textBox1;
        private Label label3;
        //private ComboBox comboBox2;
        private Label label2;
        //private ComboBox comboBox1;
        private Label label1;
        //private TextBox textBox5;
        private Label label7;
        //private TextBox textBox4;
        private Label label6;
        //private TextBox textBox3;
        private Label label5;
        private Button ResetBtn;
        private Button SaveBtn;
        private DataGridView dataGridView1;
        private TextBox DescriptionTxtbox;
        private TextBox PhoneNumberTxtbox;
        private TextBox BirthdayTxtbox;
        private TextBox LastnameTxtbox;
        private TextBox NameTxtbox;
        private ComboBox GenderCombo;
        private ComboBox GroupCombo;
        private Label label8;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewButtonColumn btnEditColumn;
        private DataGridViewButtonColumn btnDeleteColumn;
        private Button RemoveAllBtn;
        private Button ImportExelBtn;
    }
}