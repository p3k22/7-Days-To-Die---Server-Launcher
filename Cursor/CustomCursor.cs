namespace _7D2D_ServerLauncher.Cursor;

using System.Windows;
using System.Windows.Input;

public static class CustomCursor
{
   public static void SetCursor(Window win)
   {
      var customCursorStream = Application.GetResourceStream(new Uri("pack://application:,,,/Cursor/cursor.cur"))
         ?.Stream;

      if (customCursorStream != null)
      {
         var customCursor = new Cursor(customCursorStream);
         win.Cursor = customCursor;
      }
   }
}