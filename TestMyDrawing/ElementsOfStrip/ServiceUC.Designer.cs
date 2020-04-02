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
            this.btn_CurveParams.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CurveParams.FlatAppearance.BorderSize = 0;
            this.btn_CurveParams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CurveParams.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_CurveParams.Image = global::TestMyDrawing.Properties.Resources.curve_1_;
            this.btn_CurveParams.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_CurveParams.Location = new System.Drawing.Point(130, 3);
            this.btn_CurveParams.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btn_CurveParams.Name = "btn_CurveParams";
            this.btn_CurveParams.Size = new System.Drawing.Size(99, 50);
            this.btn_CurveParams.TabIndex = 0;
            this.btn_CurveParams.Text = "Параметры кривых";
            this.btn_CurveParams.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_CurveParams.UseVisualStyleBackColor = true;
            this.btn_CurveParams.Click += new System.EventHandler(this.btn_CurveParams_Click);
            // 
            // btn_DiagrammParams
            // 
            this.btn_DiagrammParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_DiagrammParams.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_DiagrammParams.FlatAppearance.BorderSize = 0;
            this.btn_DiagrammParams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DiagrammParams.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_DiagrammParams.Image = global::TestMyDrawing.Properties.Resources.icons8_edit_graph_report_20px;
            this.btn_DiagrammParams.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_DiagrammParams.Location = new System.Drawing.Point(5, 3);
            this.btn_DiagrammParams.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btn_DiagrammParams.Name = "btn_DiagrammParams";
            this.btn_DiagrammParams.Size = new System.Drawing.Size(115, 50);
            this.btn_DiagrammParams.TabIndex = 0;
            this.btn_DiagrammParams.Text = "Параметры диаграммы";
            this.btn_DiagrammParams.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_DiagrammParams.UseVisualStyleBackColor = true;
            this.btn_DiagrammParams.Click += new System.EventHandler(this.btn_DiagrammParams_Click);
            // 
            // ServiceUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_CurveParams);
            this.Controls.Add(this.btn_DiagrammParams);
            this.Name = "ServiceUC";
            this.Size = new System.Drawing.Size(964, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_DiagrammParams;
        private System.Windows.Forms.Button btn_CurveParams;
    }
}
