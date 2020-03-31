namespace TestMyDrawing
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_CurrentFile = new MetroFramework.Controls.MetroLabel();
            this.lbl_Edit = new System.Windows.Forms.Label();
            this.lbl_Service = new System.Windows.Forms.Label();
            this.lbl_File = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnl_CurveSettings = new System.Windows.Forms.Panel();
            this.cmb_Curves = new MetroFramework.Controls.MetroComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nud_Thickness = new System.Windows.Forms.NumericUpDown();
            this.txb_DotsString = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txb_CurveLegend = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_CurvesDots = new MetroFramework.Controls.MetroComboBox();
            this.rtb_TableTxt = new System.Windows.Forms.RichTextBox();
            this.pnl_StripElements = new System.Windows.Forms.Panel();
            this.btn_RefreshCurve = new System.Windows.Forms.Button();
            this.btn_AddNewCurve = new System.Windows.Forms.Button();
            this.btn_DeleteCurve = new System.Windows.Forms.Button();
            this.rb_Solid = new System.Windows.Forms.RadioButton();
            this.rb_Dot = new System.Windows.Forms.RadioButton();
            this.rb_DashDotDot = new System.Windows.Forms.RadioButton();
            this.rb_DashDot = new System.Windows.Forms.RadioButton();
            this.rb_Dash = new System.Windows.Forms.RadioButton();
            this.pcb_CurveColor = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_Back = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnl_CurveSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Thickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_CurveColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(89)))), ((int)(((byte)(107)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btn_Back);
            this.panel1.Controls.Add(this.lbl_CurrentFile);
            this.panel1.Controls.Add(this.lbl_Edit);
            this.panel1.Controls.Add(this.lbl_Service);
            this.panel1.Controls.Add(this.lbl_File);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("MT Extra", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 58);
            this.panel1.TabIndex = 0;
            // 
            // lbl_CurrentFile
            // 
            this.lbl_CurrentFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_CurrentFile.AutoSize = true;
            this.lbl_CurrentFile.Location = new System.Drawing.Point(475, 5);
            this.lbl_CurrentFile.Name = "lbl_CurrentFile";
            this.lbl_CurrentFile.Size = new System.Drawing.Size(0, 0);
            this.lbl_CurrentFile.Style = MetroFramework.MetroColorStyle.White;
            this.lbl_CurrentFile.TabIndex = 2;
            this.lbl_CurrentFile.UseCustomBackColor = true;
            this.lbl_CurrentFile.UseStyleColors = true;
            // 
            // lbl_Edit
            // 
            this.lbl_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(89)))), ((int)(((byte)(107)))));
            this.lbl_Edit.Font = new System.Drawing.Font("Myanmar Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Edit.ForeColor = System.Drawing.Color.LightCyan;
            this.lbl_Edit.Location = new System.Drawing.Point(157, 35);
            this.lbl_Edit.Name = "lbl_Edit";
            this.lbl_Edit.Size = new System.Drawing.Size(71, 23);
            this.lbl_Edit.TabIndex = 1;
            this.lbl_Edit.Text = "Правка";
            this.lbl_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Edit.Click += new System.EventHandler(this.lbl_Edit_Click);
            this.lbl_Edit.MouseEnter += new System.EventHandler(this.lbl_Edit_MouseEnter);
            this.lbl_Edit.MouseLeave += new System.EventHandler(this.lbl_Edit_MouseLeave);
            // 
            // lbl_Service
            // 
            this.lbl_Service.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(89)))), ((int)(((byte)(107)))));
            this.lbl_Service.Font = new System.Drawing.Font("Myanmar Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Service.ForeColor = System.Drawing.Color.LightCyan;
            this.lbl_Service.Location = new System.Drawing.Point(69, 35);
            this.lbl_Service.Name = "lbl_Service";
            this.lbl_Service.Size = new System.Drawing.Size(82, 23);
            this.lbl_Service.TabIndex = 1;
            this.lbl_Service.Text = "Сервис";
            this.lbl_Service.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Service.Click += new System.EventHandler(this.lbl_Service_Click);
            this.lbl_Service.MouseEnter += new System.EventHandler(this.lbl_Service_MouseEnter);
            this.lbl_Service.MouseLeave += new System.EventHandler(this.lbl_Service_MouseLeave);
            // 
            // lbl_File
            // 
            this.lbl_File.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(154)))), ((int)(((byte)(185)))));
            this.lbl_File.Font = new System.Drawing.Font("Myanmar Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_File.ForeColor = System.Drawing.Color.LightCyan;
            this.lbl_File.Location = new System.Drawing.Point(0, 35);
            this.lbl_File.Name = "lbl_File";
            this.lbl_File.Size = new System.Drawing.Size(63, 23);
            this.lbl_File.TabIndex = 1;
            this.lbl_File.Text = "Файл";
            this.lbl_File.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_File.Click += new System.EventHandler(this.lbl_File_Click);
            this.lbl_File.MouseEnter += new System.EventHandler(this.lbl_File_MouseEnter);
            this.lbl_File.MouseLeave += new System.EventHandler(this.lbl_File_MouseLeave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1004, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightCyan;
            this.panel2.Controls.Add(this.pnl_CurveSettings);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.cmb_CurvesDots);
            this.panel2.Controls.Add(this.rtb_TableTxt);
            this.panel2.Controls.Add(this.pnl_StripElements);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1030, 542);
            this.panel2.TabIndex = 1;
            // 
            // pnl_CurveSettings
            // 
            this.pnl_CurveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_CurveSettings.AutoScroll = true;
            this.pnl_CurveSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_CurveSettings.Controls.Add(this.cmb_Curves);
            this.pnl_CurveSettings.Controls.Add(this.groupBox2);
            this.pnl_CurveSettings.Controls.Add(this.groupBox1);
            this.pnl_CurveSettings.Controls.Add(this.nud_Thickness);
            this.pnl_CurveSettings.Controls.Add(this.pcb_CurveColor);
            this.pnl_CurveSettings.Controls.Add(this.txb_DotsString);
            this.pnl_CurveSettings.Controls.Add(this.panel4);
            this.pnl_CurveSettings.Controls.Add(this.txb_CurveLegend);
            this.pnl_CurveSettings.Controls.Add(this.panel3);
            this.pnl_CurveSettings.Controls.Add(this.label6);
            this.pnl_CurveSettings.Controls.Add(this.label5);
            this.pnl_CurveSettings.Controls.Add(this.label4);
            this.pnl_CurveSettings.Controls.Add(this.label3);
            this.pnl_CurveSettings.Controls.Add(this.label2);
            this.pnl_CurveSettings.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pnl_CurveSettings.Location = new System.Drawing.Point(1050, 45);
            this.pnl_CurveSettings.Name = "pnl_CurveSettings";
            this.pnl_CurveSettings.Size = new System.Drawing.Size(353, 481);
            this.pnl_CurveSettings.TabIndex = 4;
            // 
            // cmb_Curves
            // 
            this.cmb_Curves.FormattingEnabled = true;
            this.cmb_Curves.ItemHeight = 23;
            this.cmb_Curves.Location = new System.Drawing.Point(136, 6);
            this.cmb_Curves.Name = "cmb_Curves";
            this.cmb_Curves.Size = new System.Drawing.Size(209, 29);
            this.cmb_Curves.TabIndex = 9;
            this.cmb_Curves.UseSelectable = true;
            this.cmb_Curves.TextChanged += new System.EventHandler(this.cmb_Curves_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_RefreshCurve);
            this.groupBox2.Controls.Add(this.btn_AddNewCurve);
            this.groupBox2.Controls.Add(this.btn_DeleteCurve);
            this.groupBox2.Location = new System.Drawing.Point(149, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 143);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_Solid);
            this.groupBox1.Controls.Add(this.rb_Dot);
            this.groupBox1.Controls.Add(this.rb_DashDotDot);
            this.groupBox1.Controls.Add(this.rb_DashDot);
            this.groupBox1.Controls.Add(this.rb_Dash);
            this.groupBox1.Location = new System.Drawing.Point(7, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 172);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип линии";
            // 
            // nud_Thickness
            // 
            this.nud_Thickness.Location = new System.Drawing.Point(136, 139);
            this.nud_Thickness.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nud_Thickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Thickness.Name = "nud_Thickness";
            this.nud_Thickness.Size = new System.Drawing.Size(70, 26);
            this.nud_Thickness.TabIndex = 5;
            this.nud_Thickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txb_DotsString
            // 
            this.txb_DotsString.BackColor = System.Drawing.Color.LightCyan;
            this.txb_DotsString.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_DotsString.Location = new System.Drawing.Point(149, 89);
            this.txb_DotsString.Name = "txb_DotsString";
            this.txb_DotsString.Size = new System.Drawing.Size(196, 19);
            this.txb_DotsString.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(89)))), ((int)(((byte)(107)))));
            this.panel4.Location = new System.Drawing.Point(149, 109);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(196, 3);
            this.panel4.TabIndex = 2;
            // 
            // txb_CurveLegend
            // 
            this.txb_CurveLegend.BackColor = System.Drawing.Color.LightCyan;
            this.txb_CurveLegend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_CurveLegend.Location = new System.Drawing.Point(145, 46);
            this.txb_CurveLegend.Name = "txb_CurveLegend";
            this.txb_CurveLegend.Size = new System.Drawing.Size(200, 19);
            this.txb_CurveLegend.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(89)))), ((int)(((byte)(107)))));
            this.panel3.Location = new System.Drawing.Point(145, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 3);
            this.panel3.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Параметры точек:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Толщина линии:";
            this.label5.Click += new System.EventHandler(this.label4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(212, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Цвет кривой:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(66, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Легенда:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Выбрать кривую:";
            // 
            // cmb_CurvesDots
            // 
            this.cmb_CurvesDots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_CurvesDots.FormattingEnabled = true;
            this.cmb_CurvesDots.ItemHeight = 23;
            this.cmb_CurvesDots.Location = new System.Drawing.Point(665, 45);
            this.cmb_CurvesDots.Name = "cmb_CurvesDots";
            this.cmb_CurvesDots.Size = new System.Drawing.Size(353, 29);
            this.cmb_CurvesDots.TabIndex = 2;
            this.cmb_CurvesDots.UseSelectable = true;
            this.cmb_CurvesDots.SelectedIndexChanged += new System.EventHandler(this.cmb_CurvesDots_SelectedIndexChanged);
            // 
            // rtb_TableTxt
            // 
            this.rtb_TableTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_TableTxt.BackColor = System.Drawing.Color.White;
            this.rtb_TableTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_TableTxt.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_TableTxt.Location = new System.Drawing.Point(665, 80);
            this.rtb_TableTxt.Name = "rtb_TableTxt";
            this.rtb_TableTxt.ReadOnly = true;
            this.rtb_TableTxt.Size = new System.Drawing.Size(353, 446);
            this.rtb_TableTxt.TabIndex = 1;
            this.rtb_TableTxt.Text = "";
            this.rtb_TableTxt.WordWrap = false;
            // 
            // pnl_StripElements
            // 
            this.pnl_StripElements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(154)))), ((int)(((byte)(185)))));
            this.pnl_StripElements.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_StripElements.Location = new System.Drawing.Point(0, 0);
            this.pnl_StripElements.Name = "pnl_StripElements";
            this.pnl_StripElements.Size = new System.Drawing.Size(1030, 39);
            this.pnl_StripElements.TabIndex = 0;
            // 
            // btn_RefreshCurve
            // 
            this.btn_RefreshCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RefreshCurve.Image = global::TestMyDrawing.Properties.Resources.refresh;
            this.btn_RefreshCurve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_RefreshCurve.Location = new System.Drawing.Point(6, 18);
            this.btn_RefreshCurve.Name = "btn_RefreshCurve";
            this.btn_RefreshCurve.Size = new System.Drawing.Size(117, 35);
            this.btn_RefreshCurve.TabIndex = 7;
            this.btn_RefreshCurve.Text = "       Обновить";
            this.btn_RefreshCurve.UseVisualStyleBackColor = true;
            this.btn_RefreshCurve.Click += new System.EventHandler(this.btn_RefreshCurve_Click);
            // 
            // btn_AddNewCurve
            // 
            this.btn_AddNewCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddNewCurve.Image = global::TestMyDrawing.Properties.Resources.txt_1_;
            this.btn_AddNewCurve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddNewCurve.Location = new System.Drawing.Point(6, 100);
            this.btn_AddNewCurve.Name = "btn_AddNewCurve";
            this.btn_AddNewCurve.Size = new System.Drawing.Size(117, 35);
            this.btn_AddNewCurve.TabIndex = 7;
            this.btn_AddNewCurve.Text = "       Добавить";
            this.btn_AddNewCurve.UseVisualStyleBackColor = true;
            this.btn_AddNewCurve.Click += new System.EventHandler(this.btn_AddNewCurve_Click);
            // 
            // btn_DeleteCurve
            // 
            this.btn_DeleteCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteCurve.Image = global::TestMyDrawing.Properties.Resources.trash_1_;
            this.btn_DeleteCurve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DeleteCurve.Location = new System.Drawing.Point(6, 59);
            this.btn_DeleteCurve.Name = "btn_DeleteCurve";
            this.btn_DeleteCurve.Size = new System.Drawing.Size(117, 35);
            this.btn_DeleteCurve.TabIndex = 7;
            this.btn_DeleteCurve.Text = "       Удалить";
            this.btn_DeleteCurve.UseVisualStyleBackColor = true;
            this.btn_DeleteCurve.Click += new System.EventHandler(this.btn_DeleteCurve_Click);
            // 
            // rb_Solid
            // 
            this.rb_Solid.AutoSize = true;
            this.rb_Solid.Image = global::TestMyDrawing.Properties.Resources.solid;
            this.rb_Solid.Location = new System.Drawing.Point(3, 141);
            this.rb_Solid.Name = "rb_Solid";
            this.rb_Solid.Size = new System.Drawing.Size(114, 22);
            this.rb_Solid.TabIndex = 0;
            this.rb_Solid.TabStop = true;
            this.rb_Solid.UseVisualStyleBackColor = true;
            // 
            // rb_Dot
            // 
            this.rb_Dot.AutoSize = true;
            this.rb_Dot.Image = global::TestMyDrawing.Properties.Resources.dot;
            this.rb_Dot.Location = new System.Drawing.Point(3, 112);
            this.rb_Dot.Name = "rb_Dot";
            this.rb_Dot.Size = new System.Drawing.Size(114, 22);
            this.rb_Dot.TabIndex = 0;
            this.rb_Dot.TabStop = true;
            this.rb_Dot.UseVisualStyleBackColor = true;
            // 
            // rb_DashDotDot
            // 
            this.rb_DashDotDot.AutoSize = true;
            this.rb_DashDotDot.Image = global::TestMyDrawing.Properties.Resources.dashdotdot;
            this.rb_DashDotDot.Location = new System.Drawing.Point(3, 83);
            this.rb_DashDotDot.Name = "rb_DashDotDot";
            this.rb_DashDotDot.Size = new System.Drawing.Size(114, 22);
            this.rb_DashDotDot.TabIndex = 0;
            this.rb_DashDotDot.TabStop = true;
            this.rb_DashDotDot.UseVisualStyleBackColor = true;
            // 
            // rb_DashDot
            // 
            this.rb_DashDot.AutoSize = true;
            this.rb_DashDot.Image = global::TestMyDrawing.Properties.Resources.dashdot;
            this.rb_DashDot.Location = new System.Drawing.Point(3, 54);
            this.rb_DashDot.Name = "rb_DashDot";
            this.rb_DashDot.Size = new System.Drawing.Size(112, 22);
            this.rb_DashDot.TabIndex = 0;
            this.rb_DashDot.TabStop = true;
            this.rb_DashDot.UseVisualStyleBackColor = true;
            // 
            // rb_Dash
            // 
            this.rb_Dash.AutoSize = true;
            this.rb_Dash.Image = global::TestMyDrawing.Properties.Resources.dash;
            this.rb_Dash.Location = new System.Drawing.Point(3, 25);
            this.rb_Dash.Name = "rb_Dash";
            this.rb_Dash.Size = new System.Drawing.Size(114, 22);
            this.rb_Dash.TabIndex = 0;
            this.rb_Dash.TabStop = true;
            this.rb_Dash.UseVisualStyleBackColor = true;
            // 
            // pcb_CurveColor
            // 
            this.pcb_CurveColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcb_CurveColor.Location = new System.Drawing.Point(319, 143);
            this.pcb_CurveColor.Name = "pcb_CurveColor";
            this.pcb_CurveColor.Size = new System.Drawing.Size(20, 20);
            this.pcb_CurveColor.TabIndex = 4;
            this.pcb_CurveColor.TabStop = false;
            this.pcb_CurveColor.Click += new System.EventHandler(this.brn_SetCurveColor_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(5, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(649, 481);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::TestMyDrawing.Properties.Resources.icons8_plot_50px;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // btn_Back
            // 
            this.btn_Back.BackgroundImage = global::TestMyDrawing.Properties.Resources.icons8_undo_50px1;
            this.btn_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Back.FlatAppearance.BorderSize = 0;
            this.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Back.Location = new System.Drawing.Point(38, 2);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(30, 30);
            this.btn_Back.TabIndex = 3;
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Visible = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnl_CurveSettings.ResumeLayout(false);
            this.pnl_CurveSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Thickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_CurveColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_File;
        private System.Windows.Forms.Label lbl_Edit;
        private System.Windows.Forms.Label lbl_Service;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnl_StripElements;
        private MetroFramework.Controls.MetroComboBox cmb_CurvesDots;
        private System.Windows.Forms.RichTextBox rtb_TableTxt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel lbl_CurrentFile;
        private System.Windows.Forms.Panel pnl_CurveSettings;
        private System.Windows.Forms.TextBox txb_CurveLegend;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pcb_CurveColor;
        private System.Windows.Forms.TextBox txb_DotsString;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_Thickness;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Solid;
        private System.Windows.Forms.RadioButton rb_Dot;
        private System.Windows.Forms.RadioButton rb_DashDotDot;
        private System.Windows.Forms.RadioButton rb_DashDot;
        private System.Windows.Forms.RadioButton rb_Dash;
        private System.Windows.Forms.Button btn_RefreshCurve;
        private System.Windows.Forms.Button btn_AddNewCurve;
        private System.Windows.Forms.Button btn_DeleteCurve;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Back;
        private MetroFramework.Controls.MetroComboBox cmb_Curves;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

