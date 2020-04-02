namespace TestMyDrawing.ElementsOfStrip
{
    partial class FileUC
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileUC));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Prev = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_SaveFile = new System.Windows.Forms.Button();
            this.btn_CloseCurrentFile = new System.Windows.Forms.Button();
            this.btn_OpenFile = new System.Windows.Forms.Button();
            this.btn_CreateNewFile = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.panel1.Location = new System.Drawing.Point(129, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 54);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.panel2.Location = new System.Drawing.Point(219, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 54);
            this.panel2.TabIndex = 1;
            // 
            // btn_Prev
            // 
            this.btn_Prev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Prev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Prev.FlatAppearance.BorderSize = 0;
            this.btn_Prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Prev.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Prev.Image = ((System.Drawing.Image)(resources.GetObject("btn_Prev.Image")));
            this.btn_Prev.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Prev.Location = new System.Drawing.Point(230, 3);
            this.btn_Prev.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.btn_Prev.Name = "btn_Prev";
            this.btn_Prev.Size = new System.Drawing.Size(50, 50);
            this.btn_Prev.TabIndex = 0;
            this.btn_Prev.Text = "Печать";
            this.btn_Prev.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Prev.UseVisualStyleBackColor = true;
            this.btn_Prev.Click += new System.EventHandler(this.btn_Prev_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Print.FlatAppearance.BorderSize = 0;
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Print.Image = ((System.Drawing.Image)(resources.GetObject("btn_Print.Image")));
            this.btn_Print.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Print.Location = new System.Drawing.Point(140, 3);
            this.btn_Print.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(69, 50);
            this.btn_Print.TabIndex = 0;
            this.btn_Print.Text = "Сохранить";
            this.btn_Print.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_SaveFile
            // 
            this.btn_SaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_SaveFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_SaveFile.FlatAppearance.BorderSize = 0;
            this.btn_SaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveFile.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_SaveFile.Image = ((System.Drawing.Image)(resources.GetObject("btn_SaveFile.Image")));
            this.btn_SaveFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_SaveFile.Location = new System.Drawing.Point(294, 3);
            this.btn_SaveFile.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.btn_SaveFile.Name = "btn_SaveFile";
            this.btn_SaveFile.Size = new System.Drawing.Size(77, 50);
            this.btn_SaveFile.TabIndex = 0;
            this.btn_SaveFile.Text = "Предпросмотр";
            this.btn_SaveFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_SaveFile.UseVisualStyleBackColor = true;
            this.btn_SaveFile.Click += new System.EventHandler(this.btn_SaveFile_Click);
            // 
            // btn_CloseCurrentFile
            // 
            this.btn_CloseCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CloseCurrentFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CloseCurrentFile.FlatAppearance.BorderSize = 0;
            this.btn_CloseCurrentFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CloseCurrentFile.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_CloseCurrentFile.Image = ((System.Drawing.Image)(resources.GetObject("btn_CloseCurrentFile.Image")));
            this.btn_CloseCurrentFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_CloseCurrentFile.Location = new System.Drawing.Point(392, 3);
            this.btn_CloseCurrentFile.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.btn_CloseCurrentFile.Name = "btn_CloseCurrentFile";
            this.btn_CloseCurrentFile.Size = new System.Drawing.Size(77, 50);
            this.btn_CloseCurrentFile.TabIndex = 0;
            this.btn_CloseCurrentFile.Text = "Закрыть файл";
            this.btn_CloseCurrentFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_CloseCurrentFile.UseVisualStyleBackColor = true;
            this.btn_CloseCurrentFile.Click += new System.EventHandler(this.btn_CloseCurrentFile_Click);
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_OpenFile.FlatAppearance.BorderSize = 0;
            this.btn_OpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OpenFile.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_OpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btn_OpenFile.Image")));
            this.btn_OpenFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_OpenFile.Location = new System.Drawing.Point(67, 3);
            this.btn_OpenFile.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Size = new System.Drawing.Size(54, 50);
            this.btn_OpenFile.TabIndex = 0;
            this.btn_OpenFile.Text = "Открыть";
            this.btn_OpenFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_OpenFile.UseVisualStyleBackColor = true;
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // btn_CreateNewFile
            // 
            this.btn_CreateNewFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CreateNewFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CreateNewFile.FlatAppearance.BorderSize = 0;
            this.btn_CreateNewFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateNewFile.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_CreateNewFile.Image = ((System.Drawing.Image)(resources.GetObject("btn_CreateNewFile.Image")));
            this.btn_CreateNewFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_CreateNewFile.Location = new System.Drawing.Point(7, 3);
            this.btn_CreateNewFile.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btn_CreateNewFile.Name = "btn_CreateNewFile";
            this.btn_CreateNewFile.Size = new System.Drawing.Size(50, 50);
            this.btn_CreateNewFile.TabIndex = 0;
            this.btn_CreateNewFile.Text = "Создать";
            this.btn_CreateNewFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_CreateNewFile.UseVisualStyleBackColor = true;
            this.btn_CreateNewFile.Click += new System.EventHandler(this.btn_CreateNewFile_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.panel3.Location = new System.Drawing.Point(381, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 54);
            this.panel3.TabIndex = 1;
            // 
            // FileUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Prev);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_SaveFile);
            this.Controls.Add(this.btn_CloseCurrentFile);
            this.Controls.Add(this.btn_OpenFile);
            this.Controls.Add(this.btn_CreateNewFile);
            this.Name = "FileUC";
            this.Size = new System.Drawing.Size(925, 60);
            this.Load += new System.EventHandler(this.FileUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CreateNewFile;
        private System.Windows.Forms.Button btn_OpenFile;
        private System.Windows.Forms.Button btn_CloseCurrentFile;
        private System.Windows.Forms.Button btn_SaveFile;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Prev;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
