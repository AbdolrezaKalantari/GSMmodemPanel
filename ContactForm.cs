using ClosedXML.Excel;
using GsmPanel.models;

namespace GsmPanel
{
    public partial class ContactForm : MetroFramework.Forms.MetroForm
    {
        private readonly IRepository<UserModel> _userRepository;
        private List<UserModel> _users;
        private BindingSource _bindingSource;
        private string? _editingUserId = null;
        private readonly IComboBoxPresetService _presetService;

        public ContactForm()
        {
            InitializeComponent();
            _userRepository = new JsonRepository<UserModel>("users.json");
            _users = new List<UserModel>();
            _bindingSource = new BindingSource();
            _presetService = new ComboBoxPresetService();
            this.Load += ContactForm_Load;
        }
        private void BindPresets()
        {
            GroupCombo.Items.Clear();
            var items = _presetService.GetAll();

            foreach (var item in items)
            {
                GroupCombo.Items.Add(item);
            }

            if (GroupCombo.Items.Count > 0)
            {
                GroupCombo.SelectedIndex = 0;
            }
        }
        private async Task LoadUsersAsync()
        {
            _users = await _userRepository.GetAllAsync();
            _bindingSource.DataSource = _users;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _bindingSource;
        }

        private async void ContactForm_Load(object? sender, EventArgs e)
        {
            BindPresets();
            await LoadUsersAsync();

        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTxtbox.Text) || string.IsNullOrWhiteSpace(PhoneNumberTxtbox.Text))
            {
                MessageBox.Show("نام کاربر و شماره همراه در ثبت الزامی است .");
                return;
            }
            if (_editingUserId == null)
            {
                // new user
                var newUser = new UserModel
                {
                    Name = NameTxtbox.Text,
                    LastName = LastnameTxtbox.Text,
                    PhoneNumber = PhoneNumberTxtbox.Text,
                    BirthDay = BirthdayTxtbox.Text,
                    GroupType = GroupCombo.SelectedItem?.ToString() ?? "Default",
                    Gender = GenderCombo.SelectedItem?.ToString(),
                    Description = DescriptionTxtbox.Text,
                };
                _users.Add(newUser);
            }
            else
            {
                // Edit User
                var userToUpdate = _users.FirstOrDefault(u => u.Id == _editingUserId);
                if (userToUpdate != null)
                {
                    userToUpdate.Name = NameTxtbox.Text.Trim();
                    userToUpdate.LastName = LastnameTxtbox.Text.Trim();
                    userToUpdate.PhoneNumber = PhoneNumberTxtbox.Text.Trim();
                    userToUpdate.BirthDay = BirthdayTxtbox.Text.Trim();
                    userToUpdate.GroupType = GroupCombo.SelectedItem?.ToString() ?? "Default";
                    userToUpdate.Gender = GenderCombo.SelectedItem?.ToString();
                    userToUpdate.Description = DescriptionTxtbox.Text.Trim();
                }
                _editingUserId = null;
            }
            await _userRepository.SaveAllAsync(_users);
            _bindingSource.ResetBindings(false);

