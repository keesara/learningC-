using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingRecorder;

namespace BrowserControlForm
{
    public partial class SelectActionForm : Form
    {
        private TestingRecorder.Browser BrowserValue{get;set;}
        private HtmlElement selElement { get; set; }
        public SelectActionForm(TestingRecorder.Browser browser, HtmlElement selectedObject)
        {
            this.BrowserValue = browser;
            this.selElement = selectedObject;
            
            InitializeComponent();
        }

        public SelectActionForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                TestingRecorder.ControlAction action = new TestingRecorder.ControlAction(selElement);
                action.ActionType = (TestingRecorder.ControlActionTypes) Enum.ToObject(typeof(TestingRecorder.ControlActionTypes), comboBox1.SelectedIndex);
                Console.WriteLine("Action is " + action);
                Console.WriteLine("Action type is " + action.ActionType);
                BrowserValue.BrowserActions.Add(action);
                Console.WriteLine("The selectedObject is " + selElement.Id);
                Console.WriteLine("The selectedObject is " + selElement.InnerText);
                Console.WriteLine("The selectedObject is " + selElement.Name);
                Console.WriteLine("The selectedObject is " + selElement.DomElement.ToString());
                this.Close();
            } else
            {
                MessageBox.Show("Please Select a value in Combo Box");
            }

        }
    }
}
