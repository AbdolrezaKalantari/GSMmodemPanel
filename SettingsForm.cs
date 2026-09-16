using System.IO.Ports;

namespace GsmPanel
{
    public partial class SettingsForm : MetroFramework.Forms.MetroForm
    {
        private IGsmModemService _modemService;
        private readonly IComboBoxPresetService _presetService;


        public SettingsForm()
        {
            InitializeComponent();
            this.Load += SettingsForm_Load;
            _presetService = new ComboBoxPresetService();
            _modemService = ModemManager.Instance;
            _modemService.DataReceived += OnModemDataReceived;
            _modemService.ErrorOccurred += OnModemErrorOccurred;
        }

        private void SettingsForm_Load(object? sender, EventArgs e)
        {
            InitializeDropdowns();
            LoadSettingsToUI();
        }
       


        private void InitializeDropdowns()
        {
            PortCombo.DataSource = SerialPort.GetPortNames().ToList();
            BaudRateCombo.DataSource = new[] { 9600, 19200, 38400, 57600, 115200 };
            DataBitsCombo.DataSource = new[] { 7, 8 };
            ParityCombo.DataSource = Enum.GetNames(typeof(Parity));
            StopBitsCombo.DataSource = Enum.GetNames(typeof(StopBits));
        }

        private void LoadSettingsToUI()
        {
            PasswordTxt.Text = Properties.Settings.Default.AppPassword;

            SetComboBoxValue(BaudRateCombo, Properties.Settings.Default.BaudRate);
            SetComboBoxValue(DataBitsCombo, Properties.Settings.Default.DataBits);
            SetComboBoxValue(ParityCombo, Properties.Settings.Default.Parity);
            SetComboBoxValue(StopBitsCombo, Properties.Settings.Default.StopBits);

            ReadTimeoutNumeric.Value = Properties.Settings.Default.ReadTimeout;
            WriteTimeoutNumeric.Value = Properties.Settings.Default.WriteTimeout;
            AutoReconnectCheckBox.Checked = Properties.Settings.Default.AutoReconnect;

            SetComboBoxValue(PortCombo, Properties.Settings.Default.PortName);

            if (PortCombo.SelectedIndex == -1 && PortCombo.Items.Count > 0)
            {
                PortCombo.SelectedIndex = 0;
            }

        }

