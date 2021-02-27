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
    public partial class SimulateReplace : Form
    {
        public List<Dictionary<string, string>> dict { get; }

        public SimulateReplace()
        {
            InitializeComponent();
        }

        public SimulateReplace(List<Dictionary<string, string>> dict)
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            this.dict = dict;

            foreach (Dictionary<string, string> e in this.dict)
            {
                e.TryGetValue("part", out string part);
                e.TryGetValue("original", out string original);
                e.TryGetValue("replace", out string replace);
                ListViewItem ee = new ListViewItem();
                switch (part)
                {
                    case "coat": ee = listView1.Items.Add("上衣"); break;
                    case "pants": ee = listView1.Items.Add("下装"); break;
                    case "hair": ee = listView1.Items.Add("头发"); break;
                    case "belt": ee = listView1.Items.Add("腰带"); break;
                    case "shoes": ee = listView1.Items.Add("鞋子"); break;
                    case "wings": ee = listView1.Items.Add("翅膀"); break;
                    case "cap": ee = listView1.Items.Add("帽子"); break;
                    case "face": ee = listView1.Items.Add("脸部"); break;
                    case "hand": ee = listView1.Items.Add("手部"); break;
                    case "item": ee = listView1.Items.Add("道具"); break;
                    case "feet": ee = listView1.Items.Add("足部"); break;
                    case "neck": ee = listView1.Items.Add("项链"); break;
                    case "earring": ee = listView1.Items.Add("耳环"); break;
                    case "eyes": ee = listView1.Items.Add("眼睛"); break;
                    case "brow": ee = listView1.Items.Add("眉毛"); break;
                    case "mouth": ee = listView1.Items.Add("嘴巴"); break;
                    default: break;
                }
                ee.SubItems.Add(original);
                ee.SubItems.Add(replace);
                ee.EnsureVisible();
            }

            // ListViewItem test1 = listView1.Items.Add("上衣");
            // test1.SubItems.Add("1400451"); test1.SubItems.Add("1400684");
            // test1.EnsureVisible();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.updateDict();
            this.DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                ListViewItem test1 = listView1.Items.Add("上衣");
                test1.SubItems.Add("请输入要替换ID"); test1.SubItems.Add("请输入替换ID");
                test1.EnsureVisible();
                test1.Selected = true;
            } else
            {
                string part = "";
                switch (this.comboBox1.SelectedItem)
                {
                    case "上衣": part = "上衣"; break;
                    case "下装": part = "下装"; break;
                    case "头发": part = "头发"; break;
                    case "腰带": part = "腰带"; break;
                    case "鞋子": part = "鞋子"; break;
                    case "翅膀": part = "翅膀"; break;

                    case "帽子": part = "帽子"; break;
                    case "脸部": part = "脸部"; break;
                    case "手部": part = "手部"; break;
                    case "道具": part = "道具"; break;
                    case "足部": part = "足部"; break;
                    case "项链": part = "项链"; break;
                    case "耳环": part = "耳环"; break;

                    case "眼睛": part = "眼睛"; break;
                    case "眉毛": part = "眉毛"; break;
                    case "嘴巴": part = "嘴巴"; break;
                    default: break;
                }
                ListViewItem test1 = listView1.Items.Add(part);
                test1.SubItems.Add(textBox1.Text); test1.SubItems.Add(textBox2.Text);
                test1.EnsureVisible();
                test1.Selected = true;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                switch (listView1.SelectedItems[0].SubItems[0].Text)
                {
                    case "上衣": this.comboBox1.SelectedItem = "上衣"; break;
                    case "下装": this.comboBox1.SelectedItem = "下装"; break;
                    case "头发": this.comboBox1.SelectedItem = "头发"; break;
                    case "腰带": this.comboBox1.SelectedItem = "腰带"; break;
                    case "鞋子": this.comboBox1.SelectedItem = "鞋子"; break;
                    case "翅膀": this.comboBox1.SelectedItem = "翅膀"; break;

                    case "帽子": this.comboBox1.SelectedItem = "帽子"; break;
                    case "脸部": this.comboBox1.SelectedItem = "脸部"; break;
                    case "手部": this.comboBox1.SelectedItem = "手部"; break;
                    case "道具": this.comboBox1.SelectedItem = "道具"; break;
                    case "足部": this.comboBox1.SelectedItem = "足部"; break;
                    case "项链": this.comboBox1.SelectedItem = "项链"; break;
                    case "耳环": this.comboBox1.SelectedItem = "耳环"; break;

                    case "眼睛": this.comboBox1.SelectedItem = "眼睛"; break;
                    case "眉毛": this.comboBox1.SelectedItem = "眉毛"; break;
                    case "嘴巴": this.comboBox1.SelectedItem = "嘴巴"; break;
                    default: break;
                }
                this.textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
                this.textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void updateDict()
        {
            this.dict.Clear();
            foreach (ListViewItem x in this.listView1.Items)
            {
                string part = "";
                switch (x.SubItems[0].Text)
                {
                    case "上衣": part = "coat"; break;
                    case "下装": part = "pants"; break;
                    case "头发": part = "hair"; break;
                    case "腰带": part = "belt"; break;
                    case "鞋子": part = "shoes"; break;
                    case "翅膀": part = "wings"; break;
                    case "帽子": part = "cap"; break;

                    case "脸部": part = "face"; break;
                    case "手部": part = "hand"; break;
                    case "道具": part = "item"; break;
                    case "足部": part = "feet"; break;
                    case "项链": part = "neck"; break;
                    case "耳环": part = "earring"; break;

                    case "眼睛": part = "eyes"; break;
                    case "眉毛": part = "brow"; break;
                    case "嘴巴": part = "mouth"; break;
                    default: break;
                }
                Dictionary<string, string> e = new Dictionary<string, string>
                {
                    { "part" , part }, { "original" , x.SubItems[1].Text }, { "replace" , x.SubItems[2].Text },
                };
                this.dict.Add(e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                button1_Click(sender, e);
                return;
            }
            switch (this.comboBox1.SelectedItem)
            {
                case "上衣": listView1.SelectedItems[0].SubItems[0].Text = "上衣"; break;
                case "下装": listView1.SelectedItems[0].SubItems[0].Text = "下装"; break;
                case "头发": listView1.SelectedItems[0].SubItems[0].Text = "头发"; break;
                case "腰带": listView1.SelectedItems[0].SubItems[0].Text = "腰带"; break;
                case "鞋子": listView1.SelectedItems[0].SubItems[0].Text = "鞋子"; break;
                case "翅膀": listView1.SelectedItems[0].SubItems[0].Text = "翅膀"; break;

                case "帽子": listView1.SelectedItems[0].SubItems[0].Text = "帽子"; break;
                case "脸部": listView1.SelectedItems[0].SubItems[0].Text = "脸部"; break;
                case "手部": listView1.SelectedItems[0].SubItems[0].Text = "手部"; break;
                case "道具": listView1.SelectedItems[0].SubItems[0].Text = "道具"; break;
                case "足部": listView1.SelectedItems[0].SubItems[0].Text = "足部"; break;
                case "项链": listView1.SelectedItems[0].SubItems[0].Text = "项链"; break;
                case "耳环": listView1.SelectedItems[0].SubItems[0].Text = "耳环"; break;

                case "眼睛": listView1.SelectedItems[0].SubItems[0].Text = "眼睛"; break;
                case "眉毛": listView1.SelectedItems[0].SubItems[0].Text = "眉毛"; break;
                case "嘴巴": listView1.SelectedItems[0].SubItems[0].Text = "嘴巴"; break;
                default: break;
            }
            listView1.SelectedItems[0].SubItems[1].Text = this.textBox1.Text;
            listView1.SelectedItems[0].SubItems[2].Text = this.textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }
    }
}
