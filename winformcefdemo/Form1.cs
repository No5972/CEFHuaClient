using CefSharp;
using CefSharp.DevTools.Page;
using CefSharp.WinForms;
using Newtonsoft.Json;
// using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winformcefdemo;

namespace CEFHuaClient
{
    public partial class CEFHuaClientFrame : Form
    {
        public ChromiumWebBrowser browser { get; set; }
        public Panel panel { get; set; }
        public ComboBox resolution { get; set; }
        public Button captureBtn  { get; set; }
        public Button resetFlashPathBtn { get; set; }
        public bool isCaptureError = false;

        PageClient pageClien = null;

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern System.IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

        [DllImport("gdi32.dll")]
        private static extern int BitBlt(
            IntPtr hdcDest,     // handle to destination DC (device context)
            int nXDest,         // x-coord of destination upper-left corner
            int nYDest,         // y-coord of destination upper-left corner
            int nWidth,         // width of destination rectangle
            int nHeight,        // height of destination rectangle
            IntPtr hdcSrc,      // handle to source DC
            int nXSrc,          // x-coordinate of source upper-left corner
            int nYSrc,          // y-coordinate of source upper-left corner
            System.Int32 dwRop  // raster operation code
        );


        public CEFHuaClientFrame()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ppapiFlashPath = ConfigurationManager.AppSettings["ppapiFlashPath"];
            // string ppapiFlashPath = Environment.GetEnvironmentVariable("TEMP") + "\\Release\\pepflashplayer.dll";
            if (!File.Exists(ppapiFlashPath))
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Flash组件文件pepflashplayer.dll (*.dll)|*.dll";
                openFile.Title = "没有找到Flash文件，或者首次运行需要指定Flash组件文件，文件名通常是pepflashplayer.dll，必须是32位的";
                DialogResult dresult = openFile.ShowDialog();
                this.Activate();
                if (dresult == DialogResult.OK)
                {
                    ppapiFlashPath = openFile.FileName;
                    Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    cfa.AppSettings.Settings["ppapiFlashPath"].Value = ppapiFlashPath;
                    cfa.Save();
                    ConfigurationManager.RefreshSection("appSettings");
                }
                else
                {
                    MessageBox.Show("未指定Flash组件文件，登录器无法运行！");
                    System.Environment.Exit(-101);
                }
            }

            CefSettings settings = new CefSettings();
            settings.CefCommandLineArgs.Add("--disable-web-security");//关闭同源策略
            settings.CefCommandLineArgs.Add("--ppapi-flash-version", "32.0.0.453");//PepperFlash\manifest.json中的version
            settings.CefCommandLineArgs.Add("--ppapi-flash-path", ppapiFlashPath);

