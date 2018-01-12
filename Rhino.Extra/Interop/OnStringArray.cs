using System;

namespace Rhino.Extra.Interop
{
  /// <summary>
  /// Internal class used to help marshall openNURBS array class.
  /// </summary>
  internal class OnStringArray : IDisposable
  {
    private IntPtr m_ptr; // ON_ClassArray<ON_wString>*

    public IntPtr ConstPointer() { return m_ptr; }

    public IntPtr NonConstPointer() { return m_ptr; }

    public OnStringArray()
    {
      m_ptr = UnsafeNativeMethods.ArrayString_New();
    }

    public int Count
    {
      get
      {
        return UnsafeNativeMethods.ArrayString_Count(m_ptr);
      }
    }

    ~OnStringArray()
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
        UnsafeNativeMethods.ArrayString_Delete(m_ptr);
        m_ptr = IntPtr.Zero;
      }
    }

    public string[] ToArray()
    {
      var count = Count;
      if (count < 1)
        return new string[0]; // MSDN guidelines prefer empty arrays

      var rc = new string[count];
      using (var holder = new OnString())
      {
        var ptr_holder = holder.NonConstPointer();
        for (var i = 0; i < count; i++)
        {
          UnsafeNativeMethods.ArrayString_Get(m_ptr, i, ptr_holder);
          rc[i] = holder.ToString();
        }
      }
      return rc;
    }
  }
}
