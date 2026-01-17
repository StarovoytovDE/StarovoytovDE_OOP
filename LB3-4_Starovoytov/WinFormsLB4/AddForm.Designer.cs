namespace WinFormsLB4
{
    partial class AddForm
    {
        /// <summary>
        /// Требуемая переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освобождает все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">True, если управляемые ресурсы должны быть удалены; 
        /// иначе False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxStrategy = new System.Windows.Forms.GroupBox();
            this.comboBoxStrategy = new System.Windows.Forms.ComboBox();
            this.groupBoxInputs = new System.Windows.Forms.GroupBox();
            this.labelValue = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.labelPurchaseAmount = new System.Windows.Forms.Label();
            this.textBoxPurchaseAmount = new System.Windows.Forms.TextBox();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxStrategy.SuspendLayout();
            this.groupBoxInputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxStrategy
            // 
            this.groupBoxStrategy.Controls.Add(this.comboBoxStrategy);
            this.groupBoxStrategy.Location = new System.Drawing.Point(12, 12);
            this.groupBoxStrategy.Name = "groupBoxStrategy";
            this.groupBoxStrategy.Size = new System.Drawing.Size(260, 55);
            this.groupBoxStrategy.TabIndex = 0;
            this.groupBoxStrategy.TabStop = false;
            this.groupBoxStrategy.Text = "Стратегия скидки";
            // 
            // comboBoxStrategy
            // 
            this.comboBoxStrategy.DropDownStyle = 
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStrategy.FormattingEnabled = true;
            this.comboBoxStrategy.Location = new System.Drawing.Point(6, 19);
            this.comboBoxStrategy.Name = "comboBoxStrategy";
            this.comboBoxStrategy.Size = new System.Drawing.Size(248, 21);
            this.comboBoxStrategy.TabIndex = 0;
            this.comboBoxStrategy.SelectedIndexChanged += 
                new System.EventHandler(this.ComboBoxStrategy_SelectedIndexChanged);
            // 
            // groupBoxInputs
            // 
            this.groupBoxInputs.Controls.Add(this.labelValue);
            this.groupBoxInputs.Controls.Add(this.textBoxValue);
            this.groupBoxInputs.Controls.Add(this.labelPurchaseAmount);
            this.groupBoxInputs.Controls.Add(this.textBoxPurchaseAmount);
            this.groupBoxInputs.Location = new System.Drawing.Point(12, 73);
            this.groupBoxInputs.Name = "groupBoxInputs";
            this.groupBoxInputs.Size = new System.Drawing.Size(260, 87);
            this.groupBoxInputs.TabIndex = 1;
            this.groupBoxInputs.TabStop = false;
            this.groupBoxInputs.Text = "Данные расчёта";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(6, 55);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(84, 13);
            this.labelValue.TabIndex = 3;
            this.labelValue.Text = "Значение (X):";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(142, 52);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(112, 20);
            this.textBoxValue.TabIndex = 2;
            this.textBoxValue.KeyPress += 
                new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // labelPurchaseAmount
            // 
            this.labelPurchaseAmount.AutoSize = true;
            this.labelPurchaseAmount.Location = new System.Drawing.Point(6, 26);
            this.labelPurchaseAmount.Name = "labelPurchaseAmount";
            this.labelPurchaseAmount.Size = new System.Drawing.Size(82, 13);
            this.labelPurchaseAmount.TabIndex = 1;
            this.labelPurchaseAmount.Text = "Сумма покупки:";
            // 
            // textBoxPurchaseAmount
            // 
            this.textBoxPurchaseAmount.Location = new System.Drawing.Point(142, 23);
            this.textBoxPurchaseAmount.Name = "textBoxPurchaseAmount";
            this.textBoxPurchaseAmount.Size = new System.Drawing.Size(112, 20);
            this.textBoxPurchaseAmount.TabIndex = 0;
            this.textBoxPurchaseAmount.KeyPress += 
                new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(12, 166);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(260, 23);
            this.buttonRandom.TabIndex = 2;
            this.buttonRandom.Text = "Случайные данные";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.ButtonRandom_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(12, 195);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(126, 23);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "ОК";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(146, 195);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(126, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 230);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonRandom);
            this.Controls.Add(this.groupBoxInputs);
            this.Controls.Add(this.groupBoxStrategy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить расчёт";
            this.groupBoxStrategy.ResumeLayout(false);
            this.groupBoxInputs.ResumeLayout(false);
            this.groupBoxInputs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxStrategy;
        private System.Windows.Forms.ComboBox comboBoxStrategy;
        private System.Windows.Forms.GroupBox groupBoxInputs;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Label labelPurchaseAmount;
        private System.Windows.Forms.TextBox textBoxPurchaseAmount;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}
