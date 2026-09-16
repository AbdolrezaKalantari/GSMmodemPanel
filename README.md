# GsmPanel

نرم‌افزار دسکتاپ Windows برای مدیریت مودم GSM و ارسال و دریافت پیامک.

## امکانات

- اتصال به مودم GSM از طریق پورت سریال COM
- نمایش وضعیت سیم‌کارت، آنتن و شبکه
- ارسال پیامک تکی و گروهی بر اساس گروه‌بندی مخاطبین
- قالب‌های آماده پیامک و شخصی‌سازی با `[نام]` و `[نام خانوادگی]`
- دریافت، نمایش و حذف پیامک‌های حافظه مودم
- آرشیو دائمی پیامک‌های دریافتی و مخاطبین در JSON
- ورود مخاطبین از Excel
- تنظیمات پورت و اتصال خودکار

## پیش‌نیازها

- Windows 10/11 x64
- مودم GSM با درایور نصب‌شده و پورت COM قابل دسترس
- سیم‌کارت فعال با امکان SMS
- Visual Studio یا .NET SDK 8+

## اجرا

```powershell
dotnet restore
dotnet build GsmPanel.csproj
dotnet run --project GsmPanel.csproj
```

اطلاعات runtime در مسیر زیر ذخیره می‌شوند و داخل مخزن قرار نمی‌گیرند:

```text
%LOCALAPPDATA%\GsmPanel\users.json
%LOCALAPPDATA%\GsmPanel\received_sms.json
```

## Publish برای Windows x64

```powershell
dotnet publish GsmPanel.csproj -c Release -r win-x64 --self-contained true `
  -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true `
  -o publish\win-x64
```

## نکات مودم

ارتباط با مودم با دستورات استاندارد AT انجام می‌شود. ارسال پیامک با حالت متنی و کدگذاری UCS2 برای پشتیبانی از فارسی انجام می‌شود. پشتیبانی دقیق از UCS2، ظرفیت SMS و دستورهای `CMGL/CMGD` به مدل و Firmware مودم وابسته است؛ پیش از ارسال گروهی، ابتدا ارسال تکی را آزمایش کنید.

## تکنولوژی‌ها

- C# / .NET 8 / Windows Forms
- `System.IO.Ports`
- `System.Text.Json`
- `ClosedXML`
- `MetroModernUI`

## توسعه‌دهنده

عبدالرضا کلانتری

## مجوز

MIT — فایل [LICENSE](LICENSE) را ببینید.
