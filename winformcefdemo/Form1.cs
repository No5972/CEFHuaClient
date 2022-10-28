using CefSharp;
using CefSharp.DevTools.Page;
using CefSharp.WinForms;
using Newtonsoft.Json;
using Sunny.UI;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using winformcefdemo;

namespace CEFHuaClient
{
    public partial class CEFHuaClientFrame : Form
    {
        public ChromiumWebBrowser browser { get; set; }
        public Panel panel { get; set; }
        public UIComboBox resolution { get; set; }
        public UISymbolButton captureBtn  { get; set; }
        public UISymbolButton resetFlashPathBtn { get; set; }
        public UISymbolButton customeCaptureBtn { get; set; }
        public UISymbolButton simulateReplaceBtn { get; set; }
        public UISymbolButton debugBtn { get; set; }
        public UISymbolButton customeBgBtn { get; set; }
        public UISymbolButton refreshBtn { get; set; }
        public UISymbolButton autoMouseBtn { get; set; }
        public bool isCaptureError = false;
        public bool isCustomCapture = false;
        public ContextMenuStrip simulateReplaceMenu;
        public ContextMenuStrip customeBgMenu;
        public ToolStripMenuItem noReplaceBg = new ToolStripMenuItem("不替换");
        public ToolStripMenuItem whiteBg = new ToolStripMenuItem("白色");
        public ToolStripMenuItem blackBg = new ToolStripMenuItem("黑色");
        public ToolStripMenuItem redBg = new ToolStripMenuItem("红色");
        public ToolStripMenuItem greenBg = new ToolStripMenuItem("绿色");
        public ToolStripMenuItem blueBg = new ToolStripMenuItem("蓝色");
        public MonitorIcons monitorIcons;
        public int mouseInterval = 50;

        public MyRequestHandler requestHandler = new MyRequestHandler();

        private int offsetX = 0, offsetY = 0, customWidth = 0, customHeight = 0, previousWidth = 0, previousHeight = 0;
        private double scale = 0.0;

        private string currentComboBoxResolution = "";

