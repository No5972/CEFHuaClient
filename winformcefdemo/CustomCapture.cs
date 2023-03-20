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
    public partial class CustomCapture : UIForm
    {
        public int w = 0, h = 0, x = 0, y = 0, delayAfterZoom = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            this.w = (int)this.numericUpDown1.Value;
            this.h = (int)this.numericUpDown2.Value;
            this.x = (int)this.numericUpDown3.Value;
            this.y = (int)this.numericUpDown4.Value;
            this.scale = (double)this.numericUpDown5.Value;
            this.delayAfterZoom = (int)this.numericUpDown6.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        public double scale = 0.0;

        public CustomCapture()
        {
            InitializeComponent();
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.w = (int) this.numericUpDown1.Value;
                this.h = (int) this.numericUpDown2.Value;
                this.x = (int) this.numericUpDown3.Value;
                this.y = (int) this.numericUpDown4.Value;
                this.scale = (double) this.numericUpDown5.Value;
                this.DialogResult = DialogResult.OK;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Dispose();
            }
        }
    }
}