            // 必须设置缓存和Cookie否则点击快速进入或者选择服务器时会卡背景logo
            settings.PersistSessionCookies = true;
            settings.CachePath = System.IO.Path.GetFullPath(@"Temp\Cache\");
            settings.UserDataPath = System.IO.Path.GetFullPath(@"Temp\User Data\");
            settings.UserDataPath = System.IO.Path.GetFullPath(@"Temp\LogData\");

            string strFlashSettingPath = string.Format(@"{0}Temp\Cache\Pepper Data\Shockwave Flash\WritableRoot\#Security\FlashPlayerTrust", AppDomain.CurrentDomain.BaseDirectory);
            if (!Directory.Exists(strFlashSettingPath))
            {
                Directory.CreateDirectory(strFlashSettingPath);
            }
            //flash配置文件路径
            string strFlashSettingFilePath = Path.Combine(strFlashSettingPath, "trust.cfg");
            using (StreamWriter sw = new StreamWriter(strFlashSettingFilePath, true, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(Path.GetPathRoot(strFlashSettingFilePath));
                sw.Close();
            }

            panel = new Panel();
            panel.AutoScroll = true;
            panel.Dock = DockStyle.Fill;


            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser("http://hua.61.com/play.shtml");
            browser.IsBrowserInitializedChanged += Browser_IsBrowserInitializedChanged;
            panel.Controls.Add(browser);
            this.Controls.Add(panel);


            captureBtn = new Button();
            captureBtn.Text = "截图";
            captureBtn.Left = 0;
            captureBtn.Top = 0;
            captureBtn.Width = 150;
            captureBtn.Height = 25;
            captureBtn.Click += CaptureBtn_Click;
            captureBtn.MouseUp += CaptureBtn_MouseUp;
            this.Controls.Add(captureBtn);
            this.Controls.SetChildIndex(captureBtn, 0);

            resolution = new ComboBox();
            resolution.Items.Add("1366x768");
            resolution.Items.Add("1920x1080");
            resolution.Items.Add("2560x1440");
            resolution.Items.Add("3840x2160");
            resolution.Items.Add("7680x4320");
            resolution.Items.Add("128x72");
            resolution.Items.Add("自定义...");
            resolution.Left = 150;
            resolution.Top = 0;
            resolution.Width = 100;
            resolution.Height = 30;
            resolution.DropDownStyle = ComboBoxStyle.DropDownList;
            resolution.SelectedIndex = 0;
            resolution.SelectedIndexChanged += Resolution_SelectedIndexChanged;
            this.Controls.Add(resolution);
            this.Controls.SetChildIndex(resolution, 0);

            resetFlashPathBtn = new Button();
            resetFlashPathBtn.Text = "重置Flash路径";
            resetFlashPathBtn.Left = 250;
            resetFlashPathBtn.Top = 0;
            resetFlashPathBtn.Width = 150;
            resetFlashPathBtn.Height = 25;
            resetFlashPathBtn.Click += ResetFlashPathBtn_Click;
            this.Controls.Add(resetFlashPathBtn);
            this.Controls.SetChildIndex(resetFlashPathBtn, 0);

            browser.LoadHtml("<html><head></head><body><embed style='position: absolute; left: 0; top: 0; height: 100%; width: 100%;' src='http://hua.61.com/Client.swf?platform=winform&timestamp="  + DateTime.Now.ToString() +  "'></embed></body></html>", "http://hua.61.com/play.shtml");
            browser.DownloadHandler = new IEDownloadHandler();

        }

        private void ResetFlashPathBtn_Click(object sender, EventArgs e)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["ppapiFlashPath"].Value = "";
            cfa.Save();
            Application.Restart();
        }

        private void CaptureBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                browser.ExecuteScriptAsync("var x = window.open('about:blank', 'newwindow', 'height = 470, width = 430, top = 100, left = 100, toolbar = no, menubar = no, scrollbars = no, resizable = no, location = no, status = no'); x.document.write('<title>求打赏！</title><img src=\\'data:image/png;base64,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\\'></img>');");
            }
        }

        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public struct POINTAPI
        {
            public int x;
            public int y;
        }

        public struct MINMAXINFO
        {
            public POINTAPI ptReserved;
            public POINTAPI ptMaxSize;
            public POINTAPI ptMaxPosition;
            public POINTAPI ptMinTrackSize;
            public POINTAPI ptMaxTrackSize;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_GETMINMAXINFO = 0x24;
            if (m.Msg == WM_GETMINMAXINFO)
            {
                MINMAXINFO mmi = (MINMAXINFO)m.GetLParam(typeof(MINMAXINFO));
                mmi.ptMinTrackSize.x = this.Size.Width;
                mmi.ptMinTrackSize.y = this.Size.Height;
                Marshal.StructureToPtr(mmi, m.LParam, true);
            }
            base.WndProc(ref m);
        }

