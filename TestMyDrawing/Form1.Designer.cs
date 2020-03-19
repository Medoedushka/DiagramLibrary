namespace TestMyDrawing
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.StepOX = new System.Windows.Forms.TrackBar();
            this.StepOY = new System.Windows.Forms.TrackBar();
            this.priceOX = new System.Windows.Forms.TextBox();
            this.priceOY = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepOX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepOY)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(335, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 521);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 63);
            this.trackBar1.Maximum = 500;
            this.trackBar1.Minimum = -500;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(193, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(12, 12);
            this.trackBar2.Maximum = 500;
            this.trackBar2.Minimum = -500;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(193, 45);
            this.trackBar2.TabIndex = 3;
            this.trackBar2.TickFrequency = 100;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 326);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(317, 183);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // StepOX
            // 
            this.StepOX.Location = new System.Drawing.Point(12, 134);
            this.StepOX.Name = "StepOX";
            this.StepOX.Size = new System.Drawing.Size(193, 45);
            this.StepOX.TabIndex = 5;
            this.StepOX.Scroll += new System.EventHandler(this.StepOX_Scroll);
            // 
            // StepOY
            // 
            this.StepOY.Location = new System.Drawing.Point(12, 185);
            this.StepOY.Name = "StepOY";
            this.StepOY.Size = new System.Drawing.Size(193, 45);
            this.StepOY.TabIndex = 5;
            this.StepOY.Scroll += new System.EventHandler(this.StepOY_Scroll);
            // 
            // priceOX
            // 
            this.priceOX.Location = new System.Drawing.Point(26, 236);
            this.priceOX.Name = "priceOX";
            this.priceOX.Size = new System.Drawing.Size(100, 20);
            this.priceOX.TabIndex = 6;
            this.priceOX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceOX_KeyPress);
            // 
            // priceOY
            // 
            this.priceOY.Location = new System.Drawing.Point(26, 263);
            this.priceOY.Name = "priceOY";
            this.priceOY.Size = new System.Drawing.Size(100, 20);
            this.priceOY.TabIndex = 7;
            this.priceOY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceOY_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 521);
            this.Controls.Add(this.priceOY);
            this.Controls.Add(this.priceOX);
            this.Controls.Add(this.StepOY);
            this.Controls.Add(this.StepOX);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepOX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepOY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TrackBar StepOX;
        private System.Windows.Forms.TrackBar StepOY;
        private System.Windows.Forms.TextBox priceOX;
        private System.Windows.Forms.TextBox priceOY;
    }
}

