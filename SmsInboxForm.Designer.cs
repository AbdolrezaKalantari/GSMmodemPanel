#nullable enable
namespace GsmPanel;

partial class SmsInboxForm
{
    private System.ComponentModel.IContainer? components;
    private GroupBox inboxGroup = null!; private DataGridView messagesGrid = null!; private Button refreshButton = null!; private Button deleteButton = null!; private Label statusLabel = null!;
    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        inboxGroup = new GroupBox(); messagesGrid = new DataGridView(); refreshButton = new Button(); deleteButton = new Button(); statusLabel = new Label();
        inboxGroup.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)messagesGrid).BeginInit(); SuspendLayout();
        inboxGroup.Controls.Add(messagesGrid); inboxGroup.Controls.Add(refreshButton); inboxGroup.Controls.Add(deleteButton); inboxGroup.Controls.Add(statusLabel); inboxGroup.Location = new Point(38, 65); inboxGroup.Size = new Size(845, 400); inboxGroup.Text = "پیامک‌های دریافتی";
        messagesGrid.AllowUserToAddRows = false; messagesGrid.AllowUserToDeleteRows = false; messagesGrid.AutoGenerateColumns = false; messagesGrid.ReadOnly = true; messagesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect; messagesGrid.RightToLeft = RightToLeft.Yes; messagesGrid.Location = new Point(20, 30); messagesGrid.Size = new Size(805, 300); messagesGrid.SelectionChanged += messagesGrid_SelectionChanged;
        messagesGrid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Index", HeaderText = "شناسه", Width = 60 }); messagesGrid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "وضعیت", Width = 110 }); messagesGrid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Sender", HeaderText = "فرستنده", Width = 150 }); messagesGrid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReceivedAt", HeaderText = "تاریخ دریافت", Width = 170 }); messagesGrid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Body", HeaderText = "متن پیام", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        refreshButton.BackColor = Color.PowderBlue; refreshButton.Location = new Point(690, 345); refreshButton.Size = new Size(135, 30); refreshButton.Text = "به‌روزرسانی"; refreshButton.Click += refreshButton_Click;
        deleteButton.Location = new Point(540, 345); deleteButton.Size = new Size(135, 30); deleteButton.Text = "حذف پیامک"; deleteButton.Click += deleteButton_Click; deleteButton.Enabled = false;
        statusLabel.AutoSize = true; statusLabel.ForeColor = Color.FromArgb(0, 128, 0); statusLabel.Location = new Point(20, 353); statusLabel.Text = "";
        ClientSize = new Size(921, 520); Controls.Add(inboxGroup); MaximizeBox = false; Resizable = false; RightToLeft = RightToLeft.Yes; RightToLeftLayout = true; Style = MetroFramework.MetroColorStyle.Lime; Text = "پیامک‌های دریافتی"; Load += SmsInboxForm_Load;
        inboxGroup.ResumeLayout(false); inboxGroup.PerformLayout(); ((System.ComponentModel.ISupportInitialize)messagesGrid).EndInit(); ResumeLayout(false);
    }
}
