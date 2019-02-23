﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyDrawing
{


    public class BarChartConfig
    {
        public byte BarWidth { get; set; }
        public byte StepOX { get; set; }
        public byte StepOY { get; set; }
        public double PriceForPointOY { get; set; }
        public byte NumberOfSepOY { get; set; }

        public Color DiagramColor { get; set; }
        public Pen DiagramPen { get; set; }
        public Font drawFont { get; set; }
        public SolidBrush drawBrush{get; set;}
        public const byte HEIGHT = 4;

        public string OXName { get; set; }
        public string OYName { get; set; }
        public TextPosition OXNamePosition { get; set; }
        public TextPosition OYNamePosition { get; set; }
        public double SizeOX { get; set; }
        public double SizeOY { get; set; }

        
        public bool HorizontalLines { get; set; }
        public bool ShowColumnName { get; set; }
        public bool ShowColumnValue { get; set; }
    }

    /// <summary>
    /// Представляет структуру для инициализации столбцов гистограммы.
    /// </summary>
    public class Bars
    {
        /// <summary>
        /// Название столбца.
        /// </summary>
        public string BarName { get; set; }
        /// <summary>
        /// Числовое значение соответствующее столбцу.
        /// </summary>
        public double BarValue { get; set; }
        /// <summary>
        /// Цвет заливки столбца.
        /// </summary>
        public Color BarColor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="red">Значение красного компонента в цвете.</param>
        /// <param name="green">Значение зелёного компоненат в цвете.</param>
        /// <param name="blue">Значение синего компонента в цвете.</param>
        public Bars(double value, string name = "Пусто", byte red = 91, int green = 155, int blue = 213)
        {
            BarName = name;
            BarValue = value;
            BarColor = Color.FromArgb(red, green, blue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="interiorColor">Цвет, входящий в структуру Color.</param>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public Bars(Color interiorColor, double value, string name = "Пусто")
        {
            BarName = name;
            BarValue = value;
            BarColor = interiorColor;
        }
    }

    public class BarChart : Diagram
    {
        List<Bars> BarCollection = new List<Bars>();
        
        public BarChartConfig Config { get; set; }
        


        public BarChart(PictureBox picture)
        {
            Config = new BarChartConfig();
            placeToDraw = picture;
            Config.DiagramColor = Color.Black;
            Config.DiagramPen = new Pen(Config.DiagramColor);
            Config.drawFont = new Font("Arial", 8);
            Config.drawBrush = new SolidBrush(Config.DiagramColor);
            Config.ShowColumnName = true;
            //координаты угловых точек рамки
            //левая нижняя точка
            pt1 = new Point(Space_From_Left, placeToDraw.Height - Space_From_Bottom);
            //левая верхняя точка
            pt2 = new Point(Space_From_Left, Space_From_Top);
            //правая нижняя точка
            pt3 = new Point(placeToDraw.Width - Space_From_Right, placeToDraw.Height - Space_From_Bottom);
            //правая верхняя точка
            pt4 = new Point(placeToDraw.Width - Space_From_Right, Space_From_Top);
            //центр пересечения осей
            Center = pt1;
        }
        /// <summary>
        /// Устанавливает настройки диаграммы по умолчанию.
        /// </summary>
        public void SetDefaultParams()
        {
            if(BarCollection.Count != 0)
            {
                Config.BarWidth = 0;
                Config.StepOX = 0;
                //определение параметров по умолчанию для оси ОХ
                while (Center.X + BarCollection.Count * (Config.BarWidth + Config.StepOX) + Config.StepOX <= pt3.X)
                {
                    Config.StepOX++;
                    Config.BarWidth++;
                }

                //определения параметров по умолчанию для оси OY
                Config.NumberOfSepOY = 5;
                double maxValue = 0;
                foreach(Bars crrBar in BarCollection)
                {
                    if (maxValue < crrBar.BarValue) maxValue = crrBar.BarValue;
                }
                while(Center.Y - Config.StepOY*Config.NumberOfSepOY >= pt2.Y)
                {
                    Config.StepOY++;
                }
                Config.PriceForPointOY = Math.Round(maxValue * 0.25);
            }
        }
        /// <summary>
        /// Добавляет созданную колонку в коллекцию для рисования гистограммы.
        /// </summary>
        /// <param name="bar"></param>
        public void AddBar(Bars bar)
        {
            bool Exist = false;
            foreach(Bars crrBar in BarCollection)
            {
                if(crrBar.BarName == bar.BarName)
                {
                    Exist = true;
                    break;
                }
            }
            if (Exist) MessageBox.Show("Столбец с названием " + bar.BarName + " уже существует.", "Попытка добавить столбец",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                BarCollection.Add(bar);
                SetDefaultParams();
            }
        }

        private void DrawAxesNames()
        {
            if (Config.SizeOX == 0) Config.SizeOX = 9;
            if (Config.SizeOY == 0) Config.SizeOY = 9;

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
                pointOX.X = LastPointOY.X + (LastPointOX.X - LastPointOY.X) / 2 - size.Width / 2;
                pointOX.Y = Center.Y + 15;
            }
            else if (Config.OXNamePosition == TextPosition.Left)
            {
                pointOX.X = Center.X;
                pointOX.Y = Center.Y + 15;
            }
            else if (Config.OXNamePosition == TextPosition.Right)
            {
                pointOX.X = LastPointOX.X;
                pointOX.Y = Center.Y + 15;
                while (pointOX.X + size.Width > LastPointOX.X)
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
                pointOY.X = Center.X - 30;
                pointOY.Y = Center.Y - (Center.Y - LastPointOY.Y) / 2 - size.Width / 2;
            }
            if (Config.OYNamePosition == TextPosition.Left)
            {
                pointOY.X = Center.X - 30;
                pointOY.Y = LastPointOY.Y;
            }
            if (Config.OYNamePosition == TextPosition.Right)
            {
                pointOY.X = Center.X - 30;
                pointOY.Y = Center.Y;
                while (pointOY.Y + size.Width > Center.Y)
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
                x = LastPointOY.X; y = LastPointOY.Y - 20;
            }
            else if (TitlePosition == TextPosition.Centre)
            {
                x = LastPointOY.X + (LastPointOX.X - LastPointOY.X) / 2 - size.Width / 2;
                y = LastPointOY.Y - 20;
            }
            else if (TitlePosition == TextPosition.Right)
            {
                x = LastPointOX.X;
                y = LastPointOY.Y - 20;
                while (x + size.Width > LastPointOX.X)
                {
                    x -= 1;
                }
            }
            PointF textPoint = new PointF(x, y);
            g.DrawString(Title, font, brush, textPoint);
        }

        private void DrawAxes()
        {
            g = placeToDraw.CreateGraphics();
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            LastPointOX = new PointF(Center.X + BarCollection.Count * (Config.BarWidth + Config.StepOX) + Config.StepOX, Center.Y);
            LastPointOY = new PointF(Center.X, Center.Y - Config.NumberOfSepOY * Config.StepOY);
            //прорисовка осей без делений
            g.DrawLine(Config.DiagramPen, Center, LastPointOX); //ось ОХ
            g.DrawLine(Config.DiagramPen, Center, LastPointOY); //ось OY
            g.DrawString("0", Config.drawFont, Config.drawBrush, Center.X - 6, Center.Y);

            //прорисовка делений на оси OY
            Point[] Oypoints1 = new Point[Config.NumberOfSepOY];
            Point[] Oypoints2 = new Point[Config.NumberOfSepOY];
            for(int i = 0; i < Oypoints1.Length; i++)
            {
                string num = Convert.ToString(i * Config.PriceForPointOY + Config.PriceForPointOY);
                if (i == 0)
                {
                    Oypoints1[i].X = Center.X - BarChartConfig.HEIGHT;
                    Oypoints1[i].Y = Center.Y - Config.StepOY;

                    Oypoints2[i].X = Center.X + BarChartConfig.HEIGHT;
                    Oypoints2[i].Y = Center.Y - Config.StepOY;
                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                }
                else
                {
                    Oypoints1[i].X = Center.X - BarChartConfig.HEIGHT;
                    Oypoints1[i].Y = Oypoints1[i - 1].Y - Config.StepOY;

                    Oypoints2[i].X = Center.X + BarChartConfig.HEIGHT;
                    Oypoints2[i].Y = Oypoints2[i - 1].Y - Config.StepOY;
                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                }
                g.DrawLine(Config.DiagramPen, Oypoints1[i], Oypoints2[i]);
                //рисование горизонтальных линий
                if(Config.HorizontalLines == true)
                {
                    PointF StartLine = new PointF(Center.X, Oypoints1[i].Y);
                    PointF EndLine = new PointF(LastPointOX.X, Oypoints1[i].Y);
                    g.DrawLine(Config.DiagramPen, StartLine, EndLine);
                }
            }
        }

        private void DrawCurrentBar()
        {
            for(int i = 0; i < BarCollection.Count; i++)
            {
                PointF BarPoint = new PointF();
                BarPoint.X = Center.X + i * Config.BarWidth + (i * Config.StepOX + Config.StepOX);
                BarPoint.Y = (float)(Center.Y - BarCollection[i].BarValue * Config.StepOY / Config.PriceForPointOY);

                RectangleF BarRectangle = new RectangleF(BarPoint.X, BarPoint.Y, Config.BarWidth, Center.Y - BarPoint.Y);

                g.FillRectangle(new SolidBrush(BarCollection[i].BarColor), BarRectangle);
                if(Config.ShowColumnName == true)
                {
                    //надпись названия колонки
                    SizeF size = g.MeasureString(BarCollection[i].BarName, Config.drawFont);
                    PointF StringPoint = new PointF();
                    StringPoint.Y = Center.Y;
                    StringPoint.X = BarPoint.X + Config.BarWidth / 2 - size.Width / 2;

                    g.DrawString(BarCollection[i].BarName, Config.drawFont, Config.drawBrush, StringPoint);
                }

                if(Config.ShowColumnValue == true)
                {
                    SizeF size = g.MeasureString(Convert.ToString(BarCollection[i].BarValue), Config.drawFont);
                    PointF ValuePoint = new PointF(BarPoint.X + Config.BarWidth / 2 - size.Width / 2, BarPoint.Y - 12);
                    g.DrawString(Convert.ToString(BarCollection[i].BarValue), Config.drawFont, Config.drawBrush, ValuePoint);
                }
                
            }
        }

        private void DrawLegend()
        {
            int CubeSide = 10;
            PointF pt = new PointF(LastPointOX.X + 10, LastPointOY.Y);
            foreach(Bars bar in BarCollection)
            {
                RectangleF rect = new RectangleF(pt.X, pt.Y, CubeSide, CubeSide);
                g.FillRectangle(new SolidBrush(bar.BarColor), rect);

                g.DrawString(bar.BarName, new Font("Arial", 7), Config.drawBrush, pt.X + CubeSide + 5, pt.Y - 3);
                pt.Y += 20;
            }
                
        }

        /// <summary>
        /// Рисует гистограмму.
        /// </summary>
        public override void DrawDiagram()
        {
           
            DrawAxes();

            if ((Config.OXName != "" && Config.SizeOX != 0) || (Config.OYName != "" && Config.SizeOY != 0))
            {
                DrawAxesNames();
            }
            else MessageBox.Show("При указании названия осей необходимо также указать размер шрифта хотя бы одного названия.\n" +
                 "(SizeOX, SizeOY)", "Попытка добавить название осей.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (Title != "" && TitleSize != 0)
            {
                DrawTitle();
            }
            else MessageBox.Show("Не указан размер шрифта описания графика.", "Попытка добавить название графика",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            if(AddDiagramLegend == true)
            {
                DrawLegend();
            }

            if (BarCollection.Count != 0) DrawCurrentBar();
        }

    }
}