        PageClient pageClien = null;

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern System.IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();//获得当前活动窗体


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

        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        //移动鼠标 
        const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        //模拟鼠标滚轮滚动操作，必须配合dwData参数
        const int MOUSEEVENTF_WHEEL = 0x0800;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,                //要定义热键的窗口的句柄
            int id,                     //定义热键ID（不能与其它ID重复）          
            KeyModifiers fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效
            Keys vk                     //定义热键的内容
        );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,                //要取消热键的窗口的句柄
            int id                      //要取消热键的ID
        );

        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }


        public CEFHuaClientFrame()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // string ppapiFlashPath = ConfigurationManager.AppSettings["ppapiFlashPath"];
            string ppapiFlashPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "pepflashplayer.dll";
            if (!File.Exists(ppapiFlashPath))
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Flash组件文件pepflashplayer.dll (*.dll)|*.dll";
                openFile.Title = "没有找到Flash文件，或者首次运行需要指定Flash组件文件，文件名通常是pepflashplayer.dll，必须是64位的";
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
                    MessageBox.Show("未指定Flash组件文件，登录器无法运行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Environment.Exit(-101);
                }
            }

            CefSettings settings = new CefSettings();
            settings.CefCommandLineArgs.Add("--disable-web-security");//关闭同源策略
            settings.CefCommandLineArgs.Add("--ppapi-flash-version", "32.0.0.453");//PepperFlash\manifest.json中的version
            settings.CefCommandLineArgs.Add("--ppapi-flash-path", ppapiFlashPath);
            settings.CefCommandLineArgs.Add("--disable-application-cache");

            // 必须设置缓存和Cookie否则点击快速进入或者选择服务器时会卡背景logo
            settings.PersistSessionCookies = true;
            settings.CachePath = System.Environment.GetEnvironmentVariable("TEMP") + @"\CEFHuaClient\Temp\Cache\";
            settings.UserDataPath = System.Environment.GetEnvironmentVariable("TEMP") + @"\CEFHuaClient\Temp\User Data\";
            // settings.LogFile = System.IO.Path.GetFullPath(@"Temp\LogData\");

            string strFlashSettingPath = System.Environment.GetEnvironmentVariable("TEMP") + @"\CEFHuaClient\Temp\Cache\Pepper Data\Shockwave Flash\WritableRoot\#Security\FlashPlayerTrust";
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


            captureBtn = new UISymbolButton();
            captureBtn.Text = "截图";
            captureBtn.Font = new Font("Microsoft Yahei", 11);
            captureBtn.Symbol = 61636;
            captureBtn.Left = 0;
            captureBtn.Top = 0;
            captureBtn.Width = 150;
            captureBtn.Height = 25;
            captureBtn.RectColor = captureBtn.RectHoverColor = captureBtn.RectPressColor = captureBtn.RectDisableColor = UIColor.White;
            captureBtn.Click += CaptureBtn_Click;
            captureBtn.MouseUp += CaptureBtn_MouseUp;
            this.Controls.Add(captureBtn);
            this.Controls.SetChildIndex(captureBtn, 0);

            resolution = new UIComboBox();
            resolution.Items.Add("1366x768");
            resolution.Items.Add("1920x1080");
            resolution.Items.Add("2560x1440");
            resolution.Items.Add("3840x2160");
            resolution.Items.Add("7680x4320");
            resolution.Items.Add("128x72");
            resolution.Items.Add("自定义...");
            resolution.Left = 150;
            resolution.Top = 0;
            resolution.Width = 150;
            resolution.Height = 25;
            resolution.DropDownStyle = UIDropDownStyle.DropDownList;
            resolution.SelectedIndex = 0;
            resolution.SelectedIndexChanged += Resolution_SelectedIndexChanged;
            this.currentComboBoxResolution = resolution.SelectedItem.ToString();
            this.Controls.Add(resolution);
            this.Controls.SetChildIndex(resolution, 0);

            resetFlashPathBtn = new UISymbolButton();
            resetFlashPathBtn.Text = "重置Flash路径";
            resetFlashPathBtn.Font = new Font("Microsoft Yahei", 11);
            resetFlashPathBtn.Symbol = 61714;
            resetFlashPathBtn.Left = 300;
            resetFlashPathBtn.Top = 0;
            resetFlashPathBtn.Width = 150;
            resetFlashPathBtn.Height = 25;
            resetFlashPathBtn.RectColor = resetFlashPathBtn.RectHoverColor = resetFlashPathBtn.RectPressColor = UIColor.White;
            resetFlashPathBtn.Click += ResetFlashPathBtn_Click;
            this.Controls.Add(resetFlashPathBtn);
            this.Controls.SetChildIndex(resetFlashPathBtn, 0);

            customeCaptureBtn = new UISymbolButton();
            customeCaptureBtn.Text = "自定义截图...";
            customeCaptureBtn.Font = new Font("Microsoft Yahei", 11);
            customeCaptureBtn.Left = 450;
            customeCaptureBtn.Top = 0;
            customeCaptureBtn.Width = 150;
            customeCaptureBtn.Height = 25;
            customeCaptureBtn.Symbol = 61918;
            customeCaptureBtn.RectColor = customeCaptureBtn.RectDisableColor = customeCaptureBtn.RectHoverColor = customeCaptureBtn.RectPressColor = UIColor.White;
            customeCaptureBtn.Click += CustomCaptureBtn_Click;
            this.Controls.Add(customeCaptureBtn);
            this.Controls.SetChildIndex(customeCaptureBtn, 0);

            simulateReplaceBtn = new UISymbolButton();
            simulateReplaceBtn.Text = "模拟衣服替换▾";
            simulateReplaceBtn.Font = new Font("Microsoft Yahei", 11);
            simulateReplaceBtn.Left = 600;
            simulateReplaceBtn.Top = 0;
            simulateReplaceBtn.Width = 150;
            simulateReplaceBtn.Height = 25;
            simulateReplaceBtn.Symbol = 57378;
            simulateReplaceBtn.RectColor = simulateReplaceBtn.RectHoverColor = simulateReplaceBtn.RectPressColor = UIColor.White;
            simulateReplaceBtn.Click += SimulateReplaceBtn_Click; ;
            this.Controls.Add(simulateReplaceBtn);
            this.Controls.SetChildIndex(simulateReplaceBtn, 0);

            debugBtn = new UISymbolButton();
            debugBtn.Text = "调试";
            debugBtn.Font = new Font("Microsoft Yahei", 11);
            debugBtn.Left = 750;
            debugBtn.Top = 0;
            debugBtn.Width = 150;
            debugBtn.Height = 25;
            debugBtn.Symbol = 61729;
            debugBtn.RectColor = debugBtn.RectHoverColor = debugBtn.RectPressColor = UIColor.White;
            debugBtn.Click += DebugBtn_Click;
            this.Controls.Add(debugBtn);
            this.Controls.SetChildIndex(debugBtn, 0);

            customeBgBtn = new UISymbolButton();
            customeBgBtn.Text = "自定义背景▾";
            customeBgBtn.Font = new Font("Microsoft Yahei", 11);
            customeBgBtn.Left = 900;
            customeBgBtn.Top = 0;
            customeBgBtn.Width = 150;
            customeBgBtn.Height = 25;
            customeBgBtn.Symbol = 61502;
            customeBgBtn.RectColor = customeBgBtn.RectHoverColor = customeBgBtn.RectPressColor = UIColor.White;
            customeBgBtn.Click += CustomeBgBtn_Click;
            this.Controls.Add(customeBgBtn);
            this.Controls.SetChildIndex(customeBgBtn, 0);

            refreshBtn = new UISymbolButton();
            refreshBtn.Text = "刷新 (Alt+F5)";
            refreshBtn.Font = new Font("Microsoft Yahei", 11);
            refreshBtn.Left = 1050;
            refreshBtn.Top = 0;
            refreshBtn.Width = 150;
            refreshBtn.Height = 25;
            refreshBtn.Symbol = 61473;
            refreshBtn.RectColor = refreshBtn.RectHoverColor = refreshBtn.RectPressColor = UIColor.White;
            refreshBtn.Click += RefreshBtn_Click; ;
            this.Controls.Add(refreshBtn);
            this.Controls.SetChildIndex(refreshBtn, 0);

            autoMouseBtn = new UISymbolButton();
            autoMouseBtn.Text = "配置鼠标连点...";
            autoMouseBtn.Font = new Font("Microsoft Yahei", 11);
            autoMouseBtn.Left = 1200;
            autoMouseBtn.Top = 0;
            autoMouseBtn.Width = 150;
            autoMouseBtn.Height = 25;
            autoMouseBtn.Symbol = 62021;
            autoMouseBtn.RectColor = autoMouseBtn.RectHoverColor = autoMouseBtn.RectPressColor = UIColor.White;
            autoMouseBtn.Click += AutoMouseBtn_Click; 
            this.Controls.Add(autoMouseBtn);
            this.Controls.SetChildIndex(autoMouseBtn, 0);

            simulateReplaceMenu = new ContextMenuStrip();
            simulateReplaceMenu.Items.Add("模拟衣服替换(&R)...");
            simulateReplaceMenu.Items.Add("查找部件ID(&M)...");
            simulateReplaceMenu.ItemClicked += SimulateReplaceMenu_ItemClicked;

            customeBgMenu = new ContextMenuStrip();
            noReplaceBg.Checked = true;
            customeBgMenu.Items.Add(noReplaceBg);
            customeBgMenu.Items.Add(whiteBg);
            customeBgMenu.Items.Add(blackBg);
            customeBgMenu.Items.Add(redBg);
            customeBgMenu.Items.Add(greenBg);
            customeBgMenu.Items.Add(blueBg);
            customeBgMenu.Items.Add("此功能必须戴一个背景秀才有效");
            customeBgMenu.ItemClicked += CustomeBgMenu_ItemClicked;

            monitorIcons = new MonitorIcons();


            // browser.DownloadHandler = new IEDownloadHandler();
            
            browser.LoadingStateChanged += Browser_LoadingStateChanged;
        }

        private void AutoMouseBtn_Click(object sender, EventArgs e)
        {
            ConfigureMouse configureMouse = new ConfigureMouse(this.mouseInterval);
            if (configureMouse.ShowDialog() == DialogResult.OK)
            {
                this.mouseInterval = configureMouse.thisInterval;
                this.timerMouseClick.Interval = this.mouseInterval;
                if (this.timerMouseClick.Enabled)
                {
                    this.Text = this.Text.Substring(0, this.Text.LastIndexOf(" - 已开启鼠标连点，间隔：")) + " - 已开启鼠标连点，间隔：" + this.timerMouseClick.Interval;
                }
                configureMouse.Dispose();
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            // browser.LoadHtml("<html><head></head><body><embed style='position: absolute; left: 0; top: 0; height: 100%; width: 100%;' src='http://hua.61.com/Client.swf?timestamp=" + DateTime.Now.Ticks.ToString() + "'></embed></body></html>", "http://hua.61.com/play.shtml?forceLoadSwf");
            browser.ExecuteScriptAsync("document.getElementById(\"flashContent\").innerHTML = '<embed type=\"application/x-shockwave-flash\" src=\"Client.swf?' + autoTimes.getTime() + '\" width=\"100%\" height=\"100%\" style=\"undefined\" id=\"Client\" name=\"Client\" bgcolor=\"#330033\" quality=\"high\" menu=\"false\" wmode=\"opaque\" allowfullscreen=\"true\" allowscriptaccess=\"always\" allowfullscreeninteractive=\"true\">';");
        }

        private void CustomeBgMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.customeBgMenu.Hide();
            if (e.ClickedItem.Text == "此功能必须戴一个背景秀才有效") return;
            this.noReplaceBg.Checked = false;
            this.whiteBg.Checked = false;
            this.blackBg.Checked = false;
            this.redBg.Checked = false;
            this.greenBg.Checked = false;
            this.blueBg.Checked = false;
            switch (e.ClickedItem.Text) {
                case "不替换":
                    this.requestHandler.bgResourceName = "";
                    this.noReplaceBg.Checked = true;
                    break;
                case "黑色":
                    this.requestHandler.bgResourceName = "blackBg.swf";
                    this.blackBg.Checked = true;
                    break;
                case "白色":
                    this.requestHandler.bgResourceName = "whiteBg.swf";
                    this.whiteBg.Checked = true;
                    break;
                case "红色":
                    this.requestHandler.bgResourceName = "redBg.swf";
                    this.redBg.Checked = true;
                    break;
                case "绿色":
                    this.requestHandler.bgResourceName = "greenBg.swf";
                    this.greenBg.Checked = true;
                    break;
                case "蓝色":
                    this.requestHandler.bgResourceName = "blueBg.swf";
                    this.blueBg.Checked = true;
                    break;
                default: break;
            }
            return;
        }

        private void CustomeBgBtn_Click(object sender, EventArgs e)
        {
            customeBgMenu.Show(MousePosition.X, MousePosition.Y);
        }

        private void SimulateReplaceMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.simulateReplaceMenu.Hide();
            switch (e.ClickedItem.Text)
            {
                case "模拟衣服替换(&R)...":
                    SimulateReplace simulateReplace = new SimulateReplace(this.requestHandler.dict);
                    if (simulateReplace.ShowDialog() == DialogResult.OK)
                    {
                        List<Dictionary<string, string>> list = simulateReplace.dict;
                        requestHandler.dict = list;

                        simulateReplace.Dispose();
                    }
                    break;
                case "查找部件ID(&M)...":
                    if (monitorIcons.IsDisposed)
                    {
                        monitorIcons = new MonitorIcons();
                    }
                    monitorIcons.Show();
                    break;
                default:
                    break;
            }
        }

        private void MonitorMenu_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SettingMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void DebugBtn_Click(object sender, EventArgs e)
        {
            this.browser.ShowDevTools();
        }

        private void SimulateReplaceBtn_Click(object sender, EventArgs e)
        {
            simulateReplaceMenu.Show(MousePosition.X, MousePosition.Y);
        }

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!browser.IsLoading)
            {
                if (browser.Address != "http://hua.61.com/play.shtml?forceLoadSwf")
                {
                    // browser.LoadHtml("<html><head></head><body><embed style='position: absolute; left: 0; top: 0; height: 100%; width: 100%;' src='http://hua.61.com/Client.swf?timestamp=" + DateTime.Now.Ticks.ToString() + "'></embed></body></html>", "http://hua.61.com/play.shtml?forceLoadSwf");
                    browser.ExecuteScriptAsync("document.getElementById(\"flashContent\").innerHTML = '<embed type=\"application/x-shockwave-flash\" src=\"Client.swf?' + autoTimes.getTime() + '\" width=\"100%\" height=\"100%\" style=\"undefined\" id=\"Client\" name=\"Client\" bgcolor=\"#330033\" quality=\"high\" menu=\"false\" wmode=\"opaque\" allowfullscreen=\"true\" allowscriptaccess=\"always\" allowfullscreeninteractive=\"true\">';");
                    this.Text = this.Text.Replace("若长时间未加载出游戏，请确认是否正确选择了Flash组件位置", "");
                    requestHandler.interceptedAnIcon = new MyRequestHandler.InterceptedAnIcon(InterceptedAnIcon);
                    browser.RequestHandler = requestHandler;
                }
                else
                {
                    requestHandler.interceptedAnIcon = new MyRequestHandler.InterceptedAnIcon(InterceptedAnIcon);
                    browser.RequestHandler = requestHandler;
                }
            } 
        }

        private void InterceptedAnIcon(string iconId)
        {
            Regex r = new Regex(@"(\/([0-9]{6,10}))"); // TODO 这里的正则要判断不是3位数的
            Match m = r.Match(iconId);
            if (m.Success)
            {
                // MessageBox.Show("拦截到了图标: " + m.Groups[0].Value.Replace("/", ""));
                if (!monitorIcons.IsDisposed)
                {
                    monitorIcons.addMonitoredItem(m.Groups[0].Value.Replace("/", ""));
                }
            }
        }

        private void CustomCaptureBtn_Click(object sender, EventArgs e)
        {
            CustomCapture customCapture = new CustomCapture();
            if (customCapture.ShowDialog() == DialogResult.OK)
            {
                int w = customCapture.w, h = customCapture.h, x = customCapture.x, y = customCapture.y;
                double scale = customCapture.scale;

                customCapture.Dispose();
                invokeCustomCapture(w, h, scale, x, y);
            }
            
        }

        private async void invokeCustomCapture(int width, int height, double scale, int offsetX, int offsetY)
        {
            int previousW = this.Width, previousH = this.Height;
            this.customeCaptureBtn.Enabled = false;
            this.captureBtn.Enabled = false;

            resizeWindow(width, height);
            // geckoWebBrowser1.Navigate("javascript:void(document.getElementsByTagName('embed')[0].Zoom(" + (100.0 / scale) + "));");
            browser.ExecuteScriptAsync("javascript:void(document.getElementsByTagName('embed')[0].Zoom(500));");
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            this.isCustomCapture = true;
            this.previousWidth = previousW;
            this.previousHeight = previousH;
            this.customWidth = width;
            this.customHeight = height;
            this.scale = scale;
            timer1.Enabled = true;

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
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_GETMINMAXINFO:
                    MINMAXINFO mmi = (MINMAXINFO)m.GetLParam(typeof(MINMAXINFO));
                    mmi.ptMinTrackSize.x = this.Size.Width;
                    mmi.ptMinTrackSize.y = this.Size.Height;
                    Marshal.StructureToPtr(mmi, m.LParam, true);
                    break;
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:    //按下的是 Alt+F5
                            IntPtr activeWindow = GetActiveWindow();
                            IntPtr foregroundWindow = GetForegroundWindow();
                            if (activeWindow !=IntPtr.Zero && activeWindow == foregroundWindow)
                            {
                                RefreshBtn_Click(null, null);         //此处填写快捷键响应代码        
                            }
                            break;
                        case 101:    //按下的是 Alt+F5
                            IntPtr activeWindow2 = GetActiveWindow();
                            IntPtr foregroundWindow2 = GetForegroundWindow();
                            if (activeWindow2 != IntPtr.Zero && activeWindow2 == foregroundWindow2)
                            {
                                if (timerMouseClick.Enabled)
                                {
                                    this.Text = this.Text.Substring(0, this.Text.LastIndexOf(" - 已开启鼠标连点，间隔："));
                                    timerMouseClick.Enabled = false;         //此处填写快捷键响应代码        
                                }
                                else
                                {
                                    this.Text = this.Text + " - 已开启鼠标连点，间隔：" + this.mouseInterval;
                                    timerMouseClick.Enabled = true;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            
            base.WndProc(ref m);
        }

        private void Resolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(((UIComboBox)sender).SelectedItem.ToString());
            string callbackSelectedItem = ((UIComboBox)sender).SelectedItem.ToString();
            if (callbackSelectedItem == this.currentComboBoxResolution)
            {
                return;
            }
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
                    } else
                    {
                        Timer tSwitch = new Timer();
                        tSwitch.Interval = 50;
                        tSwitch.Tick += (senderT, eT) =>
                        {
                            this.Activate();
                            tSwitch.Enabled = false;
                            tSwitch.Dispose();
                        };
                        tSwitch.Enabled = true;
                    }
                    break;
                default: break;
            }
            this.currentComboBoxResolution = ((UIComboBox)sender).SelectedItem.ToString();
        }

        /// <summary>
        /// 老写法
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            browser.ExecuteScriptAsync("javascript:void(document.getElementsByTagName('embed')[0].Zoom(" + 100.0 / this.scale + "));");
            timer2.Enabled = true;
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            browser.ExecuteScriptAsync("javascript:void(document.getElementsByTagName('embed')[0].Pan(" + this.offsetX + "," + this.offsetY + ", 0));");
            timer3.Enabled = true;
            timer2.Enabled = false;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            this.timer3.Enabled = false;
            invokeCapture();
            
        }

        private void CEFHuaClientFrame_Activated(object sender, EventArgs e)
        {
            RegisterHotKey(Handle, 100, KeyModifiers.Alt, Keys.F5);
            RegisterHotKey(Handle, 101, KeyModifiers.Alt, Keys.F6);
        }

        private void CEFHuaClientFrame_Leave(object sender, EventArgs e)
        {
            UnregisterHotKey(Handle, 100);
            UnregisterHotKey(Handle, 101);
        }

        private void timerMouseClick_Tick(object sender, EventArgs e)
        {
            Point p = this.PointToClient(Control.MousePosition);

            IntPtr activeWindow = GetActiveWindow();
            IntPtr foregroundWindow = GetForegroundWindow();
            if (activeWindow != IntPtr.Zero && activeWindow == foregroundWindow &&
                p.X > 0 && p.X < this.ClientSize.Width && p.Y > 0 && p.Y < this.ClientSize.Height)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }
        }

        private void CaptureBtn_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                invokeCapture();
            }
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


                Task.Run(async () =>
                    await DevToolsExtensions.ExecuteDevToolsMethodAsync(browser.GetBrowser(), 0, "Network.setCacheDisabled", new Dictionary<string, object>
                    {
                        {
                            "cacheDisabled", true
                        }
                    })
                );
                

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

                    if (isCustomCapture)
                    {
                        isCustomCapture = false;
                        customeCaptureBtn.Enabled = true;
                        resizeWindow(previousWidth, previousHeight);
                        browser.ExecuteScriptAsync("javascript:void(document.getElementsByTagName('embed')[0].Zoom(500));");
                    }

                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "PNG图片 (*.PNG)|*.PNG";
                    DialogResult dresult = dialog.ShowDialog();
                    if (dresult == DialogResult.OK)
                    {
                        string path = dialog.FileName;
                        try
                        {
                            
                            File.WriteAllBytes(path, result.Data);
                            MessageBox.Show(path + "保存成功。文件大小：" + decimal.Round(
                                decimal.Divide(decimal.Parse(result.Data.Length.ToString()), decimal.Parse("1048576")), 2) + "MB", "截图结果", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(path + "保存失败！错误信息：" + e.Message, "截图结果", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            } catch (Exception e)
            {
                isCaptureError = true;
                captureBtn.Cursor = Cursors.Arrow;
                captureBtn.Enabled = true;
                captureBtn.Text = "截图";
                MessageBox.Show("截图过程中出现了未知的错误：" + e.Message, "西一爱服 小花仙登录器", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resizeWindow(int width, int height)
        {
            const int SWP_NOSENDCHANGING = 0x0400;

            Process[] processes = Process.GetProcesses(".");
            foreach (var process in processes)
            {
                // var handle = process.MainWindowHandle;
                var handle = FindWindow(null, this.Text);
                var form = Control.FromHandle(handle);

                if (form == null) continue;

                RECT windowRect = new RECT();
                GetWindowRect(this.Handle, ref windowRect);
                SetWindowPos(handle, 0, this.Left, this.Top, width, height, SWP_NOSENDCHANGING);
            }
        }

        
    }
}
