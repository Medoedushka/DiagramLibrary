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
            richTextBox1.Text = T1.Table_of_Function();
            gr = new PointsGraphic(pictureBox1);
            PointF[] pt = new PointF[1000];
            PointF[] pt2 = new PointF[1000];
            //for(int i = 0; i < T1.Points.Length; i++)
            //{
            //    pt[i].X = (float)T1.Points[i].X;
            //    pt[i].Y = (float)T1.Points[i].F;
            //}
            double x = -50;
            for(int i = 0; i < pt.Length; i++)
            {
                pt[i].X = (float)x;
                pt[i].Y = (float)Math.Cos(x);
                x += 0.1;
            }
            x = -50;
            for (int i = 0; i < pt.Length; i++)
            {
                pt2[i].X = (float)x;
                pt2[i].Y = (float)Math.Sin(x);
                x += 0.1;
            }
            gr.AddCurve(new Curves(pt, Color.Red));
            gr.AddCurve(new Curves(pt2, Color.Green));
            //gr.Config.SmoothAngles = false;
            //gr.Config.Grid = true;
            //gr.placeToDraw.BackColor = Color.White;
            //gr.Config.StepOY += 10;
            //gr.RealCenter = new Point(gr.RealCenter.X - 100, gr.RealCenter.Y);
            //gr.Config.PriceForPointOX = 0.25;
            //gr.RealCenter = new Point(gr.RealCenter.X - 100, gr.RealCenter.Y);
            gr.RealCenter = new Point(gr.RealCenter.X -250, gr.RealCenter.Y);
            gr.DrawDiagram();
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            gr.SetPlaceToDrawSize(pictureBox1.Width, pictureBox1.Height);
            gr.RealCenter = new Point(gr.RealCenter.X - 400, gr.RealCenter.Y);
            gr.DrawDiagram();
        }
    }
}
