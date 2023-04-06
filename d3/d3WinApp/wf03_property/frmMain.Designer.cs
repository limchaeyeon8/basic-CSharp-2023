namespace wf03_property
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.GbxMain = new System.Windows.Forms.GroupBox();
            this.RdoIndent = new System.Windows.Forms.RadioButton();
            this.RdoNormal = new System.Windows.Forms.RadioButton();
            this.NudFontSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtResult = new System.Windows.Forms.TextBox();
            this.ChkItalic = new System.Windows.Forms.CheckBox();
            this.ChkBold = new System.Windows.Forms.CheckBox();
            this.CboFontFamily = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PgbDummy = new System.Windows.Forms.ProgressBar();
            this.TrbDummy = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnMessageBox = new System.Windows.Forms.Button();
            this.BtnModaless = new System.Windows.Forms.Button();
            this.BtnModal = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnAddChild = new System.Windows.Forms.Button();
            this.BtnAddRoot = new System.Windows.Forms.Button();
            this.TrvDummy = new System.Windows.Forms.TreeView();
            this.LsvDummy = new System.Windows.Forms.ListView();
            this.픽쳐박스 = new System.Windows.Forms.GroupBox();
            this.PcbDummy = new System.Windows.Forms.PictureBox();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.GbxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudFontSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrbDummy)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.픽쳐박스.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PcbDummy)).BeginInit();
            this.SuspendLayout();
            // 
            // GbxMain
            // 
            this.GbxMain.Controls.Add(this.RdoIndent);
            this.GbxMain.Controls.Add(this.RdoNormal);
            this.GbxMain.Controls.Add(this.NudFontSize);
            this.GbxMain.Controls.Add(this.label2);
            this.GbxMain.Controls.Add(this.TxtResult);
            this.GbxMain.Controls.Add(this.ChkItalic);
            this.GbxMain.Controls.Add(this.ChkBold);
            this.GbxMain.Controls.Add(this.CboFontFamily);
            this.GbxMain.Controls.Add(this.label1);
            resources.ApplyResources(this.GbxMain, "GbxMain");
            this.GbxMain.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GbxMain.Name = "GbxMain";
            this.GbxMain.TabStop = false;
            // 
            // RdoIndent
            // 
            resources.ApplyResources(this.RdoIndent, "RdoIndent");
            this.RdoIndent.Name = "RdoIndent";
            this.RdoIndent.TabStop = true;
            this.RdoIndent.UseVisualStyleBackColor = true;
            this.RdoIndent.CheckedChanged += new System.EventHandler(this.RdoIndent_CheckedChanged);
            // 
            // RdoNormal
            // 
            resources.ApplyResources(this.RdoNormal, "RdoNormal");
            this.RdoNormal.Name = "RdoNormal";
            this.RdoNormal.TabStop = true;
            this.RdoNormal.UseVisualStyleBackColor = true;
            this.RdoNormal.CheckedChanged += new System.EventHandler(this.RdoNormal_CheckedChanged);
            // 
            // NudFontSize
            // 
            resources.ApplyResources(this.NudFontSize, "NudFontSize");
            this.NudFontSize.Name = "NudFontSize";
            this.NudFontSize.ValueChanged += new System.EventHandler(this.NudFontSize_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // TxtResult
            // 
            resources.ApplyResources(this.TxtResult, "TxtResult");
            this.TxtResult.Name = "TxtResult";
            // 
            // ChkItalic
            // 
            resources.ApplyResources(this.ChkItalic, "ChkItalic");
            this.ChkItalic.Name = "ChkItalic";
            this.ChkItalic.UseVisualStyleBackColor = true;
            this.ChkItalic.CheckedChanged += new System.EventHandler(this.ChkItalic_CheckedChanged);
            // 
            // ChkBold
            // 
            resources.ApplyResources(this.ChkBold, "ChkBold");
            this.ChkBold.Name = "ChkBold";
            this.ChkBold.UseVisualStyleBackColor = true;
            this.ChkBold.CheckedChanged += new System.EventHandler(this.ChkBold_CheckedChanged);
            // 
            // CboFontFamily
            // 
            resources.ApplyResources(this.CboFontFamily, "CboFontFamily");
            this.CboFontFamily.FormattingEnabled = true;
            this.CboFontFamily.Name = "CboFontFamily";
            this.CboFontFamily.SelectedIndexChanged += new System.EventHandler(this.CboFontFamily_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PgbDummy);
            this.groupBox1.Controls.Add(this.TrbDummy);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // PgbDummy
            // 
            this.PgbDummy.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.PgbDummy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            resources.ApplyResources(this.PgbDummy, "PgbDummy");
            this.PgbDummy.Maximum = 20;
            this.PgbDummy.Name = "PgbDummy";
            // 
            // TrbDummy
            // 
            this.TrbDummy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TrbDummy.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.TrbDummy, "TrbDummy");
            this.TrbDummy.Maximum = 20;
            this.TrbDummy.Name = "TrbDummy";
            this.TrbDummy.Scroll += new System.EventHandler(this.TrbDummy_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnMessageBox);
            this.groupBox2.Controls.Add(this.BtnModaless);
            this.groupBox2.Controls.Add(this.BtnModal);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // BtnMessageBox
            // 
            resources.ApplyResources(this.BtnMessageBox, "BtnMessageBox");
            this.BtnMessageBox.Name = "BtnMessageBox";
            this.BtnMessageBox.UseVisualStyleBackColor = true;
            this.BtnMessageBox.Click += new System.EventHandler(this.BtnMessageBox_Click);
            // 
            // BtnModaless
            // 
            resources.ApplyResources(this.BtnModaless, "BtnModaless");
            this.BtnModaless.Name = "BtnModaless";
            this.BtnModaless.UseVisualStyleBackColor = true;
            this.BtnModaless.Click += new System.EventHandler(this.BtnModaless_Click);
            // 
            // BtnModal
            // 
            resources.ApplyResources(this.BtnModal, "BtnModal");
            this.BtnModal.Name = "BtnModal";
            this.BtnModal.UseVisualStyleBackColor = true;
            this.BtnModal.Click += new System.EventHandler(this.BtnModal_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnAddChild);
            this.groupBox3.Controls.Add(this.BtnAddRoot);
            this.groupBox3.Controls.Add(this.TrvDummy);
            this.groupBox3.Controls.Add(this.LsvDummy);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // BtnAddChild
            // 
            resources.ApplyResources(this.BtnAddChild, "BtnAddChild");
            this.BtnAddChild.Name = "BtnAddChild";
            this.BtnAddChild.UseVisualStyleBackColor = true;
            this.BtnAddChild.Click += new System.EventHandler(this.BtnAddChild_Click);
            // 
            // BtnAddRoot
            // 
            resources.ApplyResources(this.BtnAddRoot, "BtnAddRoot");
            this.BtnAddRoot.Name = "BtnAddRoot";
            this.BtnAddRoot.UseVisualStyleBackColor = true;
            this.BtnAddRoot.Click += new System.EventHandler(this.BtnAddRoot_Click);
            // 
            // TrvDummy
            // 
            resources.ApplyResources(this.TrvDummy, "TrvDummy");
            this.TrvDummy.Name = "TrvDummy";
            // 
            // LsvDummy
            // 
            resources.ApplyResources(this.LsvDummy, "LsvDummy");
            this.LsvDummy.HideSelection = false;
            this.LsvDummy.Name = "LsvDummy";
            this.LsvDummy.UseCompatibleStateImageBehavior = false;
            // 
            // 픽쳐박스
            // 
            this.픽쳐박스.Controls.Add(this.BtnLoad);
            this.픽쳐박스.Controls.Add(this.PcbDummy);
            resources.ApplyResources(this.픽쳐박스, "픽쳐박스");
            this.픽쳐박스.Name = "픽쳐박스";
            this.픽쳐박스.TabStop = false;
            // 
            // PcbDummy
            // 
            resources.ApplyResources(this.PcbDummy, "PcbDummy");
            this.PcbDummy.Name = "PcbDummy";
            this.PcbDummy.TabStop = false;
            this.PcbDummy.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // BtnLoad
            // 
            resources.ApplyResources(this.BtnLoad, "BtnLoad");
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.픽쳐박스);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GbxMain);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.GbxMain.ResumeLayout(false);
            this.GbxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudFontSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrbDummy)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.픽쳐박스.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PcbDummy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbxMain;
        private System.Windows.Forms.NumericUpDown NudFontSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtResult;
        private System.Windows.Forms.CheckBox ChkItalic;
        private System.Windows.Forms.CheckBox ChkBold;
        private System.Windows.Forms.ComboBox CboFontFamily;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar PgbDummy;
        private System.Windows.Forms.TrackBar TrbDummy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnMessageBox;
        private System.Windows.Forms.Button BtnModaless;
        private System.Windows.Forms.Button BtnModal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView TrvDummy;
        private System.Windows.Forms.ListView LsvDummy;
        private System.Windows.Forms.Button BtnAddChild;
        private System.Windows.Forms.Button BtnAddRoot;
        private System.Windows.Forms.RadioButton RdoNormal;
        private System.Windows.Forms.RadioButton RdoIndent;
        private System.Windows.Forms.GroupBox 픽쳐박스;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.PictureBox PcbDummy;
    }
}

