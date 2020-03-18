using System;
using System.IO;
using System.Drawing;
using MyDrawing;
using MAC_Dll;
using System.Windows.Forms;

namespace TestMyDrawing
{
    public partial class Form1 : Form
    {
        PointsGraphic gr;
        public Form1()
        {
            InitializeComponent();
            TableOfData T1 = new TableOfData("MAC_LabWork_1_3_2020_2k_1g_v06.bin", "Test Table");
            //richTextBox1.Text = T1.Table_of_Function();
            gr = new PointsGraphic(pictureBox1);
            PointF[] pt = new PointF[201];
            PointF[] pt2 = new PointF[201];
            PointF[] pt3 = new PointF[10];

            double x = -1;
            for(int i = 0; i < pt.Length; i++)
            {
                pt[i].X = (float)x;
                pt[i].Y = (float)Math.Sqrt(1 - pt[i].X * pt[i].X);
                x += 0.01;
            }
            x = -1;
            for (int i = 0; i < pt.Length; i++)
            {
                pt2[i].X = (float)x;
                pt2[i].Y = -(float)Math.Sqrt(1 - pt[i].X * pt[i].X);
                x += 0.01;
            }
            gr.AddCurve(new Curves(pt, Color.Red));
            gr.AddCurve(new Curves(pt2, Color.Red));

            PointF p = new PointF(0.5f, 0.866f);

            x = -5;
            for(int i = 0; i < pt3.Length; i++)
            {
                pt3[i].X = (float)x;
                pt3[i].Y = (float)(-p.X * Math.Pow(1 - p.X * p.X, -0.5) * (pt3[i].X - p.X) + p.Y);
                x++;
            }
            gr.AddCurve(new Curves(pt3, Color.Red));
            gr.Config.StepOX = gr.Config.StepOY += 50;
            gr.Config.DrawPoints = true;
            gr.DrawDiagram();
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            gr.SetPlaceToDrawSize(pictureBox1.Width, pictureBox1.Height);
            gr.DrawDiagram();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            gr.RealCenter = new Point(trackBar2.Value, gr.RealCenter.Y);
            gr.DrawDiagram();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            gr.RealCenter = new Point(gr.RealCenter.X, trackBar1.Value);
            gr.DrawDiagram();
        }
    }
}
