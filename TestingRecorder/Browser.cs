using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
