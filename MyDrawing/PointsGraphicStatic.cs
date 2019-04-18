using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyDrawing
{
    public partial class PointsGraphic
    {
        public int NegSepOX { get; set; }
        public int NegSepOY { get; set; }
        public int PosSepOX { get; set; }
        public int PosSepOY { get; set; }

        private void DrawStaticAxes()
        {
            //рисует оси
            g.DrawLine(Config.GraphPen, pt1.X, Center.Y, pt3.X, Center.Y); //ось абсцисс
            g.DrawLine(Config.GraphPen, Center.X, pt1.Y, Center.X, pt2.Y); //ось ординат
            g.DrawString("0", Config.drawFont, Config.drawBrush, Center.X - 6, Center.Y);

            float LengthOXNegative = Math.Abs(Center.X);
            float LenghtOYNegative = Math.Abs(pt1.Y - Center.Y);
            float LenghtOXPositive = Math.Abs(pt4.X - Center.X);
            float LenghtOYPositive = Math.Abs(Center.Y);

            NegSepOX = (int)Math.Round(LengthOXNegative / Config.StepOX);
            if (NegSepOX % 2 != 0) NegSepOX--;

            NegSepOY = (int)Math.Round(LenghtOYNegative / Config.StepOY);
            if (NegSepOY % 2 != 0) NegSepOY--;

            PosSepOX = (int)Math.Round(LenghtOXPositive / Config.StepOX);
            if (PosSepOX % 2 != 0) PosSepOX--;

            PosSepOY = (int)Math.Round(LenghtOYPositive / Config.StepOY);
            if (PosSepOY % 2 != 0) PosSepOY--;

            PointF StartLine, EndLine;
            Point[] Oxpoints1 = null;
            Point[] Oxpoints2 = null;
            Point[] Oypoints1 = null;
            Point[] Oypoints2 = null;

     

            if (Config.CurrentAxesPos == AxesPosition.FirstQuarter)
            {
                //прорисовка положительных делений оси OX
                Oxpoints1 = new Point[PosSepOX];
                Oxpoints2 = new Point[PosSepOX];
                for (int i = 0; i < Oxpoints1.Length; i++)
                {
                    if (Config.Grid == true)
                    {
                        StartLine = new PointF(Center.X + (i + 1) * Config.StepOX, Center.Y);
                        EndLine = new PointF(Center.X + (i + 1) * Config.StepOX, 0);
                        g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                    }
                    string num = Convert.ToString((i + 1) * Config.PriceForPointOX);
                    Oxpoints1[i].X = Center.X + (i + 1) * Config.StepOX;
                    Oxpoints1[i].Y = Center.Y - PointsGraphConfig.HEIGHT;

                    Oxpoints2[i].X = Center.X + (i + 1) * Config.StepOX;
                    Oxpoints2[i].Y = Center.Y + PointsGraphConfig.HEIGHT;

                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);
                    g.DrawLine(new Pen(Config.GraphColor), Oxpoints1[i], Oxpoints2[i]);
                }

                Oxpoints1 = null;
                Oxpoints2 = null;

                //прорисовка положительных делений оси OY
                Oypoints1 = new Point[PosSepOY];
                Oypoints2 = new Point[PosSepOY];
                for (int i = 0; i < Oypoints1.Length; i++)
                {
                    if (Config.Grid == true)
                    {
                        StartLine = new PointF(Center.X, Center.Y - (i + 1) * Config.StepOY);
                        EndLine = new PointF(placeToDraw.Width, Center.Y - (i + 1) * Config.StepOY);
                        g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                    }
                    string num = Convert.ToString((i + 1) * Config.PriceForPointOY);
                    Oypoints1[i].X = Center.X - PointsGraphConfig.HEIGHT;
                    Oypoints1[i].Y = Center.Y - (i + 1) * Config.StepOY;

                    Oypoints2[i].X = Center.X + PointsGraphConfig.HEIGHT;
                    Oypoints2[i].Y = Center.Y - (i + 1) * Config.StepOY;
                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                    g.DrawLine(Config.GraphPen, Oypoints1[i], Oypoints2[i]);
                }

                Oypoints1 = null;
                Oypoints2 = null;
            }
            else if (Config.CurrentAxesPos == AxesPosition.AllQuarters)
            {
                //прорисовка отрицательных делений оси OX
                Oxpoints1 = new Point[NegSepOX];
                Oxpoints2 = new Point[NegSepOX];
                for (int i = 0; i < Oxpoints1.Length; i++)
                {
                    if (Config.Grid == true)
                    {
                        StartLine = new PointF(Center.X - (i + 1) * Config.StepOX, placeToDraw.Height);
                        EndLine = new PointF(Center.X - (i + 1) * Config.StepOX, 0);
                        g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                    }
                    string num = "-" + Convert.ToString((i + 1) * Config.PriceForPointOX);
                    Oxpoints2[i].X = Oxpoints1[i].X = Center.X - (i + 1) * Config.StepOX;

                    Oxpoints1[i].Y = Center.Y - PointsGraphConfig.HEIGHT;
                    Oxpoints2[i].Y = Center.Y + PointsGraphConfig.HEIGHT;
                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);

                    g.DrawLine(new Pen(Config.GraphColor), Oxpoints1[i], Oxpoints2[i]);
                }

                Oxpoints1 = null;
                Oxpoints2 = null;

                //прорисовка положительных делений оси OX
                Oxpoints1 = new Point[PosSepOX];
                Oxpoints2 = new Point[PosSepOX];
                for (int i = 0; i < Oxpoints1.Length; i++)
                {
                    if (Config.Grid == true)
                    {
                        StartLine = new PointF(Center.X + (i + 1) * Config.StepOX, placeToDraw.Height);
                        EndLine = new PointF(Center.X + (i + 1) * Config.StepOX, 0);
                        g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                    }

                    string num = Convert.ToString((i + 1) * Config.PriceForPointOX);
                    Oxpoints1[i].X = Center.X + (i + 1) * Config.StepOX;
                    Oxpoints1[i].Y = Center.Y - PointsGraphConfig.HEIGHT;

                    Oxpoints2[i].X = Center.X + (i + 1) * Config.StepOX;
                    Oxpoints2[i].Y = Center.Y + PointsGraphConfig.HEIGHT;

                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);
                    g.DrawLine(new Pen(Config.GraphColor), Oxpoints1[i], Oxpoints2[i]);
                }

                Oxpoints1 = null;
                Oxpoints2 = null;

                //прорисовка отрицательных делений оси OY
                Oypoints1 = new Point[NegSepOY];
                Oypoints2 = new Point[NegSepOY];
                for(int i = 0; i < Oypoints1.Length; i++)
                {
                    if (Config.Grid == true)
                    {
                        StartLine = new PointF(0, Center.Y + (i + 1) * Config.StepOY);
                        EndLine = new PointF(placeToDraw.Width, Center.Y + (i + 1) * Config.StepOY);
                        g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                    }

                    string num = "-" + Convert.ToString((i + 1) * Config.PriceForPointOY);
                    Oypoints1[i].X = Center.X - PointsGraphConfig.HEIGHT;
                    Oypoints1[i].Y = Center.Y + (i + 1) * Config.StepOY;

                    Oypoints2[i].X = Center.X + PointsGraphConfig.HEIGHT;
                    Oypoints2[i].Y = Center.Y + (i + 1) * Config.StepOY;
                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                    g.DrawLine(Config.GraphPen, Oypoints1[i], Oypoints2[i]);
                }

                Oypoints1 = null;
                Oypoints2 = null;

                //прорисовка положительных делений оси OY
                Oypoints1 = new Point[PosSepOY];
                Oypoints2 = new Point[PosSepOY];
                for(int i = 0; i < Oypoints1.Length; i++)
                {
                    if (Config.Grid == true)
                    {
                        StartLine = new PointF(0, Center.Y - (i + 1) * Config.StepOY);
                        EndLine = new PointF(placeToDraw.Width, Center.Y - (i + 1) * Config.StepOY);
                        g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                    }
                    string num = Convert.ToString((i + 1) * Config.PriceForPointOY);
                    Oypoints1[i].X = Center.X - PointsGraphConfig.HEIGHT;
                    Oypoints1[i].Y = Center.Y - (i + 1) * Config.StepOY;

                    Oypoints2[i].X = Center.X + PointsGraphConfig.HEIGHT;
                    Oypoints2[i].Y = Center.Y - (i + 1) * Config.StepOY;

                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                    g.DrawLine(Config.GraphPen, Oypoints1[i], Oypoints2[i]);
                }

                Oypoints1 = null;
                Oypoints2 = null;
            }
           
        }

        private void StaticDrawCurrentCurve(Curves currentCurve)
        {
            Pen grafpen = new Pen(currentCurve.CurveColor, currentCurve.CurveThickness);
            PointF[] points = new PointF[currentCurve.PointsToDraw.Length];
            for (int i = 0; i < currentCurve.PointsToDraw.Length; i++)
            {

                float x = (float)(Center.X + currentCurve.PointsToDraw[i].X * Config.StepOX / Config.PriceForPointOX);

                float y = (float)(Center.Y - currentCurve.PointsToDraw[i].Y * Config.StepOY / Config.PriceForPointOY);

                if (float.IsPositiveInfinity(x)) x = 1000000;
                if (float.IsPositiveInfinity(y)) y = 1000000;
                if (float.IsNegativeInfinity(x)) x = -1000000;
                if (float.IsNegativeInfinity(y)) y = -1000000;
                
                points[i].X = x;
                points[i].Y = y;
            }

            if (Config.SmoothAngles == true) g.DrawCurve(grafpen, points);
            else if (Config.SmoothAngles == false) g.DrawLines(grafpen, points);

            if (Config.DrawPoints == true)
            {
                int r = 4;
                foreach (PointF pt in points)
                {
                    g.FillEllipse(new SolidBrush(currentCurve.CurveColor), pt.X - r / 2, pt.Y - r / 2, r, r);
                }
            }
        }

    }
}
