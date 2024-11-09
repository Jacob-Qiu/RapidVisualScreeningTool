namespace rapid_visual_screening_tools_1._0
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChgFrmIntro = new System.Windows.Forms.Button();
            this.btnChgFrmThreat = new System.Windows.Forms.Button();
            this.btnChgFrmInform = new System.Windows.Forms.Button();
            this.btnChgFrmVul = new System.Windows.Forms.Button();
            this.btnChgFrmCon = new System.Windows.Forms.Button();
            this.btnChgFrmRisk = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.temiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSavemore = new System.Windows.Forms.ToolStripMenuItem();
            this.output = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(30, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 480);
            this.panel1.TabIndex = 0;
            // 
            // btnChgFrmIntro
            // 
            this.btnChgFrmIntro.Location = new System.Drawing.Point(30, 34);
            this.btnChgFrmIntro.Margin = new System.Windows.Forms.Padding(2);
            this.btnChgFrmIntro.Name = "btnChgFrmIntro";
            this.btnChgFrmIntro.Size = new System.Drawing.Size(82, 20);
            this.btnChgFrmIntro.TabIndex = 1;
            this.btnChgFrmIntro.Text = "使用说明";
            this.btnChgFrmIntro.UseVisualStyleBackColor = true;
            this.btnChgFrmIntro.Click += new System.EventHandler(this.btnChgFrmIntro_Click);
            // 
            // btnChgFrmThreat
            // 
            this.btnChgFrmThreat.Location = new System.Drawing.Point(300, 34);
            this.btnChgFrmThreat.Margin = new System.Windows.Forms.Padding(2);
            this.btnChgFrmThreat.Name = "btnChgFrmThreat";
            this.btnChgFrmThreat.Size = new System.Drawing.Size(82, 20);
            this.btnChgFrmThreat.TabIndex = 4;
            this.btnChgFrmThreat.Text = "威胁评估";
            this.btnChgFrmThreat.UseVisualStyleBackColor = true;
            this.btnChgFrmThreat.Click += new System.EventHandler(this.btnChgFrmThreat_Click);
            // 
            // btnChgFrmInform
            // 
            this.btnChgFrmInform.Location = new System.Drawing.Point(120, 34);
            this.btnChgFrmInform.Margin = new System.Windows.Forms.Padding(2);
            this.btnChgFrmInform.Name = "btnChgFrmInform";
            this.btnChgFrmInform.Size = new System.Drawing.Size(82, 20);
            this.btnChgFrmInform.TabIndex = 2;
            this.btnChgFrmInform.Text = "建筑信息";
            this.btnChgFrmInform.UseVisualStyleBackColor = true;
            this.btnChgFrmInform.Click += new System.EventHandler(this.btnChgFrmInform_Click);
            // 
            // btnChgFrmVul
            // 
            this.btnChgFrmVul.Location = new System.Drawing.Point(390, 34);
            this.btnChgFrmVul.Margin = new System.Windows.Forms.Padding(2);
            this.btnChgFrmVul.Name = "btnChgFrmVul";
            this.btnChgFrmVul.Size = new System.Drawing.Size(82, 20);
            this.btnChgFrmVul.TabIndex = 5;
            this.btnChgFrmVul.Text = "易损性评估";
            this.btnChgFrmVul.UseVisualStyleBackColor = true;
            this.btnChgFrmVul.Click += new System.EventHandler(this.btnChgFrmVul_Click);
            // 
            // btnChgFrmCon
            // 
            this.btnChgFrmCon.Location = new System.Drawing.Point(210, 34);
            this.btnChgFrmCon.Margin = new System.Windows.Forms.Padding(2);
            this.btnChgFrmCon.Name = "btnChgFrmCon";
            this.btnChgFrmCon.Size = new System.Drawing.Size(82, 20);
            this.btnChgFrmCon.TabIndex = 3;
            this.btnChgFrmCon.Text = "后果评估";
            this.btnChgFrmCon.UseVisualStyleBackColor = true;
            this.btnChgFrmCon.Click += new System.EventHandler(this.btnChgFrmCon_Click);
            // 
            // btnChgFrmRisk
            // 
            this.btnChgFrmRisk.Location = new System.Drawing.Point(476, 34);
            this.btnChgFrmRisk.Margin = new System.Windows.Forms.Padding(2);
            this.btnChgFrmRisk.Name = "btnChgFrmRisk";
            this.btnChgFrmRisk.Size = new System.Drawing.Size(82, 20);
            this.btnChgFrmRisk.TabIndex = 5;
            this.btnChgFrmRisk.Text = "风险评估";
            this.btnChgFrmRisk.UseVisualStyleBackColor = true;
            this.btnChgFrmRisk.Click += new System.EventHandler(this.btnChgFrmRisk_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(962, 25);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temiOpen,
            this.tsmiSave,
            this.tsmiSavemore,
            this.output});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(44, 21);
            this.tsmiFile.Text = "文件";
            // 
            // temiOpen
            // 
            this.temiOpen.Name = "temiOpen";
            this.temiOpen.Size = new System.Drawing.Size(112, 22);
            this.temiOpen.Text = "打开";
            this.temiOpen.Click += new System.EventHandler(this.temiOpen_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(112, 22);
            this.tsmiSave.Text = "保存";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiSavemore
            // 
            this.tsmiSavemore.Name = "tsmiSavemore";
            this.tsmiSavemore.Size = new System.Drawing.Size(112, 22);
            this.tsmiSavemore.Text = "另存为";
            this.tsmiSavemore.Click += new System.EventHandler(this.tsmiSavemore_Click);
            // 
            // output
            // 
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(112, 22);
            this.output.Text = "导出";
            this.output.Click += new System.EventHandler(this.output_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.OverwritePrompt = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(962, 543);
            this.Controls.Add(this.btnChgFrmCon);
            this.Controls.Add(this.btnChgFrmRisk);
            this.Controls.Add(this.btnChgFrmVul);
            this.Controls.Add(this.btnChgFrmThreat);
            this.Controls.Add(this.btnChgFrmInform);
            this.Controls.Add(this.btnChgFrmIntro);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "快速筛查工具数据库";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnChgFrmIntro;
        private System.Windows.Forms.Button btnChgFrmThreat;
        private System.Windows.Forms.Button btnChgFrmInform;
        private System.Windows.Forms.Button btnChgFrmVul;
        private System.Windows.Forms.Button btnChgFrmCon;
        private System.Windows.Forms.Button btnChgFrmRisk;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem temiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiSavemore;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem output;
    }
}

