namespace _7D2D_ServerLauncher.Interfaces;

/// <summary>
///    $SUMMARY$
/// </summary>
public interface IControlData
{
   Dictionary<string, string> GetMembers { get; }

   void SetMembers(Dictionary<string, string> properties);
}