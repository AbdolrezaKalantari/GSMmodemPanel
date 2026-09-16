using System.Text;
using System.Text.RegularExpressions;
using GsmPanel.models;

namespace GsmPanel;

public partial class SmsInboxForm : MetroFramework.Forms.MetroForm
{
    private readonly IGsmModemService _modemService = ModemManager.Instance;
    private readonly IRepository<SmsMessage> _messageRepository = new JsonRepository<SmsMessage>("received_sms.json");
    private readonly List<SmsMessage> _messages = new();

    public SmsInboxForm() => InitializeComponent();

    private async void SmsInboxForm_Load(object? sender, EventArgs e) => await LoadMessagesAsync();

    private async void refreshButton_Click(object? sender, EventArgs e) => await LoadMessagesAsync();

    private async Task LoadMessagesAsync()
    {
        if (!_modemService.IsConnected)
        {
            _messages.Clear();
            _messages.AddRange(await _messageRepository.GetAllAsync());
            BindMessages("آرشیو محلی؛ مودم متصل نیست.");
            return;
        }
        refreshButton.Enabled = false; deleteButton.Enabled = false; statusLabel.Text = "در حال دریافت پیامک‌ها...";
        try
        {
            await _modemService.SendCommandWithResponseAsync("AT+CMGF=1", 5000);
            var response = await _modemService.SendCommandWithResponseAsync("AT+CMGL=\"ALL\"", 15000);
            var modemMessages = ParseMessages(response);
            var storedMessages = await _messageRepository.GetAllAsync();
            foreach (var message in modemMessages)
            {
                if (!storedMessages.Any(x => SameMessage(x, message)))
                    storedMessages.Add(message);
            }
            await _messageRepository.SaveAllAsync(storedMessages);
            _messages.Clear(); _messages.AddRange(storedMessages.OrderByDescending(x => x.ReceivedAt));
            BindMessages($"تعداد پیامک‌های آرشیو شده: {_messages.Count}");
        }
        catch (Exception ex) { statusLabel.Text = "خطا در دریافت پیامک‌ها."; MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        finally { refreshButton.Enabled = true; }
    }

    private async void deleteButton_Click(object? sender, EventArgs e)
    {
        if (messagesGrid.CurrentRow?.DataBoundItem is not SmsMessage selected) return;
        if (MessageBox.Show("پیامک انتخاب‌شده حذف شود؟", "حذف پیامک", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        deleteButton.Enabled = false;
        try
        {
            if (_modemService.IsConnected)
            {
                var response = await _modemService.SendCommandWithResponseAsync($"AT+CMGD={selected.Index}", 5000);
                if (response.Contains("ERROR", StringComparison.OrdinalIgnoreCase)) throw new InvalidOperationException("حذف پیامک توسط مودم رد شد.");
            }
            var storedMessages = await _messageRepository.GetAllAsync();
            storedMessages.RemoveAll(x => x.Id == selected.Id);
            await _messageRepository.SaveAllAsync(storedMessages);
            await LoadMessagesAsync();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "خطا در حذف", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        finally { deleteButton.Enabled = true; }
    }

    private void messagesGrid_SelectionChanged(object? sender, EventArgs e) => deleteButton.Enabled = messagesGrid.CurrentRow?.DataBoundItem is SmsMessage;

    private void BindMessages(string status)
    {
        messagesGrid.DataSource = null;
        messagesGrid.DataSource = _messages;
        statusLabel.Text = $"{status} | تعداد: {_messages.Count}";
    }

    private static bool SameMessage(SmsMessage left, SmsMessage right) =>
        string.Equals(left.Sender?.Trim(), right.Sender?.Trim(), StringComparison.OrdinalIgnoreCase) &&
        string.Equals(left.ReceivedAt?.Trim(), right.ReceivedAt?.Trim(), StringComparison.OrdinalIgnoreCase) &&
        string.Equals(left.Body?.Trim(), right.Body?.Trim(), StringComparison.Ordinal);

    private static IReadOnlyList<SmsMessage> ParseMessages(string response)
    {
        var result = new List<SmsMessage>();
        var lines = response.Replace("\r", string.Empty).Split('\n');
        SmsMessage? current = null; var body = new StringBuilder();
        foreach (var raw in lines)
        {
            var line = raw.Trim();
            var match = Regex.Match(line, @"\+CMGL:\s*(\d+),""([^""]*)"",""([^""]*)""(?:,""[^""]*"")?,""([^""]*)""");
            if (match.Success)
            {
                if (current != null) result.Add(current with { Body = DecodeBody(body.ToString().Trim()) });
                body.Clear(); current = new SmsMessage { Index = int.Parse(match.Groups[1].Value), Status = DecodeBody(match.Groups[2].Value), Sender = DecodeBody(match.Groups[3].Value), ReceivedAt = DecodeBody(match.Groups[4].Value) };
            }
            else if (current != null && !line.Equals("OK", StringComparison.OrdinalIgnoreCase) && !line.Equals("ERROR", StringComparison.OrdinalIgnoreCase)) body.AppendLine(raw);
        }
        if (current != null) result.Add(current with { Body = DecodeBody(body.ToString().Trim()) });
        return result;
    }

    private static string DecodeBody(string value)
    {
        var compact = value.Replace(" ", string.Empty);
        if (compact.Length > 0 && compact.Length % 4 == 0 && Regex.IsMatch(compact, "^[0-9A-Fa-f]+$"))
        {
            try { return string.Concat(Enumerable.Range(0, compact.Length / 4).Select(i => (char)Convert.ToInt32(compact.Substring(i * 4, 4), 16))); } catch { }
        }
        return value;
    }
}
