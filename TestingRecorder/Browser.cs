using System.Collections.Generic;

namespace TestingRecorder
{
    /// <summary>
    /// This class is an instance of a browser. It will hold everything a user does from start to end.
    /// </summary>
    public class Browser
    {
        public string StartURL { get; set; }
        public List<ControlAction> BrowserActions { get; set; }

        public Browser()
        {
            this.BrowserActions = new List<ControlAction>();
        }
    }
}
