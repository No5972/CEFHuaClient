namespace winformcefdemo
{
    partial class MonitorIcons
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorIcons));
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new Sunny.UI.UIListBox();
            this.button2 = new Sunny.UI.UISymbolButton();
            this.button1 = new Sunny.UI.UISymbolButton();
            this.panel = new Sunny.UI.UIPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(613, 202);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.listBox1.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.listBox1.Location = new System.Drawing.Point(12, 66);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.listBox1.Name = "listBox1";
            this.listBox1.Padding = new System.Windows.Forms.Padding(2);
            this.listBox1.Size = new System.Drawing.Size(220, 330);
            this.listBox1.Style = Sunny.UI.UIStyle.Custom;
            this.listBox1.TabIndex = 6;
            this.listBox1.Text = null;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.button2.Location = new System.Drawing.Point(127, 38);
            this.button2.MinimumSize = new System.Drawing.Size(1, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.Style = Sunny.UI.UIStyle.Custom;
            this.button2.Symbol = 61534;
            this.button2.TabIndex = 8;
            this.button2.Text = "清空";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FillColor = System.Drawing.Color.Red;
            this.button1.FillHoverColor = System.Drawing.Color.Coral;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.button1.Location = new System.Drawing.Point(12, 38);
            this.button1.MinimumSize = new System.Drawing.Size(1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.Style = Sunny.UI.UIStyle.Custom;
            this.button1.Symbol = 61713;
            this.button1.TabIndex = 9;
            this.button1.Text = "监测";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel
            // 
            this.panel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.panel.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.panel.Location = new System.Drawing.Point(239, 38);
            this.panel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel.MinimumSize = new System.Drawing.Size(1, 1);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(3);
            this.panel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.panel.Size = new System.Drawing.Size(387, 358);
            this.panel.Style = Sunny.UI.UIStyle.Custom;
            this.panel.TabIndex = 10;
            this.panel.Text = null;
            // 
            // MonitorIcons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 619);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MonitorIcons";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "查找部件ID";
            this.Load += new System.EventHandler(this.MonitorIcons_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIListBox listBox1;
        private Sunny.UI.UISymbolButton button2;
        private Sunny.UI.UISymbolButton button1;
        private Sunny.UI.UIPanel panel;
    }
}