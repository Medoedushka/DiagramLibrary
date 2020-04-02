namespace TestMyDrawing.ElementsOfStrip
{
    partial class EditUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditUC));
            this.btn_ZoomOut = new System.Windows.Forms.Button();
            this.btn_ZoomIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ZoomOut
            // 
            this.btn_ZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ZoomOut.FlatAppearance.BorderSize = 0;
            this.btn_ZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btn_ZoomOut.Image")));
            this.btn_ZoomOut.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ZoomOut.Location = new System.Drawing.Point(86, 2);
            this.btn_ZoomOut.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.btn_ZoomOut.Name = "btn_ZoomOut";
            this.btn_ZoomOut.Size = new System.Drawing.Size(65, 50);
            this.btn_ZoomOut.TabIndex = 0;
            this.btn_ZoomOut.Text = "Отдалить";
            this.btn_ZoomOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ZoomOut.UseVisualStyleBackColor = true;
            this.btn_ZoomOut.Click += new System.EventHandler(this.btn_ZoomOut_Click);
            // 
            // btn_ZoomIn
            // 
            this.btn_ZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ZoomIn.FlatAppearance.BorderSize = 0;
            this.btn_ZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ZoomIn.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btn_ZoomIn.Image")));
            this.btn_ZoomIn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ZoomIn.Location = new System.Drawing.Point(7, 3);
            this.btn_ZoomIn.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.btn_ZoomIn.Name = "btn_ZoomIn";
            this.btn_ZoomIn.Size = new System.Drawing.Size(65, 50);
            this.btn_ZoomIn.TabIndex = 0;
            this.btn_ZoomIn.Text = "Приблизить";
            this.btn_ZoomIn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ZoomIn.UseVisualStyleBackColor = true;
            this.btn_ZoomIn.Click += new System.EventHandler(this.btn_ZoomIn_Click);
            // 
            // EditUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_ZoomOut);
            this.Controls.Add(this.btn_ZoomIn);
            this.Name = "EditUC";
            this.Size = new System.Drawing.Size(963, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ZoomIn;
        private System.Windows.Forms.Button btn_ZoomOut;
    }
}
