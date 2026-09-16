using System.Reflection;

namespace GsmPanel;

public sealed class AboutForm : MetroFramework.Forms.MetroForm
{
    public AboutForm()
    {
        Text = "درباره برنامه"; Style = MetroFramework.MetroColorStyle.Lime; RightToLeft = RightToLeft.Yes; RightToLeftLayout = true;
        MaximizeBox = false; Resizable = false; ClientSize = new Size(560, 330);
        var group = new GroupBox { Text = "درباره GsmPanel", Location = new Point(25, 60), Size = new Size(510, 235) };
        var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";
        var text = new Label { AutoSize = false, Location = new Point(25, 30), Size = new Size(460, 170), TextAlign = ContentAlignment.TopRight,
            Text = $"نرم‌افزار مدیریت ارسال و دریافت پیامک با مودم GSM\n\nنسخه برنامه: {version}\nتوسعه‌دهنده: عبدالرضا کلانتری\n\nتکنولوژی‌های استفاده‌شده:\n• C# و .NET 8 Windows Forms\n• ارتباط سریال با System.IO.Ports\n• ذخیره‌سازی JSON\n• ClosedXML برای ورود مخاطبین از Excel\n• MetroModernUI برای رابط کاربری" };
        var close = new Button { Text = "بستن", BackColor = Color.PowderBlue, Location = new Point(350, 190), Size = new Size(135, 28) };
        close.Click += (_, _) => Close(); group.Controls.Add(text); group.Controls.Add(close); Controls.Add(group);
    }
}
