using GsmPanel.models;

namespace GsmPanel;

public partial class SmsSendForm : MetroFramework.Forms.MetroForm
{
    private readonly Dictionary<string, string> _templates = new()
    {
        ["یادآوری قرار"] = "سلام [نام] عزیز، یادآوری می‌شود قرار شما در تاریخ ... برگزار خواهد شد.",
        ["تبریک"] = "[نام] عزیز، فرا رسیدن این روز را به شما تبریک می‌گوییم.",
        ["اطلاع‌رسانی"] = "[نام] عزیز، اطلاع‌رسانی مهم: ...",
        ["تشکر"] = "[نام] عزیز، از همراهی و اعتماد شما سپاسگزاریم."
    };
    private readonly IGsmModemService _modemService = ModemManager.Instance;
    private readonly IRepository<UserModel> _userRepository = new JsonRepository<UserModel>("users.json");
    private readonly IComboBoxPresetService _presetService = new ComboBoxPresetService();
    private List<UserModel> _users = new();

    public SmsSendForm() => InitializeComponent();

    private async void SmsSendForm_Load(object? sender, EventArgs e)
    {
        _users = await _userRepository.GetAllAsync();
        recipientCombo.DataSource = _users.ToList();
        recipientCombo.DisplayMember = nameof(UserModel.Name);
        recipientCombo.SelectedIndex = -1;

        groupCombo.Items.Clear();
        foreach (var group in _presetService.GetAll().Concat(_users.Select(u => u.GroupType)).Where(g => !string.IsNullOrWhiteSpace(g)).Distinct(StringComparer.OrdinalIgnoreCase))
            groupCombo.Items.Add(group.Trim());
        if (groupCombo.Items.Count > 0) groupCombo.SelectedIndex = 0;
        singleModeRadio.Checked = true;
        UpdateMode();
        UpdateMessageInfo();
        templateCombo.Items.Clear();
        templateCombo.Items.AddRange(_templates.Keys.ToArray());
    }

    private void singleModeRadio_CheckedChanged(object? sender, EventArgs e) => UpdateMode();
    private void groupModeRadio_CheckedChanged(object? sender, EventArgs e) => UpdateMode();

    private void UpdateMode()
    {
        bool groupMode = groupModeRadio.Checked;
        recipientCombo.Enabled = !groupMode;
        phoneTextBox.Enabled = !groupMode;
        groupCombo.Enabled = groupMode;
        recipientsList.Enabled = groupMode;
        selectAllButton.Enabled = groupMode;
        clearSelectionButton.Enabled = groupMode;
        if (groupMode) PopulateGroupRecipients();
        UpdateRecipientCount();
    }

