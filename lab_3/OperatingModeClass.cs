using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lab_3
{
  /// <summary>
  /// Class for listing operating modes of forms
  /// </summary>
  public class OperatingModeClass
  {
    /// <summary>
    /// Enumeration of form operating modes
    /// </summary>
    public enum OperatingMode
    {
      /// <summary>
      /// Mode of operation of the form for creating a lock object
      /// </summary>
      Add,
      /// <summary>
      /// Mode of operation of the form for changing the lock object
      /// </summary>
      Update,
      /// <summary>
      /// Form operation mode for deleting a lock object
      /// </summary>
      Delete
    }

    /// <summary>
    /// Method for returning the form's operating mode in Russian
    /// </summary>
    /// <param name="parMode">Form operating mode</param>
    /// <returns>Name of the form's operating mode in Russian</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string GetName(OperatingMode parMode)
    {
      switch (parMode)
      {
        case OperatingMode.Add:
          return "Добавить";
        case OperatingMode.Update:
          return "Изменить";
        case OperatingMode.Delete:
          return "Удалить";
        default:
          return null;
      }
    }
  }
}
