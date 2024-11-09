﻿using System;
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
    public partial class frmThreat : Form
    {
        public frmThreat()
        {
            InitializeComponent();
        }

        public const int itemnum = 10;
        const int choicenum = 15;
        const int errornum = 6;
        public static Label[] name = new Label[itemnum];
        /*条目解释*/
        public static ComboBox[] choice = new ComboBox[choicenum];
        public static TextBox[,] txt = new TextBox[itemnum, 9];
        public static TextBox[] sumthreat = new TextBox[9];
        public static double[] sumthreatdata = new double[9];
        public static Label[] lblmentary = new Label[itemnum];
        public static ToolTip[] ttp = new ToolTip[itemnum];
        Label[] labelerror = new Label[errornum] ;
        
        //数据项目输入
        string[] nameitem = new string[itemnum] 
        { "2.1 使用用途", "2.2 设计使用人数", "2.3 人员密度",
        "2.4 象征性","2.5.1 区域1内目标密度","2.5.2 区域2内目标密度",
        "2.5.3 区域3内目标密度","2.6 场地总体可达性",
        "2.7.1 该设施成为目标的可能性","2.7.2 该类型设施成为目标的可能性"};
        string[,] choiceitem = new string[itemnum, choicenum]
        {
            { "第一组","第二组","第三组","","","","","","","","","","","",""},
            { "<200","200-400","400-600","600-800","800-1000","1000-2000","2000-4000","4000-6000","6000-8000","8000-10000","10000-20000","20000-40000","40000-60000","60000-80000","≥80000"},
            {"1/10000","1/1000","1/400","1/40","1/10","","","","","","","","","","" },
            {"很低","低","中等","高","很高","","","","","","","","","","" },
            {"0","1","2","3","≥4","","","","","","","","","","" },
            {"0","1-3","4-6","7-9","≥10","","","","","","","","","","" },
            {"0","1-6","7-12","13-19","≥20","","","","","","","","","","" },
            {"无法到达","可到达","","","","","","","","","","","","","" },
            {"否","是","","","","","","","","","","","","","" },
            {"否","是","","","","","","","","","","","","","" },
        };
        public static double[,,] numitem = new double[itemnum, 9, choicenum]
        {
            { { 0.14, 1.13,1.4,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.14, 1.13,1.4,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.14, 1.13,1.4,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.11, 0.89,1.1,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.11, 0.89,1.1,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            },
            { { 0.14, 0.68,0.85,0.97,1.07,1.11,1.17,1.23,1.28,1.33,1.35,1.36,1.38,1.39,1.4 },
              { 0.14, 0.68,0.85,0.97,1.07,1.11,1.17,1.23,1.28,1.33,1.35,1.36,1.38,1.39,1.4 },
              { 0.14, 0.68,0.85,0.97,1.07,1.11,1.17,1.23,1.28,1.33,1.35,1.36,1.38,1.39,1.4 },
              { 0.11, 0.53,0.67,0.77,0.84,0.87,0.92,0.96,1.00,1.04,1.06,1.07,1.08,1.09,1.1 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.11, 0.53,0.67,0.77,0.84,0.87,0.92,0.96, 1.00, 1.04, 1.06, 1.07, 1.08,1.09,1.1 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            },
            { { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.11, 0.81,0.93,1.02,1.1,0,0,0,0,0,0,0,0,0,0 },
              { 0.30, 2.21,2.53,2.78,3.0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.11, 0.81,0.93,1.02,1.1,0,0,0,0,0,0,0,0,0,0 },
              { 0.30, 2.21,2.53,2.78,3.0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            },
            { { 0.29, 2.14,2.45,2.69,2.9,0,0,0,0,0,0,0,0,0,0 },
              { 0.29, 2.14,2.45,2.69,2.9,0,0,0,0,0,0,0,0,0,0 },
              { 0.29, 2.14,2.45,2.69,2.9,0,0,0,0,0,0,0,0,0,0 },
              { 0.24, 1.77,2.02,2.23,2.4,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.24, 1.77,2.02,2.23,2.4,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            },
            { { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.12, 0.88,1.01,1.11,1.2,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.12, 0.88,1.01,1.11,1.2,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            },
            { { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.30, 2.21,2.53,2.78,3.0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.30, 2.21,2.53,2.78,3.0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            },
            { { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.80, 5.89,6.75,7.43,8.0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.80, 5.89,6.75,7.43,8.0,0,0,0,0,0,0,0,0,0,0 }
            },
            { { 0.14, 1.4,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.14, 1.4,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.14, 1.4,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.06, 0.6,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.06, 0.6,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            },
            { { 0.15, 1.45,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.15, 1.45,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.15, 1.45,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.13, 1.25,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.2, 2,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.1, 1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.13, 1.25,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.2, 2,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.1, 1,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            },
            { { 0.15, 1.45,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.15, 1.45,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.15, 1.45,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.13, 1.25,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.2, 2,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.1, 1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.13, 1.25,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.2, 2,0,0,0,0,0,0,0,0,0,0,0,0,0 },
              { 0.1, 1,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            }
        };
        string[] mentaryitem = new string[itemnum]
        {
            "建筑的使用功能",
            "使用人数，与建筑信息页一致（单位：人）",
            "建筑附近区域人员密度（单位：人/m^2）",
            "该建筑在公众心目中的知名度",
            "建筑物一定距离内的高价值目标数量，与建筑信息页一致",
            "建筑物一定距离内的高价值目标数量，与建筑信息页一致",
            "建筑物一定距离内的高价值目标数量，与建筑信息页一致",
            "现场的可访问性",
            "该设施成为目标的可能性，与建筑信息页一致",
            "该类型设施成为目标的可能性，与建筑信息页一致"
        };

        private void frmThreat_Load(object sender, EventArgs e)
        {
            Function.Load(this, itemnum, choicenum, name, nameitem, lblmentary , ttp, mentaryitem, choice, choiceitem, txt, sumthreat);
            for (int i = 0; i < errornum; i++)
                labelerror[i] = new Label();
            labelerror[0].Top = 135;
            labelerror[0].Left = 315;
            labelerror[0].Height = 20;
            labelerror[0].ForeColor = Color.Red;
            labelerror[1].Top = 225;
            labelerror[1].Left = 315;
            labelerror[1].Height = 20;
            labelerror[1].ForeColor = Color.Red;
            labelerror[2].Top = 255;
            labelerror[2].Left = 315;
            labelerror[2].Height = 20;
            labelerror[2].ForeColor = Color.Red;
            labelerror[3].Top = 285;
            labelerror[3].Left = 315;
            labelerror[3].Height = 20;
            labelerror[3].ForeColor = Color.Red;
            labelerror[4].Top = 345;
            labelerror[4].Left = 315;
            labelerror[4].Height = 20;
            labelerror[4].ForeColor = Color.Red;
            labelerror[5].Top = 375;
            labelerror[5].Left = 315;
            labelerror[5].Height = 20;
            labelerror[5].ForeColor = Color.Red;
            for (int i = 0; i < errornum; i++)
                this.Controls.Add(labelerror[i]);
        }

        private void check_intdata(ComboBox[] choice, Label[] labelerror)
        {
            int i, j;
            //使用人数
            int standard1 = int.Parse(frmInformation.check_text[8]);
            int sample1 = choice[1].SelectedIndex;
            int[] library1 = new int[15]{0,200,400,600,800,1000,2000,4000,6000,8000,10000,20000,40000,60000,80000};
            for (i = 0; i < 14; i++)
            {
                if ((standard1 >= library1[i] && standard1 <= library1[i + 1]) || (standard1 >= library1[14]))
                {
                    if (sample1 == i)
                        labelerror[0].Text = "";
                    else
                        labelerror[0].Text = "!";
                }
            }
            //目标密度
            int[] standard2 = new int[3];
            int[] sample2 = new int[3];
            for (int k = 0;k<3;k++ )
            {
                standard2[k] = int.Parse(frmInformation.check_text[16 + k]);
                sample2[k] = choice[4+k].SelectedIndex;
            }
            int[,] library2 = new int[3, 5] { { 0, 1, 2, 3, 4 }, { 0, 1, 4, 7, 10 }, { 0, 1, 7, 13, 20 } };
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 4; j++ )
                {
                    if ((standard2[i] >= library2[i,j] && standard2[i] < library2[i,j+1]) || (standard2[i] >= library2[i,4]))
                    {
                        if (sample2[i] == j)
                            labelerror[i + 1].Text = "";
                        else
                            labelerror[i + 1].Text = "!";
                    }
                }
            }
            //成为目标的可能性
            string[] standard3 = new string[2];
            string[] sample3 = new string[2];
            for(int k =0;k<2;k++)
            {
                standard3[k] = frmInformation.check_text[14 + k];
                sample3[k] = choice[8 + k].SelectedItem.ToString();
            }
            string[,] library3 = new string[2,2] { {"否","是" },{ "否","是"} };
            for (i = 0; i < 2; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    if (standard3[i] == library3[i, j])
                    {
                        if (sample3[i] == library3[i, j])
                            labelerror[i + 4].Text = "";
                        else
                            labelerror[i + 4].Text = "!";
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Function.OK(txt, sumthreat, choice, numitem, 10, sumthreatdata);
            check_intdata(choice, labelerror);
        }

    }
}