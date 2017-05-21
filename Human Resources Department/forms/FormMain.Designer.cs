namespace Human_Resources_Department.forms
{
    partial class FormMain
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
            this.findField = new System.Windows.Forms.TextBox();
            this.panelEmployee = new System.Windows.Forms.Panel();
            this.fieldUpdateAt = new System.Windows.Forms.DateTimePicker();
            this.fieldSetCompany = new System.Windows.Forms.DateTimePicker();
            this.fieldBirthday = new System.Windows.Forms.DateTimePicker();
            this.fieldCity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fieldLName = new System.Windows.Forms.TextBox();
            this.fieldMName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fieldTel = new System.Windows.Forms.TextBox();
            this.fieldEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fieldJob = new System.Windows.Forms.TextBox();
            this.fieldSalary = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldFName = new System.Windows.Forms.TextBox();
            this.formChooseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вибірФіліалаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.імпортВExcelkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.експортЗExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пошукToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.додатиПрацівникаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.додатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.посадиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зарплатаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.фільтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проПрограмуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panelEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // findField
            // 
            this.findField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.findField.Location = new System.Drawing.Point(285, 31);
            this.findField.Name = "findField";
            this.findField.Size = new System.Drawing.Size(184, 20);
            this.findField.TabIndex = 0;
            this.findField.Text = "Швидкий пошук по Прізвищу";
            this.findField.Enter += new System.EventHandler(this.FindField_Enter);
            this.findField.Leave += new System.EventHandler(this.FindField_Leave);
            // 
            // panelEmployee
            // 
            this.panelEmployee.BackColor = System.Drawing.Color.White;
            this.panelEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEmployee.Controls.Add(this.fieldUpdateAt);
            this.panelEmployee.Controls.Add(this.fieldSetCompany);
            this.panelEmployee.Controls.Add(this.fieldBirthday);
            this.panelEmployee.Controls.Add(this.fieldCity);
            this.panelEmployee.Controls.Add(this.label12);
            this.panelEmployee.Controls.Add(this.label10);
            this.panelEmployee.Controls.Add(this.label4);
            this.panelEmployee.Controls.Add(this.fieldLName);
            this.panelEmployee.Controls.Add(this.fieldMName);
            this.panelEmployee.Controls.Add(this.label2);
            this.panelEmployee.Controls.Add(this.label9);
            this.panelEmployee.Controls.Add(this.label7);
            this.panelEmployee.Controls.Add(this.label8);
            this.panelEmployee.Controls.Add(this.pictureBox1);
            this.panelEmployee.Controls.Add(this.fieldTel);
            this.panelEmployee.Controls.Add(this.fieldEmail);
            this.panelEmployee.Controls.Add(this.label5);
            this.panelEmployee.Controls.Add(this.fieldJob);
            this.panelEmployee.Controls.Add(this.fieldSalary);
            this.panelEmployee.Controls.Add(this.label3);
            this.panelEmployee.Controls.Add(this.label1);
            this.panelEmployee.Controls.Add(this.fieldFName);
            this.panelEmployee.Location = new System.Drawing.Point(12, 53);
            this.panelEmployee.Name = "panelEmployee";
            this.panelEmployee.Size = new System.Drawing.Size(255, 573);
            this.panelEmployee.TabIndex = 4;
            // 
            // fieldUpdateAt
            // 
            this.fieldUpdateAt.Location = new System.Drawing.Point(6, 542);
            this.fieldUpdateAt.Name = "fieldUpdateAt";
            this.fieldUpdateAt.Size = new System.Drawing.Size(242, 20);
            this.fieldUpdateAt.TabIndex = 32;
            // 
            // fieldSetCompany
            // 
            this.fieldSetCompany.Location = new System.Drawing.Point(6, 503);
            this.fieldSetCompany.Name = "fieldSetCompany";
            this.fieldSetCompany.Size = new System.Drawing.Size(242, 20);
            this.fieldSetCompany.TabIndex = 31;
            // 
            // fieldBirthday
            // 
            this.fieldBirthday.Location = new System.Drawing.Point(6, 464);
            this.fieldBirthday.Name = "fieldBirthday";
            this.fieldBirthday.Size = new System.Drawing.Size(242, 20);
            this.fieldBirthday.TabIndex = 30;
            // 
            // fieldCity
            // 
            this.fieldCity.Location = new System.Drawing.Point(6, 308);
            this.fieldCity.Name = "fieldCity";
            this.fieldCity.Size = new System.Drawing.Size(242, 20);
            this.fieldCity.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 292);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Місто";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "По-батькові";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата народження";
            // 
            // fieldLName
            // 
            this.fieldLName.Location = new System.Drawing.Point(6, 230);
            this.fieldLName.Name = "fieldLName";
            this.fieldLName.Size = new System.Drawing.Size(242, 20);
            this.fieldLName.TabIndex = 2;
            // 
            // fieldMName
            // 
            this.fieldMName.Location = new System.Drawing.Point(6, 269);
            this.fieldMName.Name = "fieldMName";
            this.fieldMName.Size = new System.Drawing.Size(242, 20);
            this.fieldMName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Прізвище";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 526);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Останнє оновлення";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 487);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Прийнятий на роботу";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Телефон роб.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(50, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // fieldTel
            // 
            this.fieldTel.Location = new System.Drawing.Point(6, 347);
            this.fieldTel.Name = "fieldTel";
            this.fieldTel.Size = new System.Drawing.Size(242, 20);
            this.fieldTel.TabIndex = 8;
            // 
            // fieldEmail
            // 
            this.fieldEmail.Location = new System.Drawing.Point(6, 425);
            this.fieldEmail.Name = "fieldEmail";
            this.fieldEmail.Size = new System.Drawing.Size(242, 20);
            this.fieldEmail.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Email";
            // 
            // fieldJob
            // 
            this.fieldJob.Location = new System.Drawing.Point(50, 146);
            this.fieldJob.Name = "fieldJob";
            this.fieldJob.Size = new System.Drawing.Size(150, 20);
            this.fieldJob.TabIndex = 5;
            this.fieldJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fieldSalary
            // 
            this.fieldSalary.Location = new System.Drawing.Point(6, 386);
            this.fieldSalary.Name = "fieldSalary";
            this.fieldSalary.Size = new System.Drawing.Size(242, 20);
            this.fieldSalary.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Зарплата";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ім\'я";
            // 
            // fieldFName
            // 
            this.fieldFName.Location = new System.Drawing.Point(6, 191);
            this.fieldFName.Name = "fieldFName";
            this.fieldFName.Size = new System.Drawing.Size(242, 20);
            this.fieldFName.TabIndex = 1;
            // 
            // formChooseToolStripMenuItem
            // 
            this.formChooseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вибірФіліалаToolStripMenuItem,
            this.імпортВExcelkToolStripMenuItem,
            this.експортЗExcelToolStripMenuItem,
            this.вихідToolStripMenuItem});
            this.formChooseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.formChooseToolStripMenuItem.Name = "formChooseToolStripMenuItem";
            this.formChooseToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.formChooseToolStripMenuItem.Text = "Меню";
            // 
            // вибірФіліалаToolStripMenuItem
            // 
            this.вибірФіліалаToolStripMenuItem.Name = "вибірФіліалаToolStripMenuItem";
            this.вибірФіліалаToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.вибірФіліалаToolStripMenuItem.Text = "Вибір філіала";
            this.вибірФіліалаToolStripMenuItem.Click += new System.EventHandler(this.FormChooseToolStripMenuItem_Click);
            // 
            // імпортВExcelkToolStripMenuItem
            // 
            this.імпортВExcelkToolStripMenuItem.Name = "імпортВExcelkToolStripMenuItem";
            this.імпортВExcelkToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.імпортВExcelkToolStripMenuItem.Text = "Імпорт в Excel";
            // 
            // експортЗExcelToolStripMenuItem
            // 
            this.експортЗExcelToolStripMenuItem.Name = "експортЗExcelToolStripMenuItem";
            this.експортЗExcelToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.експортЗExcelToolStripMenuItem.Text = "Експорт з Excel";
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.вихідToolStripMenuItem.Text = "Вихід";
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // пошукToolStripMenuItem
            // 
            this.пошукToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.пошукToolStripMenuItem.Name = "пошукToolStripMenuItem";
            this.пошукToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.пошукToolStripMenuItem.Text = "Пошук";
            this.пошукToolStripMenuItem.Click += new System.EventHandler(this.FormSearchToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formChooseToolStripMenuItem,
            this.додатиПрацівникаToolStripMenuItem,
            this.пошукToolStripMenuItem,
            this.фільтрToolStripMenuItem,
            this.проПрограмуToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(776, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // додатиПрацівникаToolStripMenuItem
            // 
            this.додатиПрацівникаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.додатиToolStripMenuItem,
            this.посадиToolStripMenuItem,
            this.зарплатаToolStripMenuItem1});
            this.додатиПрацівникаToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.додатиПрацівникаToolStripMenuItem.Name = "додатиПрацівникаToolStripMenuItem";
            this.додатиПрацівникаToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.додатиПрацівникаToolStripMenuItem.Text = "Філіал";
            // 
            // додатиToolStripMenuItem
            // 
            this.додатиToolStripMenuItem.Name = "додатиToolStripMenuItem";
            this.додатиToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.додатиToolStripMenuItem.Text = "Додати працівника";
            this.додатиToolStripMenuItem.Click += new System.EventHandler(this.FormInsertToolStripMenuItem_Click);
            // 
            // посадиToolStripMenuItem
            // 
            this.посадиToolStripMenuItem.Name = "посадиToolStripMenuItem";
            this.посадиToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.посадиToolStripMenuItem.Text = "Посади";
            this.посадиToolStripMenuItem.Click += new System.EventHandler(this.JobsToolStripMenuItem_Click);
            // 
            // зарплатаToolStripMenuItem1
            // 
            this.зарплатаToolStripMenuItem1.Name = "зарплатаToolStripMenuItem1";
            this.зарплатаToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            this.зарплатаToolStripMenuItem1.Text = "Зарплата";
            this.зарплатаToolStripMenuItem1.Click += new System.EventHandler(this.SalaryToolStripMenuItem_Click);
            // 
            // фільтрToolStripMenuItem
            // 
            this.фільтрToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.фільтрToolStripMenuItem.Name = "фільтрToolStripMenuItem";
            this.фільтрToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.фільтрToolStripMenuItem.Text = "Фільтри";
            this.фільтрToolStripMenuItem.Click += new System.EventHandler(this.FormFilterToolStripMenuItem_Click);
            // 
            // проПрограмуToolStripMenuItem
            // 
            this.проПрограмуToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.проПрограмуToolStripMenuItem.Name = "проПрограмуToolStripMenuItem";
            this.проПрограмуToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.проПрограмуToolStripMenuItem.Text = "Про програму";
            this.проПрограмуToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(464, 31);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(62, 20);
            this.button4.TabIndex = 6;
            this.button4.Text = "Знайти";
            this.button4.UseMnemonic = false;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listView1.Location = new System.Drawing.Point(285, 57);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(479, 569);
            this.listView1.TabIndex = 23;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(532, 31);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(153, 20);
            this.button6.TabIndex = 24;
            this.button6.Text = "Оновити / Скинути фільтри";
            this.button6.UseMnemonic = false;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button7.Enabled = false;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(12, 31);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(255, 23);
            this.button7.TabIndex = 34;
            this.button7.Text = "Оберіть працівника";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.EmployeeToolStripMenuItem_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(691, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 17);
            this.checkBox1.TabIndex = 38;
            this.checkBox1.Text = "Звільнені";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(776, 639);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panelEmployee);
            this.Controls.Add(this.findField);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Human Resources Department";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelEmployee.ResumeLayout(false);
            this.panelEmployee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox findField;
        private System.Windows.Forms.Panel panelEmployee;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox fieldTel;
        private System.Windows.Forms.TextBox fieldEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fieldJob;
        private System.Windows.Forms.TextBox fieldSalary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fieldLName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fieldFName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox fieldMName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem formChooseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пошукToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox fieldCity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem фільтрToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem додатиПрацівникаToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker fieldBirthday;
        private System.Windows.Forms.DateTimePicker fieldSetCompany;
        private System.Windows.Forms.DateTimePicker fieldUpdateAt;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolStripMenuItem проПрограмуToolStripMenuItem;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ToolStripMenuItem додатиToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem вибірФіліалаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem імпортВExcelkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem експортЗExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem посадиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зарплатаToolStripMenuItem1;
    }
}

