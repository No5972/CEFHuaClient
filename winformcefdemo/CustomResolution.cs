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
    public partial class CustomResolution : UIForm
    {
        public int thisHeight { get; set; }
        public int thisWidth { get; set; }

        public CustomResolution()
        {
            InitializeComponent();
        }

        public CustomResolution(int width, int height)
        {
            InitializeComponent();
            this.textBox1.Value = width;
            this.textBox2.Value = height;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.thisWidth = (int) this.textBox1.Value;
            this.thisHeight = (int) this.textBox2.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void CustomResolution_Load(object sender, EventArgs e)
        {
            this.textBox1.Select();
        }

        
    }
}