    private void recipientCombo_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (recipientCombo.SelectedItem is UserModel user)
            phoneTextBox.Text = user.PhoneNumber ?? string.Empty;
        UpdateRecipientCount();
    }

    private void groupCombo_SelectedIndexChanged(object? sender, EventArgs e) => PopulateGroupRecipients();

    private void PopulateGroupRecipients()
    {
        if (groupCombo.SelectedItem == null) return;
        string group = groupCombo.SelectedItem.ToString() ?? string.Empty;
        var groupUsers = _users.Where(u => string.Equals(u.GroupType?.Trim(), group.Trim(), StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(u.PhoneNumber)).ToList();
        recipientsList.Items.Clear();
        foreach (var user in groupUsers)
            recipientsList.Items.Add(new RecipientItem(user), true);
        UpdateRecipientCount();
    }

    private void selectAllButton_Click(object? sender, EventArgs e)
    {
        for (int i = 0; i < recipientsList.Items.Count; i++) recipientsList.SetItemChecked(i, true);
        UpdateRecipientCount();
    }

    private void clearSelectionButton_Click(object? sender, EventArgs e)
    {
        for (int i = 0; i < recipientsList.Items.Count; i++) recipientsList.SetItemChecked(i, false);
        UpdateRecipientCount();
    }

    private void recipientsList_ItemCheck(object? sender, ItemCheckEventArgs e) => BeginInvoke(new Action(UpdateRecipientCount));
    private void messageTextBox_TextChanged(object? sender, EventArgs e) => UpdateMessageInfo();

    private void templateButton_Click(object? sender, EventArgs e)
    {
        if (templateCombo.SelectedItem is string title && _templates.TryGetValue(title, out var template))
        {
            messageTextBox.Text = template;
            messageTextBox.SelectionStart = messageTextBox.Text.Length;
            messageTextBox.Focus();
        }
    }

    private void UpdateMessageInfo()
    {
        int length = messageTextBox?.Text.Length ?? 0;
        int parts = length == 0 ? 0 : (int)Math.Ceiling(length / 70.0);
        characterLabel.Text = $"تعداد کاراکتر: {length} | بخش پیامک: {parts}";
    }

    private void UpdateRecipientCount()
    {
        if (recipientCountLabel == null) return;
        int count = groupModeRadio.Checked ? recipientsList.CheckedItems.Count : (recipientCombo.SelectedItem is UserModel ? 1 : 0);
        recipientCountLabel.Text = $"تعداد گیرندگان: {count}";
    }

    private async void sendButton_Click(object? sender, EventArgs e)
    {
        if (!_modemService.IsConnected)
        {
            MessageBox.Show("ابتدا مودم را از بخش تنظیمات متصل کنید.", "اتصال مودم", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (string.IsNullOrWhiteSpace(messageTextBox.Text))
        {
            MessageBox.Show("متن پیامک الزامی است.", "اطلاعات ناقص", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var recipients = GetRecipients();
        if (recipients.Count == 0)
        {
            MessageBox.Show("حداقل یک گیرنده انتخاب کنید.", "اطلاعات ناقص", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (recipients.Count > 1 && MessageBox.Show($"پیام برای {recipients.Count} مخاطب ارسال شود؟", "تأیید ارسال گروهی", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        sendButton.Enabled = false; clearButton.Enabled = false; refreshControls(false);
        int success = 0, failed = 0;
        progressBar.Minimum = 0; progressBar.Maximum = recipients.Count; progressBar.Value = 0;
        try
        {
            for (int i = 0; i < recipients.Count; i++)
            {
                var item = recipients[i];
                statusLabel.Text = $"در حال ارسال {i + 1} از {recipients.Count}: {item.Name}";
                string text = messageTextBox.Text.Replace("[نام]", item.Name ?? string.Empty).Replace("[نام خانوادگی]", item.LastName ?? string.Empty);
                try { await _modemService.SendSmsAsync(item.PhoneNumber!, text); success++; }
                catch { failed++; }
                progressBar.Value = i + 1;
                if (i < recipients.Count - 1) await Task.Delay(350);
            }
            statusLabel.Text = $"ارسال پایان یافت؛ موفق: {success}، ناموفق: {failed}";
            if (failed == 0) messageTextBox.Clear();
        }
        finally
        {
            sendButton.Enabled = true; clearButton.Enabled = true; refreshControls(true);
        }
    }

    private List<UserModel> GetRecipients()
    {
        if (!groupModeRadio.Checked)
        {
            if (string.IsNullOrWhiteSpace(phoneTextBox.Text)) return new List<UserModel>();
            if (recipientCombo.SelectedItem is UserModel user)
                return new List<UserModel> { new UserModel { Id = user.Id, Name = user.Name, LastName = user.LastName, BirthDay = user.BirthDay, Gender = user.Gender, GroupType = user.GroupType, Description = user.Description, PhoneNumber = phoneTextBox.Text.Trim() } };
            return new List<UserModel> { new UserModel { Name = "گیرنده", PhoneNumber = phoneTextBox.Text.Trim() } };
        }
        return recipientsList.CheckedItems.Cast<RecipientItem>().Select(x => x.User).ToList();
    }

    private void refreshControls(bool enabled)
    {
        singleModeRadio.Enabled = enabled; groupModeRadio.Enabled = enabled; groupCombo.Enabled = enabled && groupModeRadio.Checked;
        recipientCombo.Enabled = enabled && !groupModeRadio.Checked; phoneTextBox.Enabled = recipientCombo.Enabled; recipientsList.Enabled = enabled && groupModeRadio.Checked;
        selectAllButton.Enabled = enabled && groupModeRadio.Checked; clearSelectionButton.Enabled = selectAllButton.Enabled;
    }

    private void clearButton_Click(object? sender, EventArgs e)
    {
        phoneTextBox.Clear(); messageTextBox.Clear(); recipientCombo.SelectedIndex = -1;
        for (int i = 0; i < recipientsList.Items.Count; i++) recipientsList.SetItemChecked(i, false);
        statusLabel.Text = string.Empty; progressBar.Value = 0; UpdateRecipientCount();
    }

    private sealed class RecipientItem
    {
        public UserModel User { get; }
        public RecipientItem(UserModel user) => User = user;
        public override string ToString() => $"{User.Name} {User.LastName} - {User.PhoneNumber}".Trim();
    }
}
