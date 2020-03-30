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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_CurrentFile = new MetroFramework.Controls.MetroLabel();
            this.lbl_Edit = new System.Windows.Forms.Label();
            this.lbl_Service = new System.Windows.Forms.Label();
            this.lbl_File = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmb_Curves = new MetroFramework.Controls.MetroComboBox();
            this.rtb_TableTxt = new System.Windows.Forms.RichTextBox();
            this.pnl_StripElements = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(89)))), ((int)(((byte)(107)))));
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
            this.panel1.Size = new System.Drawing.Size(967, 58);
            this.panel1.TabIndex = 0;
            // 
            // lbl_CurrentFile
            // 
            this.lbl_CurrentFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_CurrentFile.AutoSize = true;
            this.lbl_CurrentFile.Location = new System.Drawing.Point(443, 5);
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
            this.label1.Location = new System.Drawing.Point(941, 5);
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
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.cmb_Curves);
            this.panel2.Controls.Add(this.rtb_TableTxt);
            this.panel2.Controls.Add(this.pnl_StripElements);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(967, 490);
            this.panel2.TabIndex = 1;
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
            this.pictureBox1.Size = new System.Drawing.Size(586, 429);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // cmb_Curves
            // 
            this.cmb_Curves.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Curves.FormattingEnabled = true;
            this.cmb_Curves.ItemHeight = 23;
            this.cmb_Curves.Location = new System.Drawing.Point(602, 45);
            this.cmb_Curves.Name = "cmb_Curves";
            this.cmb_Curves.Size = new System.Drawing.Size(353, 29);
            this.cmb_Curves.TabIndex = 2;
            this.cmb_Curves.UseSelectable = true;
            // 
            // rtb_TableTxt
            // 
            this.rtb_TableTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_TableTxt.BackColor = System.Drawing.Color.White;
            this.rtb_TableTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_TableTxt.Location = new System.Drawing.Point(602, 80);
            this.rtb_TableTxt.Name = "rtb_TableTxt";
            this.rtb_TableTxt.ReadOnly = true;
            this.rtb_TableTxt.Size = new System.Drawing.Size(353, 394);
            this.rtb_TableTxt.TabIndex = 1;
            this.rtb_TableTxt.Text = "";
            // 
            // pnl_StripElements
            // 
            this.pnl_StripElements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(154)))), ((int)(((byte)(185)))));
            this.pnl_StripElements.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_StripElements.Location = new System.Drawing.Point(0, 0);
            this.pnl_StripElements.Name = "pnl_StripElements";
            this.pnl_StripElements.Size = new System.Drawing.Size(967, 39);
            this.pnl_StripElements.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Location = new System.Drawing.Point(602, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(353, 429);
            this.panel3.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 548);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private MetroFramework.Controls.MetroComboBox cmb_Curves;
        private System.Windows.Forms.RichTextBox rtb_TableTxt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel lbl_CurrentFile;
        private System.Windows.Forms.Panel panel3;
    }
}

