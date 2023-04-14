namespace wf14_winformsThread
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNumb = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.PgbCalculate = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.LblResult = new System.Windows.Forms.Label();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕OTF", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(35, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "입력(수)";
            // 
            // TxtNumb
            // 
            this.TxtNumb.Location = new System.Drawing.Point(101, 46);
            this.TxtNumb.Name = "TxtNumb";
            this.TxtNumb.Size = new System.Drawing.Size(114, 25);
            this.TxtNumb.TabIndex = 1;
            this.TxtNumb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.MintCream;
            this.BtnCancel.Location = new System.Drawing.Point(311, 46);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 56);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "취소";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.Honeydew;
            this.BtnStart.Location = new System.Drawing.Point(230, 46);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 56);
            this.BtnStart.TabIndex = 2;
            this.BtnStart.Text = "시작";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // PgbCalculate
            // 
            this.PgbCalculate.BackColor = System.Drawing.SystemColors.Control;
            this.PgbCalculate.Location = new System.Drawing.Point(28, 79);
            this.PgbCalculate.Name = "PgbCalculate";
            this.PgbCalculate.Size = new System.Drawing.Size(187, 23);
            this.PgbCalculate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(155, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "결과";
            // 
            // LblResult
            // 
            this.LblResult.AutoSize = true;
            this.LblResult.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblResult.Location = new System.Drawing.Point(236, 125);
            this.LblResult.Name = "LblResult";
            this.LblResult.Size = new System.Drawing.Size(17, 17);
            this.LblResult.TabIndex = 4;
            this.LblResult.Text = "0";
            // 
            // Worker
            // 
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(414, 181);
            this.Controls.Add(this.LblResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PgbCalculate);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.TxtNumb);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("나눔고딕OTF", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Background Worker Test";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNumb;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.ProgressBar PgbCalculate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblResult;
        private System.ComponentModel.BackgroundWorker Worker;
    }
}

