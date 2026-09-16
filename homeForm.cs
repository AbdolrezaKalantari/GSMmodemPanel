using System.IO.Ports;
using System.Text.RegularExpressions;

namespace GsmPanel
{
    public partial class homeForm : MetroFramework.Forms.MetroForm
    {
        private IGsmModemService? _modemService;

        public homeForm()
        {
            InitializeComponent();
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            this.Opacity = 0;
            settings.ShowDialog();
            this.Opacity = 1;
        }

        private void homeForm_Load(object sender, EventArgs e)
        {
            _modemService = ModemManager.Instance;
            if (Properties.Settings.Default.AutoReconnect)
                AutoConnectToSavedPort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ContactForm contact = new ContactForm();
            this.Opacity = 0;
            contact.ShowDialog();
            this.Opacity = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using var form = new SmsSendForm();
            Opacity = 0; form.ShowDialog(this); Opacity = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using var form = new SmsInboxForm();
            Opacity = 0; form.ShowDialog(this); Opacity = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using var form = new AboutForm();
            Opacity = 0; form.ShowDialog(this); Opacity = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var form = new HelpForm();
            Opacity = 0; form.ShowDialog(this); Opacity = 1;
        }

        private async void RefreshBtn_Click(object sender, EventArgs e)
        {
            if (_modemService == null || !_modemService.IsConnected)
            {
                MessageBox.Show("ابتدا از بخش تنظیمات به پورت مودم متصل شوید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RefreshBtn.Enabled = false;

            try
            {
                string simResponse = await _modemService.SendCommandWithResponseAsync("AT+CPIN?");
                lblSimStatus.Text = ParseSimStatus(simResponse);

                string signalResponse = await _modemService.SendCommandWithResponseAsync("AT+CSQ");
                lblSignal.Text = ParseSignalStatus(signalResponse);

                string netResponse = await _modemService.SendCommandWithResponseAsync("AT+CREG?");
                lblNetwork.Text = ParseNetworkStatus(netResponse);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در دریافت اطلاعات: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RefreshBtn.Enabled = true;
            }
        }

        #region Helpers for AT Command Parsing

        private string ParseSimStatus(string response)
        {
            if (response.Contains("+CPIN: READY")) return "آماده (Ready)";
            if (response.Contains("SIM PIN")) return "نیازمند پین‌کد";
            if (response.Contains("SIM NOT INSERTED") || response.Contains("ERROR")) return "عدم شناسایی سیم‌کارت";
            return "نامشخص";
        }

        private string ParseSignalStatus(string response)
        {
            Match match = Regex.Match(response, @"\+CSQ:\s*(\d+),");
            if (match.Success)
            {
                int signalRaw = int.Parse(match.Groups[1].Value);
                if (signalRaw == 99) return "0%";

                int percentage = (int)Math.Round((signalRaw / 31.0) * 100);
                return $"{percentage}%";
            }
            return "نامشخص";
        }

        private string ParseNetworkStatus(string response)
        {
            Match match = Regex.Match(response, @"\+CREG:\s*\d+,(\d+)");
            if (match.Success)
            {
                int status = int.Parse(match.Groups[1].Value);
                return status switch
                {
                    1 => "متصل (شبکه اصلی)",
                    5 => "متصل (رومینگ)",
                    2 => "در حال جستجو...",
                    3 => "ثبت رد شد",
                    _ => "قطع ارتباط"
                };
            }
            return "نامشخص";
        }

        #endregion

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AutoConnectToSavedPort()
        {
            string savedPort = Properties.Settings.Default.PortName;

            // اگر پورتی وجود ندارد، بدون مزاحمت برای کاربر خارج شو
            if (string.IsNullOrEmpty(savedPort)) return;

            // استخراج تنظیمات با مقادیر امن
            int baudRate = Properties.Settings.Default.BaudRate > 0 ? Properties.Settings.Default.BaudRate : 9600;
            int dataBits = Properties.Settings.Default.DataBits > 0 ? Properties.Settings.Default.DataBits : 8;

            string parityStr = string.IsNullOrEmpty(Properties.Settings.Default.Parity) ? "None" : Properties.Settings.Default.Parity;
            string stopBitsStr = string.IsNullOrEmpty(Properties.Settings.Default.StopBits) ? "One" : Properties.Settings.Default.StopBits;

            if (!Enum.TryParse(parityStr, true, out Parity parity)) parity = Parity.None;
            if (!Enum.TryParse(stopBitsStr, true, out StopBits stopBits) || stopBits == StopBits.None)
                stopBits = StopBits.One;

            int readTimeout = Properties.Settings.Default.ReadTimeout > 0 ? Properties.Settings.Default.ReadTimeout : 5000;
            int writeTimeout = Properties.Settings.Default.WriteTimeout > 0 ? Properties.Settings.Default.WriteTimeout : 5000;

            // تلاش برای اتصال
            _modemService?.Connect(savedPort, baudRate, parity, dataBits, stopBits, readTimeout, writeTimeout);

            // بررسی حیاتی: آیا پس از اجرای متد، اتصال واقعاً برقرار شد؟
            if (_modemService == null || !_modemService.IsConnected)
            {
                MessageBox.Show($"سیستم در زمان اجرا تلاش کرد به پورت {savedPort} متصل شود اما موفق نشد!\n" +
                                $"احتمالاً پورت {savedPort} در حال حاضر توسط QCOM اشغال شده است یا وجود ندارد.",
                                "خطا در اتصال خودکار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




    }
}

