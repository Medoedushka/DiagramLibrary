﻿using System;
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

        private void DrawAxes(bool enableGrid)
        {
            
            g.DrawLine(Config.GraphPen, pt1, pt4); //ось абсцисс
            
            g.DrawLine(Config.GraphPen, pt1, pt2); //ось ординат
            
            //дополнительные линии
            g.DrawLine(Config.GraphPen, pt1.X - PointsGraphConfig.HEIGHT, RealCenter.Y, pt3.X, RealCenter.Y); //параллельная оси абсцисс
            g.DrawLine(Config.GraphPen, RealCenter.X, pt1.Y + PointsGraphConfig.HEIGHT, RealCenter.X, pt2.Y); //параллельная оси ординат
            g.DrawLine(Config.GraphPen, pt2, pt3);
            g.DrawLine(Config.GraphPen, pt3, pt4);
            g.DrawString("0", Config.DrawFont, Config.drawBrush, RealCenter.X - 6, pt1.Y);
            g.DrawString("0", Config.DrawFont, Config.drawBrush, pt1.X - 6, RealCenter.Y);
            
            float LengthOXNegative = Math.Abs(RealCenter.X - pt1.X);
            float LenghtOYNegative = Math.Abs(pt1.Y - RealCenter.Y);
            float LenghtOXPositive = Math.Abs(pt4.X - RealCenter.X);
            float LenghtOYPositive = Math.Abs(RealCenter.Y - pt2.Y);

            NegSepOX = (int)Math.Truncate(LengthOXNegative / Config.StepOX);
            PosSepOX = (int)Math.Truncate(LenghtOXPositive / Config.StepOX);

            NegSepOY = (int)Math.Truncate(LenghtOYNegative / Config.StepOY);
            PosSepOY = (int)Math.Truncate(LenghtOYPositive / Config.StepOY);

            PointF StartLine, EndLine;
            PointF topP, botP;
            int n = 4; //кол-во промежуточних делений

            #region<---Прорисовка положительных делений оси OX--->
            //Основные деления
            for (int i = 0; i < PosSepOX; i++)
            {
                string num = Convert.ToString((i + 1) * Config.PriceForPointOX);
                topP = new PointF(RealCenter.X + (i + 1) * Config.StepOX, pt1.Y - PointsGraphConfig.HEIGHT);

                botP = new PointF(RealCenter.X + (i + 1) * Config.StepOX, pt1.Y + PointsGraphConfig.HEIGHT);

                if (topP.X < pt1.X || topP.X > pt4.X) continue;
                
                if (Config.Grid == true && enableGrid)
                {
                    StartLine = new PointF(RealCenter.X + (i + 1) * Config.StepOX, pt1.Y);
                    EndLine = new PointF(RealCenter.X + (i + 1) * Config.StepOX, pt2.Y);
                    g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                }

                g.DrawString(num, Config.DrawFont, Config.drawBrush, botP.X - 3, botP.Y);
                g.DrawLine(new Pen(Config.GraphColor), topP, botP);
                
                
            }
            //Промежуточные деления
            for (int j = 1; j <= n * (PosSepOX + 1); j++)
            {
                topP = new PointF(RealCenter.X + j * Config.StepOX / n, pt1.Y - PointsGraphConfig.subHEIGHT);
                botP = new PointF(RealCenter.X + j * Config.StepOX / n, pt1.Y + PointsGraphConfig.subHEIGHT);
                if (topP.X < pt1.X || topP.X > pt4.X) continue;
                g.DrawLine(new Pen(Config.GraphColor), topP, botP);
            }
            #endregion

            #region<---Прорисовка положительных делений оси OY--->
            //Основные деления
            for (int i = 0; i < PosSepOY; i++)
            {
                string num = Convert.ToString((i + 1) * Config.PriceForPointOY);

                topP = new PointF(pt1.X + PointsGraphConfig.HEIGHT, RealCenter.Y - (i + 1) * Config.StepOY);
                botP = new PointF(pt1.X - PointsGraphConfig.HEIGHT, RealCenter.Y - (i + 1) * Config.StepOY);

                if (topP.Y > pt1.Y || topP.Y < pt2.Y) continue;
                if (Config.Grid == true && enableGrid)
                {
                    StartLine = new PointF(pt1.X, RealCenter.Y - (i + 1) * Config.StepOY);
                    EndLine = new PointF(pt4.X, RealCenter.Y - (i + 1) * Config.StepOY);
                    g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                }
                g.DrawString(num, Config.DrawFont, Config.drawBrush, botP.X - 10, botP.Y);
                g.DrawLine(Config.GraphPen, topP, botP);
            }
            //Промежуточные деления
            for (int j = 1; j <= n * (PosSepOY + 1); j++)
            {
                topP = new PointF(pt1.X + PointsGraphConfig.subHEIGHT, RealCenter.Y - j * Config.StepOY / n);
                botP = new PointF(pt1.X - PointsGraphConfig.subHEIGHT, RealCenter.Y - j * Config.StepOY / n);
                if (topP.Y > pt1.Y || topP.Y < pt2.Y) continue;
                g.DrawLine(new Pen(Config.GraphColor), topP, botP);
            }
            #endregion

            #region<---Прорисовка отрицательных делений оси OX--->
            //Основные деления
            for (int i = 0; i < NegSepOX; i++)
            {

                string num = "-" + Convert.ToString((i + 1) * Config.PriceForPointOX);
                topP = new PointF(RealCenter.X - (i + 1) * Config.StepOX, pt1.Y - PointsGraphConfig.HEIGHT);
                botP = new PointF(RealCenter.X - (i + 1) * Config.StepOX, pt1.Y + PointsGraphConfig.HEIGHT);

                if (topP.X < pt1.X || topP.X > pt4.X) continue;
                if (Config.Grid == true && enableGrid)
                {
                    StartLine = new PointF(RealCenter.X - (i + 1) * Config.StepOX, pt1.Y);
                    EndLine = new PointF(RealCenter.X - (i + 1) * Config.StepOX, pt2.Y);
                    g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                }
                g.DrawString(num, Config.DrawFont, Config.drawBrush, botP.X - 3, botP.Y);
                g.DrawLine(new Pen(Config.GraphColor), topP, botP);
            }
            //Промежуточные деления
            for (int j = 1; j <= n * (NegSepOX + 1); j++)
            {
                topP = new PointF(RealCenter.X - j * Config.StepOX / n, pt1.Y - PointsGraphConfig.subHEIGHT);
                botP = new PointF(RealCenter.X - j * Config.StepOX / n, pt1.Y + PointsGraphConfig.subHEIGHT);
                if (topP.X < pt1.X || topP.X > pt4.X) continue;
                g.DrawLine(new Pen(Config.GraphColor), topP, botP);
            }
            #endregion

            #region<---Прорисовка отрицательных делений оси OY--->
            for (int i = 0; i < NegSepOY; i++)
            {
                string num = "-" + Convert.ToString((i + 1) * Config.PriceForPointOY);
                topP = new PointF(pt1.X + PointsGraphConfig.HEIGHT, RealCenter.Y + (i + 1) * Config.StepOY);
                botP = new PointF(pt1.X - PointsGraphConfig.HEIGHT, RealCenter.Y + (i + 1) * Config.StepOY);
                if (topP.Y > pt1.Y || topP.Y < pt2.Y) continue;
                if (Config.Grid == true && enableGrid)
                {
                    StartLine = new PointF(pt1.X, RealCenter.Y + (i + 1) * Config.StepOY);
                    EndLine = new PointF(pt4.X, RealCenter.Y + (i + 1) * Config.StepOY);
                    g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                }
                g.DrawString(num, Config.DrawFont, Config.drawBrush, botP.X - 10, botP.Y);
                
                g.DrawLine(Config.GraphPen, topP, botP);
            }
            //Промежуточные деления
            for (int j = 1; j <= n * (NegSepOY + 1); j++)
            {
                topP = new PointF(pt1.X + PointsGraphConfig.subHEIGHT, RealCenter.Y + j * Config.StepOY / n);
                botP = new PointF(pt1.X - PointsGraphConfig.subHEIGHT, RealCenter.Y + j * Config.StepOY / n);
                if (topP.Y > pt1.Y || topP.Y < pt2.Y) continue;
                g.DrawLine(new Pen(Config.GraphColor), topP, botP);
            }
            #endregion

        }

        private void StaticDrawCurrentCurve(Curves currentCurve)
        {
            Pen grafpen = new Pen(currentCurve.CurveColor, currentCurve.CurveThickness);
            PointF[] points = new PointF[currentCurve.PointsToDraw.Length];
            bool isDotOut = false;
            for (int i = 0; i < currentCurve.PointsToDraw.Length; i++)
            {

                float x = (float)(RealCenter.X + currentCurve.PointsToDraw[i].X * Config.StepOX / Config.PriceForPointOX);

                float y = (float)(RealCenter.Y - currentCurve.PointsToDraw[i].Y * Config.StepOY / Config.PriceForPointOY);

                if (x >= pt1.X && x <= pt4.X && y >= pt2.Y && y <= pt1.Y)
                {
                    points[i].X = x;
                    points[i].Y = y;
                }
                else
                {
                    points[i].X = x;
                    points[i].Y = y;
                    isDotOut = true;
                }
                if (float.IsPositiveInfinity(x)) x = 1000000;
                if (float.IsPositiveInfinity(y)) y = 1000000;
                if (float.IsNegativeInfinity(x)) x = -1000000;
                if (float.IsNegativeInfinity(y)) y = -1000000;
                
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

            if (isDotOut)
            {
                g.FillRectangle(new SolidBrush(placeToDraw.BackColor), 0, -1, placeToDraw.Width, pt2.Y+1);
                g.FillRectangle(new SolidBrush(placeToDraw.BackColor), 0, placeToDraw.Height - Space_From_Bottom, placeToDraw.Width, Space_From_Bottom);
                g.FillRectangle(new SolidBrush(placeToDraw.BackColor), pt3.X, pt3.Y, Space_From_Right, pt4.Y - pt3.Y);
                g.FillRectangle(new SolidBrush(placeToDraw.BackColor), -1, pt2.Y, Space_From_Left + 1, pt1.Y - pt2.Y);
                DrawAxes(false);
            }
        }
        private void DrawAxesNames()
        {
            Font fontOX = new Font("Arial", (float)Config.OXNameSize);
            Font fontOY = new Font("Arial", (float)Config.OYNameSize);
            SolidBrush brush = new SolidBrush(Color.Black);
            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            #region<---Координаты для строки названия оси Ох--->

            SizeF size = g.MeasureString(Config.OXName, fontOX);
            PointF pointOX = new PointF();

            if (Config.OXNamePosition == TextPosition.Centre)
            {
                pointOX.X = pt4.X / 2 - size.Width / 2;
                pointOX.Y = pt1.Y + size.Height;
            }
            else if (Config.OXNamePosition == TextPosition.Left)
            {
                pointOX.X = pt1.X;
                pointOX.Y = pt1.Y + size.Height;
            }
            else if (Config.OXNamePosition == TextPosition.Right)
            {
                pointOX.X = pt4.X;
                pointOX.Y = pt1.Y + size.Height;
                while (pointOX.X + size.Width > pt4.X)
                {
                    pointOX.X--;
                }
            }
            #endregion
            #region<---Координаты для строки названия оси Оy--->
            size = g.MeasureString(Config.OYName, fontOY);
            PointF pointOY = new PointF();
            if (Config.OYNamePosition == TextPosition.Centre)
            {
                pointOY.X = pt1.X - 35;
                pointOY.Y = pt1.Y / 2 - size.Width / 2;
            }
            if (Config.OYNamePosition == TextPosition.Left)
            {
                pointOY.X = pt1.X - 35;
                pointOY.Y = pt2.Y;
            }
            if (Config.OYNamePosition == TextPosition.Right)
            {
                pointOY.X = pt1.X - 35;
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
            float n = size.Height / 2;
            if (TitlePosition == TextPosition.Left)
            {
                x = pt1.X;
                y = Space_From_Top / 2 - n;
            }
            else if (TitlePosition == TextPosition.Centre)
            {
                x = pt3.X / 2 - size.Width / 2;
                y = Space_From_Top / 2 - n;
            }
            else if (TitlePosition == TextPosition.Right)
            {
                x = pt4.X;
                y = Space_From_Top / 2 - n;
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
            Font font = new Font("Arial", 9);
            PointF temp = new PointF(pt3.X, pt3.Y + 5);
            float minX = float.MaxValue, maxY = 0;
            foreach (Curves crrCurve in GraphCurves)
            {
                
                string str = " - " + crrCurve.Legend;
                SizeF size = g.MeasureString(str, font);
                while (temp.X + size.Width > pt3.X) temp.X--;
                if (temp.X < minX) minX = temp.X - lineLength - 5;

                g.DrawString(str, font, new SolidBrush(Color.Black), temp);
                g.DrawLine(new Pen(crrCurve.CurveColor, 4), temp.X - lineLength, temp.Y + size.Height / 2, temp.X, temp.Y + size.Height / 2);
                temp = new PointF(pt3.X, temp.Y + 20);
                maxY = temp.Y;
            }
            g.DrawLine(new Pen(Color.Black), minX, pt3.Y, minX, maxY);
            g.DrawLine(new Pen(Color.Black), minX, maxY, pt3.X, maxY);
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
        /// <summary>
        /// Преобразует входящие параметры в значения прямоугольной системы координат или в значение системы координат объекта Control.
        /// </summary>
        /// <param name="convertPt">Точка для конвертации</param>
        /// <param name="type">Тип системы координат, в котором возвращаются значения</param>
        /// <returns></returns>
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
