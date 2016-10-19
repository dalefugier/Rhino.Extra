using Rhino;
using Rhino.Commands;
using Rhino.Extra;

namespace TestRhinoExtra
{
  [System.Runtime.InteropServices.Guid("441978bd-1c8c-4b9b-9085-5a52c50af20b")]
  public class TestWorksessionCommand : Command
  {
    public override string EnglishName
    {
      get { return "TestWorksession"; }
    }

    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
      var serial_nos = Worksession.SerialNumbers();
      if (0 == serial_nos.Length)
        return Result.Nothing;

      foreach (var sn in serial_nos)
      {
        RhinoApp.WriteLine("Worksession serial number = {0}", sn);

        var filename = Worksession.FileName(sn);
        RhinoApp.WriteLine("Filename = {0}", filename);

        var model_count = Worksession.ModelCount(sn);
        RhinoApp.WriteLine("Model count = {0}", model_count);

        var model_names = Worksession.ModelNames(sn);
        var count = 1;
        foreach (var name in model_names)
          RhinoApp.WriteLine("Model {0} = {1}", count++, name);
      }

      return Result.Success;
    }
  }
}
