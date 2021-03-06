﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace MyDrawing
{
    public enum LegendPosition
    {
        Top,
        Bottom
    }

    public class BarChartConfig
    {
        public double BarWidth { get; internal set; }
        public byte StepOX { get; set; }
        public int StepOY { get; set; }
        public double PriceForPointOY { get; set; }
        public byte NumberOfSepOY { get; set; }

        public Color DiagramColor { get; set; }
        public Pen DiagramPen { get; set; }
        public Font drawFont { get; set; }
        public SolidBrush drawBrush{get; set;}
        public const byte HEIGHT = 4;

        public string[] Fileds { get; set; }
        public string OXName { get; set; }
        public string OYName { get; set; }
        public TextPosition OXNamePosition { get; set; }
        public TextPosition OYNamePosition { get; set; }
        public double SizeOX { get; set; }
        public double SizeOY { get; set; }

        public LegendPosition LegendPosition { get; set; }
        public bool ShowGroupBorder { get; set; }
        public bool HorizontalLines { get; set; }
        public bool ShowColumnValue { get; set; }
    }

    /// <summary>
    /// Представляет структуру для инициализации столбцов гистограммы.
    /// </summary>
    public class Bars
    {
        /// <summary>
        /// Название ряда данных.
        /// </summary>
        public string BarName { get; set; }
        /// <summary>
        /// Массив значений ряда данных. Порядок значений должен соответствовать порядку названий секторов.
        /// </summary>
        public double[] BarValues { get; set; }
        /// <summary>
        /// Цвет заливки столбца.
        /// </summary>
        public Color BarColor
        {
            get { return barColor; }
            set
            {
                textureImage = null;
                gradientColor1 = gradientColor2 = Color.Transparent;
                barColor = value;
            }
        }
        private Color barColor;
        /// <summary>
        /// Картинка для текстуры ряда данных.
        /// </summary>
        public Image TextureImgage
        {
            get { return textureImage; }
            set
            {
                BarColor = Color.Transparent;
                gradientColor1 = gradientColor2 = Color.Transparent;
                textureImage = value;
            }
        }
        private Image textureImage;
        /// <summary>
        /// Первый цвет градиента столбца.
        /// </summary>
        public Color GradientColor1
        {
            get { return gradientColor1; }
            set
            {
                barColor = Color.Transparent;
                textureImage = null;
                gradientColor1 = value;
            }
        }
        private Color gradientColor1;
        /// <summary>
        /// Второй цвет градиента столбца.
        /// </summary>
        public Color GradientColor2
        {
            get { return gradientColor2; }
            set
            {
                barColor = Color.Transparent;
                textureImage = null;
                gradientColor2 = value;
            }
        }
        private Color gradientColor2;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interiorColor">Цвет, входящий в структуру Color.</param>
        /// <param name="values"></param>
        /// <param name="name"></param>
        public Bars(double[] values, Color interiorColor, string name = "Пусто")
        {
            BarName = name;
            BarValues = values;
            BarColor = interiorColor;
        }

        public Bars(double[] values, string textureFilePath, string name = "Пусто")
        {
            BarName = name;
            BarValues = values;
            if (File.Exists(textureFilePath) )
            {
                FileInfo fi = new FileInfo(textureFilePath);
                if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".bmp")
                    TextureImgage = Image.FromFile(textureFilePath);
                else throw new Exception("Расширение указаного файла не соответствует требуемым(.jpg; .png; .bmp)");
            }
            else throw new Exception("Файл, по указанному пути, не существует.");
        }

        public Bars(double[] values, Color gradient1, Color gradient2, string name = "Пусто")
        {
            BarName = name;
            BarValues = values;
            GradientColor1 = gradient1;
            GradientColor2 = gradient2;
        }
    }

    public class BarChart : Diagram
    {
        public BarChartConfig Config { get; set; } //Настройки гистограммы
        public List<Bars> BarCollection { get; set; } // коллекция рядов данных
        private PointF[] fieldPt; // массив точек центров секторов
        private int sectorStep = 30; // расстояние между секторами
        private int columnStep = 0; // расстояние между колонками
        private float Length; // длина области, доступной для построения столбцов в каждой категории.
        
        
        public BarChart(PictureBox picture, string[] fields)
        {
            Config = new BarChartConfig();
            BarCollection = new List<Bars>();
            placeToDraw = picture;
            g = placeToDraw.CreateGraphics();

            Config.DiagramColor = Color.Black;
            Config.DiagramPen = new Pen(Config.DiagramColor);
            Config.drawFont = new Font("Arial", 8);
            Config.drawBrush = new SolidBrush(Config.DiagramColor);
            Config.Fileds = fields;
            Config.ShowGroupBorder = false;
            Config.LegendPosition = LegendPosition.Bottom;
            Config.NumberOfSepOY = 5;

            Title = "Название диаграммы";
            TitlePosition = TextPosition.Centre;
            TitleSize = 15;
        }

        public void SetPlaceToDrawSize(int width, int height, bool defParams = true)
        {

            //координаты угловых точек рамки
            pt2 = new Point(Space_From_Left, Space_From_Top); //левая верхняя точка
            pt3 = new Point(width - Space_From_Right, Space_From_Top); //правая верхняя точка
            if (AddDiagramLegend != true || Config.LegendPosition == LegendPosition.Top )
            {
                
                pt1 = new Point(Space_From_Left, height - Space_From_Bottom); //левая нижняя точка
                pt4 = new Point(width - Space_From_Right, height - Space_From_Bottom); //правая нижняя точка

            }
            else if (AddDiagramLegend == true && Config.LegendPosition == LegendPosition.Bottom)
            {
                
                pt1 = new Point(Space_From_Left, height - Space_From_Bottom - 30); //левая нижняя точка
                pt4 = new Point(width - Space_From_Right, height - Space_From_Bottom - 30); //правая нижняя точка
            }
            //центр пересечения осей
            Center = pt1;

            if (defParams)
                SetDefaultParams();
        }

        /// <summary>
        /// Устанавливает настройки диаграммы по умолчанию.
        /// </summary>
        public void SetDefaultParams()
        {
            if (BarCollection.Count != 0)
            {
                //определения параметров по умолчанию для оси OY
                double maxValue = 0;
                foreach(Bars crrBar in BarCollection)
                {
                    for(int i = 0; i < crrBar.BarValues.Length; i++)
                    {
                        if (maxValue < crrBar.BarValues[i])
                            maxValue = crrBar.BarValues[i];
                    }
                }
                Config.StepOY = (int)((pt1.Y - pt2.Y) / Config.NumberOfSepOY);
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
        private void DrawAxes()
        {
            //прорисовка осей без делений
            g.DrawLine(Config.DiagramPen, Center, pt4); //ось ОХ
            g.DrawLine(Config.DiagramPen, Center, pt2); //ось OY
            g.DrawString("0", Config.drawFont, Config.drawBrush, Center.X - 6, Center.Y);

            float step = (pt4.X - pt1.X) / (Config.Fileds.Length); // длина области одной категории
            fieldPt = new PointF[Config.Fileds.Length]; // массив точек середин области категории
            float prevX = Center.X;
            float Templen = 0;
            for (int i = 0; i < Config.Fileds.Length; i++)
            {
                PointF secPt = new PointF(Center.X + (i + 1) * (step), Center.Y);
                fieldPt[i] = new PointF(prevX + (secPt.X - prevX) / 2, Center.Y);
                SizeF size = g.MeasureString(Config.Fileds[i], Config.drawFont);
                Templen = secPt.X - prevX; // длина области одной категории
                prevX = secPt.X;

                if (Config.ShowGroupBorder)
                {
                    g.DrawLine(new Pen(Color.FromArgb(213, 209, 200)), secPt.X, secPt.Y, secPt.X, pt3.Y);
                }
            }

            // Вычисление длины области построения столбцов.
            PointF testP1 = fieldPt[0], testP2 = fieldPt[0];
            while (testP2.X < fieldPt[0].X + Templen / 2 - sectorStep / 2)
            {
                testP1.X--;
                testP2.X++;
            }
            Length = testP2.X - testP1.X;

            #region<---Прорисовка делений на оси OY--->
            Point[] Oypoints1 = new Point[Config.NumberOfSepOY];
            Point[] Oypoints2 = new Point[Config.NumberOfSepOY];
            for(int i = 0; i < Config.NumberOfSepOY; i++)
            {
                string num = Convert.ToString(i * Config.PriceForPointOY + Config.PriceForPointOY);
                SizeF size = g.MeasureString(num, Config.drawFont);
                if (i == 0)
                {
                    Oypoints1[i].X = Center.X - BarChartConfig.HEIGHT;
                    Oypoints1[i].Y = Center.Y - Config.StepOY;

                    Oypoints2[i].X = Center.X + BarChartConfig.HEIGHT;
                    Oypoints2[i].Y = Center.Y - Config.StepOY;
                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oypoints1[i].X - size.Width, Oypoints1[i].Y - size.Height / 2);
                }
                else
                {
                    Oypoints1[i].X = Center.X - BarChartConfig.HEIGHT;
                    Oypoints1[i].Y = Oypoints1[i - 1].Y - Config.StepOY;

                    Oypoints2[i].X = Center.X + BarChartConfig.HEIGHT;
                    Oypoints2[i].Y = Oypoints2[i - 1].Y - Config.StepOY;
                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oypoints1[i].X - size.Width, Oypoints1[i].Y - size.Height / 2);
                }
                g.DrawLine(Config.DiagramPen, Oypoints1[i], Oypoints2[i]);

                //рисование горизонтальных линий
                if(Config.HorizontalLines == true)
                {
                    PointF StartLine = new PointF(Center.X, Oypoints1[i].Y);
                    PointF EndLine = new PointF(pt4.X, Oypoints1[i].Y);
                    g.DrawLine(new Pen(Color.FromArgb(213, 209, 200)), StartLine, EndLine);
                }
            }
            #endregion
            //Рассчёт толщины столбца
            Config.BarWidth = 0;
            if (BarCollection.Count != 0)
            {
                while (Config.BarWidth * BarCollection.Count + (BarCollection.Count - 1) * columnStep < Length)
                    Config.BarWidth++;
            }
        }

        private void DrawCurrentBar()
        {
            for(int i = 0; i < Config.Fileds.Length; i++)
            {
                float x = fieldPt[i].X - Length / 2;
                foreach(Bars br in BarCollection)
                {
                    if (br.BarValues[i] == 0)
                    {
                        x += (float)Config.BarWidth + columnStep;
                        continue;
                    }
                    PointF BarPoint = new PointF();
                    BarPoint.X = x;
                    BarPoint.Y = (float)(Center.Y - br.BarValues[i] * Config.StepOY / Config.PriceForPointOY);
                    

                    RectangleF BarRectangle = new RectangleF(BarPoint.X, BarPoint.Y, (float)Config.BarWidth, Center.Y - BarPoint.Y);
                    
                    if (br.TextureImgage != null)
                        g.FillRectangle(new TextureBrush(br.TextureImgage, System.Drawing.Drawing2D.WrapMode.TileFlipXY), BarRectangle);
                    else if (br.GradientColor1 != Color.Transparent && br.GradientColor2 != Color.Transparent)
                        g.FillRectangle(new LinearGradientBrush(BarRectangle, br.GradientColor2, br.GradientColor1, LinearGradientMode.Vertical), 
                            BarRectangle);
                    else
                        g.FillRectangle(new SolidBrush(br.BarColor), BarRectangle);
                   
                    if (Config.ShowColumnValue == true)
                    {
                        SizeF size = g.MeasureString(Convert.ToString(br.BarValues[i]), Config.drawFont);
                        PointF ValuePoint = new PointF((float)(BarPoint.X + Config.BarWidth / 2 - size.Width / 2), BarPoint.Y - 12);
                        g.DrawString(Convert.ToString(br.BarValues[i]), Config.drawFont, Config.drawBrush, ValuePoint);
                    }

                    x += (float)Config.BarWidth + columnStep;
                }
            }
        }
        
        private void DrawTitle()
        {
            Font font = new Font("Arial", TitleSize);
            SolidBrush brush = new SolidBrush(Color.Black);
            SizeF size = g.MeasureString(Title, font);

            float x = 0, y = 0;
            if (TitlePosition == TextPosition.Left)
            {
                x = pt1.X; y = pt2.Y - 20;
            }
            else if (TitlePosition == TextPosition.Centre)
            {
                x = pt2.X + (pt3.X - pt2.X) / 2 - size.Width / 2;
                y = pt2.Y - 20;
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
        private void DrawLegend()
        {
            int CubeSide = 8; // длина стороны кубика, представляющего цвета ряда
            int step = 3; //расстояние между отдельными названиями рядов
            PointF pt = new PointF();

            //определение определение длины легенды в пикселях
            float lenght = 0;
            foreach (Bars bar in BarCollection)
            {
                string str = "-" + bar.BarName;
                SizeF size = g.MeasureString(str, Config.drawFont);
                lenght += CubeSide + size.Width;
            }

            //Определение координаты X точки начала построения легенды
            pt.X = pt2.X + (pt3.X - pt2.X - lenght) / 2;

            //Определение координаты Y в зависимости от выбраного способа отображения
            if (Config.LegendPosition == LegendPosition.Bottom) //под осью OX
            {
                pt.Y = pt1.Y + 30;
            }
            else //под названием гистограммы
            {
                pt.Y = pt2.Y + 5;
            }

            //непосредственно рисование легенды
            foreach(Bars bar in BarCollection)
            {
                string str = " " + bar.BarName;
                SizeF size = g.MeasureString(str, Config.drawFont);
                RectangleF rect = new RectangleF(pt.X, pt.Y, CubeSide, CubeSide);

                if (bar.TextureImgage != null)
                    g.FillRectangle(new TextureBrush(bar.TextureImgage, System.Drawing.Drawing2D.WrapMode.TileFlipXY), rect);
                else if (bar.GradientColor1 != Color.Transparent && bar.GradientColor2 != Color.Transparent)
                    g.FillRectangle(new LinearGradientBrush(rect, bar.GradientColor2, bar.GradientColor1, LinearGradientMode.Vertical),
                        rect);
                else
                    g.FillRectangle(new SolidBrush(bar.BarColor), rect);
                g.DrawString(str, new Font("Arial", 8), Config.drawBrush, pt.X + CubeSide, pt.Y - size.Height/ 3);
                pt.X += CubeSide + size.Width + step;
            }
        }

        /// <summary>
        /// Рисует гистограмму.
        /// </summary>
        public override void DrawDiagram()
        {
            SetPlaceToDrawSize(placeToDraw.Width, placeToDraw.Height);
            Bitmap bm = new Bitmap(placeToDraw.Width, placeToDraw.Height);
            using (g = Graphics.FromImage(bm))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                DrawAxes();

                if (AddDiagramLegend == true)
                {
                    DrawLegend();
                }

                if (Title != "" && TitleSize != 0)
                {
                    DrawTitle();
                }


                if (BarCollection.Count != 0) DrawCurrentBar();

            }
            placeToDraw.Image = bm;
            

            
        }

    }
}
