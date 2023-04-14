namespace wf13_bookrentalshop
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MniGenMng = new System.Windows.Forms.ToolStripMenuItem();
            this.MniBookMng = new System.Windows.Forms.ToolStripMenuItem();
            this.MniMembMng = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MniRentMng = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.CadetBlue;
            this.menuStrip.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.viewMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(804, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.BackColor = System.Drawing.Color.CadetBlue;
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileMenu.ForeColor = System.Drawing.Color.LavenderBlush;
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(66, 24);
            this.fileMenu.Text = "파일(&F)";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.exitToolStripMenuItem.Text = "끝내기(&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.BackColor = System.Drawing.Color.CadetBlue;
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MniGenMng,
            this.MniBookMng,
            this.MniMembMng,
            this.toolStripMenuItem1,
            this.MniRentMng});
            this.viewMenu.ForeColor = System.Drawing.Color.LavenderBlush;
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(67, 24);
            this.viewMenu.Text = "관리(&V)";
            // 
            // MniGenMng
            // 
            this.MniGenMng.Name = "MniGenMng";
            this.MniGenMng.Size = new System.Drawing.Size(153, 24);
            this.MniGenMng.Text = "책 장르 관리";
            this.MniGenMng.Click += new System.EventHandler(this.MniGenMng_Click);
            // 
            // MniBookMng
            // 
            this.MniBookMng.Name = "MniBookMng";
            this.MniBookMng.Size = new System.Drawing.Size(153, 24);
            this.MniBookMng.Text = "책 정보 관리";
            this.MniBookMng.Click += new System.EventHandler(this.MniBookMng_Click);
            // 
            // MniMembMng
            // 
            this.MniMembMng.Name = "MniMembMng";
            this.MniMembMng.Size = new System.Drawing.Size(153, 24);
            this.MniMembMng.Text = "회원 관리";
            this.MniMembMng.Click += new System.EventHandler(this.MniMembMng_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
            // 
            // MniRentMng
            // 
            this.MniRentMng.Name = "MniRentMng";
            this.MniRentMng.Size = new System.Drawing.Size(153, 24);
            this.MniRentMng.Text = "대여 관리";
            this.MniRentMng.Click += new System.EventHandler(this.MniRentMng_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.BackColor = System.Drawing.Color.CadetBlue;
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MniAbout});
            this.helpMenu.ForeColor = System.Drawing.Color.LavenderBlush;
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(79, 24);
            this.helpMenu.Text = "도움말(&H)";
            // 
            // MniAbout
            // 
            this.MniAbout.Name = "MniAbout";
            this.MniAbout.Size = new System.Drawing.Size(147, 24);
            this.MniAbout.Text = "정보(&A)... ...";
            this.MniAbout.Click += new System.EventHandler(this.MniAbout_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 639);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 20, 0);
            this.statusStrip.Size = new System.Drawing.Size(804, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel.Text = "상태";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 661);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("나눔고딕OTF", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem MniAbout;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem MniGenMng;
        private System.Windows.Forms.ToolStripMenuItem MniBookMng;
        private System.Windows.Forms.ToolStripMenuItem MniMembMng;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MniRentMng;
    }
}



