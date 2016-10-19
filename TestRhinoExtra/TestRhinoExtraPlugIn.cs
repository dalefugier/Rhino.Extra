namespace TestRhinoExtra
{
  public class TestRhinoExtraPlugIn : Rhino.PlugIns.PlugIn
  {
    public TestRhinoExtraPlugIn()
    {
      Instance = this;
    }

    /// <summary>
    /// Gets the only instance of the TestRhinoExtraPlugIn plug-in.
    /// </summary>
    public static TestRhinoExtraPlugIn Instance
    {
      get;
      private set;
    }

    // You can override methods here to change the plug-in behavior on
    // loading and shut down, add options pages to the Rhino _Option command
    // and mantain plug-in wide options in a document.
  }
}