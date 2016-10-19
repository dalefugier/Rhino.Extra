using System;

namespace Rhino.Extra
{
  /// <summary>
  /// Internal class used to help marshall openNURBS array class.
  /// </summary>
  internal class OnUintArray : IDisposable
  {
    private IntPtr m_ptr; // ON_SimpleArray<unsigned int>*

    public IntPtr ConstPointer() { return m_ptr; }

    public IntPtr NonConstPointer() { return m_ptr; }

    public OnUintArray()
    {
      m_ptr = UnsafeNativeMethods.ArrayUint_New();
    }

    public int Count
    {
      get { return UnsafeNativeMethods.ArrayUint_Count(m_ptr); }
    }

    private uint UnsignedCount
    {
      get { return UnsafeNativeMethods.ArrayUint_UnsignedCount(m_ptr); }
    }

    public uint[] ToArray()
    {
      var count = UnsignedCount;
      if (count < 1)
        return new uint[0];
      var rc = new uint[count];
      UnsafeNativeMethods.ArrayUint_CopyValues(m_ptr, rc);
      return rc;
    }

    ~OnUintArray()
    {
      InternalDispose();
    }

    public void Dispose()
    {
      InternalDispose();
      GC.SuppressFinalize(this);
    }

    private void InternalDispose()
    {
      if (IntPtr.Zero != m_ptr)
      {
        UnsafeNativeMethods.ArrayUint_Delete(m_ptr);
        m_ptr = IntPtr.Zero;
      }
    }

  }
}
