using System.Windows.Forms;

namespace TestingRecorder
{
    public enum ControlActionTypes
    {
        Activate=0,
        Click=1,
        ClickMiddle=2,
        ClickRight=3,
        Close=4,
        DoubleClick=5,
        DoubleClickMiddle=6,
        DoubleClickRight=7
    }

    /// <summary>
    /// This class is an instance of the action performed by a user on Browser.
    /// </summary>
    public class ControlAction
    {

        public ControlActionTypes ActionType { get; set; }


    public ControlAction(HtmlElement element)
    {
        this.SelectedElement = element;
    }
        public HtmlElement SelectedElement {get; set; }

    }
}