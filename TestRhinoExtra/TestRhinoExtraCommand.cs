using Rhino;
using Rhino.Commands;

namespace TestRhinoExtra
{
  [System.Runtime.InteropServices.Guid("bf52fcd0-fb23-4d28-b892-60b298b71998")]
  public class TestRhinoExtraCommand : Command
  {
    public override string EnglishName
    {
      get { return "TestRhinoExtra"; }
    }

    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
      RhinoApp.WriteLine("{0} plug-in loaded.", TestRhinoExtraPlugIn.Instance.Name);
      return Result.Success;
    }
  }
}
