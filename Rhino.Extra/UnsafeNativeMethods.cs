using System;
using System.Runtime.InteropServices;
using Rhino.Geometry;

namespace Rhino.Extra
{
  internal class UnsafeNativeMethods
  {
    // OnString interface

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr StringHolder_New();

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void StringHolder_Delete(IntPtr ptrHolder);

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr StringHolder_Get(IntPtr ptrHolder);
    
    // OnStringArray interface

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr ArrayString_New();

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void ArrayString_Delete(IntPtr ptrStrings);

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int ArrayString_Count(IntPtr ptrStrings);

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void ArrayString_Get(IntPtr ptrStrings, int index, IntPtr ptrHolder);

    // OnUintArray interface

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr ArrayUint_New();

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void ArrayUint_Delete(IntPtr p);

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int ArrayUint_Count(IntPtr ptr);

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern uint ArrayUint_UnsignedCount(IntPtr ptr);

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void ArrayUint_CopyValues(IntPtr ptr, [In, Out] uint[] vals);

    // Worksession interface

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int CRhinoWorkSession_WorksessionSerialNumbers(IntPtr ptrArray);

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern bool CRhinoWorkSession_FileName(uint serialno, IntPtr ptrHolder);

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int CRhinoWorkSession_ModelCount(uint serialno);

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int CRhinoWorkSession_ModelNames(uint serialno, IntPtr ptrStrings);

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int CRhinoWorkSession_ModelAliases(uint serialno, IntPtr ptrStrings);

    // Geometry interface

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr RHC_RhinoMergeSrf(IntPtr pConstBrep0, IntPtr pConstBrep1, Point2d pickPoint0, Point2d pickPoint1, double roundness, [MarshalAs(UnmanagedType.U1)]bool smooth, double tolerance);

    [DllImport("RhinoExtraLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RHC_RhinoRepairBrep(IntPtr pBrep, double tolerance);
  }
}
