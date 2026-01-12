namespace WinFormsLB4
{
    partial class AddForm
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
            this.groupBoxParameters = new System.Windows.Forms.GroupBox();
            this.SummTextbox = new System.Windows.Forms.TextBox();
            this.SummLabel = new System.Windows.Forms.Label();
            this.DiscountValueTextBox = new System.Windows.Forms.TextBox();
            this.DiscounValueLabel = new System.Windows.Forms.Label();
            this.AddCancelButton = new System.Windows.Forms.Button();
            this.AddApproveFigureButton = new System.Windows.Forms.Button();
            this.groupBoxDiscountStrategy.SuspendLayout();
            this.groupBoxParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDiscountStrategy
            // 
            this.groupBoxDiscountStrategy.Controls.Add(this.comboBox1);
            this.groupBoxDiscountStrategy.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDiscountStrategy.Name = "groupBoxDiscountStrategy";
            this.groupBoxDiscountStrategy.Size = new System.Drawing.Size(204, 52);
            this.groupBoxDiscountStrategy.TabIndex = 0;
            this.groupBoxDiscountStrategy.TabStop = false;
            this.groupBoxDiscountStrategy.Text = "Скидочаня стратегия";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBoxParameters
            // 
            this.groupBoxParameters.Controls.Add(this.DiscountValueTextBox);
            this.groupBoxParameters.Controls.Add(this.DiscounValueLabel);
            this.groupBoxParameters.Controls.Add(this.SummTextbox);
            this.groupBoxParameters.Controls.Add(this.SummLabel);
            this.groupBoxParameters.Location = new System.Drawing.Point(12, 70);
            this.groupBoxParameters.Name = "groupBoxParameters";
            this.groupBoxParameters.Size = new System.Drawing.Size(204, 88);
            this.groupBoxParameters.TabIndex = 1;
            this.groupBoxParameters.TabStop = false;
            this.groupBoxParameters.Text = "Параметры";
            // 
            // SummTextbox
            // 
            this.SummTextbox.Location = new System.Drawing.Point(97, 19);
            this.SummTextbox.Name = "SummTextbox";
            this.SummTextbox.Size = new System.Drawing.Size(101, 20);
            this.SummTextbox.TabIndex = 9;
            // 
            // SummLabel
            // 
            this.SummLabel.AutoSize = true;
            this.SummLabel.Location = new System.Drawing.Point(3, 26);
            this.SummLabel.Name = "SummLabel";
            this.SummLabel.Size = new System.Drawing.Size(88, 13);
            this.SummLabel.TabIndex = 8;
            this.SummLabel.Text = "Сумма покупки:";
            // 
            // DiscountValueTextBox
            // 
            this.DiscountValueTextBox.Location = new System.Drawing.Point(112, 53);
            this.DiscountValueTextBox.Name = "DiscountValueTextBox";
            this.DiscountValueTextBox.Size = new System.Drawing.Size(86, 20);
            this.DiscountValueTextBox.TabIndex = 11;
            // 
            // DiscounValueLabel
            // 
            this.DiscounValueLabel.AutoSize = true;
            this.DiscounValueLabel.Location = new System.Drawing.Point(5, 60);
            this.DiscounValueLabel.Name = "DiscounValueLabel";
            this.DiscounValueLabel.Size = new System.Drawing.Size(101, 13);
            this.DiscounValueLabel.TabIndex = 10;
            this.DiscounValueLabel.Text = "% / сумма скидки:";
            // 
            // AddCancelButton
            // 
            this.AddCancelButton.Location = new System.Drawing.Point(116, 164);
            this.AddCancelButton.Name = "AddCancelButton";
            this.AddCancelButton.Size = new System.Drawing.Size(100, 23);
            this.AddCancelButton.TabIndex = 7;
            this.AddCancelButton.Text = "Отмена";
            this.AddCancelButton.UseVisualStyleBackColor = true;
            this.AddCancelButton.Click += new System.EventHandler(this.AddCancelButton_Click);
            // 
            // AddApproveFigureButton
            // 
            this.AddApproveFigureButton.Location = new System.Drawing.Point(12, 164);
            this.AddApproveFigureButton.Name = "AddApproveFigureButton";
            this.AddApproveFigureButton.Size = new System.Drawing.Size(100, 23);
            this.AddApproveFigureButton.TabIndex = 6;
            this.AddApproveFigureButton.Text = "Добавить";
            this.AddApproveFigureButton.UseVisualStyleBackColor = true;
            this.AddApproveFigureButton.Click += new System.EventHandler(this.AddApproveFigureButton_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 198);
            this.Controls.Add(this.AddCancelButton);
            this.Controls.Add(this.AddApproveFigureButton);
            this.Controls.Add(this.groupBoxParameters);
            this.Controls.Add(this.groupBoxDiscountStrategy);
            this.Name = "AddForm";
            this.Text = "Добавить расчёт";
            this.groupBoxDiscountStrategy.ResumeLayout(false);
            this.groupBoxParameters.ResumeLayout(false);
            this.groupBoxParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDiscountStrategy;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBoxParameters;
        private System.Windows.Forms.TextBox DiscountValueTextBox;
        private System.Windows.Forms.Label DiscounValueLabel;
        private System.Windows.Forms.TextBox SummTextbox;
        private System.Windows.Forms.Label SummLabel;
        private System.Windows.Forms.Button AddCancelButton;
        private System.Windows.Forms.Button AddApproveFigureButton;
    }
}