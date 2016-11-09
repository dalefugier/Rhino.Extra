using Rhino.Geometry;
using Rhino.Runtime;

namespace Rhino.Extra
{
  /// <summary>
  /// Utility geometry functions
  /// </summary>
  public static class Geometry
  {
    /// <summary>
    /// Merges two surfaces into one surface at untrimmed edges.
    /// </summary>
    /// <param name="surface0">The first surface to merge.</param>
    /// <param name="surface1">The second surface to merge.</param>
    /// <returns>The merged surfaces as a Brep if successful, null if not successful.</returns>
    public static Brep MergeSurfaces(Surface surface0, Surface surface1)
    {
      if (null == surface0 || null == surface1)
        return null;

      var brep0 = Brep.CreateFromSurface(surface0);
      var brep1 = Brep.CreateFromSurface(surface1);
      if (null == brep0 || null == brep1)
        return null;

      return MergeSurfaces(brep0, brep1, Point2d.Unset, Point2d.Unset, 1.0, true, RhinoMath.UnsetValue);
    }

    /// <summary>
    /// Merges two surfaces into one surface at untrimmed edges.
    /// Both surfaces must be untrimmed and share an edge.
    /// </summary>
    /// <param name="brep0">The first single-face Brep to merge.</param>
    /// <param name="brep1">The second single-face Brep to merge.</param>
    /// <returns>The merged Brep if successful, null if not successful.</returns>
    public static Brep MergeSurfaces(Brep brep0, Brep brep1)
    {
      if (null == brep0 || null == brep1)
        return null;

      return MergeSurfaces(brep0, brep1, Point2d.Unset, Point2d.Unset, 1.0, true, RhinoMath.UnsetValue);
    }

    /// <summary>
    /// Merges two surfaces into one surface at untrimmed edges.
    /// Both surfaces must be untrimmed and share an edge.
    /// </summary>
    /// <param name="brep0">The first single-face Brep to merge.</param>
    /// <param name="brep1">The second single-face Brep to merge.</param>
    /// <param name="point0">2D pick point on the first single-face Brep. The value can be unset.</param>
    /// <param name="point1">2D pick point on the second single-face Brep. The value can be unset.</param>
    /// <param name="roundness">Defines the roundness of the merge. Acceptable values are between 0.0 (sharp) and 1.0 (smooth, default).</param>
    /// <param name="smooth">The surface will be smooth. This makes the surface behave better for control point editing, but may alter the shape of both surfaces.</param>
    /// <param name="tolerance">Surface edges must be within this tolerance for the two surfaces to merge. The value can be unset.</param>
    /// <returns>The merged Brep if successful, null if not successful.</returns>
    public static Brep MergeSurfaces(Brep brep0, Brep brep1, Point2d point0, Point2d point1, double roundness, bool smooth, double tolerance)
    {
      if (null == brep0 || null == brep1)
        return null;

      var const_ptr_brep0 = Interop.NativeGeometryConstPointer(brep0);
      var const_ptr_brep1 = Interop.NativeGeometryConstPointer(brep1);

      var ptr_brep = UnsafeNativeMethods.RHC_RhinoMergeSrf(const_ptr_brep0, const_ptr_brep1, point0, point1, roundness, smooth, tolerance);
      return Interop.CreateFromNativePointer(ptr_brep) as Brep;
    }

  }
}
