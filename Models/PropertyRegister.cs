namespace _7D2D_ServerLauncher.Models;

public class PropertyRegistry<T>
{
   private readonly Dictionary<string, Action<T, string>> _setters = new Dictionary<string, Action<T, string>>();

   private readonly Dictionary<string, Func<T, string>> _getters = new Dictionary<string, Func<T, string>>();

   /// <summary>
   ///    Gets the value of all registered properties for a given instance.
   /// </summary>
   /// <param name="instance">The instance to retrieve property values from.</param>
   /// <returns>A dictionary of property names and values.</returns>
   public Dictionary<string, string> GetAllProperties(T instance)
   {
      return _getters.ToDictionary(entry => entry.Key, entry => entry.Value(instance));
   }

   /// <summary>
   ///    Registers a property with a getter and setter.
   /// </summary>
   /// <param name="propertyName">The name of the property.</param>
   /// <param name="getter">A function to retrieve the property's value.</param>
   /// <param name="setter">An action to set the property's value.</param>
   public void RegisterProperty(string propertyName, Func<T, string> getter, Action<T, string> setter)
   {
      _getters[propertyName] = getter;
      _setters[propertyName] = setter;
   }

   /// <summary>
   ///    Sets the values of registered properties for a given instance.
   /// </summary>
   /// <param name="instance">The instance to set property values on.</param>
   /// <param name="properties">A dictionary of property names and values to set.</param>
   public void SetAllProperties(T instance, Dictionary<string, string> properties)
   {
      foreach (var property in properties)
      {
         if (_setters.TryGetValue(property.Key, out var setter))
         {
            setter(instance, property.Value);
         }
      }
   }
}