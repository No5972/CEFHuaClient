﻿namespace winformcefdemo
{
    partial class CustomResolution
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new Sunny.UI.UIButton();
            this.button2 = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "宽";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "高";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(39, 38);
            this.textBox1.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.textBox1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(101, 29);
            this.textBox1.TabIndex = 6;
            this.textBox1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(39, 73);
            this.textBox2.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.textBox2.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(101, 29);
            this.textBox2.TabIndex = 7;
            this.textBox2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FillColor = System.Drawing.Color.DeepPink;
            this.button1.FillHoverColor = System.Drawing.Color.HotPink;
            this.button1.FillPressColor = System.Drawing.Color.MediumVioletRed;
            this.button1.FillSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button1.Location = new System.Drawing.Point(146, 46);
            this.button1.MinimumSize = new System.Drawing.Size(1, 1);
            this.button1.Name = "button1";
            this.button1.RectColor = System.Drawing.Color.DeepPink;
            this.button1.RectHoverColor = System.Drawing.Color.HotPink;
            this.button1.RectPressColor = System.Drawing.Color.MediumVioletRed;
            this.button1.RectSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button1.Size = new System.Drawing.Size(73, 21);
            this.button1.Style = Sunny.UI.UIStyle.Custom;
            this.button1.TabIndex = 8;
            this.button1.Text = "确认";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FillColor = System.Drawing.Color.DeepPink;
            this.button2.FillHoverColor = System.Drawing.Color.HotPink;
            this.button2.FillPressColor = System.Drawing.Color.MediumVioletRed;
            this.button2.FillSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button2.Location = new System.Drawing.Point(146, 82);
            this.button2.MinimumSize = new System.Drawing.Size(1, 1);
            this.button2.Name = "button2";
            this.button2.RectColor = System.Drawing.Color.DeepPink;
            this.button2.RectHoverColor = System.Drawing.Color.HotPink;
            this.button2.RectPressColor = System.Drawing.Color.MediumVioletRed;
            this.button2.RectSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button2.Size = new System.Drawing.Size(73, 20);
            this.button2.Style = Sunny.UI.UIStyle.Custom;
            this.button2.TabIndex = 9;
            this.button2.Text = "取消";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CustomResolution
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(230, 113);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomResolution";
            this.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.RectColor = System.Drawing.Color.DeepPink;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "自定义分辨率";
            this.TitleColor = System.Drawing.Color.DeepPink;
            this.TitleHeight = 31;
            this.Load += new System.EventHandler(this.CustomResolution_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown textBox1;
        private System.Windows.Forms.NumericUpDown textBox2;
        private Sunny.UI.UIButton button1;
        private Sunny.UI.UIButton button2;
    }
}