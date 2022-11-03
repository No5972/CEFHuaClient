namespace winformcefdemo
{
    partial class SimulateReplace
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.part = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.original = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.replace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new Sunny.UI.UITextBox();
            this.textBox2 = new Sunny.UI.UITextBox();
            this.comboBox1 = new Sunny.UI.UIComboBox();
            this.button4 = new Sunny.UI.UIButton();
            this.button5 = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.button1 = new Sunny.UI.UISymbolButton();
            this.button2 = new Sunny.UI.UISymbolButton();
            this.button3 = new Sunny.UI.UISymbolButton();
            this.btnImport = new Sunny.UI.UISymbolButton();
            this.btnExport = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.part,
            this.original,
            this.replace});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 38);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(797, 311);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // part
            // 
            this.part.Text = "部位";
            // 
            // original
            // 
            this.original.Text = "要替换的部件ID";
            this.original.Width = 200;
            // 
            // replace
            // 
            this.replace.Text = "替换的部件ID";
            this.replace.Width = 200;
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.FillColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.textBox1.Location = new System.Drawing.Point(329, 358);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Maximum = 2147483647D;
            this.textBox1.Minimum = -2147483648D;
            this.textBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Padding = new System.Windows.Forms.Padding(5);
            this.textBox1.RectColor = System.Drawing.Color.DeepPink;
            this.textBox1.Size = new System.Drawing.Size(150, 29);
            this.textBox1.Style = Sunny.UI.UIStyle.Custom;
            this.textBox1.TabIndex = 12;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox2.FillColor = System.Drawing.Color.White;
            this.textBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.textBox2.Location = new System.Drawing.Point(649, 358);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Maximum = 2147483647D;
            this.textBox2.Minimum = -2147483648D;
            this.textBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.textBox2.Name = "textBox2";
            this.textBox2.Padding = new System.Windows.Forms.Padding(5);
            this.textBox2.RectColor = System.Drawing.Color.DeepPink;
            this.textBox2.Size = new System.Drawing.Size(150, 29);
            this.textBox2.Style = Sunny.UI.UIStyle.Custom;
            this.textBox2.TabIndex = 13;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.comboBox1.FillColor = System.Drawing.Color.White;
            this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.comboBox1.Items.AddRange(new object[] {
            "上衣",
            "下装",
            "头发",
            "腰带",
            "鞋子",
            "翅膀",
            "帽子",
            "脸部",
            "手部",
            "道具",
            "足部",
            "项链",
            "耳环",
            "眼睛",
            "眉毛",
            "嘴巴"});
            this.comboBox1.Location = new System.Drawing.Point(62, 358);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboBox1.RectColor = System.Drawing.Color.DeepPink;
            this.comboBox1.Size = new System.Drawing.Size(100, 29);
            this.comboBox1.Style = Sunny.UI.UIStyle.Custom;
            this.comboBox1.TabIndex = 14;
            this.comboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.FillColor = System.Drawing.Color.DeepPink;
            this.button4.FillHoverColor = System.Drawing.Color.HotPink;
            this.button4.FillPressColor = System.Drawing.Color.MediumVioletRed;
            this.button4.FillSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button4.Location = new System.Drawing.Point(709, 400);
            this.button4.MinimumSize = new System.Drawing.Size(1, 1);
            this.button4.Name = "button4";
            this.button4.RectColor = System.Drawing.Color.HotPink;
            this.button4.RectHoverColor = System.Drawing.Color.HotPink;
            this.button4.RectPressColor = System.Drawing.Color.MediumVioletRed;
            this.button4.RectSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button4.Size = new System.Drawing.Size(90, 30);
            this.button4.Style = Sunny.UI.UIStyle.Custom;
            this.button4.TabIndex = 18;
            this.button4.Text = "取消";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button5.FillColor = System.Drawing.Color.DeepPink;
            this.button5.FillHoverColor = System.Drawing.Color.HotPink;
            this.button5.FillPressColor = System.Drawing.Color.MediumVioletRed;
            this.button5.FillSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button5.Location = new System.Drawing.Point(614, 400);
            this.button5.MinimumSize = new System.Drawing.Size(1, 1);
            this.button5.Name = "button5";
            this.button5.RectColor = System.Drawing.Color.HotPink;
            this.button5.RectHoverColor = System.Drawing.Color.HotPink;
            this.button5.RectPressColor = System.Drawing.Color.MediumVioletRed;
            this.button5.RectSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button5.Size = new System.Drawing.Size(90, 30);
            this.button5.Style = Sunny.UI.UIStyle.Custom;
            this.button5.TabIndex = 19;
            this.button5.Text = "确认";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(486, 363);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(105, 21);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 20;
            this.uiLabel1.Text = "替换的部件ID";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.Click += new System.EventHandler(this.uiLabel1_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(169, 363);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(121, 21);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 21;
            this.uiLabel2.Text = "要替换的部件ID";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.Click += new System.EventHandler(this.uiLabel2_Click);
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(3, 363);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(42, 21);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 22;
            this.uiLabel3.Text = "部位";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.Click += new System.EventHandler(this.uiLabel3_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FillColor = System.Drawing.Color.DeepPink;
            this.button1.FillHoverColor = System.Drawing.Color.HotPink;
            this.button1.FillPressColor = System.Drawing.Color.MediumVioletRed;
            this.button1.FillSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button1.Location = new System.Drawing.Point(3, 400);
            this.button1.MinimumSize = new System.Drawing.Size(1, 1);
            this.button1.Name = "button1";
            this.button1.RectColor = System.Drawing.Color.HotPink;
            this.button1.RectHoverColor = System.Drawing.Color.HotPink;
            this.button1.RectPressColor = System.Drawing.Color.MediumVioletRed;
            this.button1.RectSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.Style = Sunny.UI.UIStyle.Custom;
            this.button1.Symbol = 61543;
            this.button1.TabIndex = 23;
            this.button1.Text = "新建";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FillColor = System.Drawing.Color.DeepPink;
            this.button2.FillHoverColor = System.Drawing.Color.HotPink;
            this.button2.FillPressColor = System.Drawing.Color.MediumVioletRed;
            this.button2.FillSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button2.Location = new System.Drawing.Point(109, 400);
            this.button2.MinimumSize = new System.Drawing.Size(1, 1);
            this.button2.Name = "button2";
            this.button2.RectColor = System.Drawing.Color.HotPink;
            this.button2.RectHoverColor = System.Drawing.Color.HotPink;
            this.button2.RectPressColor = System.Drawing.Color.MediumVioletRed;
            this.button2.RectSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.Style = Sunny.UI.UIStyle.Custom;
            this.button2.Symbol = 61460;
            this.button2.TabIndex = 24;
            this.button2.Text = "删除选中";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FillColor = System.Drawing.Color.DeepPink;
            this.button3.FillHoverColor = System.Drawing.Color.HotPink;
            this.button3.FillPressColor = System.Drawing.Color.MediumVioletRed;
            this.button3.FillSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button3.Location = new System.Drawing.Point(215, 400);
            this.button3.MinimumSize = new System.Drawing.Size(1, 1);
            this.button3.Name = "button3";
            this.button3.RectColor = System.Drawing.Color.HotPink;
            this.button3.RectHoverColor = System.Drawing.Color.HotPink;
            this.button3.RectPressColor = System.Drawing.Color.MediumVioletRed;
            this.button3.RectSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.button3.Size = new System.Drawing.Size(100, 30);
            this.button3.Style = Sunny.UI.UIStyle.Custom;
            this.button3.TabIndex = 25;
            this.button3.Text = "保存选中";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnImport
            // 
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.FillColor = System.Drawing.Color.DeepPink;
            this.btnImport.FillHoverColor = System.Drawing.Color.HotPink;
            this.btnImport.FillPressColor = System.Drawing.Color.MediumVioletRed;
            this.btnImport.FillSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.btnImport.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnImport.Location = new System.Drawing.Point(321, 400);
            this.btnImport.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnImport.Name = "btnImport";
            this.btnImport.RectColor = System.Drawing.Color.HotPink;
            this.btnImport.RectHoverColor = System.Drawing.Color.HotPink;
            this.btnImport.RectPressColor = System.Drawing.Color.MediumVioletRed;
            this.btnImport.RectSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.btnImport.Size = new System.Drawing.Size(100, 30);
            this.btnImport.Style = Sunny.UI.UIStyle.Custom;
            this.btnImport.Symbol = 61465;
            this.btnImport.TabIndex = 26;
            this.btnImport.Text = "导入";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FillColor = System.Drawing.Color.DeepPink;
            this.btnExport.FillHoverColor = System.Drawing.Color.HotPink;
            this.btnExport.FillPressColor = System.Drawing.Color.MediumVioletRed;
            this.btnExport.FillSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnExport.Location = new System.Drawing.Point(427, 400);
            this.btnExport.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExport.Name = "btnExport";
            this.btnExport.RectColor = System.Drawing.Color.HotPink;
            this.btnExport.RectHoverColor = System.Drawing.Color.HotPink;
            this.btnExport.RectPressColor = System.Drawing.Color.MediumVioletRed;
            this.btnExport.RectSelectedColor = System.Drawing.Color.MediumVioletRed;
            this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.Style = Sunny.UI.UIStyle.Custom;
            this.btnExport.Symbol = 61587;
            this.btnExport.TabIndex = 27;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // SimulateReplace
            // 
            this.AcceptButton = this.button5;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.button4;
            this.ClientSize = new System.Drawing.Size(803, 434);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimulateReplace";
            this.RectColor = System.Drawing.Color.DeepPink;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "模拟衣服替换";
            this.TitleColor = System.Drawing.Color.DeepPink;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader part;
        private System.Windows.Forms.ColumnHeader original;
        private System.Windows.Forms.ColumnHeader replace;
        private Sunny.UI.UITextBox textBox1;
        private Sunny.UI.UITextBox textBox2;
        private Sunny.UI.UIComboBox comboBox1;
        private Sunny.UI.UIButton button4;
        private Sunny.UI.UIButton button5;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UISymbolButton button1;
        private Sunny.UI.UISymbolButton button2;
        private Sunny.UI.UISymbolButton button3;
        private Sunny.UI.UISymbolButton btnImport;
        private Sunny.UI.UISymbolButton btnExport;
    }
}