        private void SaveBtn_Click(object? sender, EventArgs e)
        {
            #region Submit Data & Save
            Properties.Settings.Default.AppPassword = PasswordTxt.Text;
            Properties.Settings.Default.PortName = PortCombo.SelectedItem?.ToString() ?? string.Empty;

           
            if (BaudRateCombo.SelectedItem == null || DataBitsCombo.SelectedItem == null ||
                ParityCombo.SelectedItem == null || StopBitsCombo.SelectedItem == null)
            {
                MessageBox.Show("لطفاً همه پارامترهای ارتباطی را انتخاب کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Properties.Settings.Default.BaudRate = Convert.ToInt32(BaudRateCombo.SelectedItem);
            Properties.Settings.Default.DataBits = Convert.ToInt32(DataBitsCombo.SelectedItem);

            Properties.Settings.Default.Parity = ParityCombo.SelectedItem?.ToString();
            Properties.Settings.Default.StopBits = StopBitsCombo.SelectedItem?.ToString();

            Properties.Settings.Default.ReadTimeout = (int)ReadTimeoutNumeric.Value;
            Properties.Settings.Default.WriteTimeout = (int)WriteTimeoutNumeric.Value;
            Properties.Settings.Default.AutoReconnect = AutoReconnectCheckBox.Checked;

            
            Properties.Settings.Default.Save();

            MessageBox.Show("تنظیمات با موفقیت ذخیره شد.", "عملیات موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

            #endregion
        }

        private void SetComboBoxValue(ComboBox comboBox, object value)
        {
            if (value == null) return;

            string targetValue = value.ToString() ?? string.Empty;

            foreach (var item in comboBox.Items)
            {
                if (item.ToString() == targetValue)
                {
                    comboBox.SelectedItem = item;
                    return;
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_modemService.IsConnected)
            {
                _modemService.Disconnect();
                btnConnect.Text = "اتصال";
                AppendLog("سیستم: ارتباط قطع شد.");
                return;
            }

            string portName = Properties.Settings.Default.PortName;
            int baudRate = Properties.Settings.Default.BaudRate;
            int dataBits = Properties.Settings.Default.DataBits;
            int readTimeout = Properties.Settings.Default.ReadTimeout;
            int writeTimeout = Properties.Settings.Default.WriteTimeout;

           
            if (!Enum.TryParse(Properties.Settings.Default.Parity, out Parity parity))
            {
                parity = Parity.None; 
            }

            
            if (!Enum.TryParse(Properties.Settings.Default.StopBits, out StopBits stopBits) || stopBits == StopBits.None)
            {
                stopBits = StopBits.One; 
            }

            if (string.IsNullOrEmpty(portName))
            {
                MessageBox.Show("لطفا ابتدا در بخش تنظیمات، پورت را انتخاب کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AppendLog($"سیستم: در حال تلاش برای اتصال به {portName}...");

           
            _modemService.Connect(portName, baudRate, parity, dataBits, stopBits, readTimeout, writeTimeout);

            if (_modemService.IsConnected)
            {
                btnConnect.Text = "قطع ارتباط";
                AppendLog("سیستم: متصل شد.");
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (!_modemService.IsConnected)
            {
                MessageBox.Show("پورت متصل نیست.", "خطا");
                return;
            }

            string command = txtCommand.Text.Trim();
            if (string.IsNullOrEmpty(command)) return;

            AppendLog($"ارسال: {command}");
            await _modemService.SendCommandAsync(command);


            txtCommand.Clear();
        }

        private void OnModemDataReceived(string data)
        {

            if (InvokeRequired)
            {
                Invoke(new Action(() => OnModemDataReceived(data)));
                return;
            }

            AppendLog($"دریافت: {data}");
        }
        private void OnModemErrorOccurred(Exception ex)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnModemErrorOccurred(ex)));
                return;
            }

            AppendLog($"خطا: {ex.Message}");
        }
        private void AppendLog(string message)
        {
            txtLog.AppendText($"{DateTime.Now:HH:mm:ss} - {message}{Environment.NewLine}");

            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
           
            _modemService.DataReceived -= OnModemDataReceived;
            _modemService.ErrorOccurred -= OnModemErrorOccurred;
            base.OnFormClosing(e);
        }

        private void Defaultbtn_Click(object sender, EventArgs e)
        {
            var messageresult = MessageBox.Show("با این کار تمام تنظیمات به حالت پیشفرض در خواهد آمد ، آیا ادامه می دهید؟", "پیغام سیستم ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(messageresult == DialogResult.Yes)
            {
                SetComboBoxValue(BaudRateCombo, 9600);
                SetComboBoxValue(DataBitsCombo, 8);
                SetComboBoxValue(ParityCombo, Parity.None.ToString());
                SetComboBoxValue(StopBitsCombo, StopBits.One.ToString());
                ReadTimeoutNumeric.Value = 5000;
                WriteTimeoutNumeric.Value = 5000;
                AutoReconnectCheckBox.Checked = true;
                _presetService.ResetToDefaults();
            }
           
        }

        private void AddGroupTypeBtn_Click(object sender, EventArgs e)
        {
            string newEntry = GroupTypeTxt.Text;

            if (_presetService.TryAdd(newEntry))
            {
                GroupTypeTxt.Clear();
                MessageBox.Show("گروه با موفقیت ثبت شد", "راهنما", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("خطایی رخ داد ، لطفا دوباره تلاش کنید !عنوان گروه نباید تکراری باشد", "راهنما", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
