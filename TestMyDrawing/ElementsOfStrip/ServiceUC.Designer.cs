namespace TestMyDrawing.ElementsOfStrip
{
    partial class ServiceUC
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
            this.btn_CurveParams = new System.Windows.Forms.Button();
            this.btn_DiagrammParams = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_CurveParams
            // 
            this.btn_CurveParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CurveParams.BackgroundImage = global::TestMyDrawing.Properties.Resources.curve_1_;
            this.btn_CurveParams.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CurveParams.FlatAppearance.BorderSize = 0;
            this.btn_CurveParams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CurveParams.Location = new System.Drawing.Point(74, 2);
            this.btn_CurveParams.Name = "btn_CurveParams";
            this.btn_CurveParams.Size = new System.Drawing.Size(65, 65);
            this.btn_CurveParams.TabIndex = 0;
            this.btn_CurveParams.UseVisualStyleBackColor = true;
            // 
            // btn_DiagrammParams
            // 
            this.btn_DiagrammParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_DiagrammParams.BackgroundImage = global::TestMyDrawing.Properties.Resources.plot_1_;
            this.btn_DiagrammParams.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_DiagrammParams.FlatAppearance.BorderSize = 0;
            this.btn_DiagrammParams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DiagrammParams.Location = new System.Drawing.Point(3, 3);
            this.btn_DiagrammParams.Name = "btn_DiagrammParams";
            this.btn_DiagrammParams.Size = new System.Drawing.Size(65, 65);
            this.btn_DiagrammParams.TabIndex = 0;
            this.btn_DiagrammParams.UseVisualStyleBackColor = true;
            // 
            // ServiceUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_CurveParams);
            this.Controls.Add(this.btn_DiagrammParams);
            this.Name = "ServiceUC";
            this.Size = new System.Drawing.Size(964, 70);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_DiagrammParams;
        private System.Windows.Forms.Button btn_CurveParams;
    }
}
