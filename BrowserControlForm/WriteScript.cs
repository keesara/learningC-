using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using TestingRecorder;

namespace BrowserControlForm
{
    
    class WriteScript
    {
        public string BASEURL { get; set; }
        public List<ControlAction> ScriptActions { get; set; }

        static string[] scriptImportLines = { "import java.util.concurrent.TimeUnit;",
                           "import org.openqa.selenium.*;",
                           //"import org.openqa.selenium.firefox.FirefoxDriver;" ,
                           "import org.openqa.selenium.chrome.ChromeDriver;"};

        static string scriptClassDeclaration = "public class ";
        static string braceOpen = "{";
        static string braceClose = "}";
        static string scriptClassName = "Script" + GetTimestamp(DateTime.Now);
        static string scriptFileName = scriptClassName + ".java";
        static string scriptFilePath = "D:\\" + scriptFileName;
        static string mainFunc = "public static void main(String[] args)";

        //static string driverInit = "WebDriver driver = new FirefoxDriver();";
        static string driverInit = "WebDriver driver = new ChromeDriver();";
        static string browserLoadWait = "driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);";
        static string navigateTo = "driver.navigate().to(";
        static string windowMax = "driver.manage().window().maximize();";
        static string findElementByXpath = "driver.findElement(By.xpath(\".//*[@id = ";
        static string findElementById = "driver.findElement(By.id(";
        static string clickElement = "]\")).click();";
        static string sendkeys = ").sendKeys(\" \");";
        static string driverclose = "driver.close();";

        public WriteScript(string url, List<ControlAction> actions)
        {
            this.BASEURL = url;
            this.ScriptActions = actions;
        }

        public void ToScript()
        {
            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(@scriptFilePath, scriptImportLines);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@scriptFilePath, true))
            {
                file.WriteLine(scriptClassDeclaration + " " + scriptClassName + " " + braceOpen);
                file.WriteLine(mainFunc + " " + braceOpen);
                file.WriteLine(driverInit);
                file.WriteLine(browserLoadWait);
                file.WriteLine(navigateTo + "\"" + "http://" + this.BASEURL + "\"" + ");");
                foreach (ControlAction action in ScriptActions)
                {
                    HtmlElement elem = action.SelectedElement;
                    string id = elem.Id;
                    if (action.ActionType == ControlActionTypes.Click)
                    {
                        file.Write(findElementByXpath);
                        file.Write("'" + id + "'");
                        file.WriteLine(clickElement);
                    }
                    if (action.ActionType == ControlActionTypes.Activate)
                    {
                        file.Write(findElementById);
                        file.Write("'" + id + "'");
                        file.WriteLine(sendkeys);
                    }
                }
                
                file.WriteLine(windowMax);
                file.WriteLine(driverclose);
                file.WriteLine(braceClose);
                file.WriteLine(braceClose);
            }
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}
