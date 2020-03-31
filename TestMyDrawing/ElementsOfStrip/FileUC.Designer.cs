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
            this.btn_Prev = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_SaveFile = new System.Windows.Forms.Button();
            this.btn_CloseCurrentFile = new System.Windows.Forms.Button();
            this.btn_OpenFile = new System.Windows.Forms.Button();
            this.btn_CreateNewFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Prev
            // 
            this.btn_Prev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Prev.BackgroundImage = global::TestMyDrawing.Properties.Resources.preview;
            this.btn_Prev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Prev.FlatAppearance.BorderSize = 0;
            this.btn_Prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Prev.Location = new System.Drawing.Point(358, 2);
            this.btn_Prev.Name = "btn_Prev";
            this.btn_Prev.Size = new System.Drawing.Size(65, 29);
            this.btn_Prev.TabIndex = 0;
            this.btn_Prev.UseVisualStyleBackColor = true;
            this.btn_Prev.Click += new System.EventHandler(this.btn_Prev_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Print.BackgroundImage = global::TestMyDrawing.Properties.Resources.print;
            this.btn_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Print.FlatAppearance.BorderSize = 0;
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.Location = new System.Drawing.Point(287, 3);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(65, 29);
            this.btn_Print.TabIndex = 0;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_SaveFile
            // 
            this.btn_SaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_SaveFile.BackgroundImage = global::TestMyDrawing.Properties.Resources.save;
            this.btn_SaveFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_SaveFile.FlatAppearance.BorderSize = 0;
            this.btn_SaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveFile.Location = new System.Drawing.Point(216, 3);
            this.btn_SaveFile.Name = "btn_SaveFile";
            this.btn_SaveFile.Size = new System.Drawing.Size(65, 29);
            this.btn_SaveFile.TabIndex = 0;
            this.btn_SaveFile.UseVisualStyleBackColor = true;
            this.btn_SaveFile.Click += new System.EventHandler(this.btn_SaveFile_Click);
            // 
            // btn_CloseCurrentFile
            // 
            this.btn_CloseCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CloseCurrentFile.BackgroundImage = global::TestMyDrawing.Properties.Resources.close1;
            this.btn_CloseCurrentFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CloseCurrentFile.FlatAppearance.BorderSize = 0;
            this.btn_CloseCurrentFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CloseCurrentFile.Location = new System.Drawing.Point(145, 2);
            this.btn_CloseCurrentFile.Name = "btn_CloseCurrentFile";
            this.btn_CloseCurrentFile.Size = new System.Drawing.Size(65, 29);
            this.btn_CloseCurrentFile.TabIndex = 0;
            this.btn_CloseCurrentFile.UseVisualStyleBackColor = true;
            this.btn_CloseCurrentFile.Click += new System.EventHandler(this.btn_CloseCurrentFile_Click);
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OpenFile.BackgroundImage = global::TestMyDrawing.Properties.Resources.folder;
            this.btn_OpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_OpenFile.FlatAppearance.BorderSize = 0;
            this.btn_OpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OpenFile.Location = new System.Drawing.Point(74, 2);
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Size = new System.Drawing.Size(65, 29);
            this.btn_OpenFile.TabIndex = 0;
            this.btn_OpenFile.UseVisualStyleBackColor = true;
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // btn_CreateNewFile
            // 
            this.btn_CreateNewFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CreateNewFile.BackgroundImage = global::TestMyDrawing.Properties.Resources._new;
            this.btn_CreateNewFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CreateNewFile.FlatAppearance.BorderSize = 0;
            this.btn_CreateNewFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateNewFile.Location = new System.Drawing.Point(3, 3);
            this.btn_CreateNewFile.Name = "btn_CreateNewFile";
            this.btn_CreateNewFile.Size = new System.Drawing.Size(65, 29);
            this.btn_CreateNewFile.TabIndex = 0;
            this.btn_CreateNewFile.UseVisualStyleBackColor = true;
            this.btn_CreateNewFile.Click += new System.EventHandler(this.btn_CreateNewFile_Click);
            // 
            // FileUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Prev);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_SaveFile);
            this.Controls.Add(this.btn_CloseCurrentFile);
            this.Controls.Add(this.btn_OpenFile);
            this.Controls.Add(this.btn_CreateNewFile);
            this.Name = "FileUC";
            this.Size = new System.Drawing.Size(925, 34);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CreateNewFile;
        private System.Windows.Forms.Button btn_OpenFile;
        private System.Windows.Forms.Button btn_CloseCurrentFile;
        private System.Windows.Forms.Button btn_SaveFile;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Prev;
    }
}
