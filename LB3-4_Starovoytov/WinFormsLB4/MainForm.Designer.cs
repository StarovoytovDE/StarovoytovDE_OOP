namespace WinFormsLB4
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.RandomButton = new System.Windows.Forms.Button();
            this.DeleteAllButton = new System.Windows.Forms.Button();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitFileButton = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLoadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindButton = new System.Windows.Forms.Button();
            this.FilterResetButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вычисление скидки";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(242, 136);
            this.dataGridView1.TabIndex = 0;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 200);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(120, 23);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Добавить расчёт";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(140, 200);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(120, 23);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Удалить расчёт";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // RandomButton
            // 
            this.RandomButton.Location = new System.Drawing.Point(12, 229);
            this.RandomButton.Name = "RandomButton";
            this.RandomButton.Size = new System.Drawing.Size(120, 23);
            this.RandomButton.TabIndex = 3;
            this.RandomButton.Text = "Случайный расчёт";
            this.RandomButton.UseVisualStyleBackColor = true;
            this.RandomButton.Click += new System.EventHandler(this.RandomButton_Click);
            // 
            // DeleteAllButton
            // 
            this.DeleteAllButton.Location = new System.Drawing.Point(140, 229);
            this.DeleteAllButton.Name = "DeleteAllButton";
            this.DeleteAllButton.Size = new System.Drawing.Size(120, 23);
            this.DeleteAllButton.TabIndex = 4;
            this.DeleteAllButton.Text = "Очистить список";
            this.DeleteAllButton.UseVisualStyleBackColor = true;
            this.DeleteAllButton.Click += new System.EventHandler(this.DeleteAllButton_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitFileButton});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(272, 25);
            this.toolStrip3.TabIndex = 6;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripSplitFileButton
            // 
            this.toolStripSplitFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitFileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSaveMenuItem,
            this.toolStripLoadMenuItem});
            this.toolStripSplitFileButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitFileButton.Image")));
            this.toolStripSplitFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitFileButton.Name = "toolStripSplitFileButton";
            this.toolStripSplitFileButton.Size = new System.Drawing.Size(52, 22);
            this.toolStripSplitFileButton.Text = "Файл";
            // 
            // toolStripSaveMenuItem
            // 
            this.toolStripSaveMenuItem.Name = "toolStripSaveMenuItem";
            this.toolStripSaveMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toolStripSaveMenuItem.Text = "Сохранить";
            this.toolStripSaveMenuItem.Click += new System.EventHandler(this.toolStripSaveMenuItem_Click);
            // 
            // toolStripLoadMenuItem
            // 
            this.toolStripLoadMenuItem.Name = "toolStripLoadMenuItem";
            this.toolStripLoadMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toolStripLoadMenuItem.Text = "Загрузить";
            this.toolStripLoadMenuItem.Click += new System.EventHandler(this.toolStripLoadMenuItem_Click);
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(12, 258);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(120, 23);
            this.FindButton.TabIndex = 7;
            this.FindButton.Text = "Найти";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // FilterResetButton
            // 
            this.FilterResetButton.Location = new System.Drawing.Point(140, 258);
            this.FilterResetButton.Name = "FilterResetButton";
            this.FilterResetButton.Size = new System.Drawing.Size(120, 23);
            this.FilterResetButton.TabIndex = 8;
            this.FilterResetButton.Text = "Сброс фильтрации";
            this.FilterResetButton.UseVisualStyleBackColor = true;
            this.FilterResetButton.Click += new System.EventHandler(this.FilterResetButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 296);
            this.Controls.Add(this.FilterResetButton);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.DeleteAllButton);
            this.Controls.Add(this.RandomButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Расчёт скидки";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button RandomButton;
        private System.Windows.Forms.Button DeleteAllButton;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitFileButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripLoadMenuItem;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Button FilterResetButton;
    }
}

