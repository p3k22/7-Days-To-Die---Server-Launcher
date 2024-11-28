namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Models;

using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

public abstract class BaseViewModel : INotifyPropertyChanged
{
   private readonly PropertyRegistry<object> _registry = new();

   public event PropertyChangedEventHandler? PropertyChanged;

   /// <summary>
   ///    Gets all registered properties and their values as a dictionary.
   /// </summary>
   /// <returns>A dictionary of property names and values.</returns>
   public Dictionary<string, string> GetMembers()
   {
      return _registry.GetAllProperties(this);
   }

   /// <summary>
   ///    Sets the values of registered properties from a dictionary.
   /// </summary>
   /// <param name="properties">A dictionary of property names and values.</param>
   public void SetMembers(Dictionary<string, string> properties)
   {
      _registry.SetAllProperties(this, properties);
   }

   /// <summary>
   ///    Raises the PropertyChanged event for a given property.
   /// </summary>
   /// <param name="propertyName">The name of the property that changed.</param>
   protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
   {
      PropertyChanged?.Invoke(this, new(propertyName));
   }

   /// <summary>
   ///    Registers a collection of properties for binding and mapping.
   /// </summary>
   /// <param name="properties">The properties to register.</param>
   protected void RegisterProperties(IEnumerable<PropertyInfo> properties)
   {
      foreach (var property in properties)
      {
         // Ensure the property is of type string, readable, and writable
         if (property.PropertyType != typeof(string) || !property.CanRead || !property.CanWrite)
         {
            continue;
         }

         _registry.RegisterProperty(
         property.Name,
         instance => (string) property.GetValue(instance)!,
         (instance, value) => property.SetValue(instance, value));
         Debug.WriteLine($"Registering:{property.Name} = {property.GetValue(this)}");
      }
   }
}