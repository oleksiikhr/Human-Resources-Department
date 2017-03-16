namespace Human_Resources_Department
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.завантажитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вийтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.працівникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фільтриToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пошукToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findField = new System.Windows.Forms.TextBox();
            this.listStaff = new System.Windows.Forms.ListView();
            this.photo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.age = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.detailStaff = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.працівникиToolStripMenuItem,
            this.фільтриToolStripMenuItem,
            this.пошукToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(446, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.зберегтиToolStripMenuItem,
            this.завантажитиToolStripMenuItem,
            this.вийтиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // зберегтиToolStripMenuItem
            // 
            this.зберегтиToolStripMenuItem.Name = "зберегтиToolStripMenuItem";
            this.зберегтиToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.зберегтиToolStripMenuItem.Text = "Зберегти";
            // 
            // завантажитиToolStripMenuItem
            // 
            this.завантажитиToolStripMenuItem.Name = "завантажитиToolStripMenuItem";
            this.завантажитиToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.завантажитиToolStripMenuItem.Text = "Завантажити";
            // 
            // вийтиToolStripMenuItem
            // 
            this.вийтиToolStripMenuItem.Name = "вийтиToolStripMenuItem";
            this.вийтиToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.вийтиToolStripMenuItem.Text = "Вийти";
            // 
            // працівникиToolStripMenuItem
            // 
            this.працівникиToolStripMenuItem.Name = "працівникиToolStripMenuItem";
            this.працівникиToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.працівникиToolStripMenuItem.Text = "Працівники";
            // 
            // фільтриToolStripMenuItem
            // 
            this.фільтриToolStripMenuItem.Name = "фільтриToolStripMenuItem";
            this.фільтриToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.фільтриToolStripMenuItem.Text = "Фільтри";
            // 
            // пошукToolStripMenuItem
            // 
            this.пошукToolStripMenuItem.Name = "пошукToolStripMenuItem";
            this.пошукToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.пошукToolStripMenuItem.Text = "Пошук";
            // 
            // findField
            // 
            this.findField.Location = new System.Drawing.Point(0, 27);
            this.findField.Name = "findField";
            this.findField.Size = new System.Drawing.Size(446, 20);
            this.findField.TabIndex = 1;
            this.findField.Text = "Пошук";
            this.findField.TextChanged += new System.EventHandler(this.findField_TextChanged);
            this.findField.Enter += new System.EventHandler(this.findField_Enter);
            this.findField.Leave += new System.EventHandler(this.findField_Leave);
            // 
            // listStaff
            // 
            this.listStaff.AllowColumnReorder = true;
            this.listStaff.AllowDrop = true;
            this.listStaff.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.photo,
            this.name,
            this.age});
            this.listStaff.FullRowSelect = true;
            this.listStaff.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listStaff.Location = new System.Drawing.Point(0, 53);
            this.listStaff.Name = "listStaff";
            this.listStaff.Size = new System.Drawing.Size(284, 321);
            this.listStaff.TabIndex = 2;
            this.listStaff.UseCompatibleStateImageBehavior = false;
            // 
            // photo
            // 
            this.photo.Text = "Фото";
            // 
            // name
            // 
            this.name.Text = "ПІБ";
            // 
            // age
            // 
            this.age.Text = "Вік";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // detailStaff
            // 
            this.detailStaff.Location = new System.Drawing.Point(290, 53);
            this.detailStaff.Name = "detailStaff";
            this.detailStaff.Size = new System.Drawing.Size(156, 321);
            this.detailStaff.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 474);
            this.Controls.Add(this.detailStaff);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listStaff);
            this.Controls.Add(this.findField);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Автоматизована система \"Кадри\"";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зберегтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem завантажитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вийтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem працівникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фільтриToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пошукToolStripMenuItem;
        private System.Windows.Forms.TextBox findField;
        private System.Windows.Forms.ListView listStaff;
        private System.Windows.Forms.ColumnHeader photo;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader age;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel detailStaff;
    }
}

