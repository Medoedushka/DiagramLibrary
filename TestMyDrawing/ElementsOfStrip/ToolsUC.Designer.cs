namespace TestMyDrawing.ElementsOfStrip
{
    partial class ToolsUC
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
            this.btn_CreateSpiral = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_CreateSpiral
            // 
            this.btn_CreateSpiral.FlatAppearance.BorderSize = 0;
            this.btn_CreateSpiral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateSpiral.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_CreateSpiral.Image = global::TestMyDrawing.Properties.Resources.spiral;
            this.btn_CreateSpiral.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_CreateSpiral.Location = new System.Drawing.Point(7, 3);
            this.btn_CreateSpiral.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.btn_CreateSpiral.Name = "btn_CreateSpiral";
            this.btn_CreateSpiral.Size = new System.Drawing.Size(61, 50);
            this.btn_CreateSpiral.TabIndex = 0;
            this.btn_CreateSpiral.Text = "Cпираль";
            this.btn_CreateSpiral.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_CreateSpiral.UseVisualStyleBackColor = true;
            this.btn_CreateSpiral.Click += new System.EventHandler(this.btn_CreateSpiral_Click);
            // 
            // ToolsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_CreateSpiral);
            this.Name = "ToolsUC";
            this.Size = new System.Drawing.Size(976, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CreateSpiral;
    }
}
