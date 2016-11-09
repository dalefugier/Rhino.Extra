using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Geometry;
using Rhino.Input.Custom;

namespace TestRhinoExtra
{
  [System.Runtime.InteropServices.Guid("f9b742e1-697d-46ab-9ed7-72524f337b78")]
  public class TestMergeSurfaceCommand : Command
  {
    public override string EnglishName
    {
      get { return "TestMergeSurface"; }
    }

    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
      var go = new GetObject();
	    go.SetCommandPrompt("Select a pair of surfaces to merge");
      go.GeometryFilter = ObjectType.Surface;
	    go.SubObjectSelect = false;
      go.GetMultiple(2, 2);
      if (go.CommandResult() != Result.Success)
        return go.CommandResult();

      var brep0 = go.Object(0).Brep();
      var brep1 = go.Object(1).Brep();
      if (null == brep0 || null == brep1)
        return Result.Failure;

      var point0 = Point2d.Unset;
      var point1 = Point2d.Unset;

      double u0, u1, v0, v1;
      var srf0 = go.Object(0).SurfaceParameter(out u0, out v0);
      var srf1 = go.Object(1).SurfaceParameter(out u1, out v1);
      if (null != srf0 && null != srf1)
      {
        point0.X = u0;
        point0.Y = v0;
        point1.X = u1;
        point1.Y = v1;
      }

      var merged = Rhino.Extra.Geometry.MergeSurfaces(brep0, brep1, point0, point1, 1.0, true, RhinoMath.UnsetValue);
      if (null == merged)
      {
        RhinoApp.WriteLine("Unable to merge surfaces.");
        return Result.Failure;
      }

      if (doc.Objects.Replace(go.Object(0), merged))
      {
        doc.Objects.Delete(go.Object(1), true);
        doc.Views.Redraw();
      }

      return Result.Success;
    }
  }
}
