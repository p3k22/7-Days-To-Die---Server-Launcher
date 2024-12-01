namespace _7D2D_ServerLauncher.ViewModels;

using _7D2D_ServerLauncher.Models;

using System.ComponentModel;
using System.Reflection;

public abstract class ViewModelBase : INotifyPropertyChanged
{
   protected ViewModelBase()
   {
      PropertyRegistry.PropertyChanged += OnRegistryPropertyChanged;
      var properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
      RegisterProperties(properties);
   }

   public event PropertyChangedEventHandler? PropertyChanged;

   protected virtual void OnPropertyChanged(string propertyName)
   {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
   }

   /// <summary>
   ///    Updates the property value and notifies both the UI and PropertyRegistry
   /// </summary>
   /// <param name="name"></param>
   /// <param name="value"></param>
   protected void SetProperty(string name, string value)
   {
      var propertyInfo = GetType().GetProperty(name);
      if (propertyInfo != null)
      {
         propertyInfo.SetValue(this, value);
         OnPropertyChanged(name);
         PropertyRegistry.SetProperty(name, value);
      }
   }

   /// <summary>
   ///    Called when any property changes in the PropertyRegistry
   /// </summary>
   /// <param name="name"></param>
   /// <param name="value"></param>
   private void OnRegistryPropertyChanged(string name, string value)
   {
      var propertyInfo = GetType().GetProperty(name);
      if (propertyInfo != null)
      {
         var currentValue = propertyInfo.GetValue(this) as string;
         if (currentValue != value)
         {
            propertyInfo.SetValue(this, value);
            OnPropertyChanged(name);
         }
      }
   }

   /// <summary>
   ///    Registers a collection of properties for binding and mapping.
   /// </summary>
   /// <param name="properties">The properties to register.</param>
   private void RegisterProperties(IEnumerable<PropertyInfo> properties)
   {
      foreach (var property in properties)
      {
         // Ensure the property is of type string, readable, and writable
         if (property.PropertyType != typeof(string) || !property.CanRead || !property.CanWrite)
         {
            continue;
         }

         SetProperty(property.Name, (string) property.GetValue(this)!);
      }
   }
}