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
    public partial class frmRisk : Form
    {
        public frmRisk()
        {
            InitializeComponent();
        }



        public static TextBox[,] txt = new TextBox[9, 4];
        public static TextBox sumrisk = new TextBox();
        public static Label labellevel = new Label()
        {
            Top=445,
            Left=390,
            Font= new Font("黑体", 14.25f)
        };


        private void frmRisk_Load(object sender, EventArgs e)
        {
            Function.frmRiskLoad(this,txt,sumrisk);
            this.Controls.Add(labellevel);
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            Function.frmRiskOK(txt, sumrisk, frmConsequence.sumcondata, frmThreat.sumthreatdata, frmVulnerability.sumvuldata);
            if (double.Parse(sumrisk.Text)<3001)
                labellevel.Text = "低风险";
            else if(double.Parse(sumrisk.Text) < 6002 && double.Parse(sumrisk.Text) >= 3001)
                labellevel.Text = "中风险";
            else
                labellevel.Text = "高风险";
        }
    }
}
