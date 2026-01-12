namespace WinFormsLB4
{
    partial class FindForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxDiscountStrategy = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBoxSummRange = new System.Windows.Forms.GroupBox();
            this.SummToTextBox = new System.Windows.Forms.TextBox();
            this.SeummToLabel = new System.Windows.Forms.Label();
            this.SummForTextbox = new System.Windows.Forms.TextBox();
            this.SummFromLabel = new System.Windows.Forms.Label();
            this.groupBoxFinalSumm = new System.Windows.Forms.GroupBox();
            this.textBoxFinalSummTo = new System.Windows.Forms.TextBox();
            this.FinalSummToLabel = new System.Windows.Forms.Label();
            this.textBoxFinalSummFrom = new System.Windows.Forms.TextBox();
            this.FinalSummFromLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CertificateToTextBox1 = new System.Windows.Forms.TextBox();
            this.CertificateToLabel = new System.Windows.Forms.Label();
            this.CertificateFromTextBox = new System.Windows.Forms.TextBox();
            this.CertificateFromLabel = new System.Windows.Forms.Label();
            this.CertificateLabel = new System.Windows.Forms.Label();
            this.PercentageLabel = new System.Windows.Forms.Label();
            this.textBoxPercentageFrom = new System.Windows.Forms.TextBox();
            this.textBoxPercentageTo = new System.Windows.Forms.TextBox();
            this.FindApplyButton = new System.Windows.Forms.Button();
            this.FindRejectButton = new System.Windows.Forms.Button();
            this.groupBoxDiscountStrategy.SuspendLayout();
            this.groupBoxSummRange.SuspendLayout();
            this.groupBoxFinalSumm.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDiscountStrategy
            // 
            this.groupBoxDiscountStrategy.Controls.Add(this.comboBox1);
            this.groupBoxDiscountStrategy.Location = new System.Drawing.Point(44, 12);
            this.groupBoxDiscountStrategy.Name = "groupBoxDiscountStrategy";
            this.groupBoxDiscountStrategy.Size = new System.Drawing.Size(140, 52);
            this.groupBoxDiscountStrategy.TabIndex = 1;
            this.groupBoxDiscountStrategy.TabStop = false;
            this.groupBoxDiscountStrategy.Text = "Скидочаня стратегия";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBoxSummRange
            // 
            this.groupBoxSummRange.Controls.Add(this.SummToTextBox);
            this.groupBoxSummRange.Controls.Add(this.SeummToLabel);
            this.groupBoxSummRange.Controls.Add(this.SummForTextbox);
            this.groupBoxSummRange.Controls.Add(this.SummFromLabel);
            this.groupBoxSummRange.Location = new System.Drawing.Point(12, 70);
            this.groupBoxSummRange.Name = "groupBoxSummRange";
            this.groupBoxSummRange.Size = new System.Drawing.Size(100, 85);
            this.groupBoxSummRange.TabIndex = 2;
            this.groupBoxSummRange.TabStop = false;
            this.groupBoxSummRange.Text = "Сумма покупки";
            // 
            // SummToTextBox
            // 
            this.SummToTextBox.Location = new System.Drawing.Point(32, 53);
            this.SummToTextBox.Name = "SummToTextBox";
            this.SummToTextBox.Size = new System.Drawing.Size(60, 20);
            this.SummToTextBox.TabIndex = 11;
            // 
            // SeummToLabel
            // 
            this.SeummToLabel.AutoSize = true;
            this.SeummToLabel.Location = new System.Drawing.Point(3, 60);
            this.SeummToLabel.Name = "SeummToLabel";
            this.SeummToLabel.Size = new System.Drawing.Size(25, 13);
            this.SeummToLabel.TabIndex = 10;
            this.SeummToLabel.Text = "До:";
            // 
            // SummForTextbox
            // 
            this.SummForTextbox.Location = new System.Drawing.Point(32, 19);
            this.SummForTextbox.Name = "SummForTextbox";
            this.SummForTextbox.Size = new System.Drawing.Size(60, 20);
            this.SummForTextbox.TabIndex = 9;
            // 
            // SummFromLabel
            // 
            this.SummFromLabel.AutoSize = true;
            this.SummFromLabel.Location = new System.Drawing.Point(3, 26);
            this.SummFromLabel.Name = "SummFromLabel";
            this.SummFromLabel.Size = new System.Drawing.Size(23, 13);
            this.SummFromLabel.TabIndex = 8;
            this.SummFromLabel.Text = "От:";
            // 
            // groupBoxFinalSumm
            // 
            this.groupBoxFinalSumm.Controls.Add(this.textBoxFinalSummTo);
            this.groupBoxFinalSumm.Controls.Add(this.FinalSummToLabel);
            this.groupBoxFinalSumm.Controls.Add(this.textBoxFinalSummFrom);
            this.groupBoxFinalSumm.Controls.Add(this.FinalSummFromLabel);
            this.groupBoxFinalSumm.Location = new System.Drawing.Point(118, 70);
            this.groupBoxFinalSumm.Name = "groupBoxFinalSumm";
            this.groupBoxFinalSumm.Size = new System.Drawing.Size(102, 85);
            this.groupBoxFinalSumm.TabIndex = 3;
            this.groupBoxFinalSumm.TabStop = false;
            this.groupBoxFinalSumm.Text = "Сумма к оплате";
            // 
            // textBoxFinalSummTo
            // 
            this.textBoxFinalSummTo.Location = new System.Drawing.Point(32, 53);
            this.textBoxFinalSummTo.MaximumSize = new System.Drawing.Size(60, 0);
            this.textBoxFinalSummTo.MinimumSize = new System.Drawing.Size(60, 0);
            this.textBoxFinalSummTo.Name = "textBoxFinalSummTo";
            this.textBoxFinalSummTo.Size = new System.Drawing.Size(60, 20);
            this.textBoxFinalSummTo.TabIndex = 11;
            // 
            // FinalSummToLabel
            // 
            this.FinalSummToLabel.AutoSize = true;
            this.FinalSummToLabel.Location = new System.Drawing.Point(3, 60);
            this.FinalSummToLabel.Name = "FinalSummToLabel";
            this.FinalSummToLabel.Size = new System.Drawing.Size(25, 13);
            this.FinalSummToLabel.TabIndex = 10;
            this.FinalSummToLabel.Text = "До:";
            // 
            // textBoxFinalSummFrom
            // 
            this.textBoxFinalSummFrom.Location = new System.Drawing.Point(32, 19);
            this.textBoxFinalSummFrom.MaximumSize = new System.Drawing.Size(60, 0);
            this.textBoxFinalSummFrom.MinimumSize = new System.Drawing.Size(60, 0);
            this.textBoxFinalSummFrom.Name = "textBoxFinalSummFrom";
            this.textBoxFinalSummFrom.Size = new System.Drawing.Size(60, 20);
            this.textBoxFinalSummFrom.TabIndex = 9;
            // 
            // FinalSummFromLabel
            // 
            this.FinalSummFromLabel.AutoSize = true;
            this.FinalSummFromLabel.Location = new System.Drawing.Point(3, 26);
            this.FinalSummFromLabel.Name = "FinalSummFromLabel";
            this.FinalSummFromLabel.Size = new System.Drawing.Size(23, 13);
            this.FinalSummFromLabel.TabIndex = 8;
            this.FinalSummFromLabel.Text = "От:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPercentageTo);
            this.groupBox1.Controls.Add(this.textBoxPercentageFrom);
            this.groupBox1.Controls.Add(this.PercentageLabel);
            this.groupBox1.Controls.Add(this.CertificateToTextBox1);
            this.groupBox1.Controls.Add(this.CertificateToLabel);
            this.groupBox1.Controls.Add(this.CertificateFromTextBox);
            this.groupBox1.Controls.Add(this.CertificateLabel);
            this.groupBox1.Controls.Add(this.CertificateFromLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 117);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сумма покупки";
            // 
            // CertificateToTextBox1
            // 
            this.CertificateToTextBox1.Location = new System.Drawing.Point(32, 83);
            this.CertificateToTextBox1.Name = "CertificateToTextBox1";
            this.CertificateToTextBox1.Size = new System.Drawing.Size(90, 20);
            this.CertificateToTextBox1.TabIndex = 11;
            // 
            // CertificateToLabel
            // 
            this.CertificateToLabel.AutoSize = true;
            this.CertificateToLabel.Location = new System.Drawing.Point(3, 90);
            this.CertificateToLabel.Name = "CertificateToLabel";
            this.CertificateToLabel.Size = new System.Drawing.Size(25, 13);
            this.CertificateToLabel.TabIndex = 10;
            this.CertificateToLabel.Text = "До:";
            // 
            // CertificateFromTextBox
            // 
            this.CertificateFromTextBox.Location = new System.Drawing.Point(32, 49);
            this.CertificateFromTextBox.Name = "CertificateFromTextBox";
            this.CertificateFromTextBox.Size = new System.Drawing.Size(90, 20);
            this.CertificateFromTextBox.TabIndex = 9;
            // 
            // CertificateFromLabel
            // 
            this.CertificateFromLabel.AutoSize = true;
            this.CertificateFromLabel.Location = new System.Drawing.Point(3, 56);
            this.CertificateFromLabel.Name = "CertificateFromLabel";
            this.CertificateFromLabel.Size = new System.Drawing.Size(23, 13);
            this.CertificateFromLabel.TabIndex = 8;
            this.CertificateFromLabel.Text = "От:";
            // 
            // CertificateLabel
            // 
            this.CertificateLabel.AutoSize = true;
            this.CertificateLabel.Location = new System.Drawing.Point(3, 25);
            this.CertificateLabel.Name = "CertificateLabel";
            this.CertificateLabel.Size = new System.Drawing.Size(125, 13);
            this.CertificateLabel.TabIndex = 8;
            this.CertificateLabel.Text = "Номинал сертификата:";
            // 
            // PercentageLabel
            // 
            this.PercentageLabel.AutoSize = true;
            this.PercentageLabel.Location = new System.Drawing.Point(163, 25);
            this.PercentageLabel.Name = "PercentageLabel";
            this.PercentageLabel.Size = new System.Drawing.Size(15, 13);
            this.PercentageLabel.TabIndex = 12;
            this.PercentageLabel.Text = "%";
            // 
            // textBoxPercentageFrom
            // 
            this.textBoxPercentageFrom.Location = new System.Drawing.Point(158, 49);
            this.textBoxPercentageFrom.Name = "textBoxPercentageFrom";
            this.textBoxPercentageFrom.Size = new System.Drawing.Size(25, 20);
            this.textBoxPercentageFrom.TabIndex = 13;
            // 
            // textBoxPercentageTo
            // 
            this.textBoxPercentageTo.Location = new System.Drawing.Point(158, 83);
            this.textBoxPercentageTo.Name = "textBoxPercentageTo";
            this.textBoxPercentageTo.Size = new System.Drawing.Size(25, 20);
            this.textBoxPercentageTo.TabIndex = 13;
            // 
            // FindApplyButton
            // 
            this.FindApplyButton.Location = new System.Drawing.Point(12, 284);
            this.FindApplyButton.Name = "FindApplyButton";
            this.FindApplyButton.Size = new System.Drawing.Size(100, 23);
            this.FindApplyButton.TabIndex = 5;
            this.FindApplyButton.Text = "Найти";
            this.FindApplyButton.UseVisualStyleBackColor = true;
            this.FindApplyButton.Click += new System.EventHandler(this.FindApplyButton_Click);
            // 
            // FindRejectButton
            // 
            this.FindRejectButton.Location = new System.Drawing.Point(120, 284);
            this.FindRejectButton.Name = "FindRejectButton";
            this.FindRejectButton.Size = new System.Drawing.Size(100, 23);
            this.FindRejectButton.TabIndex = 6;
            this.FindRejectButton.Text = "Отмена";
            this.FindRejectButton.UseVisualStyleBackColor = true;
            this.FindRejectButton.Click += new System.EventHandler(this.FindRejectButton_Click);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 315);
            this.Controls.Add(this.FindRejectButton);
            this.Controls.Add(this.FindApplyButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxFinalSumm);
            this.Controls.Add(this.groupBoxSummRange);
            this.Controls.Add(this.groupBoxDiscountStrategy);
            this.Name = "FindForm";
            this.Text = "Поиск";
            this.groupBoxDiscountStrategy.ResumeLayout(false);
            this.groupBoxSummRange.ResumeLayout(false);
            this.groupBoxSummRange.PerformLayout();
            this.groupBoxFinalSumm.ResumeLayout(false);
            this.groupBoxFinalSumm.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDiscountStrategy;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBoxSummRange;
        private System.Windows.Forms.TextBox SummToTextBox;
        private System.Windows.Forms.Label SeummToLabel;
        private System.Windows.Forms.TextBox SummForTextbox;
        private System.Windows.Forms.Label SummFromLabel;
        private System.Windows.Forms.GroupBox groupBoxFinalSumm;
        private System.Windows.Forms.TextBox textBoxFinalSummTo;
        private System.Windows.Forms.Label FinalSummToLabel;
        private System.Windows.Forms.TextBox textBoxFinalSummFrom;
        private System.Windows.Forms.Label FinalSummFromLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CertificateToTextBox1;
        private System.Windows.Forms.Label CertificateToLabel;
        private System.Windows.Forms.TextBox CertificateFromTextBox;
        private System.Windows.Forms.Label CertificateLabel;
        private System.Windows.Forms.Label CertificateFromLabel;
        private System.Windows.Forms.Label PercentageLabel;
        private System.Windows.Forms.TextBox textBoxPercentageTo;
        private System.Windows.Forms.TextBox textBoxPercentageFrom;
        private System.Windows.Forms.Button FindApplyButton;
        private System.Windows.Forms.Button FindRejectButton;
    }
}