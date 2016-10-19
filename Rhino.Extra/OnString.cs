using System;
using System.Runtime.InteropServices;

namespace Rhino.Extra
{
  /// <summary>
  /// Internal class used to help marshall openNURBS string class.
  /// </summary>
  internal class OnString : IDisposable
  {
    private IntPtr m_ptr; // CStringHolder*

    public IntPtr ConstPointer() { return m_ptr; }

    public IntPtr NonConstPointer() { return m_ptr; }

    public OnString()
    {
      m_ptr = UnsafeNativeMethods.StringHolder_New();
    }

    ~OnString()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (IntPtr.Zero != m_ptr)
      {
        UnsafeNativeMethods.StringHolder_Delete(m_ptr);
        m_ptr = IntPtr.Zero;
      }
    }

    public override string ToString()
    {
      return GetString(m_ptr);
    }

    public static string GetString(IntPtr ptrHolder)
    {
      var ptr_string = UnsafeNativeMethods.StringHolder_Get(ptrHolder);
      var rc = Marshal.PtrToStringUni(ptr_string);
      return rc ?? string.Empty;
    }
  }
}
