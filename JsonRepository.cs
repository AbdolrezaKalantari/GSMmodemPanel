using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GsmPanel
{
    public class JsonRepository<T> : IRepository<T>
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        public JsonRepository(string fileName)
        {
            var dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GsmPanel");
            Directory.CreateDirectory(dataDirectory);
            _filePath = Path.Combine(dataDirectory, fileName);
        }
        public async Task<List<T>> GetAllAsync()
        {
            if (!File.Exists(_filePath)) return new List<T>();

            try
            {
                string json = await File.ReadAllTextAsync(_filePath);
                return JsonSerializer.Deserialize<List<T>>(json, _options) ?? new List<T>();
            }
            catch (JsonException)
            {
                return new List<T>();
            }
        }
        public async Task SaveAllAsync(List<T> items)
        {
            string json = JsonSerializer.Serialize(items, _options);
            string tempPath = _filePath + ".tmp";
            await File.WriteAllTextAsync(tempPath, json);
            File.Move(tempPath, _filePath, true);
        }
    }
}
