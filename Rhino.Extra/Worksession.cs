
using Rhino.Extra.Interop;

namespace Rhino.Extra
{
  /// <summary>
  /// Class represents a Rhino Worksession
  /// </summary>
  public static class Worksession
  {
    /// <summary>
    /// Returns the runtime serial numbers of the active worksessions.
    /// </summary>
    /// <returns>The runtime serial numbers of the active worksessions.</returns>
    public static uint[] SerialNumbers()
    {
      using (var array = new OnUintArray())
      {
        var ptr_array = array.NonConstPointer();
        var rc = UnsafeNativeMethods.CRhinoWorkSession_WorksessionSerialNumbers(ptr_array);
        return rc == 0 ? new uint[0] : array.ToArray();
      }
    }

    /// <summary>
    /// Returns the path to the open worksession .rws file. 
    /// If null is returned, then either there is no worksession .rws file open,
    /// or the active worksession has not yet been saved.
    /// </summary>
    /// <param name="serialno">The worksession's runtime serial number.</param>
    /// <returns>The path to the open worksession .rws file if successful, null otherwise.</returns>
    public static string FileName(uint serialno)
    {
      using (var holder = new OnString())
      {
        var ptr_holder = holder.NonConstPointer();
        var rc = UnsafeNativeMethods.CRhinoWorkSession_FileName(serialno, ptr_holder);
        return rc ? holder.ToString() : null;
      }
    }

    /// <summary>
    /// Returns the number of models in the worksession,
    /// including the active model which might not be saved.
    /// </summary>
    /// <param name="serialno">The worksession's runtime serial number.</param>
    /// <returns>The number of models in the worksession.</returns>
    public static int ModelCount(uint serialno)
    {
      var rc = UnsafeNativeMethods.CRhinoWorkSession_ModelCount(serialno);
      return rc;
    }

    /// <summary>
    /// Returns the paths to the models used by the worksession.
    /// </summary>
    /// <param name="serialno">The worksession's runtime serial number.</param>
    /// <returns>The paths to the models.</returns>
    public static string[] ModelNames(uint serialno)
    {
      using (var array = new OnStringArray())
      {
        var ptr_array = array.NonConstPointer();
        var rc = UnsafeNativeMethods.CRhinoWorkSession_ModelNames(serialno, ptr_array);
        return rc > 0 ? array.ToArray() : new string[0];
      }
    }

    /// <summary>
    /// Returns the aliases of the models used by the worksession,
    /// including the active model which might not be saved.
    /// </summary>
    /// <param name="serialno">The worksession's runtime serial number.</param>
    /// <returns>The aliases of the models.</returns>
    public static string[] ModelAliases(uint serialno)
    {
      using (var array = new OnStringArray())
      {
        var ptr_array = array.NonConstPointer();
        var rc = UnsafeNativeMethods.CRhinoWorkSession_ModelAliases(serialno, ptr_array);
        return rc > 0 ? array.ToArray() : new string[0];
      }
    }
  }
}
