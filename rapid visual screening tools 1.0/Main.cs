using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace rapid_visual_screening_tools_1._0
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        frmIntroduction frmIntroduction = new frmIntroduction();
        frmInformation frmInformation = new frmInformation();
        frmConsequence frmConsequence = new frmConsequence();
        frmThreat frmThreat = new frmThreat();
        frmVulnerability frmVulnerability = new frmVulnerability();
        frmRisk frmRisk = new frmRisk();

        private void frmMain_Load(object sender, EventArgs e)//主界面加载
        {
            Function.ChangeForm(btnChgFrmInform, Color.White, Color.Green, btnChgFrmIntro, btnChgFrmCon, btnChgFrmThreat, btnChgFrmVul, btnChgFrmRisk, Color.Black, Color.Gray, frmInformation, panel1);
            Function.ChangeForm(btnChgFrmCon, Color.White, Color.Green, btnChgFrmInform, btnChgFrmIntro, btnChgFrmThreat, btnChgFrmVul, btnChgFrmRisk, Color.Black, Color.Gray, frmConsequence, panel1);
            Function.ChangeForm(btnChgFrmThreat, Color.White, Color.Green, btnChgFrmIntro, btnChgFrmInform, btnChgFrmCon, btnChgFrmVul, btnChgFrmRisk, Color.Black, Color.Gray, frmThreat, panel1);
            Function.ChangeForm(btnChgFrmVul, Color.White, Color.Green, btnChgFrmIntro, btnChgFrmInform, btnChgFrmCon, btnChgFrmThreat, btnChgFrmRisk, Color.Black, Color.Gray, frmVulnerability, panel1);
            Function.ChangeForm(btnChgFrmRisk, Color.White, Color.Green, btnChgFrmIntro, btnChgFrmInform, btnChgFrmCon, btnChgFrmThreat, btnChgFrmVul, Color.Black, Color.Gray, frmRisk, panel1);
            Function.ChangeForm(btnChgFrmIntro, Color.White, Color.Green, btnChgFrmInform, btnChgFrmCon, btnChgFrmThreat, btnChgFrmVul, btnChgFrmRisk, Color.Black, Color.Gray, frmIntroduction,panel1);
        }
        private void btnChgFrmIntro_Click(object sender, EventArgs e)//切换到软件介绍界面
        {
            Function.ChangeForm(btnChgFrmIntro, Color.White, Color.Green, btnChgFrmInform, btnChgFrmCon, btnChgFrmThreat, btnChgFrmVul, btnChgFrmRisk, Color.Black, Color.Gray, frmIntroduction, panel1);
        }
        private void btnChgFrmInform_Click(object sender, EventArgs e)//切换到建筑信息界面
        {
            Function.ChangeForm(btnChgFrmInform, Color.White, Color.Green, btnChgFrmIntro, btnChgFrmCon, btnChgFrmThreat, btnChgFrmVul, btnChgFrmRisk, Color.Black, Color.Gray, frmInformation, panel1);
        }
        private void btnChgFrmCon_Click(object sender, EventArgs e)//切换到后果界面
        {
            Function.ChangeForm(btnChgFrmCon, Color.White, Color.Green, btnChgFrmInform, btnChgFrmIntro, btnChgFrmThreat, btnChgFrmVul, btnChgFrmRisk, Color.Black, Color.Gray, frmConsequence, panel1);
        }
        private void btnChgFrmThreat_Click(object sender, EventArgs e)//切换到威胁界面
        {
            Function.ChangeForm(btnChgFrmThreat, Color.White, Color.Green, btnChgFrmIntro, btnChgFrmInform, btnChgFrmCon, btnChgFrmVul, btnChgFrmRisk, Color.Black, Color.Gray, frmThreat, panel1);
        }
        private void btnChgFrmVul_Click(object sender, EventArgs e)//切换到易损性界面
        {
            Function.ChangeForm(btnChgFrmVul, Color.White, Color.Green, btnChgFrmIntro, btnChgFrmInform, btnChgFrmCon, btnChgFrmThreat, btnChgFrmRisk, Color.Black, Color.Gray, frmVulnerability, panel1);
        }
        private void btnChgFrmRisk_Click(object sender, EventArgs e)//切换到风险界面
        {
            Function.ChangeForm(btnChgFrmRisk, Color.White, Color.Green, btnChgFrmIntro, btnChgFrmInform, btnChgFrmCon, btnChgFrmThreat, btnChgFrmVul, Color.Black, Color.Gray, frmRisk, panel1);
        }

        private void tsmiSavemore_Click(object sender, EventArgs e)
        //另存为，存为数据文件
        {
            Function.fSavemore(this);
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        //保存，存为数据文件
        {
            if (this.Text!="快速筛查工具数据库")
            {
                Function.fSave(this);
            }
            else
                Function.fSavemore(this);
        }

        private void temiOpen_Click(object sender, EventArgs e)
        //打开数据文件csv，方便修改和继续编辑
        {
            Function.fOpen(this);
        }

        private void output_Click(object sender, EventArgs e)
        {
            Function.fOutput(this);
        }
    }
}
