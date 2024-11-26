namespace _7D2D_ServerLauncher;

using System.IO;

public class ConfigManager
{
   private readonly Dictionary<string, string> _configurations;

   private readonly string _configFilePath;

   public ConfigManager(string configFilePath)
   {
      _configFilePath = configFilePath;
      _configurations = new Dictionary<string, string>();

      LoadConfigurations();
   }

   // Check if a key exists
   public bool ContainsKey(string name)
   {
      return _configurations.ContainsKey(name);
   }

   // Retrieve a value by name
   public string GetValue(string name)
   {
      return _configurations.TryGetValue(name, out var value) ? value : string.Empty;
   }

   // Set or update a value by name
   public void SetValue(string name, string value)
   {
      _configurations[name] = value;
      SaveConfigurations();
   }

   // Load configurations from the file
   private void LoadConfigurations()
   {
      if (!File.Exists(_configFilePath))
      {
         return;
      }

      foreach (var line in File.ReadAllLines(_configFilePath))
      {
         var trimmedLine = line.Trim();
         if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith("#"))
         {
            continue; // Skip empty lines or comments
         }

         var keyValue = trimmedLine.Split('=');
         if (keyValue.Length == 2)
         {
            var name = keyValue[0].Trim();
            var value = keyValue[1].Trim();
            _configurations[name] = value;
         }
      }
   }

   // Save configurations to the file
   private void SaveConfigurations()
   {
      using var writer = new StreamWriter(_configFilePath);
      foreach (var entry in _configurations)
      {
         writer.WriteLine($"{entry.Key}={entry.Value}");
      }
   }

   public static void WritePropertiesToFile(string filePath, Dictionary<string, string> properties)
   {
      using var writer = new StreamWriter(filePath, false);
      writer.Write("<?xml version=\"1.0\"?>\r\n<ServerSettings>\n");
      foreach (var kvp in properties)
      {
         writer.WriteLine($"<property name=\"{kvp.Key}\"\t value=\"{kvp.Value}\"/>\n");
      }

      writer.Write("</ServerSettings>");
   }
}