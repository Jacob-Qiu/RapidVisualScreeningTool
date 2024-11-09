using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace rapid_visual_screening_tools_1._0
{
    class Function
    {
        public static string filepath;

        //切换窗口功能
        public static void ChangeForm
            (Button change, Color fore1, Color back1,
            Button unchange1, Button unchange2, Button unchange3, Button unchange4, Button unchange5, Color fore2, Color back2,
            Form frmchange, Panel panel1)
        {
            change.BackColor = back1;
            change.ForeColor = fore1;
            unchange1.BackColor = back2;
            unchange1.ForeColor = fore2;
            unchange2.BackColor = back2;
            unchange2.ForeColor = fore2;
            unchange3.BackColor = back2;
            unchange3.ForeColor = fore2;
            unchange4.BackColor = back2;
            unchange4.ForeColor = fore2;
            unchange5.BackColor = back2;
            unchange5.ForeColor = fore2;
            frmchange.Show();
            frmchange.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(frmchange);
            frmchange.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        //frmConsequence,frmThreat,frmVulnerability窗口加载
        public static void Load(Form frm, int itemnum, int choicenum, Label[] name, string[] nameitem, Label[] lblmentary, ToolTip[] ttp, string[] mentaryitem, ComboBox[] choice, string[,] choiceitem, TextBox[,] txt, TextBox[] sum)
        {
            int i, j, k;
            //创建单个条目
            for (i = 0; i < itemnum; i++)
            {
                //创建项目名称
                name[i] = new Label();
                name[i].Top = 70 + 30 * (i + 1);
                name[i].Left = 100;
                name[i].Width = 200;
                name[i].Text = nameitem[i];
                name[i].TextAlign = ContentAlignment.MiddleCenter;
                frm.Controls.Add(name[i]);
                //创建项目选项
                choice[i] = new ComboBox();
                choice[i].Top = 70 + 30 * (i + 1);
                choice[i].Left = 375;
                choice[i].Width = 100;
                choice[i].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                for (j = 0; j < choicenum; j++)
                {
                    if (choiceitem[i, j] != "")
                    {
                        choice[i].Items.Add(choiceitem[i, j]);
                    }
                }
                choice[i].TabIndex = i;
                frm.Controls.Add(choice[i]);
                choice[i].SelectedIndex = 0;
                //创建项目注释
                lblmentary[i] = new Label();
                lblmentary[i].Top = 70 + 30 * (i + 1);
                lblmentary[i].Left = 330;
                lblmentary[i].Width = 20;
                lblmentary[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                lblmentary[i].Text = "?";
                lblmentary[i].TextAlign = ContentAlignment.MiddleCenter;
                frm.Controls.Add(lblmentary[i]);
                ttp[i] = new ToolTip();
                ttp[i].SetToolTip(lblmentary[i], mentaryitem[i]);
                //创建项目评分栏
                for (k = 0; k < 9; k++)
                {
                    txt[i, k] = new TextBox();
                    txt[i, k].Top = 70 + 30 * (i + 1);
                    txt[i, k].Left = 490 + 40 * k;
                    txt[i, k].Width = 35;
                    txt[i, k].ReadOnly = true;
                    txt[i, k].TabIndex = 10000;
                    frm.Controls.Add(txt[i, k]);
                }
            }
            //创建汇总栏
            for (k = 0; k < 9; k++)
            {
                sum[k] = new TextBox();
                sum[k].Top = 70 + 30 * (itemnum + 1) + 10;
                sum[k].Left = 490 + 40 * k;
                sum[k].Width = 35;
                sum[k].ReadOnly = true;
                frm.Controls.Add(sum[k]);
            }
        }

        //frmConsequence,frmThreat,frmVulnerability确认计算按钮
        public static void OK(TextBox[,] txt, TextBox[] sum, ComboBox[] choice, double[,,] numitem, int itemnum, double[] sumcondata)
        {
            int i, j;
            double[] sumnum = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (j = 0; j < 9; j++)
            {
                for (i = 0; i < itemnum; i++)
                {
                    txt[i, j].Text = numitem[i, j, choice[i].SelectedIndex].ToString();
                    sumnum[j] += numitem[i, j, choice[i].SelectedIndex];
                }
                sum[j].Text = sumnum[j].ToString();
            }
            for (int k = 0; k < 9; k++)
                sumcondata[k] = double.Parse(sum[k].Text);
        }

        //风险计算窗口（frmRisk）加载
        public static void frmRiskLoad(Form frm, TextBox[,] txt, TextBox sumrisk)
        {
            int i, k;
            for (i = 0; i < 9; i++)
            {
                //创建项目评分栏
                for (k = 0; k < 3; k++)
                {
                    txt[i, k] = new TextBox();
                    txt[i, k].Top = 266 + 33 * (i - 5);
                    txt[i, k].Left = 230 + 150 * k;
                    txt[i, k].Width = 125;
                    txt[i, k].ReadOnly = true;
                    txt[i, k].TabIndex = 10000;
                    frm.Controls.Add(txt[i, k]);
                }
                txt[i, 3] = new TextBox();
                txt[i, 3].Top = 266 + 33 * (i - 5);
                txt[i, 3].Left = 230 + 150 * 3;
                txt[i, 3].Width = 185;
                txt[i, 3].ReadOnly = true;
                txt[i, 3].TabIndex = 10000;
                frm.Controls.Add(txt[i, 3]);
            }
            sumrisk.Top = 403;
            sumrisk.Left = 230 + 150 * 3;
            sumrisk.Width = 185;
            sumrisk.ReadOnly = true;
            sumrisk.TabIndex = 10000;
            frm.Controls.Add(sumrisk);
        }

        //风险窗口frmRisk确认计算按钮
        public static void frmRiskOK(TextBox[,] txt, TextBox sum, double[] sumcondata, double[] sumthreatdata, double[] sumvuldata)
        {
            int i;
            double[] sumnum = new double[9];
            double sumsum;
            double temp = 0;
            for (i = 0; i < 9; i++)
            {
                txt[i, 0].Text = sumcondata[i].ToString();
                txt[i, 1].Text = sumthreatdata[i].ToString();
                txt[i, 2].Text = sumvuldata[i].ToString();
                sumnum[i] = sumcondata[i] * sumthreatdata[i] * sumvuldata[i];
                txt[i, 3].Text = sumnum[i].ToString();
                temp += Math.Pow(sumnum[i], 10);
            }
            sumsum = 7.227 * Math.Pow(temp, 0.1);
            sum.Text = sumsum.ToString();
        }

        //保存为数据文件
        public static void fSavemore(Form frm)
        {
            //场地信息
            int imnum = 16;
            string[] imname = new string[imnum];
            string[] imtext = new string[imnum];
            //目标密度信息
            int targetnum = 19;
            string[] targetname = new string[targetnum];
            string[,] targettext = new string[targetnum, 3];
            //选项信息
            int itemnum = 57;
            string[] choicename = new string[itemnum];
            int[] choiceindex = new int[itemnum];
            int sumnum = imnum + targetnum + itemnum;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "另存为";
            saveFileDialog.FileName = "评估工具";
            saveFileDialog.Filter = "CSV Files(*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = File.CreateText(saveFileDialog.FileName); //保存到指定路径
                //保存场地信息
                for (int i = 0; i < imnum; i++)
                {
                    imname[i] = frmInformation.name[i].Text;
                    if (i == 2 || i == 3)
                        imtext[i] = frmInformation.dtp[i - 2].Value.ToString();
                    else if (i == 14 || i == 15)
                        imtext[i] = frmInformation.cb[i - 14].SelectedIndex.ToString();
                    else
                        imtext[i] = frmInformation.txt[i].Text;
                    sw.WriteLine(imname[i] + "," + imtext[i]);
                }
                //保存目标密度信息
                for (int i = 0; i < targetnum; i++)
                {
                    targetname[i] = frmInformation.targetname[i].Text;
                    for (int j = 0; j < 3; j++)
                        targettext[i, j] = frmInformation.targettxt[i, j].Text;
                    sw.WriteLine(targetname[i] + "," + targettext[i, 0] + "," + targettext[i, 1] + "," + targettext[i, 2]);
                }
                //保存选项信息
                for (int i = 0; i < itemnum; i++)
                {
                    if (i < 6)
                    {
                        choiceindex[i] = frmConsequence.choice[i].SelectedIndex;
                        choicename[i] = frmConsequence.name[i].Text;
                    }
                    else if (i >= 6 && i < 16)
                    {
                        choiceindex[i] = frmThreat.choice[i - 6].SelectedIndex;
                        choicename[i] = frmThreat.name[i - 6].Text;
                    }
                    else
                    {
                        choiceindex[i] = frmVulnerability.choice[i - 16].SelectedIndex;
                        choicename[i] = frmVulnerability.name[i - 16].Text;
                    }
                    //line[i] = $"{choicename[i]}, {choiceindex[i]}";
                    sw.WriteLine(choicename[i] + "," + choiceindex[i]);
                }
                string localFilePath = saveFileDialog.FileName.ToString(); //获得文件路径
                frm.Text = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                sw.Flush();
                sw.Close();
            }
        }

        //更新已有数据文件
        public static void fSave(Form frm)
        {
            using (StreamWriter writer = new StreamWriter(filepath, false))
            {
                //场地信息
                int imnum = 16;
                string[] imname = new string[imnum];
                string[] imtext = new string[imnum];
                //目标密度信息
                int targetnum = 19;
                string[] targetname = new string[targetnum];
                string[,] targettext = new string[targetnum, 3];
                //选项信息
                int itemnum = 57;
                string[] choicename = new string[itemnum];
                int[] choiceindex = new int[itemnum];
                int sumnum = imnum + targetnum + itemnum;
                //保存场地信息
                for (int i = 0; i < imnum; i++)
                {
                    imname[i] = frmInformation.name[i].Text;
                    if (i == 2 || i == 3)
                        imtext[i] = frmInformation.dtp[i - 2].Value.ToString();
                    else if (i == 14 || i == 15)
                        imtext[i] = frmInformation.cb[i - 14].SelectedIndex.ToString();
                    else
                        imtext[i] = frmInformation.txt[i].Text;
                    writer.WriteLine(imname[i] + "," + imtext[i]);
                }
                //保存目标密度信息
                for (int i = 0; i < targetnum; i++)
                {
                    targetname[i] = frmInformation.targetname[i].Text;
                    for (int j = 0; j < 3; j++)
                        targettext[i, j] = frmInformation.targettxt[i, j].Text;
                    writer.WriteLine(targetname[i] + "," + targettext[i, 0] + "," + targettext[i, 1] + "," + targettext[i, 2]);
                }
                //保存选项信息
                for (int i = 0; i < itemnum; i++)
                {
                    if (i < 6)
                    {
                        choiceindex[i] = frmConsequence.choice[i].SelectedIndex;
                        choicename[i] = frmConsequence.name[i].Text;
                    }
                    else if (i >= 6 && i < 16)
                    {
                        choiceindex[i] = frmThreat.choice[i - 6].SelectedIndex;
                        choicename[i] = frmThreat.name[i - 6].Text;
                    }
                    else
                    {
                        choiceindex[i] = frmVulnerability.choice[i - 16].SelectedIndex;
                        choicename[i] = frmVulnerability.name[i - 16].Text;
                    }
                    //line[i] = $"{choicename[i]}, {choiceindex[i]}";
                    writer.WriteLine(choicename[i] + "," + choiceindex[i]);
                }

            }
        }

        //打开已有数据文件
        public static void fOpen(Form frm)
        {
            int itemnum = 57;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开文件";
            openFileDialog.Filter = "CSV Files(*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 读取场地信息
                string[,] sitedata = ReadDataRange(openFileDialog.FileName, 1, 16, 2, 2);
                //读取目标密度信息
                string[,] targetdata = ReadDataRange(openFileDialog.FileName, 17, 35, 2, 4);
                //读取选项信息
                string[,] choicedata = ReadDataRange(openFileDialog.FileName, 36, 92, 2, 2);
                //输入场地信息
                for (int i = 0; i < 16; i++)
                {
                    if (i == 2 || i == 3)
                    {
                        // 将字符串解析为 DateTime 对象
                        if (DateTime.TryParseExact(sitedata[i, 0], "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out DateTime dateTime))
                            frmInformation.dtp[i - 2].Value = dateTime;
                        else
                            Console.WriteLine("无法将字符串转换为 DateTime");
                    }
                    else if (i == 14 || i == 15)
                        frmInformation.cb[i - 14].SelectedIndex = int.Parse(sitedata[i, 0]);
                    else
                        frmInformation.txt[i].Text = sitedata[i, 0];
                }
                //输入目标密度信息
                for (int i = 0; i < 19; i++)
                    for (int j = 0; j < 3; j++)
                        frmInformation.targettxt[i, j].Text = targetdata[i, j];
                //输入选项信息
                for (int i = 0; i < 57; i++)
                {
                    if (i < 6)
                        frmConsequence.choice[i].SelectedIndex = int.Parse(choicedata[i, 0]);
                    else if (i >= 6 && i < 16)
                        frmThreat.choice[i - 6].SelectedIndex = int.Parse(choicedata[i, 0]);
                    else
                        frmVulnerability.choice[i - 16].SelectedIndex = int.Parse(choicedata[i, 0]);
                }
                OK(frmConsequence.txt, frmConsequence.sumcon, frmConsequence.choice, frmConsequence.numitem, frmConsequence.itemnum, frmConsequence.sumcondata);
                OK(frmThreat.txt, frmThreat.sumthreat, frmThreat.choice, frmThreat.numitem, frmThreat.itemnum, frmThreat.sumthreatdata);
                OK(frmVulnerability.txt, frmVulnerability.sumvul, frmVulnerability.choice, frmVulnerability.numitem, frmVulnerability.itemnum, frmVulnerability.sumvuldata);
                frmRiskOK(frmRisk.txt, frmRisk.sumrisk, frmConsequence.sumcondata, frmThreat.sumthreatdata, frmVulnerability.sumvuldata);
            }
            string localFilePath = openFileDialog.FileName.ToString(); //获得文件路径
            filepath = localFilePath;
            frm.Text = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
        }

        //读取数据文件中连续几行、连续几列的数据
        public static string[,] ReadDataRange(string filePath, int startRow, int endRow, int startColumn, int endColumn)
        {
            // 计算需要读取的数据的行数和列数
            int rowCount = endRow - startRow + 1;
            int columnCount = endColumn - startColumn + 1;

            // 创建一个二维数组来存储读取到的数据
            string[,] data = new string[rowCount, columnCount];

            using (StreamReader reader = new StreamReader(filePath))
            {
                for (int i = 0; i < endRow; i++)
                {
                    // 跳过指定的起始行数
                    if (i < startRow - 1)
                    {
                        reader.ReadLine();
                        continue;
                    }

                    string line = reader.ReadLine();
                    string[] columns = line.Split(',');

                    // 跳过不在指定列范围内的数据
                    if (columns.Length < endColumn)
                    {
                        Console.WriteLine($"行的列数不足：{line}");
                        continue;
                    }

                    for (int j = startColumn - 1; j <= endColumn - 1; j++)
                    {
                        // 将每个元素直接存储到字符串数组中
                        data[i - startRow + 1, j - startColumn + 1] = columns[j];
                    }
                }
            }

            return data;
        }

        //导出结果文件
        public static void fOutput(Form frm)
        {
            //场地信息
            int imnum = 16;
            string[] imname = new string[imnum];
            string[] imtext = new string[imnum];
            //目标密度信息
            int targetnum = 19;
            string[] targetname = new string[targetnum];
            string[,] targettext = new string[targetnum, 3];
            //选项信息
            int itemnum = 57;
            string[] choicename = new string[itemnum];
            string[] choiceitem = new string[itemnum];
            //风险信息
            int risknum = 9;
            string[] riskname = new string[]{ "内    部    入    侵", "内    部    爆    炸", "内   部   C   B   R", "外部爆炸区域一", "外部爆炸区域二", "外部爆炸区域三", "外部CBR区域一", "外部CBR区域二", "外部CBR区域三" };
            string[,] risktxt = new string[risknum, 4];

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "导出";
            saveFileDialog.FileName = "风险评估结果";
            saveFileDialog.Filter = "TXT Files(*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = File.CreateText(saveFileDialog.FileName); //保存到指定路径
                sw.WriteLine("                                                      建筑风险评估结果");
                sw.WriteLine("****************************************************************************");
                sw.WriteLine("");
                //保存场地信息
                sw.WriteLine("一、场地信息");
                sw.WriteLine("");
                for (int i = 0; i < imnum; i++)
                {
                    imname[i] = frmInformation.name[i].Text;
                    if (i == 2 || i == 3)
                        imtext[i] = frmInformation.dtp[i - 2].Value.ToString("yyyy/MM/dd");
                    else if (i == 14 || i == 15)
                        imtext[i] = frmInformation.cb[i - 14].SelectedItem.ToString();
                    else
                        imtext[i] = frmInformation.txt[i].Text;
                    sw.WriteLine(imname[i] + "：" + imtext[i]);
                }
                sw.WriteLine("****************************************************************************");
                sw.WriteLine("");
                //保存目标密度信息
                sw.WriteLine("二、目标数量");
                sw.WriteLine("");
                sw.WriteLine("                  |                                                 距离");
                sw.WriteLine("设施类型   |           <30米             |    ≥30米且＜90米    |    ≥90米且＜300米");
                sw.WriteLine("————————————————————————————————");
                for (int i = 0; i < targetnum-1; i++)
                {
                    targetname[i] = frmInformation.targetname[i].Text;
                    for (int j = 0; j < 3; j++)
                    {
                        if (frmInformation.targettxt[i, j].Text != "")
                            targettext[i, j] = frmInformation.targettxt[i, j].Text;
                        else
                            targettext[i, j] = "0";
                    }
                    sw.WriteLine(targetname[i]+ "    |                " + targettext[i, 0]+ "                |                " + targettext[i, 1] + "                |                " + targettext[i, 2]);
                }
                sw.WriteLine("————————————————————————————————");
                targetname[18] = frmInformation.targetname[18].Text;
                for (int j = 0; j < 3; j++)
                {
                    if (frmInformation.targettxt[18, j].Text != "")
                        targettext[18, j] = frmInformation.targettxt[18, j].Text;
                    else
                        targettext[18, j] = "0";
                }
                sw.WriteLine(targetname[18] + "    |                " + targettext[18, 0] + "                |                " + targettext[18, 1] + "                |                " + targettext[18, 2]);
                sw.WriteLine("****************************************************************************");
                sw.WriteLine("");
                //保存选项信息
                sw.WriteLine("三、后果评估");
                sw.WriteLine("");
                for (int i = 0; i < 6; i++)
                {
                    choiceitem[i] = frmConsequence.choice[i].SelectedItem.ToString();
                    choicename[i] = frmConsequence.name[i].Text;
                    sw.WriteLine(choicename[i] + "：" + choiceitem[i]);
                }
                sw.WriteLine("****************************************************************************");
                sw.WriteLine("");
                sw.WriteLine("四、威胁评估");
                sw.WriteLine("");
                for (int i = 6; i < 16; i++)
                {
                    choiceitem[i] = frmThreat.choice[i - 6].SelectedItem.ToString();
                    choicename[i] = frmThreat.name[i - 6].Text;
                    sw.WriteLine(choicename[i] + "：" + choiceitem[i]);
                }
                sw.WriteLine("****************************************************************************");
                sw.WriteLine("");
                sw.WriteLine("五、易损性评估");
                sw.WriteLine("");
                for (int i = 16; i < 57; i++)
                {
                    choiceitem[i] = frmVulnerability.choice[i - 16].SelectedItem.ToString();
                    choicename[i] = frmVulnerability.name[i - 16].Text;
                    sw.WriteLine(choicename[i] + "：" + choiceitem[i]);
                }
                sw.WriteLine("****************************************************************************");
                sw.WriteLine("");
                //保存风险信息
                sw.WriteLine("六、风险评估");
                sw.WriteLine("");
                sw.WriteLine("        威胁情景       |    后果    |    威胁    |    易损性  |    风险");
                sw.WriteLine("—————————————————————————");
                for (int i =0;i<risknum;i++)
                {
                    for (int j = 0; j < 4; j++)
                        risktxt[i, j] = frmRisk.txt[i, j].Text;
                    sw.WriteLine(riskname[i] + "   |    " + risktxt[i, 0]+ "    |    " + risktxt[i, 1]+ "    |    " + risktxt[i, 2]+ "    |    " + risktxt[i, 3]);
                }
                sw.WriteLine("—————————————————————————");
                sw.WriteLine("");
                sw.WriteLine("综合风险为："+ frmRisk.sumrisk.Text);
                sw.WriteLine("风险等级为："+ frmRisk.labellevel.Text);
                sw.WriteLine("****************************************************************************");

                string localFilePath = saveFileDialog.FileName.ToString(); //获得文件路径
                frm.Text = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                sw.Flush();
                sw.Close();
            }
        }
    }
}
