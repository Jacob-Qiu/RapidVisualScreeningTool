using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rapid_visual_screening_tools_1._0
{
    public partial class frmInformation : Form
    {
        const int itemnum = 16;
        const int targetnum = 19;
        public static Label[] name = new Label[itemnum];
        public static Label[] targetname = new Label[targetnum];
        Label labelerror = new Label
        {
            Top = 135,
            Left = 305,
            Height = 50,
            ForeColor = Color.Red,
        };
        public static TextBox[] txt = new TextBox[itemnum];
        public static TextBox[,] targettxt = new TextBox[targetnum,3];
        public static DateTimePicker[] dtp = new DateTimePicker[2];
        public static ComboBox[] cb = new ComboBox[2];
        public static string[] check_text = new string[itemnum + 3]{"","","","","","","0","0.0","0","0.0","0.0","","","0.0","","","0","0","0"};

        public frmInformation()
        {
            InitializeComponent();
        }



        //数据项目
        string[] nameitem = new string[itemnum]
        {
            "建筑名称", "地址", "建造时间","翻新时间","翻修内容","玻璃类型","建筑层数","建筑高度(m)","使用人数",
            "建筑面积(m^2)","占地面积(m^2)","使用功能","危险物品存放情况","更换价值(亿元)","该设施为潜在袭击目标","该类型设施为潜在袭击目标"
        };

        string[] target_name = new string[targetnum]
        {
            "农业食品","银行金融","化学工业",
            "   商  业   ","制  造  业","水利设施","国防工业",
            "紧急服务","能源设施","政府设施","信息技术","国家地标",
            "核  工  业","邮政航运","公共健康","通信技术","交通运输","供水设施","   合  计   "
        };

        //窗口项目加载
        private void Information_Load(object sender, EventArgs e)
        {
            this.Controls.Add(labelerror);
            //加载场地信息
            for (int i = 0; i < itemnum; i++)
            {
                //创建项目名称
                name[i] = new Label
                {
                    Top = 40 + 30 * (i + 1),
                    Left = 20,
                    Width = 150,
                    Text = nameitem[i],
                    TextAlign = ContentAlignment.MiddleCenter
                };
                this.Controls.Add(name[i]);
                //创建文本框、时间框、下拉框
                if (i == 2|| i == 3)
                {
                    dtp[i - 2] = new DateTimePicker
                    {
                        Top = 40 + 30 * (i + 1),
                        Left = 180,
                        Width = 120
                    };
                    this.Controls.Add(dtp[i - 2]);
                }
                else if (i == 6 || i == 8)
                {
                    txt[i] = new TextBox
                    {
                        Top = 40 + 30 * (i + 1),
                        Left = 180,
                        Width = 200
                    };
                    // 添加KeyPress事件处理程序
                    txt[i].KeyPress += new KeyPressEventHandler(textBox_KeyPress1);
                    this.Controls.Add(txt[i]);
                }
                else if (i == 7 || i == 9 || i == 10 || i == 13)
                {
                    txt[i] = new TextBox
                    {
                        Top = 40 + 30 * (i + 1),
                        Left = 180,
                        Width = 200
                    };
                    // 添加KeyPress事件处理程序
                    txt[i].KeyPress += new KeyPressEventHandler(textBox_KeyPress2);
                    this.Controls.Add(txt[i]);
                }
                else if (i == 14 || i == 15)
                {
                    cb[i - 14] = new ComboBox
                    {
                        Top = 40 + 30 * (i + 1),
                        Left = 180,
                        Width = 200,
                        DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList,
                    };
                    cb[i - 14].Items.Add("否");
                    cb[i - 14].Items.Add("是");
                    cb[i - 14].SelectedIndex = 0;
                    this.Controls.Add(cb[i-14]);
                }
                else
                {
                    txt[i] = new TextBox
                    {
                        Top = 40 + 30 * (i + 1),
                        Left = 180,
                        Width = 200
                    };
                    this.Controls.Add(txt[i]);
                }
            }


            //加载目标密度
            for (int i = 0; i < targetnum; i++) 
            {
                //创建项目名称
                if (i!=18)
                {
                    targetname[i] = new Label
                    {
                        Top = 122 + 20 * (i + 1),
                        Left = 430,
                        Width = 100,
                        Height = 15,
                        Text = target_name[i],
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    this.Controls.Add(targetname[i]);
                    //创建文本框
                    for (int j = 0; j < 3; j++)
                    {
                        targettxt[i, j] = new TextBox
                        {
                            Top = 120 + 20 * (i + 1),
                            Left = 428 + 110 * (j + 1),
                            Width = 100,
                            Height = 15,
                        };
                        // 添加KeyPress事件处理程序
                        targettxt[i, j].KeyPress += new KeyPressEventHandler(textBox_KeyPress2);
                        this.Controls.Add(targettxt[i, j]);
                    }
                }
                else
                {
                    targetname[i] = new Label
                    {
                        Top = 508,
                        Left = 430,
                        Width = 100,
                        Height = 30,
                        Text = target_name[i],
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    this.Controls.Add(targetname[i]);
                    //创建文本框
                    for (int j = 0; j < 3; j++)
                    {
                        targettxt[i, j] = new TextBox
                        {
                            Top = 510,
                            Left = 428 + 110 * (j + 1),
                            Width = 100,
                            Height = 30,
                            ReadOnly = true
                        };
                        // 添加KeyPress事件处理程序
                        targettxt[i, j].KeyPress += new KeyPressEventHandler(textBox_KeyPress1);
                        this.Controls.Add(targettxt[i, j]);
                    }
                }
            }
        }

        private void check_date(DateTimePicker[] dtp)
        //时间框合理性判别，即修缮时间不应早于修建时间，否则出提示
        {
            if (dtp[1].Value <= dtp[0].Value)
                labelerror.Text = "翻新时间不得早于建造时间！！";
            else
                labelerror.Text = "";
        }

        private void calculate_num(TextBox[,] targettxt ,string[] check_text)
        //计算合计
        {
            for(int j=0;j<3;j++)
            {
                int sum = 0;
                for(int i =0;i<18;i++)
                {
                    if (targettxt[i, j].Text == "")
                        sum += 0;
                    else
                        sum += int.Parse(targettxt[i, j].Text);
                }
                check_text[16 + j] = sum.ToString();
                targettxt[18, j].Text = check_text[16 + j];
            }

        }

        private void record_text(string[] check_text)
        //记录输入的数据
        {
            for(int i =0;i<16;i++)
            {
                if (i == 2 || i == 3)
                    check_text[i] = dtp[i - 2].Value.ToString();
                else if (i == 14 || i == 15)
                    check_text[i] = cb[i - 14].SelectedItem.ToString();
                else if (i == 7 || i == 9 || i == 10 || i == 13)
                {
                    if (txt[i].Text == "")
                        txt[i].Text = "0.0";
                    check_text[i] = txt[i].Text;
                }
                else if (i == 6 || i == 8)
                {
                    if (txt[i].Text == "")
                        txt[i].Text = "0";
                    check_text[i] = txt[i].Text;
                }
                else
                    check_text[i] = txt[i].Text;
            }
        }


        // 在KeyPress事件处理程序中实现限制输入的逻辑，只允许输入数字、退格符
        void textBox_KeyPress1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // 在KeyPress事件处理程序中实现限制输入的逻辑，只允许输入数字、1个小数点、退格符
        void textBox_KeyPress2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // 只允许一个小数点
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            check_date(dtp);
            calculate_num(targettxt,check_text);
            record_text(check_text);
        }
    }
}
