using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyDrawing
{

    public enum CoordType
    {
        GetRectangleCoord, 
        GetControlCoord
    }
    public partial class PointsGraphic
    {
        public int NegSepOX { get; set; }
        public int NegSepOY { get; set; }
        public int PosSepOX { get; set; }
        public int PosSepOY { get; set; }

        private void DrawStaticAxes()
        {
            //рисует оси
            g.DrawLine(Config.GraphPen, pt1.X, RealCenter.Y, pt3.X, RealCenter.Y); //ось абсцисс
            g.DrawLine(Config.GraphPen, RealCenter.X, pt1.Y, RealCenter.X, pt2.Y); //ось ординат
            g.DrawString("0", Config.DrawFont, Config.drawBrush, RealCenter.X - 6, RealCenter.Y);

            float LengthOXNegative = Math.Abs(RealCenter.X);
            float LenghtOYNegative = Math.Abs(pt1.Y - RealCenter.Y);
            float LenghtOXPositive = Math.Abs(pt4.X - RealCenter.X);
            float LenghtOYPositive = Math.Abs(RealCenter.Y - pt2.Y);

            NegSepOX = (int)Math.Truncate(LengthOXNegative / Config.StepOX);
            if (NegSepOX % 2 != 0) NegSepOX--;

            NegSepOY = (int)Math.Truncate(LenghtOYNegative / Config.StepOY);
            if (NegSepOY % 2 != 0) NegSepOY--;

            PosSepOX = (int)Math.Truncate(LenghtOXPositive / Config.StepOX);
            if (PosSepOX % 2 != 0) PosSepOX--;

            PosSepOY = (int)Math.Truncate(LenghtOYPositive / Config.StepOY);
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
                        StartLine = new PointF(RealCenter.X + (i + 1) * Config.StepOX, RealCenter.Y);
                        EndLine = new PointF(RealCenter.X + (i + 1) * Config.StepOX, pt2.Y);
                        g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                    }
                    string num = Convert.ToString((i + 1) * Config.PriceForPointOX);
                    Oxpoints1[i].X = RealCenter.X + (i + 1) * Config.StepOX;
                    Oxpoints1[i].Y = RealCenter.Y - PointsGraphConfig.HEIGHT;

                    Oxpoints2[i].X = RealCenter.X + (i + 1) * Config.StepOX;
                    Oxpoints2[i].Y = RealCenter.Y + PointsGraphConfig.HEIGHT;
                    
                    g.DrawString(num, Config.DrawFont, Config.drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);
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
                        StartLine = new PointF(RealCenter.X, RealCenter.Y - (i + 1) * Config.StepOY);
                        EndLine = new PointF(pt4.X, RealCenter.Y - (i + 1) * Config.StepOY);
                        g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                    }
                    string num = Convert.ToString((i + 1) * Config.PriceForPointOY);
                    Oypoints1[i].X = RealCenter.X - PointsGraphConfig.HEIGHT;
                    Oypoints1[i].Y = RealCenter.Y - (i + 1) * Config.StepOY;

                    Oypoints2[i].X = RealCenter.X + PointsGraphConfig.HEIGHT;
                    Oypoints2[i].Y = RealCenter.Y - (i + 1) * Config.StepOY;
                   
                    g.DrawString(num, Config.DrawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
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
                        StartLine = new PointF(RealCenter.X - (i + 1) * Config.StepOX, placeToDraw.Height);
                        EndLine = new PointF(RealCenter.X - (i + 1) * Config.StepOX, 0);
                        g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                    }
                    string num = "-" + Convert.ToString((i + 1) * Config.PriceForPointOX);
                    Oxpoints2[i].X = Oxpoints1[i].X = RealCenter.X - (i + 1) * Config.StepOX;

                    Oxpoints1[i].Y = RealCenter.Y - PointsGraphConfig.HEIGHT;
                    Oxpoints2[i].Y = RealCenter.Y + PointsGraphConfig.HEIGHT;
                    g.DrawString(num, Config.DrawFont, Config.drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);

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
                        StartLine = new PointF(RealCenter.X + (i + 1) * Config.StepOX, placeToDraw.Height);
                        EndLine = new PointF(RealCenter.X + (i + 1) * Config.StepOX, 0);
                        g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                    }

                    string num = Convert.ToString((i + 1) * Config.PriceForPointOX);
                    Oxpoints1[i].X = RealCenter.X + (i + 1) * Config.StepOX;
                    Oxpoints1[i].Y = RealCenter.Y - PointsGraphConfig.HEIGHT;

                    Oxpoints2[i].X = RealCenter.X + (i + 1) * Config.StepOX;
                    Oxpoints2[i].Y = RealCenter.Y + PointsGraphConfig.HEIGHT;

                    g.DrawString(num, Config.DrawFont, Config.drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);
                    g.DrawLine(new Pen(Config.GraphColor), Oxpoints1[i], Oxpoints2[i]);
                }

                Oxpoints1 = null;
                Oxpoints2 = null;

                //прорисовка отрицательных делений оси OY
                Oypoints1 = new Point[NegSepOY];
                Oypoints2 = new Point[NegSepOY];
                for (int i = 0; i < Oypoints1.Length; i++)
                {
                    if (Config.Grid == true)
                    {
                        StartLine = new PointF(0, RealCenter.Y + (i + 1) * Config.StepOY);
                        EndLine = new PointF(placeToDraw.Width, RealCenter.Y + (i + 1) * Config.StepOY);
                        g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                    }

                    string num = "-" + Convert.ToString((i + 1) * Config.PriceForPointOY);
                    Oypoints1[i].X = RealCenter.X - PointsGraphConfig.HEIGHT;
                    Oypoints1[i].Y = RealCenter.Y + (i + 1) * Config.StepOY;

                    Oypoints2[i].X = RealCenter.X + PointsGraphConfig.HEIGHT;
                    Oypoints2[i].Y = RealCenter.Y + (i + 1) * Config.StepOY;
                    g.DrawString(num, Config.DrawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                    g.DrawLine(Config.GraphPen, Oypoints1[i], Oypoints2[i]);
                }

                Oypoints1 = null;
                Oypoints2 = null;

                //прорисовка положительных делений оси OY
                Oypoints1 = new Point[PosSepOY];
                Oypoints2 = new Point[PosSepOY];
                for (int i = 0; i < Oypoints1.Length; i++)
                {
                    if (Config.Grid == true)
                    {
                        StartLine = new PointF(0, RealCenter.Y - (i + 1) * Config.StepOY);
                        EndLine = new PointF(placeToDraw.Width, RealCenter.Y - (i + 1) * Config.StepOY);
                        g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                    }
                    string num = Convert.ToString((i + 1) * Config.PriceForPointOY);
                    Oypoints1[i].X = RealCenter.X - PointsGraphConfig.HEIGHT;
                    Oypoints1[i].Y = RealCenter.Y - (i + 1) * Config.StepOY;

                    Oypoints2[i].X = RealCenter.X + PointsGraphConfig.HEIGHT;
                    Oypoints2[i].Y = RealCenter.Y - (i + 1) * Config.StepOY;

                    g.DrawString(num, Config.DrawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
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
            //
            //test
            //int count = 0;
            
            for (int i = 0; i < currentCurve.PointsToDraw.Length; i++)
            {

                float x = (float)(RealCenter.X + currentCurve.PointsToDraw[i].X * Config.StepOX / Config.PriceForPointOX);

                float y = (float)(RealCenter.Y - currentCurve.PointsToDraw[i].Y * Config.StepOY / Config.PriceForPointOY);

                if (float.IsPositiveInfinity(x)) x = 1000000;
                if (float.IsPositiveInfinity(y)) y = 1000000;
                if (float.IsNegativeInfinity(x)) x = -1000000;
                if (float.IsNegativeInfinity(y)) y = -1000000;
                points[i].X = x;
                points[i].Y = y;
            }
            
            if (Config.SmoothAngles == true)
            {
                if (points.Length >= 2)
                {
                    g.DrawCurve(grafpen, points);
                    
                }
            }
            else if (Config.SmoothAngles == false)
            {
                if (points.Length >= 2)
                {
                    g.DrawLines(grafpen, points);
                   
                }
            }

            if (Config.DrawPoints == true)
            {
                int r = 4;
                foreach (PointF pt in points)
                {
                    g.FillEllipse(new SolidBrush(currentCurve.DotsColor), pt.X - r / 2, pt.Y - r / 2, r, r);
                }
            }
        }

        private void DrawAxesNames()
        {
            Font fontOX = new Font("Arial", (float)Config.SizeOX);
            Font fontOY = new Font("Arial", (float)Config.SizeOY);
            SolidBrush brush = new SolidBrush(Color.Black);
            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            #region Координаты для строки названия оси Ох.
            SizeF size = g.MeasureString(Config.OXName, fontOX);
            PointF pointOX = new PointF();
            if (Config.OXNamePosition == TextPosition.Centre)
            {
                pointOX.X = RealCenter.X + 10; //+ (pt4.X - RealCenter.X) / 2 - size.Width / 2;
                pointOX.Y = RealCenter.Y + 20;
            }
            else if (Config.OXNamePosition == TextPosition.Left)
            {
                pointOX.X = pt1.X;
                pointOX.Y = RealCenter.Y + 20;
            }
            else if (Config.OXNamePosition == TextPosition.Right)
            {
                pointOX.X = pt4.X;
                pointOX.Y = RealCenter.Y + 20;
                while (pointOX.X + size.Width > pt4.X)
                {
                    pointOX.X--;
                }
            }
            #endregion
            #region Координаты для строки названия оси Оy.
            size = g.MeasureString(Config.OYName, fontOY);
            PointF pointOY = new PointF();
            if (Config.OYNamePosition == TextPosition.Centre)
            {
                pointOY.X = RealCenter.X - 35;
                pointOY.Y = RealCenter.Y - (RealCenter.Y - pt2.Y) / 2 - size.Width / 2;
            }
            if (Config.OYNamePosition == TextPosition.Left)
            {
                pointOY.X = RealCenter.X - 35;
                pointOY.Y = pt2.Y;
            }
            if (Config.OYNamePosition == TextPosition.Right)
            {
                pointOY.X = RealCenter.X - 35;
                pointOY.Y = pt1.Y;
                while (pointOY.Y + size.Width > pt1.Y)
                {
                    pointOY.Y--;
                }
            }
            #endregion

            //рисование названия Ox
            g.DrawString(Config.OXName, fontOX, brush, pointOX);
            //рисование названия Oy
            g.DrawString(Config.OYName, fontOY, brush, pointOY, stringFormat);
        }

        private void DrawTitle()
        {
            Font font = new Font("Arial", TitleSize);
            SolidBrush brush = new SolidBrush(Color.Black);
            SizeF size = g.MeasureString(Title, font);
            

            float x = 0, y = 0;
            if (TitlePosition == TextPosition.Left)
            {
                x = pt1.X;
                y = Space_From_Top / 2;
            }
            else if (TitlePosition == TextPosition.Centre)
            {
                x = RealCenter.X + 20; // (pt4.X - RealCenter.X) / 2 - size.Width / 2;
                y = Space_From_Top / 2;
            }
            else if (TitlePosition == TextPosition.Right)
            {
                x = pt4.X;
                y = Space_From_Top / 2;
                while (x + size.Width > pt4.X)
                {
                    x -= 1;
                }
            }
            PointF textPoint = new PointF(x, y);
            g.DrawString(Title, font, brush, textPoint);
        }

        private void DrawDiagramLegend()
        {
            int lineLength = 15;
            PointF StartPoint = new PointF(LastPointOX.X + 10, LastPointOX.Y / 2);
            PointF EndPoint = new PointF(StartPoint.X + lineLength, StartPoint.Y);
            foreach (Curves crrCurve in GraphCurves)
            {
                g.DrawLine(new Pen(crrCurve.CurveColor, 2), StartPoint, EndPoint);
                string str = " - " + crrCurve.Legend;
                g.DrawString(str, new Font("Arial", 7), new SolidBrush(Color.Black), EndPoint.X, EndPoint.Y - 7);

                StartPoint.Y += 25;
                EndPoint.Y += 25;
            }
        }


        /// <summary>
        /// Преобразует входящие параметры в значения прямоугольной системы координат или в значение системы координат объекта Control.
        /// </summary>
        /// <param name="x">Значение абсциссы точки</param>
        /// <param name="y">Значение ординаты точки</param>
        /// <param name="type">Тип системы координат, в котором возвращаются значения</param>
        /// <returns></returns>
        public PointF ConvertValues(double x, double y,  CoordType type)
        {
            PointF res = new PointF(0,0);
            if (type == CoordType.GetControlCoord)
            {
                res.X = (float)(RealCenter.X + x * Config.StepOX / Config.PriceForPointOX);
                res.Y = (float)(RealCenter.Y - y * Config.StepOY / Config.PriceForPointOY);
            }
            else if (type == CoordType.GetRectangleCoord)
            {
                res.X = (float)((x - RealCenter.X) * Config.PriceForPointOX / Config.StepOX);
                res.Y = (float)((RealCenter.Y - y) * Config.PriceForPointOY / Config.StepOY);
            }
            return res;
        }

        public PointF ConvertValues(PointF convertPt, CoordType type)
        {
            PointF res = new PointF(0, 0);
            if (type == CoordType.GetControlCoord)
            {
                res.X = (float)(RealCenter.X + convertPt.X * Config.StepOX / Config.PriceForPointOX);
                res.Y = (float)(RealCenter.Y - convertPt.Y * Config.StepOY / Config.PriceForPointOY);
            }
            else if (type == CoordType.GetRectangleCoord)
            {
                res.X = (float)((convertPt.X - RealCenter.X) * Config.PriceForPointOX / Config.StepOX);
                res.Y = (float)((RealCenter.Y - convertPt.Y) * Config.PriceForPointOY / Config.StepOY);
            }
            return res;
        }
    }
}
