#nullable enable
namespace GsmPanel;

partial class SmsSendForm
{
    private System.ComponentModel.IContainer? components;
    private GroupBox messageGroup = null!; private RadioButton singleModeRadio = null!; private RadioButton groupModeRadio = null!;
    private ComboBox recipientCombo = null!; private ComboBox groupCombo = null!; private TextBox phoneTextBox = null!; private TextBox messageTextBox = null!;
    private ComboBox templateCombo = null!; private Button templateButton = null!;
    private CheckedListBox recipientsList = null!; private Button selectAllButton = null!; private Button clearSelectionButton = null!; private Button sendButton = null!; private Button clearButton = null!;
    private ProgressBar progressBar = null!; private Label statusLabel = null!; private Label recipientCountLabel = null!; private Label characterLabel = null!;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container(); messageGroup = new GroupBox(); singleModeRadio = new RadioButton(); groupModeRadio = new RadioButton(); recipientCombo = new ComboBox(); groupCombo = new ComboBox(); phoneTextBox = new TextBox(); messageTextBox = new TextBox(); templateCombo = new ComboBox(); templateButton = new Button(); recipientsList = new CheckedListBox(); selectAllButton = new Button(); clearSelectionButton = new Button(); sendButton = new Button(); clearButton = new Button(); progressBar = new ProgressBar(); statusLabel = new Label(); recipientCountLabel = new Label(); characterLabel = new Label();
        messageGroup.SuspendLayout(); SuspendLayout();
        messageGroup.Controls.Add(singleModeRadio); messageGroup.Controls.Add(groupModeRadio); messageGroup.Controls.Add(recipientCombo); messageGroup.Controls.Add(groupCombo); messageGroup.Controls.Add(phoneTextBox); messageGroup.Controls.Add(messageTextBox); messageGroup.Controls.Add(templateCombo); messageGroup.Controls.Add(templateButton); messageGroup.Controls.Add(recipientsList); messageGroup.Controls.Add(selectAllButton); messageGroup.Controls.Add(clearSelectionButton); messageGroup.Controls.Add(sendButton); messageGroup.Controls.Add(clearButton); messageGroup.Controls.Add(progressBar); messageGroup.Controls.Add(statusLabel); messageGroup.Controls.Add(recipientCountLabel); messageGroup.Controls.Add(characterLabel);
        messageGroup.Location = new Point(38, 65); messageGroup.Size = new Size(845, 500); messageGroup.Text = "ارسال پیامک پیشرفته";
        singleModeRadio.AutoSize = true; singleModeRadio.Location = new Point(675, 35); singleModeRadio.Text = "ارسال تکی"; singleModeRadio.CheckedChanged += singleModeRadio_CheckedChanged;
        groupModeRadio.AutoSize = true; groupModeRadio.Location = new Point(560, 35); groupModeRadio.Text = "ارسال گروهی"; groupModeRadio.CheckedChanged += groupModeRadio_CheckedChanged;
        recipientCombo.DropDownStyle = ComboBoxStyle.DropDownList; recipientCombo.Location = new Point(450, 75); recipientCombo.Size = new Size(300, 23); recipientCombo.SelectedIndexChanged += recipientCombo_SelectedIndexChanged;
        groupCombo.DropDownStyle = ComboBoxStyle.DropDownList; groupCombo.Location = new Point(450, 115); groupCombo.Size = new Size(300, 23); groupCombo.SelectedIndexChanged += groupCombo_SelectedIndexChanged;
        phoneTextBox.Location = new Point(450, 155); phoneTextBox.Size = new Size(300, 23); phoneTextBox.RightToLeft = RightToLeft.No;
        messageTextBox.Location = new Point(25, 75); messageTextBox.Multiline = true; messageTextBox.ScrollBars = ScrollBars.Vertical; messageTextBox.Size = new Size(390, 150); messageTextBox.TextChanged += messageTextBox_TextChanged;
        templateCombo.DropDownStyle = ComboBoxStyle.DropDownList; templateCombo.Location = new Point(25, 270); templateCombo.Size = new Size(245, 23);
        templateButton.BackColor = Color.PowderBlue; templateButton.Location = new Point(280, 270); templateButton.Size = new Size(135, 23); templateButton.Text = "درج قالب آماده"; templateButton.Click += templateButton_Click;
        recipientsList.CheckOnClick = true; recipientsList.Location = new Point(450, 195); recipientsList.Size = new Size(300, 180); recipientsList.ItemCheck += recipientsList_ItemCheck;
        selectAllButton.Location = new Point(590, 382); selectAllButton.Size = new Size(160, 28); selectAllButton.Text = "انتخاب همه"; selectAllButton.Click += selectAllButton_Click;
        clearSelectionButton.Location = new Point(450, 382); clearSelectionButton.Size = new Size(130, 28); clearSelectionButton.Text = "لغو انتخاب"; clearSelectionButton.Click += clearSelectionButton_Click;
        characterLabel.AutoSize = true; characterLabel.Location = new Point(25, 235); characterLabel.Text = "تعداد کاراکتر: 0 | بخش پیامک: 0";
        recipientCountLabel.AutoSize = true; recipientCountLabel.Location = new Point(25, 270); recipientCountLabel.Text = "تعداد گیرندگان: 0";
        progressBar.Location = new Point(25, 310); progressBar.Size = new Size(390, 22);
        statusLabel.AutoSize = true; statusLabel.ForeColor = Color.FromArgb(0, 128, 0); statusLabel.Location = new Point(25, 350); statusLabel.Text = "";
        sendButton.BackColor = Color.PowderBlue; sendButton.Location = new Point(616, 440); sendButton.Size = new Size(134, 30); sendButton.Text = "ارسال پیامک"; sendButton.Click += sendButton_Click;
        clearButton.Location = new Point(466, 440); clearButton.Size = new Size(134, 30); clearButton.Text = "پاک کردن"; clearButton.Click += clearButton_Click;
        AddLabel("مخاطب:", 765, 79); AddLabel("گروه:", 765, 119); AddLabel("شماره:", 765, 159); AddLabel("متن پیام:", 330, 79); AddLabel("اعضای گروه:", 765, 199);
        ClientSize = new Size(921, 620); Controls.Add(messageGroup); MaximizeBox = false; Resizable = false; RightToLeft = RightToLeft.Yes; RightToLeftLayout = true; Style = MetroFramework.MetroColorStyle.Lime; Text = "ارسال پیامک"; Load += SmsSendForm_Load;
        messageGroup.ResumeLayout(false); messageGroup.PerformLayout(); ResumeLayout(false);
    }

    private void AddLabel(string text, int x, int y) => messageGroup.Controls.Add(new Label { AutoSize = true, Location = new Point(x, y), Text = text });
}
