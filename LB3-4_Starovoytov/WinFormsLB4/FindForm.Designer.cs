namespace WinFormsLB4
{
    partial class FindForm
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
            this.checkBoxCertificate = new System.Windows.Forms.CheckBox();
            this.checkBoxPercent = new System.Windows.Forms.CheckBox();
            this.groupBoxPurchase = new System.Windows.Forms.GroupBox();
            this.textBoxPurchaseTo = new System.Windows.Forms.TextBox();
            this.labelPurchaseTo = new System.Windows.Forms.Label();
            this.textBoxPurchaseFrom = new System.Windows.Forms.TextBox();
            this.labelPurchaseFrom = new System.Windows.Forms.Label();
            this.groupBoxDiscountValue = new System.Windows.Forms.GroupBox();
            this.textBoxDiscountTo = new System.Windows.Forms.TextBox();
            this.labelDiscountTo = new System.Windows.Forms.Label();
            this.textBoxDiscountFrom = new System.Windows.Forms.TextBox();
            this.labelDiscountFrom = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxStrategy.SuspendLayout();
            this.groupBoxPurchase.SuspendLayout();
            this.groupBoxDiscountValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxStrategy
            // 
            this.groupBoxStrategy.Controls.Add(this.checkBoxCertificate);
            this.groupBoxStrategy.Controls.Add(this.checkBoxPercent);
            this.groupBoxStrategy.Location = new System.Drawing.Point(12, 12);
            this.groupBoxStrategy.Name = "groupBoxStrategy";
            this.groupBoxStrategy.Size = new System.Drawing.Size(260, 63);
            this.groupBoxStrategy.TabIndex = 0;
            this.groupBoxStrategy.TabStop = false;
            this.groupBoxStrategy.Text = "Стратегии скидки";
            // 
            // checkBoxCertificate
            // 
            this.checkBoxCertificate.AutoSize = true;
            this.checkBoxCertificate.Location = new System.Drawing.Point(9, 39);
            this.checkBoxCertificate.Name = "checkBoxCertificate";
            this.checkBoxCertificate.Size = new System.Drawing.Size(82, 17);
            this.checkBoxCertificate.TabIndex = 1;
            this.checkBoxCertificate.Text = "Сертификат";
            this.checkBoxCertificate.UseVisualStyleBackColor = true;
            // 
            // checkBoxPercent
            // 
            this.checkBoxPercent.AutoSize = true;
            this.checkBoxPercent.Location = new System.Drawing.Point(9, 19);
            this.checkBoxPercent.Name = "checkBoxPercent";
            this.checkBoxPercent.Size = new System.Drawing.Size(87, 17);
            this.checkBoxPercent.TabIndex = 0;
            this.checkBoxPercent.Text = "Процентная";
            this.checkBoxPercent.UseVisualStyleBackColor = true;
            // 
            // groupBoxPurchase
            // 
            this.groupBoxPurchase.Controls.Add(this.textBoxPurchaseTo);
            this.groupBoxPurchase.Controls.Add(this.labelPurchaseTo);
            this.groupBoxPurchase.Controls.Add(this.textBoxPurchaseFrom);
            this.groupBoxPurchase.Controls.Add(this.labelPurchaseFrom);
            this.groupBoxPurchase.Location = new System.Drawing.Point(12, 81);
            this.groupBoxPurchase.Name = "groupBoxPurchase";
            this.groupBoxPurchase.Size = new System.Drawing.Size(260, 70);
            this.groupBoxPurchase.TabIndex = 1;
            this.groupBoxPurchase.TabStop = false;
            this.groupBoxPurchase.Text = "Сумма покупки";
            // 
            // textBoxPurchaseTo
            // 
            this.textBoxPurchaseTo.Location = new System.Drawing.Point(142, 42);
            this.textBoxPurchaseTo.Name = "textBoxPurchaseTo";
            this.textBoxPurchaseTo.Size = new System.Drawing.Size(112, 20);
            this.textBoxPurchaseTo.TabIndex = 3;
            this.textBoxPurchaseTo.KeyPress += 
                new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // labelPurchaseTo
            // 
            this.labelPurchaseTo.AutoSize = true;
            this.labelPurchaseTo.Location = new System.Drawing.Point(6, 45);
            this.labelPurchaseTo.Name = "labelPurchaseTo";
            this.labelPurchaseTo.Size = new System.Drawing.Size(25, 13);
            this.labelPurchaseTo.TabIndex = 2;
            this.labelPurchaseTo.Text = "До:";
            // 
            // textBoxPurchaseFrom
            // 
            this.textBoxPurchaseFrom.Location = new System.Drawing.Point(142, 16);
            this.textBoxPurchaseFrom.Name = "textBoxPurchaseFrom";
            this.textBoxPurchaseFrom.Size = new System.Drawing.Size(112, 20);
            this.textBoxPurchaseFrom.TabIndex = 1;
            this.textBoxPurchaseFrom.KeyPress += 
                new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // labelPurchaseFrom
            // 
            this.labelPurchaseFrom.AutoSize = true;
            this.labelPurchaseFrom.Location = new System.Drawing.Point(6, 19);
            this.labelPurchaseFrom.Name = "labelPurchaseFrom";
            this.labelPurchaseFrom.Size = new System.Drawing.Size(23, 13);
            this.labelPurchaseFrom.TabIndex = 0;
            this.labelPurchaseFrom.Text = "От:";
            // 
            // groupBoxDiscountValue
            // 
            this.groupBoxDiscountValue.Controls.Add(this.textBoxDiscountTo);
            this.groupBoxDiscountValue.Controls.Add(this.labelDiscountTo);
            this.groupBoxDiscountValue.Controls.Add(this.textBoxDiscountFrom);
            this.groupBoxDiscountValue.Controls.Add(this.labelDiscountFrom);
            this.groupBoxDiscountValue.Location = new System.Drawing.Point(12, 157);
            this.groupBoxDiscountValue.Name = "groupBoxDiscountValue";
            this.groupBoxDiscountValue.Size = new System.Drawing.Size(260, 70);
            this.groupBoxDiscountValue.TabIndex = 2;
            this.groupBoxDiscountValue.TabStop = false;
            this.groupBoxDiscountValue.Text = "Величина скидки";
            // 
            // textBoxDiscountTo
            // 
            this.textBoxDiscountTo.Location = new System.Drawing.Point(142, 42);
            this.textBoxDiscountTo.Name = "textBoxDiscountTo";
            this.textBoxDiscountTo.Size = new System.Drawing.Size(112, 20);
            this.textBoxDiscountTo.TabIndex = 3;
            this.textBoxDiscountTo.KeyPress += 
                new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // labelDiscountTo
            // 
            this.labelDiscountTo.AutoSize = true;
            this.labelDiscountTo.Location = new System.Drawing.Point(6, 45);
            this.labelDiscountTo.Name = "labelDiscountTo";
            this.labelDiscountTo.Size = new System.Drawing.Size(25, 13);
            this.labelDiscountTo.TabIndex = 2;
            this.labelDiscountTo.Text = "До:";
            // 
            // textBoxDiscountFrom
            // 
            this.textBoxDiscountFrom.Location = new System.Drawing.Point(142, 16);
            this.textBoxDiscountFrom.Name = "textBoxDiscountFrom";
            this.textBoxDiscountFrom.Size = new System.Drawing.Size(112, 20);
            this.textBoxDiscountFrom.TabIndex = 1;
            this.textBoxDiscountFrom.KeyPress += 
                new System.Windows.Forms.KeyPressEventHandler(this.NumericTextboxKeyPress);
            // 
            // labelDiscountFrom
            // 
            this.labelDiscountFrom.AutoSize = true;
            this.labelDiscountFrom.Location = new System.Drawing.Point(6, 19);
            this.labelDiscountFrom.Name = "labelDiscountFrom";
            this.labelDiscountFrom.Size = new System.Drawing.Size(23, 13);
            this.labelDiscountFrom.TabIndex = 0;
            this.labelDiscountFrom.Text = "От:";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(12, 238);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(126, 23);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "Найти";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(146, 238);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(126, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 273);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBoxDiscountValue);
            this.Controls.Add(this.groupBoxPurchase);
            this.Controls.Add(this.groupBoxStrategy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск";
            this.groupBoxStrategy.ResumeLayout(false);
            this.groupBoxStrategy.PerformLayout();
            this.groupBoxPurchase.ResumeLayout(false);
            this.groupBoxPurchase.PerformLayout();
            this.groupBoxDiscountValue.ResumeLayout(false);
            this.groupBoxDiscountValue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxStrategy;
        private System.Windows.Forms.CheckBox checkBoxCertificate;
        private System.Windows.Forms.CheckBox checkBoxPercent;
        private System.Windows.Forms.GroupBox groupBoxPurchase;
        private System.Windows.Forms.TextBox textBoxPurchaseTo;
        private System.Windows.Forms.Label labelPurchaseTo;
        private System.Windows.Forms.TextBox textBoxPurchaseFrom;
        private System.Windows.Forms.Label labelPurchaseFrom;
        private System.Windows.Forms.GroupBox groupBoxDiscountValue;
        private System.Windows.Forms.TextBox textBoxDiscountTo;
        private System.Windows.Forms.Label labelDiscountTo;
        private System.Windows.Forms.TextBox textBoxDiscountFrom;
        private System.Windows.Forms.Label labelDiscountFrom;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}
