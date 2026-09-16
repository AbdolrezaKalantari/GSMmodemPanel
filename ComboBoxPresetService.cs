using System.Collections.Specialized;

namespace GsmPanel
{
    public class ComboBoxPresetService : IComboBoxPresetService
    {
        public IReadOnlyList<string> GetAll()
        {
            EnsureCollectionInitialized();
            return Properties.Settings.Default.GroupType
                .Cast<string>()
                .ToList()
                .AsReadOnly();
        }
        public bool TryAdd(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            EnsureCollectionInitialized();

            var collection = Properties.Settings.Default.GroupType;

            if (collection.Contains(value.Trim()))
                return false;

            collection.Add(value.Trim());
   
            Properties.Settings.Default.Save();
            return true;
        }

        private static void EnsureCollectionInitialized()
        {         
            if (Properties.Settings.Default.GroupType == null)
            {
                Properties.Settings.Default.GroupType = new StringCollection();
                Properties.Settings.Default.Save();
            }
        }

        public void ResetToDefaults()
        {
            var defaultValues = new[] { "عمومی", "مشتریان", "اختصاصی", "کارمندان" };
            var newCollection = new StringCollection();
            newCollection.AddRange(defaultValues);
            Properties.Settings.Default.GroupType = newCollection;
            Properties.Settings.Default.Save();
        }
    }
}
