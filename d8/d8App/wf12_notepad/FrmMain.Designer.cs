namespace wf12_notepad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.TbxPath = new System.Windows.Forms.TextBox();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.RtbEditor = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TbxPath
            // 
            this.TbxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxPath.BackColor = System.Drawing.Color.SeaShell;
            this.TbxPath.Location = new System.Drawing.Point(12, 28);
            this.TbxPath.Name = "TbxPath";
            this.TbxPath.ReadOnly = true;
            this.TbxPath.Size = new System.Drawing.Size(541, 27);
            this.TbxPath.TabIndex = 0;
            this.TbxPath.TabStop = false;
            // 
            // BtnLoad
            // 
            this.BtnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLoad.BackColor = System.Drawing.Color.Gray;
            this.BtnLoad.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnLoad.Location = new System.Drawing.Point(570, 28);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(93, 27);
            this.BtnLoad.TabIndex = 1;
            this.BtnLoad.Text = "Load";
            this.BtnLoad.UseVisualStyleBackColor = false;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BtnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnSave.Location = new System.Drawing.Point(679, 28);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(93, 27);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // RtbEditor
            // 
            this.RtbEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RtbEditor.BackColor = System.Drawing.Color.Linen;
            this.RtbEditor.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RtbEditor.Location = new System.Drawing.Point(12, 70);
            this.RtbEditor.Name = "RtbEditor";
            this.RtbEditor.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.RtbEditor.Size = new System.Drawing.Size(760, 459);
            this.RtbEditor.TabIndex = 3;
            this.RtbEditor.Text = "";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(784, 541);
            this.Controls.Add(this.RtbEditor);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.TbxPath);
            this.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "FrmMain";
            this.Text = "Simple 메모장";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbxPath;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.RichTextBox RtbEditor;
    }
}

