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
            TableOfData T1 = new TableOfData("MAC_LabWork_1_3_2020_2k_1g_v06.txt", "Test Table");
            richTextBox1.Text = T1.Table_of_Function();
            gr = new PointsGraphic(pictureBox1, AxesPosition.AllQuarters);
            PointF[] pt = new PointF[T1.Points.Length];
            for(int i = 0; i < T1.Points.Length; i++)
            {
                pt[i].X = (float)T1.Points[i].X;
                pt[i].Y = (float)T1.Points[i].F;
            }
            gr.AddCurve(new Curves(pt, Color.Black));
            gr.Config.SmoothAngles = false;
            gr.Config.Grid = true;
            gr.DrawDiagram();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            gr.SetPlaceToDrawSize(pictureBox1.Width, pictureBox1.Height);
            gr.DrawDiagram();
        }
    }
}
