using CefSharp.WinForms;
using CefSharp;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Management;
using System.Linq;

namespace StaffManagers
{
    public static class ProcessExtensions
    {
        public static IList<Process> GetChildProcesses(this Process process)
            => new ManagementObjectSearcher(
                    $"Select * From Win32_Process Where ParentProcessID={process.Id}")
                .Get()
                .Cast<ManagementObject>()
                .Select(mo =>
                    Process.GetProcessById(Convert.ToInt32(mo["ProcessID"])))
                .ToList();
    }

    public partial class HelpBrowser : UserControl
    {
        private ChromiumWebBrowser browser;

        private string html_file;

        public string Html_file
        {
            get { return html_file; }
            set { html_file = value; }
        }

        public event EventHandler CloseBrowserClick;

        public HelpBrowser()
        {
            InitializeComponent();

            this.Load += HelpAddEmployee_Load;
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void HelpAddEmployee_Load(object sender, EventArgs e)
        {
            InitializeBrowser();

            Timer timer1 = new Timer();
            timer1.Interval = 1;
            timer1.Enabled = true;

            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (browser.CanGoBack)
            {
                btnBack.Enabled = true;
            }
            else
            {
                btnBack.Enabled = false;
            }

            if (browser.CanGoForward)
            {
                btnForward.Enabled = true;
            }
            else
            {
                btnForward.Enabled = false;
            }
        }

        private void InitializeBrowser()
        {
            string appFolder = AppDomain.CurrentDomain.BaseDirectory;
            string htmlFilePath = appFolder + "web_help\\" + Html_file; // Change "file.html" to the name of your HTML file

            CefSettings settings = new CefSettings();

            //settings.IgnoreCertificateErrors = true;
            settings.LogFile = appFolder + "Debug.log";
            settings.LogSeverity = LogSeverity.Verbose;

            if (!Cef.IsInitialized)
            {
                Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
            }

            browser = new ChromiumWebBrowser("file:///" + htmlFilePath);
            //browser = new ChromiumWebBrowser("https://webglsamples.org/aquarium/aquarium.html");
            browser.Dock = DockStyle.Fill;
            browser.Size = new Size(785, 405);

            browser.LoadingStateChanged += Browser_LoadingStateChanged;

            panel1.Controls.Add(browser);
        }

        private async void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading)
            {
                // If the browser is loading, increment the progress bar value
                progressLoading.Invoke(new Action(() => {
                    try
                    {
                        progressLoading.Value = progressLoading.Value + 25;
                    }
                    catch (Exception)
                    {
                        progressLoading.Value = 100;
                    }
                }));

                await Task.Delay(180);

                btnBack.Invoke(new Action(() =>
                {
                    btnBack.BackColor = ColorTranslator.FromHtml("#06B025");
                }));

                btnForward.Invoke(new Action(() =>
                {
                    btnForward.BackColor = ColorTranslator.FromHtml("#06B025");
                }));
            }
            else
            {
                // If the loading is complete, reset the progress bar value to 0
                progressLoading.Invoke(new Action(() => {
                    progressLoading.Value = 100;
                }));

                await Task.Delay(395);

                btnDevTool.Invoke(new Action(() =>
                {
                    btnDevTool.BackColor = ColorTranslator.FromHtml("#06B025");
                }));

                btnReload.Invoke(new Action(() =>
                {
                    btnReload.BackColor = ColorTranslator.FromHtml("#06B025");
                }));

                btnClose.Invoke(new Action(() =>
                {
                    btnClose.BackColor = ColorTranslator.FromHtml("#06B025");
                }));

                await Task.Delay(2000);

                progressLoading.Invoke(new Action(() => {
                    progressLoading.Value = 0;
                }));

                btnBack.Invoke(new Action(() =>
                {
                    btnBack.BackColor = ColorTranslator.FromHtml("#E6E6E6");
                }));

                btnForward.Invoke(new Action(() =>
                {
                    btnForward.BackColor = ColorTranslator.FromHtml("#E6E6E6");
                }));

                btnDevTool.Invoke(new Action(() =>
                {
                    btnDevTool.BackColor = ColorTranslator.FromHtml("#E6E6E6");
                }));

                btnReload.Invoke(new Action(() =>
                {
                    btnReload.BackColor = ColorTranslator.FromHtml("#E6E6E6");
                }));

                btnClose.Invoke(new Action(() =>
                {
                    btnClose.BackColor = ColorTranslator.FromHtml("#E6E6E6");
                }));
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            browser.Forward();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            browser.Back();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            browser.Reload();
        }

        protected virtual void OnCloseBrowserClick()
        {
            CloseBrowserClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnCloseBrowserClick();
        }

        private bool showDevTool;

        public bool ShowDevTool
        {
            get { return showDevTool; }
            set { showDevTool = value; }
        }

        private void btnDevTool_Click(object sender, EventArgs e)
        {
            if (!ShowDevTool)
            {
                ShowDevTool = true;

                browser.ShowDevTools();
            }
            else
            {
                ShowDevTool = false;

                browser.CloseDevTools();
            }
        }
    }
}
