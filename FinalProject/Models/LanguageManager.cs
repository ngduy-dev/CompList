using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public static class LanguageManager
{
    private static Dictionary<string, string> _translations = new Dictionary<string, string>();
    private static string _currentLanguage = "en";

    public static void LoadLanguage(string languageCode)
    {
        _currentLanguage = languageCode;
        var filePath = $"Languages/{languageCode}.json";

        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            _translations = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
    }

    public static string Translate(string key)
    {
        return _translations.ContainsKey(key) ? _translations[key] : key;
    }

    public static string CurrentLanguage => _currentLanguage;
}
