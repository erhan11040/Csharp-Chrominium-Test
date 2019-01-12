using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
namespace BrowserHack
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [PermissionSetAttribute(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromeBrowser;
       

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            

            try
            {
               /* browser.Document.GetElementById("btnClear").InvokeMember("click");
                browser.Document.GetElementById("btn").InvokeMember("click");
                string sonuc=browser.Document.GetElementById("speech").InnerHtml;
                lbl.Text = sonuc;*/
            }
            catch (Exception ex)
            {
                string exmes = ex.Message;
            }
            
        }

        private void btn_click(object sender, EventArgs e)
        {
            /*browser.Document.GetElementById("btn").InvokeMember("click");
            string sonuc = browser.Document.GetElementById("speech").InnerHtml;*/
        }

        

        public Form1()
        {
            InitializeComponent();
            // Start the browser after initialize global component
            InitializeChromium();
            // Register an object in javascript named "cefCustomObject" with function of the CefCustomObject class :3
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chromeBrowser.ShowDevTools();
            

        }

        public void InitializeChromium()
        {
            

            // Note that if you get an error or a white screen, you may be doing something wrong !
            // Try to load a local file that you're sure that exists and give the complete path instead to test
            // for example, replace page with a direct path instead :
            // String page = @"C:\Users\SDkCarlos\Desktop\afolder\index.html";

            //String page = @"C:\Users\SDkCarlos\Desktop\artyom-HOMEPAGE\index.html";


            // Initialize cef with the provided settings
            CefSettings settings = new CefSettings();

            // Initialize cef with a command line argument
            // In this case the enable-media-stream flag that allows you to access the camera and the microphone
            settings.CefCommandLineArgs.Add("enable-media-stream", "1");
            settings.CefCommandLineArgs.Add("allow-running-insecure-content", "1");
            settings.CefCommandLineArgs.Add("use-fake-ui-for-media-stream", "1");
            settings.CefCommandLineArgs.Add("enable-usermedia-screen-capture", "1");
            Cef.Initialize(settings);
            // Create a browser component      q
            chromeBrowser = new ChromiumWebBrowser("https://www.google.com");

            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;

            // Allow the use of local resources in the browser
            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrls = CefState.Enabled;
            browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            chromeBrowser.BrowserSettings = browserSettings;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
