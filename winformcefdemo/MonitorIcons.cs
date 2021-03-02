using CefSharp;
using CefSharp.WinForms;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformcefdemo
{
    public partial class MonitorIcons : UIForm
    {
        public ChromiumWebBrowser browser { get; set; }
        private bool isMonitoring { get; set; } = true;

        public MonitorIcons()
        {
            InitializeComponent();
            // Panel panel = new Panel();
            browser = new ChromiumWebBrowser("about:blank");
            // panel.SetBounds(242, 13, 360, 360);
            panel.Controls.Add(browser);
            this.Controls.Add(panel);
            Control.CheckForIllegalCrossThreadCalls = false;

            /// TODO: Test case
            /*
            this.addMonitoredItem("143404");
            this.addMonitoredItem("144746");
            */
        }

        public void addMonitoredItem(string iconId)
        {
            if (this.isMonitoring)
            {
                this.listBox1.Items.Add(iconId);
            }
        }

        private void MonitorIcons_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            browser.LoadHtml("<html><head></head><body><embed style='position: absolute; left: 0; top: 0; height: 100%; width: 100%;' src='http://hua.61.com/resource/cloth/icon/" + listBox1.SelectedItem + ".swf'></embed></body></html>", "http://hua.61.com/play.shtml?forceLoadSwf");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.isMonitoring)
            {
                this.isMonitoring = false;
                button1.FillColor = Color.Yellow;
                button1.FillHoverColor = Color.LightYellow;
                button1.FillPressColor = Color.Olive;
                button1.ForeColor = Color.Black;
                button1.ForeHoverColor = Color.Black;
                button1.ForePressColor = Color.Black;
            } else
            {
                this.isMonitoring = true;
                button1.FillColor = Color.Red;
                button1.FillHoverColor = Color.Coral;
                button1.FillPressColor = Color.DarkRed;
                button1.ForeColor = Color.White;
                button1.ForeHoverColor = Color.White;
                button1.ForePressColor = Color.White;
            }
        }
    }
}
