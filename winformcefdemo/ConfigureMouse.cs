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
    public partial class ConfigureMouse : UIForm
    {
        public int thisInterval { get; set; }

        public ConfigureMouse()
        {
            InitializeComponent();
        }

        public ConfigureMouse(int interval)
        {
            InitializeComponent();
            this.numericUpDown1.Value = interval;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.thisInterval = (int) this.numericUpDown1.Value;
            this.DialogResult = DialogResult.OK;
        }
    }
}
