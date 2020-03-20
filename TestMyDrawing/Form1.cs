﻿using System;
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
        BarChart bc;
        public Form1()
        {
            InitializeComponent();
            //TableOfData T1 = new TableOfData("dots0,3_15_20_50.txt", "Test Table", sort: false);
            //richTextBox1.Text = T1.Table_of_Function();
            //gr = new PointsGraphic(pictureBox1);
            //PointF[] pt = new PointF[T1.Points.Length];
            //PointF[] pt2 = new PointF[201];
            //PointF[] pt3 = new PointF[10];

            //for(int i = 0; i < pt.Length; i++)
            //{
            //    pt[i].X = (float)T1.Points[i].X;
            //    pt[i].Y = (float)T1.Points[i].F;
            //}

            //double x = -1;
            //for(int i = 0; i < pt.Length; i++)
            //{
            //    pt[i].X = (float)x;
            //    pt[i].Y = (float)Math.Sqrt(1 - pt[i].X * pt[i].X);
            //    x += 0.01;
            //}
            //x = -1;
            //for (int i = 0; i < pt.Length; i++)
            //{
            //    pt2[i].X = (float)x;
            //    pt2[i].Y = -(float)Math.Sqrt(1 - pt[i].X * pt[i].X);
            //    x += 0.01;
            //}
            //gr.AddCurve(new Curves(pt, Color.Red, Legend: "Первая половина окружности"));
            //gr.AddCurve(new Curves(pt2, Color.Red, Legend: "Вторая половина окружности"));

            //PointF p = new PointF(0.5f, 0.866f);
            //double x = -5;
            //for (int i = 0; i < pt3.Length; i++)
            //{
            //    pt3[i].X = (float)x;
            //    pt3[i].Y = (float)(-p.X * Math.Pow(1 - p.X * p.X, -0.5) * (pt3[i].X - p.X) + p.Y);
            //    x++;
            //}
            //gr.AddCurve(new Curves(pt3, Color.Blue, Legend: "Касательная", dotsType: "g;st;t;5"));
            ////gr.Config.StepOX = gr.Config.StepOY += 60;

            //gr.Title = "Test plot of custom functions";
            //gr.TitlePosition = TextPosition.Centre;
            //gr.TitleSize = 15;

            //gr.Config.OXName = "X Axis";
            //gr.Config.OXNamePosition = TextPosition.Centre;
            //gr.Config.OXNameSize = 10;
            //gr.Config.OYName = "Y Axis";
            //gr.Config.OYNamePosition = TextPosition.Centre;
            //gr.Config.OYNameSize = 10;
            //gr.Config.Grid = true;
            //gr.Config.PriceForPointOX = gr.Config.PriceForPointOY;
            //gr.AddDiagramLegend = true;
            //gr.DrawDiagram();
            bc = new BarChart(pictureBox1, new string[] { "Осень", "Зима", "Весна", "Лето"});
            bc.Config.PriceForPointOY = 5;
            bc.AddBar(new Bars(Color.FromArgb(237, 125, 49), new double[] { 45, 34, 22, 30}, "Column1"));
            bc.AddBar(new Bars(Color.FromArgb(91, 155, 213), new double[] { 11, 23, 12, 8 }, "Column2"));
            bc.AddBar(new Bars(Color.FromArgb(165, 165, 165), new double[] { 6, 7, 23, 11 }, "Column3"));
            bc.AddBar(new Bars(Color.FromArgb(255, 192, 0), new double[] { 22, 11, 14, 77 }, "Column4"));
            bc.AddBar(new Bars(Color.FromArgb(255, 108, 0), new double[] { 67, 11, 15, 67 }, "Column5"));
            bc.AddBar(new Bars(Color.FromArgb(255, 108, 100), new double[] { 6, 10, 2, 60 }, "Column6"));
            bc.Config.ShowColumnValue = true;
            bc.Config.HorizontalLines = true;
            bc.Config.ShowGroupBorder = true;
            bc.DrawDiagram();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //gr.SetPlaceToDrawSize(pictureBox1.Width, pictureBox1.Height);
            //gr.DrawDiagram();
            bc.SetPlaceToDrawSize(pictureBox1.Width, pictureBox1.Height);
            bc.DrawDiagram();
        }

        private void priceOX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                gr.Config.PriceForPointOX = double.Parse(priceOX.Text);
                gr.DrawDiagram();
            }
        }

        private void priceOY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                gr.Config.PriceForPointOY = double.Parse(priceOY.Text);
                gr.DrawDiagram();
            }
        }

        Point mouseLoc;
        bool mousePressed = false;
        float d, angle;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePressed = true;
            pictureBox1.Cursor = Cursors.SizeAll;
            mouseLoc = e.Location;
            d = (float)Math.Sqrt(Math.Pow(gr.RealCenter.X - e.Location.X, 2) + Math.Pow(gr.RealCenter.Y - e.Location.Y, 2));
            angle = (float)Math.Asin((gr.RealCenter.Y - e.Location.Y) / d);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mousePressed = false;
            pictureBox1.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointF center0_cont = new PointF(gr.pt2.X + (gr.pt3.X - gr.pt2.X) / 2, gr.pt1.Y - (gr.pt1.Y - gr.pt2.Y) / 2);
            PointF center0_dec = gr.ConvertValues(center0_cont, CoordType.GetRectangleCoord);

            gr.Config.PriceForPointOX = Math.Round(gr.Config.PriceForPointOX / 2, 3);
            gr.Config.PriceForPointOY = Math.Round(gr.Config.PriceForPointOY / 2, 3);

            PointF center1_cont = gr.ConvertValues(center0_dec, CoordType.GetControlCoord);
            PointF vector = new PointF(center1_cont.X - center0_cont.X, center1_cont.Y - center0_cont.Y);
            gr.RealCenter = new Point(gr.RealCenter.X - (int)vector.X, gr.RealCenter.Y - (int)vector.Y);
            gr.DrawDiagram();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PointF center0_cont = new PointF(gr.pt2.X + (gr.pt3.X - gr.pt2.X) / 2, gr.pt1.Y - (gr.pt1.Y - gr.pt2.Y) / 2);
            PointF center0_dec = gr.ConvertValues(center0_cont, CoordType.GetRectangleCoord);

            gr.Config.PriceForPointOX = Math.Round(gr.Config.PriceForPointOX * 2, 3);
            gr.Config.PriceForPointOY = Math.Round(gr.Config.PriceForPointOY * 2, 3);

            PointF center1_cont = gr.ConvertValues(center0_dec, CoordType.GetControlCoord);
            PointF vector = new PointF(center1_cont.X - center0_cont.X, center1_cont.Y - center0_cont.Y);
            gr.RealCenter = new Point(gr.RealCenter.X - (int)vector.X, gr.RealCenter.Y - (int)vector.Y);
            gr.DrawDiagram();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePressed)
            {
                if (mouseLoc.X > gr.RealCenter.X)
                    gr.RealCenter = new Point(e.Location.X - (int)(d * Math.Cos(angle)), e.Location.Y + (int)(d * Math.Sin(angle)));
                else
                    gr.RealCenter = new Point(e.Location.X + (int)(d * Math.Cos(angle)), e.Location.Y + (int)(d * Math.Sin(angle)));
                gr.DrawDiagram();
            }
        }
    }
}
