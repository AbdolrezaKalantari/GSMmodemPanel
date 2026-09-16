namespace GsmPanel;

public sealed class HelpForm : MetroFramework.Forms.MetroForm
{
    public HelpForm()
    {
        Text = "راهنمای استفاده"; Style = MetroFramework.MetroColorStyle.Lime; RightToLeft = RightToLeft.Yes; RightToLeftLayout = true;
        MaximizeBox = false; Resizable = false; ClientSize = new Size(650, 430);
        var group = new GroupBox { Text = "راهنمای سریع", Location = new Point(25, 60), Size = new Size(600, 330) };
        var text = new TextBox { Multiline = true, ReadOnly = true, BorderStyle = System.Windows.Forms.BorderStyle.None, BackColor = SystemColors.Control, Location = new Point(25, 30), Size = new Size(550, 245), ScrollBars = ScrollBars.Vertical,
            Text = "۱) ابتدا از بخش تنظیمات، پورت COM و پارامترهای مودم را انتخاب و ذخیره کنید.\r\n\r\n۲) در صورت فعال بودن اتصال خودکار، برنامه در شروع به مودم متصل می‌شود.\r\n\r\n۳) برای ارسال تکی، مخاطب یا شماره را انتخاب کنید. برای ارسال گروهی، گروه را انتخاب و اعضای موردنظر را علامت بزنید.\r\n\r\n۴) در متن پیام می‌توانید از [نام] و [نام خانوادگی] استفاده کنید تا برای هر مخاطب شخصی‌سازی شود.\r\n\r\n۵) پیامک‌های دریافتی از مودم خوانده و در فایل received_sms.json آرشیو می‌شوند.\r\n\r\nنکته: هنگام ارسال یا دریافت، اتصال مودم و آماده بودن سیم‌کارت و شبکه را بررسی کنید." };
        var close = new Button { Text = "بستن", BackColor = Color.PowderBlue, Location = new Point(440, 280), Size = new Size(135, 28) };
        close.Click += (_, _) => Close(); group.Controls.Add(text); group.Controls.Add(close); Controls.Add(group);
    }
}
