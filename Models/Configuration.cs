namespace _7D2D_ServerLauncher;

using System.IO;

public static class Configuration
{
   private static readonly Dictionary<string, string> Configurations;

   static Configuration()
   {
      Configurations = new Dictionary<string, string>();

      LoadConfigurations();
   }

   private static string ConfigFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "7d2dsl.config");

   /// <summary>
   ///    Retrieve a value by name
   /// </summary>
   /// <param name="name"></param>
   /// <returns></returns>
   public static string GetValue(string name)
   {
      return Configurations.TryGetValue(name, out var value) ? value : string.Empty;
   }

   /// <summary>
   ///    Set or update a value by name
   /// </summary>
   /// <param name="name"></param>
   /// <param name="value"></param>
   public static void SetValue(string name, string value)
   {
      Configurations[name] = value;
      SaveConfigurations();
   }

   /// <summary>
   ///    Load configurations from the file
   /// </summary>
   private static void LoadConfigurations()
   {
      if (!File.Exists(ConfigFilePath))
      {
         return;
      }

      foreach (var line in File.ReadAllLines(ConfigFilePath))
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
            Configurations[name] = value;
         }
      }
   }

   /// <summary>
   ///    Save configurations to the file
   /// </summary>
   private static void SaveConfigurations()
   {
      using var writer = new StreamWriter(ConfigFilePath);
      foreach (var entry in Configurations)
      {
         writer.WriteLine($"{entry.Key}={entry.Value}");
      }
   }
}