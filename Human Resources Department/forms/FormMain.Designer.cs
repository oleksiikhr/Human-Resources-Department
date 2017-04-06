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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.findField = new System.Windows.Forms.TextBox();
            this.detailStaff = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.fieldIsFulltime = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.fieldCity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.fieldFamily = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.fieldMName = new System.Windows.Forms.TextBox();
            this.fieldUpdateAt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.fieldSetCompany = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fieldTel = new System.Windows.Forms.TextBox();
            this.fieldEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fieldJob = new System.Windows.Forms.TextBox();
            this.fieldSalary = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fieldBirthday = new System.Windows.Forms.TextBox();
            this.fieldLName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldFName = new System.Windows.Forms.TextBox();
            this.formChooseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пошукToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.додатиПрацівникаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фільтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.налаштуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.detailStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // findField
            // 
            this.findField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.findField.Location = new System.Drawing.Point(285, 31);
            this.findField.Name = "findField";
            this.findField.Size = new System.Drawing.Size(275, 20);
            this.findField.TabIndex = 0;
            this.findField.Text = "Швидкий пошук по Прізвищу";
            this.findField.Enter += new System.EventHandler(this.FindField_Enter);
            this.findField.Leave += new System.EventHandler(this.FindField_Leave);
            // 
            // detailStaff
            // 
            this.detailStaff.BackColor = System.Drawing.Color.White;
            this.detailStaff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailStaff.Controls.Add(this.button3);
            this.detailStaff.Controls.Add(this.fieldIsFulltime);
            this.detailStaff.Controls.Add(this.label13);
            this.detailStaff.Controls.Add(this.fieldCity);
            this.detailStaff.Controls.Add(this.label12);
            this.detailStaff.Controls.Add(this.fieldFamily);
            this.detailStaff.Controls.Add(this.label11);
            this.detailStaff.Controls.Add(this.button2);
            this.detailStaff.Controls.Add(this.button1);
            this.detailStaff.Controls.Add(this.label10);
            this.detailStaff.Controls.Add(this.fieldLName);
            this.detailStaff.Controls.Add(this.fieldMName);
            this.detailStaff.Controls.Add(this.label2);
            this.detailStaff.Controls.Add(this.fieldUpdateAt);
            this.detailStaff.Controls.Add(this.label9);
            this.detailStaff.Controls.Add(this.fieldSetCompany);
            this.detailStaff.Controls.Add(this.label7);
            this.detailStaff.Controls.Add(this.label8);
            this.detailStaff.Controls.Add(this.pictureBox1);
            this.detailStaff.Controls.Add(this.fieldTel);
            this.detailStaff.Controls.Add(this.fieldEmail);
            this.detailStaff.Controls.Add(this.label5);
            this.detailStaff.Controls.Add(this.label6);
            this.detailStaff.Controls.Add(this.fieldJob);
            this.detailStaff.Controls.Add(this.fieldSalary);
            this.detailStaff.Controls.Add(this.label3);
            this.detailStaff.Controls.Add(this.label4);
            this.detailStaff.Controls.Add(this.fieldBirthday);
            this.detailStaff.Controls.Add(this.label1);
            this.detailStaff.Controls.Add(this.fieldFName);
            this.detailStaff.Location = new System.Drawing.Point(12, 50);
            this.detailStaff.Name = "detailStaff";
            this.detailStaff.Size = new System.Drawing.Size(255, 400);
            this.detailStaff.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.button3.Enabled = false;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(130, 369);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 23);
            this.button3.TabIndex = 29;
            this.button3.Text = "Відмінити";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // textBox13
            // 
            this.fieldIsFulltime.Location = new System.Drawing.Point(129, 181);
            this.fieldIsFulltime.Name = "textBox13";
            this.fieldIsFulltime.ReadOnly = true;
            this.fieldIsFulltime.Size = new System.Drawing.Size(120, 20);
            this.fieldIsFulltime.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(126, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Повна зайнятість";
            // 
            // textBox12
            // 
            this.fieldCity.Location = new System.Drawing.Point(4, 181);
            this.fieldCity.Name = "textBox12";
            this.fieldCity.ReadOnly = true;
            this.fieldCity.Size = new System.Drawing.Size(120, 20);
            this.fieldCity.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 165);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Місто";
            // 
            // textBox11
            // 
            this.fieldFamily.Location = new System.Drawing.Point(129, 264);
            this.fieldFamily.Name = "textBox11";
            this.fieldFamily.ReadOnly = true;
            this.fieldFamily.Size = new System.Drawing.Size(120, 20);
            this.fieldFamily.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(126, 248);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Сімейний стан";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(5, 369);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Зберегти";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(5, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Режим редагування";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(126, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "По-батькові";
            // 
            // fieldMName
            // 
            this.fieldMName.Location = new System.Drawing.Point(129, 61);
            this.fieldMName.Name = "fieldMName";
            this.fieldMName.ReadOnly = true;
            this.fieldMName.Size = new System.Drawing.Size(120, 20);
            this.fieldMName.TabIndex = 3;
            // 
            // textBox9
            // 
            this.fieldUpdateAt.Location = new System.Drawing.Point(129, 303);
            this.fieldUpdateAt.Name = "textBox9";
            this.fieldUpdateAt.ReadOnly = true;
            this.fieldUpdateAt.Size = new System.Drawing.Size(120, 20);
            this.fieldUpdateAt.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(126, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Останнє оновлення";
            // 
            // textBox7
            // 
            this.fieldSetCompany.Location = new System.Drawing.Point(4, 303);
            this.fieldSetCompany.Name = "textBox7";
            this.fieldSetCompany.ReadOnly = true;
            this.fieldSetCompany.Size = new System.Drawing.Size(120, 20);
            this.fieldSetCompany.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Назначений";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Телефон";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox8
            // 
            this.fieldTel.Location = new System.Drawing.Point(4, 222);
            this.fieldTel.Name = "textBox8";
            this.fieldTel.ReadOnly = true;
            this.fieldTel.Size = new System.Drawing.Size(120, 20);
            this.fieldTel.TabIndex = 8;
            // 
            // textBox5
            // 
            this.fieldEmail.Location = new System.Drawing.Point(129, 222);
            this.fieldEmail.Name = "textBox5";
            this.fieldEmail.ReadOnly = true;
            this.fieldEmail.Size = new System.Drawing.Size(120, 20);
            this.fieldEmail.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(126, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Посада";
            // 
            // textBox6
            // 
            this.fieldJob.Location = new System.Drawing.Point(129, 142);
            this.fieldJob.Name = "textBox6";
            this.fieldJob.ReadOnly = true;
            this.fieldJob.Size = new System.Drawing.Size(120, 20);
            this.fieldJob.TabIndex = 5;
            // 
            // textBox3
            // 
            this.fieldSalary.Location = new System.Drawing.Point(4, 264);
            this.fieldSalary.Name = "textBox3";
            this.fieldSalary.ReadOnly = true;
            this.fieldSalary.Size = new System.Drawing.Size(120, 20);
            this.fieldSalary.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Зарплата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата народження";
            // 
            // textBox4
            // 
            this.fieldBirthday.Location = new System.Drawing.Point(4, 142);
            this.fieldBirthday.Name = "textBox4";
            this.fieldBirthday.ReadOnly = true;
            this.fieldBirthday.Size = new System.Drawing.Size(120, 20);
            this.fieldBirthday.TabIndex = 4;
            // 
            // fieldLName
            // 
            this.fieldLName.Location = new System.Drawing.Point(129, 100);
            this.fieldLName.Name = "fieldLName";
            this.fieldLName.ReadOnly = true;
            this.fieldLName.Size = new System.Drawing.Size(120, 20);
            this.fieldLName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Прізвище";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "І\'мя";
            // 
            // fieldFName
            // 
            this.fieldFName.Location = new System.Drawing.Point(129, 22);
            this.fieldFName.Name = "fieldFName";
            this.fieldFName.ReadOnly = true;
            this.fieldFName.Size = new System.Drawing.Size(120, 20);
            this.fieldFName.TabIndex = 1;
            // 
            // formChooseToolStripMenuItem
            // 
            this.formChooseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.formChooseToolStripMenuItem.Name = "formChooseToolStripMenuItem";
            this.formChooseToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.formChooseToolStripMenuItem.Text = "Вибір фірми";
            this.formChooseToolStripMenuItem.Click += new System.EventHandler(this.FormChooseToolStripMenuItem_Click);
            // 
            // пошукToolStripMenuItem
            // 
            this.пошукToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.пошукToolStripMenuItem.Name = "пошукToolStripMenuItem";
            this.пошукToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.пошукToolStripMenuItem.Text = "Пошук";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formChooseToolStripMenuItem,
            this.додатиПрацівникаToolStripMenuItem,
            this.пошукToolStripMenuItem,
            this.фільтрToolStripMenuItem,
            this.налаштуванняToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // додатиПрацівникаToolStripMenuItem
            // 
            this.додатиПрацівникаToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.додатиПрацівникаToolStripMenuItem.Name = "додатиПрацівникаToolStripMenuItem";
            this.додатиПрацівникаToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.додатиПрацівникаToolStripMenuItem.Text = "Додати працівника";
            this.додатиПрацівникаToolStripMenuItem.Click += new System.EventHandler(this.AddNewEmployeeToolStripMenuItem_Click);
            // 
            // фільтрToolStripMenuItem
            // 
            this.фільтрToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.фільтрToolStripMenuItem.Name = "фільтрToolStripMenuItem";
            this.фільтрToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.фільтрToolStripMenuItem.Text = "Фільтр";
            // 
            // налаштуванняToolStripMenuItem
            // 
            this.налаштуванняToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.налаштуванняToolStripMenuItem.Name = "налаштуванняToolStripMenuItem";
            this.налаштуванняToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.налаштуванняToolStripMenuItem.Text = "Налаштування";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(285, 57);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(343, 518);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.DataGridView1_CurrentCellChanged);
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
            this.button4.Location = new System.Drawing.Point(557, 31);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 20);
            this.button4.TabIndex = 6;
            this.button4.Text = "Знайти";
            this.button4.UseMnemonic = false;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Location = new System.Drawing.Point(12, 460);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 15);
            this.label14.TabIndex = 8;
            this.label14.Text = "Файли співробітника";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 480);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(255, 95);
            this.listBox1.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoEllipsis = true;
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Location = new System.Drawing.Point(12, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 15);
            this.label15.TabIndex = 10;
            this.label15.Text = "Вибраний співробітник";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Brown;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(161, 31);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 20);
            this.button5.TabIndex = 11;
            this.button5.Text = "Звільнити";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(161, 460);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(106, 21);
            this.button6.TabIndex = 12;
            this.button6.Text = "Відкрити папку";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(640, 582);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.detailStaff);
            this.Controls.Add(this.findField);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Human Resources Department";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.detailStaff.ResumeLayout(false);
            this.detailStaff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox findField;
        private System.Windows.Forms.Panel detailStaff;
        private System.Windows.Forms.TextBox fieldSetCompany;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox fieldTel;
        private System.Windows.Forms.TextBox fieldEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fieldJob;
        private System.Windows.Forms.TextBox fieldSalary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fieldBirthday;
        private System.Windows.Forms.TextBox fieldLName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fieldFName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox fieldMName;
        private System.Windows.Forms.TextBox fieldUpdateAt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox fieldFamily;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem formChooseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пошукToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox fieldIsFulltime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox fieldCity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem фільтрToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolStripMenuItem налаштуванняToolStripMenuItem;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem додатиПрацівникаToolStripMenuItem;
        private System.Windows.Forms.Button button6;
    }
}