        private void Resolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (resolution.SelectedItem)
            {
                case "128x72":
                    resizeWindow(128, 72);
                    browser.ExecuteScriptAsync("document.getElementsByTagName('embed')[0].Zoom(100);");
                    break;
                case "1366x768":
                    resizeWindow(1366, 768);
                    browser.ExecuteScriptAsync("document.getElementsByTagName('embed')[0].Zoom(100);");
                    break;
                case "1920x1080":
                    resizeWindow(1920, 1080);
                    browser.ExecuteScriptAsync("document.getElementsByTagName('embed')[0].Zoom(100);");
                    break;
                case "2560x1440":
                    resizeWindow(2560, 1440);
                    browser.ExecuteScriptAsync("document.getElementsByTagName('embed')[0].Zoom(100);");
                    break;
                case "3840x2160":
                    resizeWindow(3840, 2160);
                    browser.ExecuteScriptAsync("document.getElementsByTagName('embed')[0].Zoom(100);");
                    break;
                case "7680x4320":
                    resizeWindow(7680, 4320);
                    browser.ExecuteScriptAsync("document.getElementsByTagName('embed')[0].Zoom(100);");
                    break;
                case "自定义...":
                    CustomResolution resolution = new CustomResolution(this.Width, this.Height);
                    if (resolution.ShowDialog() == DialogResult.OK)
                    {
                        resizeWindow(resolution.thisWidth, resolution.thisHeight);
                        resolution.Dispose();
                    }
                    break;
                default: break;
            }
        }

        private void CaptureBtn_Click(object sender, EventArgs e)
        {
            invokeCapture();
        }

        private void Browser_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            Trace.WriteLine(browser.GetDevToolsClient().ToString());
            // browser.GetDevToolsClient().ExecuteDevToolsMethodAsync("Capture screenshot");
            if (browser.IsBrowserInitialized)
            {
                Cef.UIThreadTaskFactory.StartNew(() =>
                {
                    string error = "";
                    var requestContext = browser.GetBrowser().GetHost().RequestContext;
                    requestContext.SetPreference("profile.default_content_setting_values.plugins", 1, out error);
                });
                // browser.ShowDevTools();
                
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            browser.ExecuteScriptAsync("console.log('window resized')");
            browser.ExecuteScriptAsync("document.getElementsByTagName('embed')[0].Zoom(100);");
        }

        private async void invokeCapture()
        {
            try
            {
                if (!isCaptureError)
                {
                    captureBtn.Enabled = false;
                    captureBtn.Text = "正在截图！";
                    captureBtn.Cursor = Cursors.WaitCursor;
                }
                if (pageClien == null)
                {
                    pageClien = browser.GetBrowser().GetDevToolsClient().Page;
                }

                var result = await pageClien.CaptureScreenshotAsync();
                captureBtn.Cursor = Cursors.Arrow;
                captureBtn.Enabled = true;
                captureBtn.Text = "截图";

                if (result.Data != null)
                {

                    MemoryStream ms = new MemoryStream(result.Data);
                    ms.Write(result.Data, 0, result.Data.Length);
                    // pictureBox1.Image = Image.FromStream(ms);

                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "PNG图片 (*.PNG)|*.PNG";
                    DialogResult dresult = dialog.ShowDialog();
                    if (dresult == DialogResult.OK)
                    {
                        string path = dialog.FileName;
                        try
                        {
                            File.WriteAllBytes(path, result.Data);
                            MessageBox.Show(path + "保存成功。");

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(path + "保存失败！错误信息：" + e.Message);
                        }
                    }

                }
            } catch (Exception e)
            {
                isCaptureError = true;
                captureBtn.Cursor = Cursors.Arrow;
                captureBtn.Enabled = true;
                captureBtn.Text = "不能再截了！";
                MessageBox.Show("截图过程中出现了未知的错误：" + e.Message, "西一爱服 小花仙登录器", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resizeWindow(int width, int height)
        {
            const int SWP_NOSENDCHANGING = 0x0400;

            Process[] processes = Process.GetProcesses(".");
            foreach (var process in processes)
            {
                var handle = process.MainWindowHandle;
                var form = Control.FromHandle(handle);

                if (form == null) continue;

                RECT windowRect = new RECT();
                GetWindowRect(this.Handle, ref windowRect);
                SetWindowPos(handle, 0, this.Left, this.Top, width, height, SWP_NOSENDCHANGING);
            }
        }

        
    }
}