            ClearForm();
            MessageBox.Show("اطلاعات با موفقیت ذخیره شد.");
        }
        private void ClearForm()
        {
            _editingUserId = null;
            NameTxtbox.Clear();
            LastnameTxtbox.Clear();
            PhoneNumberTxtbox.Clear();
            BirthdayTxtbox.Clear();
            GroupCombo.SelectedIndex = -1;
            GenderCombo.SelectedIndex = -1;
            DescriptionTxtbox.Clear();
            label8.Text = string.Empty;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var selectedUser = _bindingSource[e.RowIndex] as UserModel;
            if (selectedUser == null) return;

            if (columnName == "btnDeleteColumn")
            {
                var result = MessageBox.Show($"آیا از حذف {selectedUser.Name} مطمئن هستید؟", "حذف", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _users.Remove(selectedUser);
                    await _userRepository.SaveAllAsync(_users);
                    _bindingSource.ResetBindings(false);
                }
            }
            else if (columnName == "btnEditColumn")
            {
                _editingUserId = selectedUser.Id;
                NameTxtbox.Text = selectedUser.Name;
                LastnameTxtbox.Text = selectedUser.LastName;
                PhoneNumberTxtbox.Text = selectedUser.PhoneNumber;
                BirthdayTxtbox.Text = selectedUser.BirthDay;
                GroupCombo.SelectedItem = selectedUser.GroupType;
                GenderCombo.SelectedItem = selectedUser.Gender;
                DescriptionTxtbox.Text = selectedUser.Description;
                label8.Text = "کد یکتا کاربر : " + selectedUser.Id;
            }
        }
        private void NameTxtbox_TextChanged(object sender, EventArgs e)
        {
            var keyword = NameTxtbox.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                _bindingSource.DataSource = _users;
            }
            else
            {
                var filteredUsers = _users.Where(u =>
           (u.Name != null && u.Name.ToLower().Contains(keyword)) ||
           (u.LastName != null && u.LastName.ToLower().Contains(keyword)) ||
           (u.PhoneNumber != null && u.PhoneNumber.Contains(keyword))).ToList();
                _bindingSource.DataSource = filteredUsers;
            }
            _bindingSource.ResetBindings(false);
        }

        private async void RemoveAllBtn_Click(object sender, EventArgs e)
        {
            if (!_users.Any()) return;

            var dialogResult = MessageBox.Show(
                "آیا از حذف تمام کاربران اطمینان دارید؟ این عملیات غیرقابل بازگشت است.",
                "هشدار امنیتی",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                _users.Clear();
                await _userRepository.SaveAllAsync(_users);

                _bindingSource.ResetBindings(false);
                MessageBox.Show("تمامی اطلاعات با موفقیت حذف شدند.");
            }
        }

        private async void ImportExelBtn_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "انتخاب فایل اکسل مخاطبین"
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            ImportExelBtn.Enabled = false;

            label8.Text = "در حال آماده‌سازی فایل...";
            try
            {
                var filePath = ofd.FileName;
                var importedUsers = await Task.Run(async () =>
                {
                    var newUsersList = new List<UserModel>();

                    using var workbook = new XLWorkbook(filePath);
                    var worksheet = workbook.Worksheet(1);
                    var usedRange = worksheet.RangeUsed();
                    if (usedRange == null)
                        return newUsersList;

                    var rows = usedRange.RowsUsed().Skip(1).ToList();

                    int totalRows = rows.Count;
                    int currentRow = 0;

                    foreach (var row in rows)
                    {
                        currentRow++;

                        this.Invoke(new Action(() =>
                        {
                            label8.Text = $"در حال خواندن ردیف {currentRow} از {totalRows}...";
                        }));

                        var phone = row.Cell(3).GetString().Trim();
                        if (string.IsNullOrWhiteSpace(phone)) continue;

                        newUsersList.Add(new UserModel
                        {
                            Name = row.Cell(1).GetString().Trim(),
                            LastName = row.Cell(2).GetString().Trim(),
                            PhoneNumber = phone,
                            BirthDay = row.Cell(4).GetString().Trim(),
                            Gender = row.Cell(5).GetString().Trim(),
                            GroupType = row.Cell(6).GetString().Trim() is { Length: > 0 } group
                                ? group
                                : "Default",
                        });
                    }

                    return newUsersList;
                });

                if (importedUsers.Count > 0)
                {
                    label8.Text = "در حال ذخیره‌سازی اطلاعات...";

                    _users.AddRange(importedUsers);
                    await _userRepository.SaveAllAsync(_users);
                    _bindingSource.ResetBindings(false);

                    MessageBox.Show($"{importedUsers.Count} مخاطب با موفقیت وارد سیستم شد.", "عملیات موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("فایل فاقد داده معتبر بود.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("فایل اکسل در برنامه دیگری باز است. لطفا آن را ببندید و مجدد تلاش کنید.", "خطای فایل", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در خواندن فایل اکسل: {ex.Message}", "خطای سیستمی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                label8.Text = string.Empty;
                ImportExelBtn.Enabled = true;
            }
        }
    }
}
