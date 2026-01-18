namespace WinFormsLB4
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = 
                new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = 
                new System.Windows.Forms.DataGridViewCellStyle();
            this.groupDiscountColculation = new System.Windows.Forms.GroupBox();
            this.dataGridViewMainForm = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.RandomButton = new System.Windows.Forms.Button();
            this.DeleteAllButton = new System.Windows.Forms.Button();
            this.FindButton = new System.Windows.Forms.Button();
            this.FilterResetButton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSave = new System.Windows.Forms.ToolStripSplitButton();
            this.ToolStripSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripLoadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupDiscountColculation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(
                this.dataGridViewMainForm)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDiscountColculation
            // 
            this.groupDiscountColculation.Anchor = ((
                System.Windows.Forms.AnchorStyles)((((
                System.Windows.Forms.AnchorStyles.Top 
                | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDiscountColculation.Controls.Add(this.dataGridViewMainForm);
            this.groupDiscountColculation.Location = new System.Drawing.Point(11, 28);
            this.groupDiscountColculation.Name = "groupDiscountColculation";
            this.groupDiscountColculation.Size = new System.Drawing.Size(661, 200);
            this.groupDiscountColculation.TabIndex = 0;
            this.groupDiscountColculation.TabStop = false;
            this.groupDiscountColculation.Text = "Вычисление скидки";
            // 
            // dataGridViewMainForm
            // 
            this.dataGridViewMainForm.ClipboardCopyMode = 
                System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = 
                System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = 
                System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new 
                System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = 
                System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = 
                System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = 
                System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = 
                System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMainForm.ColumnHeadersDefaultCellStyle = 
                dataGridViewCellStyle1;
            this.dataGridViewMainForm.ColumnHeadersHeightSizeMode = 
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = 
                System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = 
                System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = 
                new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = 
                System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = 
                System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = 
                System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = 
                System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMainForm.DefaultCellStyle = 
                dataGridViewCellStyle2;
            this.dataGridViewMainForm.Dock = 
                System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMainForm.Location = 
                new System.Drawing.Point(3, 16);
            this.dataGridViewMainForm.Name = "dataGridViewMainForm";
            this.dataGridViewMainForm.ReadOnly = true;
            this.dataGridViewMainForm.Size = 
                new System.Drawing.Size(655, 181);
            this.dataGridViewMainForm.TabIndex = 0;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddButton.Location = new System.Drawing.Point(219, 245);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(120, 23);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Добавить расчёт";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(
                this.AddButton_Clicked);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DeleteButton.Location = new System.Drawing.Point(347, 245);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(120, 23);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Удалить расчёт";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(
                this.DeleteButton_Clicked);
            // 
            // RandomButton
            // 
#if DEBUG
            this.RandomButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RandomButton.Location = new System.Drawing.Point(508, 274);
            this.RandomButton.Name = "RandomButton";
            this.RandomButton.Size = new System.Drawing.Size(120, 23);
            this.RandomButton.TabIndex = 3;
            this.RandomButton.Text = "Случайный расчёт";
            this.RandomButton.UseVisualStyleBackColor = true;
            this.RandomButton.Click += new System.EventHandler(
                this.RandomButton_Clicked);
#endif
            // 
            // DeleteAllButton
            // 
            this.DeleteAllButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DeleteAllButton.Location = new System.Drawing.Point(219, 274);
            this.DeleteAllButton.Name = "DeleteAllButton";
            this.DeleteAllButton.Size = new System.Drawing.Size(248, 23);
            this.DeleteAllButton.TabIndex = 4;
            this.DeleteAllButton.Text = "Очистить список";
            this.DeleteAllButton.UseVisualStyleBackColor = true;
            this.DeleteAllButton.Click += new System.EventHandler(
                this.DeleteAllButton_Clicked);
            // 
            // FindButton
            // 
            this.FindButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.FindButton.Location = new System.Drawing.Point(219, 303);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(120, 23);
            this.FindButton.TabIndex = 5;
            this.FindButton.Text = "Найти";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(
                this.FindButton_Clicked);
            // 
            // FilterResetButton
            // 
            this.FilterResetButton.Anchor = 
                System.Windows.Forms.AnchorStyles.Bottom;
            this.FilterResetButton.Location = new System.Drawing.Point(347, 303);
            this.FilterResetButton.Name = "FilterResetButton";
            this.FilterResetButton.Size = new System.Drawing.Size(120, 23);
            this.FilterResetButton.TabIndex = 6;
            this.FilterResetButton.Text = "Сброс фильтрации";
            this.FilterResetButton.UseVisualStyleBackColor = true;
            this.FilterResetButton.Click += new System.EventHandler(
                this.FilterResetButton_Clicked);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(
                new System.Windows.Forms.ToolStripItem[] {this.toolStripSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(684, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSave
            // 
            this.toolStripSave.DisplayStyle = 
                System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSave.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSaveMenuItem,
            this.ToolStripLoadMenuItem});
            this.toolStripSave.ImageTransparentColor = 
                System.Drawing.Color.Magenta;
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.Size = new System.Drawing.Size(52, 22);
            this.toolStripSave.Text = "Файл";
            // 
            // ToolStripSaveMenuItem
            // 
            this.ToolStripSaveMenuItem.Name = "ToolStripSaveMenuItem";
            this.ToolStripSaveMenuItem.Size = 
                new System.Drawing.Size(132, 22);
            this.ToolStripSaveMenuItem.Text = "Сохранить";
            this.ToolStripSaveMenuItem.Click += 
                new System.EventHandler(this.ToolStripSaveMenuItem_Clicked);
            // 
            // ToolStripLoadMenuItem
            // 
            this.ToolStripLoadMenuItem.Name = "ToolStripLoadMenuItem";
            this.ToolStripLoadMenuItem.Size = 
                new System.Drawing.Size(132, 22);
            this.ToolStripLoadMenuItem.Text = "Загрузить";
            this.ToolStripLoadMenuItem.Click += 
                new System.EventHandler(this.ToolStripLoadMenuItem_Clicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 341);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.FilterResetButton);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.DeleteAllButton);
            this.Controls.Add(this.RandomButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.groupDiscountColculation);
            this.MinimumSize = new System.Drawing.Size(700, 380);
            this.Name = "MainForm";
            this.StartPosition = 
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расчёт скидки";
            this.groupDiscountColculation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(
                this.dataGridViewMainForm)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion

        private System.Windows.Forms.GroupBox groupDiscountColculation;
        private System.Windows.Forms.DataGridView dataGridViewMainForm;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button RandomButton;
        private System.Windows.Forms.Button DeleteAllButton;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Button FilterResetButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSave;
        private System.Windows.Forms.ToolStripMenuItem ToolStripSaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripLoadMenuItem;
    }
}
