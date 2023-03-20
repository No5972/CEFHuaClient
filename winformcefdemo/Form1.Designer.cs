namespace CEFHuaClient
{
    partial class CEFHuaClientFrame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CEFHuaClientFrame));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timerMouseClick = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 10000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timerMouseClick
            // 
            this.timerMouseClick.Interval = 50;
            this.timerMouseClick.Tick += new System.EventHandler(this.timerMouseClick_Tick);
            // 
            // CEFHuaClientFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 673);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CEFHuaClientFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "西一爱服 小花仙登录器 V1.3 BY 鄙人 贴吧/B站：wujiuqier Github：No5972 若长时间未加载出游戏，请确认是否正确选择了Flash组件" +
    "位置";
            this.Activated += new System.EventHandler(this.CEFHuaClientFrame_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Leave += new System.EventHandler(this.CEFHuaClientFrame_Leave);
            this.MouseLeave += new System.EventHandler(this.CEFHuaClientFrame_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timerMouseClick;
    }
}

