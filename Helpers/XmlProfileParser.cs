namespace _7D2D_ServerLauncher.Helpers;

using System.IO;
using System.Xml.Linq;

public static class XmlProfileParser
{
   /// <summary>
   ///    Reads all the properties within a given XML file
   /// </summary>
   /// <param name="profilePath">Location to load the profile</param>
   /// <returns>Dictionary of Property Names and Values</returns>
   public static Dictionary<string, string> LoadPropertiesFromFile(string profilePath)
   {
      var propertiesDictionary = new Dictionary<string, string>();
      try
      {
         var file = File.ReadAllText(profilePath);
         var xmlDoc = XDocument.Parse(file);

         foreach (var property in xmlDoc.Descendants("property"))
         {
            var name = property.Attribute("name")?.Value;
            var value = property.Attribute("value")?.Value;

            if (name != null && value != null)
            {
               propertiesDictionary[name] = value;
            }
         }
      }
      catch (Exception ex)
      {
         Console.WriteLine($"Error parsing XML: {ex.Message}");
      }

      return propertiesDictionary;
   }

   /// <summary>
   ///    Writes all the properties within the register to disk.
   /// </summary>
   /// <param name="profilePath">Location to save profile</param>
   public static async Task SavePropertiesToFile(string profilePath, Dictionary<string, string> properties)
   {
      await using var writer = new StreamWriter(profilePath, false);
      await writer.WriteAsync("<?xml version=\"1.0\"?>\r\n<ServerSettings>\n");
      foreach (var kvp in properties)
      {
         if (kvp.Key == "UserDataFolder" && (string.IsNullOrEmpty(kvp.Value) || string.IsNullOrWhiteSpace(kvp.Value)))
         {
            continue;
         }

         await writer.WriteLineAsync($"<property name=\"{kvp.Key}\"\t value=\"{kvp.Value}\"/>\n");
      }

      await writer.WriteAsync("</ServerSettings>");
   }
}