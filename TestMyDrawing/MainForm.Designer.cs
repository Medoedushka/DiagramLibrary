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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pcb_Minimize = new System.Windows.Forms.PictureBox();
            this.pcb_Normalize = new System.Windows.Forms.PictureBox();
            this.pcb_CloseApp = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_Back = new System.Windows.Forms.Button();
            this.lbl_CurrentFile = new MetroFramework.Controls.MetroLabel();
            this.lbl_Tools = new System.Windows.Forms.Label();
            this.lbl_Edit = new System.Windows.Forms.Label();
            this.lbl_Service = new System.Windows.Forms.Label();
            this.lbl_File = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnl_CreateSpiral = new System.Windows.Forms.Panel();
            this.btn_DeleteSpiral = new System.Windows.Forms.Button();
            this.btn_AddSpiralToMainList = new System.Windows.Forms.Button();
            this.btn_BuildSpiral = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txb_SpiralCoef = new System.Windows.Forms.TextBox();
            this.txb_SpiralOmega = new System.Windows.Forms.TextBox();
            this.txb_SpiralLenght = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txb_SpiralStart = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_DiagramParams = new System.Windows.Forms.Panel();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.chb_Smooth = new System.Windows.Forms.CheckBox();
            this.chb_Grid = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nud_OYSize = new System.Windows.Forms.NumericUpDown();
            this.nud_OXSize = new System.Windows.Forms.NumericUpDown();
            this.nud_TitleSize = new System.Windows.Forms.NumericUpDown();
            this.cmb_OYPos = new MetroFramework.Controls.MetroComboBox();
            this.cmb_OXPos = new MetroFramework.Controls.MetroComboBox();
            this.cmb_TitlePos = new MetroFramework.Controls.MetroComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txb_OYName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txb_OYPrice = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txb_OXPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txb_OXName = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txb_Title = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnl_CurveSettings = new System.Windows.Forms.Panel();
            this.cmb_Curves = new MetroFramework.Controls.MetroComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_RefreshCurve = new System.Windows.Forms.Button();
            this.btn_AddNewCurve = new System.Windows.Forms.Button();
            this.btn_DeleteCurve = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_Solid = new System.Windows.Forms.RadioButton();
            this.rb_Dot = new System.Windows.Forms.RadioButton();
            this.rb_DashDotDot = new System.Windows.Forms.RadioButton();
            this.rb_DashDot = new System.Windows.Forms.RadioButton();
            this.rb_Dash = new System.Windows.Forms.RadioButton();
            this.nud_Thickness = new System.Windows.Forms.NumericUpDown();
            this.pcb_CurveColor = new System.Windows.Forms.PictureBox();
            this.txb_DotsString = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txb_CurveLegend = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmb_CurvesDots = new MetroFramework.Controls.MetroComboBox();
            this.rtb_TableTxt = new System.Windows.Forms.RichTextBox();
            this.pnl_StripElements = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chb_SaveToFile = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_Normalize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_CloseApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnl_CreateSpiral.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.pnl_DiagramParams.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OYSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OXSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TitleSize)).BeginInit();
            this.pnl_CurveSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Thickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_CurveColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(89)))), ((int)(((byte)(107)))));
            this.panel1.Controls.Add(this.pcb_Minimize);
            this.panel1.Controls.Add(this.pcb_Normalize);
            this.panel1.Controls.Add(this.pcb_CloseApp);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btn_Back);
            this.panel1.Controls.Add(this.lbl_CurrentFile);
            this.panel1.Controls.Add(this.lbl_Tools);
            this.panel1.Controls.Add(this.lbl_Edit);
            this.panel1.Controls.Add(this.lbl_Service);
            this.panel1.Controls.Add(this.lbl_File);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("MT Extra", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 58);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pcb_Minimize
            // 
            this.pcb_Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcb_Minimize.BackgroundImage = global::TestMyDrawing.Properties.Resources.minimize;
            this.pcb_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcb_Minimize.Location = new System.Drawing.Point(958, 0);
            this.pcb_Minimize.Name = "pcb_Minimize";
            this.pcb_Minimize.Size = new System.Drawing.Size(20, 20);
            this.pcb_Minimize.TabIndex = 6;
            this.pcb_Minimize.TabStop = false;
            this.pcb_Minimize.Click += new System.EventHandler(this.pcb_Minimize_Click);
            this.pcb_Minimize.MouseEnter += new System.EventHandler(this.pcb_Minimize_MouseEnter);
            this.pcb_Minimize.MouseLeave += new System.EventHandler(this.pcb_Minimize_MouseLeave);
            // 
            // pcb_Normalize
            // 
            this.pcb_Normalize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcb_Normalize.BackgroundImage = global::TestMyDrawing.Properties.Resources.normalize;
            this.pcb_Normalize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcb_Normalize.Location = new System.Drawing.Point(984, 0);
            this.pcb_Normalize.Name = "pcb_Normalize";
            this.pcb_Normalize.Size = new System.Drawing.Size(20, 20);
            this.pcb_Normalize.TabIndex = 6;
            this.pcb_Normalize.TabStop = false;
            this.pcb_Normalize.Click += new System.EventHandler(this.pcb_Normalize_Click);
            this.pcb_Normalize.MouseEnter += new System.EventHandler(this.pcb_Normalize_MouseEnter);
            this.pcb_Normalize.MouseLeave += new System.EventHandler(this.pcb_Normalize_MouseLeave);
            // 
            // pcb_CloseApp
            // 
            this.pcb_CloseApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcb_CloseApp.BackgroundImage = global::TestMyDrawing.Properties.Resources.close;
            this.pcb_CloseApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcb_CloseApp.Location = new System.Drawing.Point(1010, 0);
            this.pcb_CloseApp.Name = "pcb_CloseApp";
            this.pcb_CloseApp.Size = new System.Drawing.Size(20, 20);
            this.pcb_CloseApp.TabIndex = 6;
            this.pcb_CloseApp.TabStop = false;
            this.pcb_CloseApp.Click += new System.EventHandler(this.pcb_CloseApp_Click);
            this.pcb_CloseApp.MouseEnter += new System.EventHandler(this.pcb_CloseApp_MouseEnter);
            this.pcb_CloseApp.MouseLeave += new System.EventHandler(this.pcb_CloseApp_MouseLeave);
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
            // lbl_Tools
            // 
            this.lbl_Tools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(89)))), ((int)(((byte)(107)))));
            this.lbl_Tools.Font = new System.Drawing.Font("Myanmar Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tools.ForeColor = System.Drawing.Color.LightCyan;
            this.lbl_Tools.Location = new System.Drawing.Point(234, 35);
            this.lbl_Tools.Name = "lbl_Tools";
            this.lbl_Tools.Size = new System.Drawing.Size(117, 23);
            this.lbl_Tools.TabIndex = 1;
            this.lbl_Tools.Text = "Инструменты";
            this.lbl_Tools.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Tools.MouseEnter += new System.EventHandler(this.lbl_Tools_MouseEnter);
            this.lbl_Tools.MouseLeave += new System.EventHandler(this.lbl_Tools_MouseLeave);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightCyan;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.pnl_StripElements);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1030, 542);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightCyan;
            this.panel5.Controls.Add(this.pnl_CreateSpiral);
            this.panel5.Controls.Add(this.pnl_DiagramParams);
            this.panel5.Controls.Add(this.pnl_CurveSettings);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.cmb_CurvesDots);
            this.panel5.Controls.Add(this.rtb_TableTxt);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 60);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1030, 482);
            this.panel5.TabIndex = 6;
            // 
            // pnl_CreateSpiral
            // 
            this.pnl_CreateSpiral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_CreateSpiral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_CreateSpiral.Controls.Add(this.chb_SaveToFile);
            this.pnl_CreateSpiral.Controls.Add(this.btn_DeleteSpiral);
            this.pnl_CreateSpiral.Controls.Add(this.btn_AddSpiralToMainList);
            this.pnl_CreateSpiral.Controls.Add(this.btn_BuildSpiral);
            this.pnl_CreateSpiral.Controls.Add(this.groupBox4);
            this.pnl_CreateSpiral.Controls.Add(this.label1);
            this.pnl_CreateSpiral.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pnl_CreateSpiral.Location = new System.Drawing.Point(674, 9);
            this.pnl_CreateSpiral.Name = "pnl_CreateSpiral";
            this.pnl_CreateSpiral.Size = new System.Drawing.Size(353, 461);
            this.pnl_CreateSpiral.TabIndex = 6;
            // 
            // btn_DeleteSpiral
            // 
            this.btn_DeleteSpiral.FlatAppearance.BorderSize = 0;
            this.btn_DeleteSpiral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteSpiral.Image = global::TestMyDrawing.Properties.Resources.icons8_delete_30px;
            this.btn_DeleteSpiral.Location = new System.Drawing.Point(174, 200);
            this.btn_DeleteSpiral.Name = "btn_DeleteSpiral";
            this.btn_DeleteSpiral.Size = new System.Drawing.Size(35, 35);
            this.btn_DeleteSpiral.TabIndex = 0;
            this.btn_DeleteSpiral.TabStop = false;
            this.btn_DeleteSpiral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_DeleteSpiral.UseVisualStyleBackColor = true;
            this.btn_DeleteSpiral.Click += new System.EventHandler(this.btn_DeleteSpiral_Click);
            // 
            // btn_AddSpiralToMainList
            // 
            this.btn_AddSpiralToMainList.FlatAppearance.BorderSize = 0;
            this.btn_AddSpiralToMainList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddSpiralToMainList.Image = global::TestMyDrawing.Properties.Resources.icons8_add_new_30px;
            this.btn_AddSpiralToMainList.Location = new System.Drawing.Point(133, 200);
            this.btn_AddSpiralToMainList.Name = "btn_AddSpiralToMainList";
            this.btn_AddSpiralToMainList.Size = new System.Drawing.Size(35, 35);
            this.btn_AddSpiralToMainList.TabIndex = 0;
            this.btn_AddSpiralToMainList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btn_AddSpiralToMainList, "Добавить созданную спираль в общий список кривых");
            this.btn_AddSpiralToMainList.UseVisualStyleBackColor = true;
            this.btn_AddSpiralToMainList.Click += new System.EventHandler(this.btn_AddSpiralToMainList_Click);
            // 
            // btn_BuildSpiral
            // 
            this.btn_BuildSpiral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BuildSpiral.Image = global::TestMyDrawing.Properties.Resources.icons8_pencil_30px;
            this.btn_BuildSpiral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_BuildSpiral.Location = new System.Drawing.Point(3, 202);
            this.btn_BuildSpiral.Name = "btn_BuildSpiral";
            this.btn_BuildSpiral.Size = new System.Drawing.Size(124, 31);
            this.btn_BuildSpiral.TabIndex = 5;
            this.btn_BuildSpiral.Text = "     Построить";
            this.btn_BuildSpiral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_BuildSpiral.UseVisualStyleBackColor = true;
            this.btn_BuildSpiral.Click += new System.EventHandler(this.btn_BuildSpiral_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txb_SpiralCoef);
            this.groupBox4.Controls.Add(this.txb_SpiralOmega);
            this.groupBox4.Controls.Add(this.txb_SpiralLenght);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.txb_SpiralStart);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Location = new System.Drawing.Point(3, 47);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(206, 149);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Параметры спирали";
            // 
            // txb_SpiralCoef
            // 
            this.txb_SpiralCoef.Location = new System.Drawing.Point(76, 117);
            this.txb_SpiralCoef.Name = "txb_SpiralCoef";
            this.txb_SpiralCoef.Size = new System.Drawing.Size(112, 26);
            this.txb_SpiralCoef.TabIndex = 4;
            // 
            // txb_SpiralOmega
            // 
            this.txb_SpiralOmega.Location = new System.Drawing.Point(76, 85);
            this.txb_SpiralOmega.Name = "txb_SpiralOmega";
            this.txb_SpiralOmega.Size = new System.Drawing.Size(112, 26);
            this.txb_SpiralOmega.TabIndex = 3;
            // 
            // txb_SpiralLenght
            // 
            this.txb_SpiralLenght.Location = new System.Drawing.Point(76, 53);
            this.txb_SpiralLenght.Name = "txb_SpiralLenght";
            this.txb_SpiralLenght.Size = new System.Drawing.Size(112, 26);
            this.txb_SpiralLenght.TabIndex = 2;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label21.Location = new System.Drawing.Point(47, 123);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(22, 19);
            this.label21.TabIndex = 1;
            this.label21.Text = "k:";
            // 
            // txb_SpiralStart
            // 
            this.txb_SpiralStart.Location = new System.Drawing.Point(76, 21);
            this.txb_SpiralStart.Name = "txb_SpiralStart";
            this.txb_SpiralStart.Size = new System.Drawing.Size(112, 26);
            this.txb_SpiralStart.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label20.Location = new System.Drawing.Point(44, 91);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(25, 19);
            this.label20.TabIndex = 1;
            this.label20.Text = "Ω:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(6, 56);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 19);
            this.label19.TabIndex = 1;
            this.label19.Text = "Lenght:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(21, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 19);
            this.label18.TabIndex = 1;
            this.label18.Text = "Start:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 13F);
            this.label1.Location = new System.Drawing.Point(100, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Генератор спирали";
            // 
            // pnl_DiagramParams
            // 
            this.pnl_DiagramParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_DiagramParams.AutoScroll = true;
            this.pnl_DiagramParams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_DiagramParams.Controls.Add(this.btn_Apply);
            this.pnl_DiagramParams.Controls.Add(this.chb_Smooth);
            this.pnl_DiagramParams.Controls.Add(this.chb_Grid);
            this.pnl_DiagramParams.Controls.Add(this.groupBox3);
            this.pnl_DiagramParams.Font = new System.Drawing.Font("Cambria", 10F);
            this.pnl_DiagramParams.Location = new System.Drawing.Point(1050, 9);
            this.pnl_DiagramParams.Name = "pnl_DiagramParams";
            this.pnl_DiagramParams.Size = new System.Drawing.Size(353, 461);
            this.pnl_DiagramParams.TabIndex = 5;
            // 
            // btn_Apply
            // 
            this.btn_Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Apply.Image = global::TestMyDrawing.Properties.Resources.icons8_checkmark_50px_1;
            this.btn_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Apply.Location = new System.Drawing.Point(212, 440);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(119, 35);
            this.btn_Apply.TabIndex = 12;
            this.btn_Apply.Text = "          Применить";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // chb_Smooth
            // 
            this.chb_Smooth.AutoSize = true;
            this.chb_Smooth.Location = new System.Drawing.Point(12, 448);
            this.chb_Smooth.Name = "chb_Smooth";
            this.chb_Smooth.Size = new System.Drawing.Size(144, 20);
            this.chb_Smooth.TabIndex = 11;
            this.chb_Smooth.Text = "Сглаженная линия";
            this.chb_Smooth.UseVisualStyleBackColor = true;
            // 
            // chb_Grid
            // 
            this.chb_Grid.AutoSize = true;
            this.chb_Grid.Location = new System.Drawing.Point(12, 422);
            this.chb_Grid.Name = "chb_Grid";
            this.chb_Grid.Size = new System.Drawing.Size(64, 20);
            this.chb_Grid.TabIndex = 11;
            this.chb_Grid.Text = "Сетка";
            this.chb_Grid.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nud_OYSize);
            this.groupBox3.Controls.Add(this.nud_OXSize);
            this.groupBox3.Controls.Add(this.nud_TitleSize);
            this.groupBox3.Controls.Add(this.cmb_OYPos);
            this.groupBox3.Controls.Add(this.cmb_OXPos);
            this.groupBox3.Controls.Add(this.cmb_TitlePos);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txb_OYName);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txb_OYPrice);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txb_OXPrice);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txb_OXName);
            this.groupBox3.Controls.Add(this.panel10);
            this.groupBox3.Controls.Add(this.panel8);
            this.groupBox3.Controls.Add(this.panel9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.panel7);
            this.groupBox3.Controls.Add(this.txb_Title);
            this.groupBox3.Controls.Add(this.panel6);
            this.groupBox3.Location = new System.Drawing.Point(3, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 410);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Название осей и диаграммы";
            // 
            // nud_OYSize
            // 
            this.nud_OYSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_OYSize.Location = new System.Drawing.Point(158, 342);
            this.nud_OYSize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nud_OYSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_OYSize.Name = "nud_OYSize";
            this.nud_OYSize.Size = new System.Drawing.Size(46, 23);
            this.nud_OYSize.TabIndex = 11;
            this.nud_OYSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_OXSize
            // 
            this.nud_OXSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_OXSize.Location = new System.Drawing.Point(158, 198);
            this.nud_OXSize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nud_OXSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_OXSize.Name = "nud_OXSize";
            this.nud_OXSize.Size = new System.Drawing.Size(46, 23);
            this.nud_OXSize.TabIndex = 11;
            this.nud_OXSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_TitleSize
            // 
            this.nud_TitleSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_TitleSize.Location = new System.Drawing.Point(158, 92);
            this.nud_TitleSize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nud_TitleSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_TitleSize.Name = "nud_TitleSize";
            this.nud_TitleSize.Size = new System.Drawing.Size(46, 23);
            this.nud_TitleSize.TabIndex = 11;
            this.nud_TitleSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmb_OYPos
            // 
            this.cmb_OYPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_OYPos.FormattingEnabled = true;
            this.cmb_OYPos.ItemHeight = 23;
            this.cmb_OYPos.Items.AddRange(new object[] {
            "Справа",
            "Слева",
            "Посередине"});
            this.cmb_OYPos.Location = new System.Drawing.Point(158, 304);
            this.cmb_OYPos.Name = "cmb_OYPos";
            this.cmb_OYPos.Size = new System.Drawing.Size(155, 29);
            this.cmb_OYPos.TabIndex = 10;
            this.cmb_OYPos.UseSelectable = true;
            // 
            // cmb_OXPos
            // 
            this.cmb_OXPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_OXPos.FormattingEnabled = true;
            this.cmb_OXPos.ItemHeight = 23;
            this.cmb_OXPos.Items.AddRange(new object[] {
            "Справа",
            "Слева",
            "Посередине"});
            this.cmb_OXPos.Location = new System.Drawing.Point(158, 160);
            this.cmb_OXPos.Name = "cmb_OXPos";
            this.cmb_OXPos.Size = new System.Drawing.Size(155, 29);
            this.cmb_OXPos.TabIndex = 10;
            this.cmb_OXPos.UseSelectable = true;
            // 
            // cmb_TitlePos
            // 
            this.cmb_TitlePos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_TitlePos.FormattingEnabled = true;
            this.cmb_TitlePos.ItemHeight = 23;
            this.cmb_TitlePos.Items.AddRange(new object[] {
            "Справа",
            "Слева",
            "Посередине"});
            this.cmb_TitlePos.Location = new System.Drawing.Point(159, 55);
            this.cmb_TitlePos.Name = "cmb_TitlePos";
            this.cmb_TitlePos.Size = new System.Drawing.Size(155, 29);
            this.cmb_TitlePos.TabIndex = 10;
            this.cmb_TitlePos.UseSelectable = true;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Cambria", 10F);
            this.label15.Location = new System.Drawing.Point(87, 310);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 16);
            this.label15.TabIndex = 7;
            this.label15.Text = "Позиция:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 10F);
            this.label11.Location = new System.Drawing.Point(87, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "Позиция:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Cambria", 10F);
            this.label14.Location = new System.Drawing.Point(42, 344);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 16);
            this.label14.TabIndex = 7;
            this.label14.Text = "Размер шрифта:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Cambria", 10F);
            this.label12.Location = new System.Drawing.Point(42, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = "Размер шрифта:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 10F);
            this.label9.Location = new System.Drawing.Point(42, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Размер шрифта:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 10F);
            this.label8.Location = new System.Drawing.Point(88, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Позиция:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 10F);
            this.label13.Location = new System.Drawing.Point(36, 275);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = "Название оси OY:";
            // 
            // txb_OYName
            // 
            this.txb_OYName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_OYName.BackColor = System.Drawing.Color.LightCyan;
            this.txb_OYName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_OYName.Font = new System.Drawing.Font("Cambria", 10F);
            this.txb_OYName.Location = new System.Drawing.Point(158, 275);
            this.txb_OYName.Name = "txb_OYName";
            this.txb_OYName.Size = new System.Drawing.Size(156, 16);
            this.txb_OYName.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Cambria", 10F);
            this.label17.Location = new System.Drawing.Point(38, 376);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 16);
            this.label17.TabIndex = 7;
            this.label17.Text = "Цена деления OY:";
            // 
            // txb_OYPrice
            // 
            this.txb_OYPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_OYPrice.BackColor = System.Drawing.Color.LightCyan;
            this.txb_OYPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_OYPrice.Font = new System.Drawing.Font("Cambria", 10F);
            this.txb_OYPrice.Location = new System.Drawing.Point(159, 376);
            this.txb_OYPrice.Name = "txb_OYPrice";
            this.txb_OYPrice.Size = new System.Drawing.Size(156, 16);
            this.txb_OYPrice.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Cambria", 10F);
            this.label16.Location = new System.Drawing.Point(38, 230);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(119, 16);
            this.label16.TabIndex = 7;
            this.label16.Text = "Цена деления OX:";
            // 
            // txb_OXPrice
            // 
            this.txb_OXPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_OXPrice.BackColor = System.Drawing.Color.LightCyan;
            this.txb_OXPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_OXPrice.Font = new System.Drawing.Font("Cambria", 10F);
            this.txb_OXPrice.Location = new System.Drawing.Point(159, 230);
            this.txb_OXPrice.Name = "txb_OXPrice";
            this.txb_OXPrice.Size = new System.Drawing.Size(156, 16);
            this.txb_OXPrice.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 10F);
            this.label10.Location = new System.Drawing.Point(36, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 16);
            this.label10.TabIndex = 7;
            this.label10.Text = "Название оси OX:";
            // 
            // txb_OXName
            // 
            this.txb_OXName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_OXName.BackColor = System.Drawing.Color.LightCyan;
            this.txb_OXName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_OXName.Font = new System.Drawing.Font("Cambria", 10F);
            this.txb_OXName.Location = new System.Drawing.Point(158, 131);
            this.txb_OXName.Name = "txb_OXName";
            this.txb_OXName.Size = new System.Drawing.Size(156, 16);
            this.txb_OXName.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(89)))), ((int)(((byte)(107)))));
            this.panel10.Location = new System.Drawing.Point(159, 393);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(156, 3);
            this.panel10.TabIndex = 8;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(89)))), ((int)(((byte)(107)))));
            this.panel8.Location = new System.Drawing.Point(158, 292);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(156, 3);
            this.panel8.TabIndex = 8;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(89)))), ((int)(((byte)(107)))));
            this.panel9.Location = new System.Drawing.Point(159, 247);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(156, 3);
            this.panel9.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 10F);
            this.label7.Location = new System.Drawing.Point(6, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Название диаграммы:";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(89)))), ((int)(((byte)(107)))));
            this.panel7.Location = new System.Drawing.Point(158, 148);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(156, 3);
            this.panel7.TabIndex = 8;
            // 
            // txb_Title
            // 
            this.txb_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_Title.BackColor = System.Drawing.Color.LightCyan;
            this.txb_Title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_Title.Font = new System.Drawing.Font("Cambria", 10F);
            this.txb_Title.Location = new System.Drawing.Point(158, 28);
            this.txb_Title.Name = "txb_Title";
            this.txb_Title.Size = new System.Drawing.Size(156, 16);
            this.txb_Title.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(89)))), ((int)(((byte)(107)))));
            this.panel6.Location = new System.Drawing.Point(158, 45);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(156, 3);
            this.panel6.TabIndex = 8;
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
            this.pnl_CurveSettings.Location = new System.Drawing.Point(1050, 9);
            this.pnl_CurveSettings.Name = "pnl_CurveSettings";
            this.pnl_CurveSettings.Size = new System.Drawing.Size(353, 461);
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
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(5, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(663, 461);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // cmb_CurvesDots
            // 
            this.cmb_CurvesDots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_CurvesDots.FormattingEnabled = true;
            this.cmb_CurvesDots.ItemHeight = 23;
            this.cmb_CurvesDots.Location = new System.Drawing.Point(674, 9);
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
            this.rtb_TableTxt.Location = new System.Drawing.Point(674, 44);
            this.rtb_TableTxt.Name = "rtb_TableTxt";
            this.rtb_TableTxt.ReadOnly = true;
            this.rtb_TableTxt.Size = new System.Drawing.Size(353, 426);
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
            this.pnl_StripElements.Size = new System.Drawing.Size(1030, 60);
            this.pnl_StripElements.TabIndex = 0;
            // 
            // chb_SaveToFile
            // 
            this.chb_SaveToFile.AutoSize = true;
            this.chb_SaveToFile.Location = new System.Drawing.Point(3, 239);
            this.chb_SaveToFile.Name = "chb_SaveToFile";
            this.chb_SaveToFile.Size = new System.Drawing.Size(221, 23);
            this.chb_SaveToFile.TabIndex = 6;
            this.chb_SaveToFile.Text = "Сохранить спираль в файл";
            this.chb_SaveToFile.UseVisualStyleBackColor = true;
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
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_Normalize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_CloseApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.pnl_CreateSpiral.ResumeLayout(false);
            this.pnl_CreateSpiral.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.pnl_DiagramParams.ResumeLayout(false);
            this.pnl_DiagramParams.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OYSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OXSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TitleSize)).EndInit();
            this.pnl_CurveSettings.ResumeLayout(false);
            this.pnl_CurveSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Thickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_CurveColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.Panel pnl_DiagramParams;
        private System.Windows.Forms.TextBox txb_Title;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nud_OXSize;
        private System.Windows.Forms.NumericUpDown nud_TitleSize;
        private MetroFramework.Controls.MetroComboBox cmb_OXPos;
        private MetroFramework.Controls.MetroComboBox cmb_TitlePos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txb_OXName;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.NumericUpDown nud_OYSize;
        private MetroFramework.Controls.MetroComboBox cmb_OYPos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txb_OYName;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txb_OYPrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txb_OXPrice;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.CheckBox chb_Smooth;
        private System.Windows.Forms.CheckBox chb_Grid;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.PictureBox pcb_CloseApp;
        private System.Windows.Forms.PictureBox pcb_Minimize;
        private System.Windows.Forms.PictureBox pcb_Normalize;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_Tools;
        private System.Windows.Forms.Panel pnl_CreateSpiral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txb_SpiralLenght;
        private System.Windows.Forms.TextBox txb_SpiralStart;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txb_SpiralOmega;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txb_SpiralCoef;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btn_BuildSpiral;
        private System.Windows.Forms.Button btn_AddSpiralToMainList;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_DeleteSpiral;
        private System.Windows.Forms.CheckBox chb_SaveToFile;
    }
}

