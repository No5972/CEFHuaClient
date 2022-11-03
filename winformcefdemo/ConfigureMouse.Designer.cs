
namespace winformcefdemo
{
    partial class ConfigureMouse
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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(4, 39);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(153, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "间隔（毫秒）：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(4, 70);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(211, 23);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "切换快捷键：Alt + F6";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(163, 38);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(73, 29);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.DeepPink;
            this.uiButton1.FillHoverColor = System.Drawing.Color.HotPink;
            this.uiButton1.FillPressColor = System.Drawing.Color.MediumVioletRed;
            this.uiButton1.FillSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton1.Location = new System.Drawing.Point(245, 39);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.RectColor = System.Drawing.Color.DeepPink;
            this.uiButton1.RectHoverColor = System.Drawing.Color.HotPink;
            this.uiButton1.RectPressColor = System.Drawing.Color.MediumVioletRed;
            this.uiButton1.RectSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.uiButton1.Size = new System.Drawing.Size(100, 28);
            this.uiButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton1.TabIndex = 3;
            this.uiButton1.Text = "确认";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiButton2.FillColor = System.Drawing.Color.DeepPink;
            this.uiButton2.FillHoverColor = System.Drawing.Color.HotPink;
            this.uiButton2.FillPressColor = System.Drawing.Color.MediumVioletRed;
            this.uiButton2.FillSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton2.Location = new System.Drawing.Point(245, 72);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.RectColor = System.Drawing.Color.DeepPink;
            this.uiButton2.RectHoverColor = System.Drawing.Color.HotPink;
            this.uiButton2.RectPressColor = System.Drawing.Color.MediumVioletRed;
            this.uiButton2.RectSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.uiButton2.Size = new System.Drawing.Size(100, 28);
            this.uiButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton2.TabIndex = 4;
            this.uiButton2.Text = "取消";
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // ConfigureMouse
            // 
            this.AcceptButton = this.uiButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.uiButton2;
            this.ClientSize = new System.Drawing.Size(348, 103);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigureMouse";
            this.RectColor = System.Drawing.Color.DeepPink;
            this.ShowRadius = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "配置鼠标连点";
            this.TitleColor = System.Drawing.Color.DeepPink;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
    }
}