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
    public partial class BrowserTool : Form
    {
        public Browser CurrentBrowserData { get; set; }

        public BrowserTool()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
            CurrentBrowserData = new Browser();
            CurrentBrowserData.StartURL = textBox1.Text;
        }


        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            label2.Text = textBox1.Text + " Loaded.";
        }

        void Document_Click(object sender, HtmlElementEventArgs e)
        {
            // Assign the selected object to property grid
            var selectedObject = ((HtmlDocument)sender).ActiveElement;
            Console.WriteLine("The mouse clicked position is " + e.ClientMousePosition);
            Console.WriteLine("The mouse has " + e.ToElement);
            Console.WriteLine("The mouse has " + e.FromElement);

            HtmlElement selectedElement = null;
                // = ((HtmlDocument)sender).GetElementFromPoint(e.ClientMousePosition);
            if (webBrowser1.Document != null)
            {
                selectedElement = webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition);
                Console.WriteLine("The document is " + webBrowser1.Document);
                Console.WriteLine("The element is " + selectedElement.GetAttribute("id"));
                Console.WriteLine("The element is " + selectedElement.TagName);
                Console.WriteLine("The element is " + selectedElement.GetType());
                if (selectedElement.TagName == "DIV")
                {
                    selectedElement = selectedElement.OffsetParent;
                    Console.WriteLine("The element is " + selectedElement.GetAttribute("id"));
                    Console.WriteLine("The element is " + selectedElement.TagName);
                    Console.WriteLine("The element is " + selectedElement.GetType());
                }  
                Console.WriteLine("The element is " + selectedElement.ToString());
                Console.WriteLine("The element is " + selectedElement.Parent);
                Console.WriteLine("The element is " + selectedElement.OffsetParent);
                Console.WriteLine("The element is " + selectedElement.Name);
                Console.WriteLine("The element is " + selectedElement.ClientRectangle);
                selectedElement.ScrollIntoView(true);
            }

            //Add the action after spying the element and create Action with the action type
            //CurrentBrowserData.BrowserActions.Add(new ControlAction(selectedObject));
            SelectActionForm actionForm = new SelectActionForm(this.CurrentBrowserData, selectedElement);
            actionForm.ShowDialog();
            webBrowser1.Document.Click -= this.Document_Click;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // add a handler for Click event
            webBrowser1.Document.Click += new HtmlElementEventHandler(this.Document_Click);
            //webBrowser1.Document.Focusing += new HtmlElementEventHandler(this.Document_Click);
            //webBrowser1.Document.MouseDown += new HtmlElementEventHandler(this.Document_Click);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("The URL is " + this.CurrentBrowserData.StartURL);
            Console.WriteLine("The Action is " + this.CurrentBrowserData.BrowserActions);
            WriteScript wscr = new WriteScript(this.CurrentBrowserData.StartURL, this.CurrentBrowserData.BrowserActions);
            wscr.ToScript();
        }

        private void BrowserTool_Load(object sender, EventArgs e)
        {

        }
    }
}
