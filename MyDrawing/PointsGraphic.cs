using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyDrawing
{
    public enum AxesPosition
    {
        FirstQuarter,
        AllQuarters
    }
    /// <summary>
    /// Содержит свойства для настройки графика.
    /// </summary>
    public class PointsGraphConfig
    {
        int stepOX;       //расстояние между делениями оси абсцисс
        int stepOY;       //расстояние между делениями оси ординат  
        int numberOfSepOx;//кол-во делений на оси Ох
        int numberOfSepOy;//кол-во делений на оси Оу
        public const int HEIGHT = 4;  //длинна одного деления

        double sizeOx, sizeOy; //размер шрифтов названия осей;
        double priceForPointOX; //цена деления на оси Ох 
        double priceForPointOY; //цена деления на оси Оу


        public Color GraphColor; //
        public Pen GraphPen;     //цвет для графика
                                 //
        public Color GridColor { get; set; }
        public Font drawFont;//параметры текста
        public SolidBrush drawBrush;//цвет заливки

        /// <summary>
        /// Устанавливает название оси Ox.
        /// </summary>
        public string OXName { get; set; }
        /// <summary>
        /// Устанавливает название оси Oy.
        /// </summary>
        public string OYName { get; set; }
        
        /// <summary>
        /// Перечисление возможных выравниваний оси абсцисс.
        /// </summary>
        public TextPosition OXNamePosition { get; set; }
        /// <summary>
        /// Перечисление возможных выравниваний оси ординат
        /// </summary>
        public TextPosition OYNamePosition { get; set; }
        /// <summary>
        /// Перечисление количества отображаемых четвертей графика.
        /// </summary>
        public AxesPosition CurrentAxesPos { get; set; }
        /// <summary>
        /// Добавление сетки на график.
        /// </summary>
        public bool Grid { get; set; }
        /// <summary>
        /// Сглаживание углов кривой.
        /// </summary>
        public bool SmoothAngles { get; set; }
        public bool DrawPoints { get; set; }


        #region Свойства полей 
        //свойства для расстояния между делениями осей
        /// <summary>
        /// Устанавливает расстояние между делениями на оси Ох.
        /// </summary>
        public int StepOX
        {
            get { return stepOX; }
            set
            {
                if (value > 0) stepOX = value;
                else stepOX = Math.Abs(value);
            }
        }
        /// <summary>
        /// Устанавливает расстояние между делениями на оси Оy.
        /// </summary>
        public int StepOY
        {
            get { return stepOY; }
            set
            {
                if (value > 0) stepOY = value;
                else stepOY = Math.Abs(value);
            }

        }
        //свойства для количества делений осей
        /// <summary>
        /// Устанавливает количество делений на оси Ох.
        /// </summary>
        public int NumberOfSepOX
        {
            get { return numberOfSepOx; }
            set
            {
                if (value > 0) numberOfSepOx = value;
                else throw new ArgumentOutOfRangeException("Передано отрицательное значение кол-ва делений оси OX");
            }

        }
        /// <summary>
        /// Устанавливает количество делений на оси Оy.
        /// </summary>
        public int NumberOfSepOY
        {
            get { return numberOfSepOy; }
            set
            {
                if (value > 0) numberOfSepOy = value;

                else throw new ArgumentOutOfRangeException("Передано отрицательное значение кол-ва делений оси OY");
            }
        }
        //свойства для названий осей
        //свойства для размера шрифтов осей
        /// <summary>
        /// Устанавливает размер шрифта для названия оси Ox.
        /// </summary>
        public double SizeOX
        {
            get { return sizeOx; }
            set
            {
                if (value > 0) sizeOx = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        /// <summary>
        /// Устанавливает размер шрифта для названия оси Oy.
        /// </summary>
        public double SizeOY
        {
            get { return sizeOy; }
            set
            {
                if (value > 0) sizeOy = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        //свойства для цены деления осей
        /// <summary>
        /// Устанавливает цену деления оси Ox.
        /// </summary>
        public double PriceForPointOX
        {
            get { return priceForPointOX; }
            set
            {
                if (value > 0) priceForPointOX = value;
                else priceForPointOX = Math.Abs(value);
            }
        }
        /// <summary>
        /// Устанавливает цену деления оси Oy.
        /// </summary>
        public double PriceForPointOY
        {
            get { return priceForPointOY; }
            set
            {
                if (value > 0) priceForPointOY = value;
                else priceForPointOY = Math.Abs(value);
            }
        }
        
        #endregion;
    }
    
    
    /// <summary>
    /// Предоставляет свойства и методы для рисования графика на элементе управления pictureBox.
    /// </summary>
    public class PointsGraphic : Diagram
    {
        private Point CountBegin;

        /// <summary>
        /// Содержит свойства для настройки графика.
        /// </summary>
        public PointsGraphConfig Config { get; set; } //структура, содержащая настройки осей и рамки для построения графика
        /// <summary>
        /// Список созданных кривых для построения.
        /// </summary>
        public List<Curves> GraphCurves { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture">область для рисования графика</param>
        /// <param name="axesPos">количесвто отображаемых четвертей</param>
        public PointsGraphic(PictureBox picture, AxesPosition axesPos = AxesPosition.AllQuarters)
        {
            placeToDraw = picture;
            GraphCurves = new List<Curves>();
            Config = new PointsGraphConfig();
            Config.GraphColor = Color.FromArgb(120, 120, 120);
            Config.GridColor = Color.FromArgb(120, 120, 120);
            Config.GraphPen = new Pen(Config.GraphColor);
            Config.drawFont = new Font("Arial", 8);
            Config.drawBrush = new SolidBrush(Config.GraphColor);
            Config.DrawPoints = false;
            Config.CurrentAxesPos = axesPos;
            
            //координаты угловых точек рамки
            //левая нижняя точка
            pt1 = new Point(Space_From_Left, placeToDraw.Height - Space_From_Bottom);
            //левая верхняя точка
            pt2 = new Point(Space_From_Left, Space_From_Top);
            //правая нижняя точка
            pt4 = new Point(placeToDraw.Width - Space_From_Right, placeToDraw.Height - Space_From_Bottom);
            //правая верхняя точка
            pt3 = new Point(placeToDraw.Width - Space_From_Right, Space_From_Top);
            //CountBegin = pt1;

            int X = pt2.X + (pt3.X - pt2.X) / 2;
            int Y = pt1.Y - (pt1.Y - pt2.Y) / 2;
            Center = new Point(X, Y);

            Config.StepOX = 25;
            Config.StepOY = 30;
            Config.PriceForPointOX = Config.PriceForPointOY = 1;
        }

        /// <summary>
        /// Устанавливает параметры Ox по умолчанию.
        /// </summary>
        public void SetDefaultOX()
        {
            if (GraphCurves.Count != 0)
            {
                double[] MaxFromEachMass = new double[GraphCurves.Count];
                double maxValue = 0; //максимальное значение среди массивов точек для каждой кривой
                //поиск максимального значения оси ОХ для каждой кривой 
                for (int i = 0; i < GraphCurves.Count; i++)
                {
                    for(int j = 0; j < GraphCurves[i].PointsToDraw.Length; j++)
                    {
                        if(MaxFromEachMass[i] < GraphCurves[i].PointsToDraw[j].X)
                        {
                            MaxFromEachMass[i] = GraphCurves[i].PointsToDraw[j].X;
                        }
                    }
                }
                //поиск максимального значения среди полученных максимальных значений
                for(int i = 0; i < MaxFromEachMass.Length; i++)
                {
                    if (maxValue < MaxFromEachMass[i]) maxValue = MaxFromEachMass[i];
                }

                Config.NumberOfSepOX = 5;
                while(Center.X + Config.NumberOfSepOX*Config.StepOX <= pt3.X)
                {
                    Config.StepOX++;
                }
                Config.PriceForPointOX = Math.Round(maxValue * 0.25, 1);

            }
            else MessageBox.Show("Недостаточно данных для оптимального построения области диагрммы", "Внимание",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        /// <summary>
        /// Устанавливает параметры Oy по умолчанию.
        /// </summary>
        public void SetDefaultOY()
        {
            
            if (GraphCurves.Count != 0)
            {
                double maxValue = 0;//максимальное значение среди массивов точек для каждой кривой
                double[] MaxFromEachMass = new double[GraphCurves.Count];
                //поиск максимального значения оси ОY для каждой кривой 
                for (int i = 0; i < GraphCurves.Count; i++)
                {
                    for (int j = 0; j < GraphCurves[i].PointsToDraw.Length; j++)
                    {
                        if (MaxFromEachMass[i] < Math.Abs(GraphCurves[i].PointsToDraw[j].Y))
                        {
                            MaxFromEachMass[i] = Math.Abs(GraphCurves[i].PointsToDraw[j].Y);
                        }
                    }
                }
                //поиск максимального значения среди полученных максимальных значений
                for (int i = 0; i < MaxFromEachMass.Length; i++)
                {
                    if (maxValue < MaxFromEachMass[i]) maxValue = MaxFromEachMass[i];
                }
                Config.NumberOfSepOY = 5;
                while (Center.Y - Config.StepOY * Config.NumberOfSepOY >= pt2.Y)
                {
                    Config.StepOY++;
                }
                Config.PriceForPointOY = Math.Round(maxValue * 0.25, 1);
            }
            else MessageBox.Show("Недостаточно данных для оптимального построения области диагрммы", "Внимание",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
     

        private void DrawAxes()
        {
            g = placeToDraw.CreateGraphics();
            g.Clear(placeToDraw.BackColor);
            //рисует линию сглаженной
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //if (Config.CurrentAxesPos == AxesPosition.FirstQuarter)
            //{
            //    Center = CountBegin;
            //}
            //if (Config.CurrentAxesPos == AxesPosition.AllQuarters)
            //{

            //    CountBegin.X = Center.X - Config.StepOX * Config.NumberOfSepOX;
            //    CountBegin.Y = Center.Y + Config.StepOY * Config.NumberOfSepOY;
            //}

            double HalfAxisOX = 0; //кол-во делений меньше нуля на оси абсцисс
            double HalfAxisOY = 0; //кол-во делений меньше нуля на оси ординат

            //рисует оси
            g.DrawLine(Config.GraphPen, 0, Center.Y, placeToDraw.Width, Center.Y); //ось абсцисс
            g.DrawLine(Config.GraphPen, Center.X, placeToDraw.Height, Center.X, 0); //ось ординат
            g.DrawString("0", Config.drawFont, Config.drawBrush, Center.X - 6, Center.Y);

            float LengthOX = pt3.X - pt2.X;
            float LengthOY = pt1.Y - pt2.Y;

            Config.NumberOfSepOX = (int)Math.Round(LengthOX / Config.StepOX);
            if (Config.NumberOfSepOX % 2 != 0) Config.NumberOfSepOX--;
            Config.NumberOfSepOY = (int)Math.Round(LengthOY / Config.StepOY);
            if (Config.NumberOfSepOY % 2 != 0) Config.NumberOfSepOY--;


            #region Прорисовка делений OX
                Point[] Oxpoints1 = null;
                Point[] Oxpoints2 = null;
                   
            Oxpoints1 = new Point[Config.NumberOfSepOX];
            Oxpoints2 = new Point[Config.NumberOfSepOX];
            HalfAxisOX = Oxpoints1.Length / 2;


            for (int i = 0; i < Oxpoints1.Length; i++)
            {
                if (Config.CurrentAxesPos == AxesPosition.FirstQuarter)
                {

                    string num = Convert.ToString(i * Config.PriceForPointOX + Config.PriceForPointOX);
                    if (i == 0)
                    {
                        Oxpoints1[i].X = CountBegin.X + Config.StepOX;
                        Oxpoints1[i].Y = CountBegin.Y - PointsGraphConfig.HEIGHT;
                        Oxpoints2[i].X = CountBegin.X + Config.StepOX;
                        Oxpoints2[i].Y = CountBegin.Y + PointsGraphConfig.HEIGHT;

                        g.DrawString(num, Config.drawFont, Config.drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);
                    }
                    else
                    {
                        Oxpoints1[i].X = Oxpoints1[i - 1].X + Config.StepOX;
                        Oxpoints1[i].Y = CountBegin.Y - PointsGraphConfig.HEIGHT;

                        Oxpoints2[i].X = Oxpoints2[i - 1].X + Config.StepOX;
                        Oxpoints2[i].Y = CountBegin.Y + PointsGraphConfig.HEIGHT;
                        g.DrawString(num, Config.drawFont, Config.drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);

                    }
                }
                else if (Config.CurrentAxesPos == AxesPosition.AllQuarters)
                {
                    if (i <= HalfAxisOX - 1)
                    {
                        
                        string num = "-" + Convert.ToString((i + 1) * Config.PriceForPointOX);
                        Oxpoints1[i].X = Center.X - (i + 1) * Config.StepOX;
                        Oxpoints1[i].Y = Center.Y - PointsGraphConfig.HEIGHT;

                        Oxpoints2[i].X = Center.X - (i + 1) * Config.StepOX;
                        Oxpoints2[i].Y = Center.Y + PointsGraphConfig.HEIGHT;

                        g.DrawString(num, Config.drawFont, Config.drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);
                    }
                    else if (i > HalfAxisOX - 1)
                    {
                        
                        string num = Convert.ToString((i + 1 - HalfAxisOX) * Config.PriceForPointOX);
                        Oxpoints1[i].X = Center.X + (i + 1 - (int)HalfAxisOX) * Config.StepOX;
                        Oxpoints1[i].Y = Center.Y - PointsGraphConfig.HEIGHT;

                        Oxpoints2[i].X = Center.X + (i + 1 - (int)HalfAxisOX) * Config.StepOX;
                        Oxpoints2[i].Y = Center.Y + PointsGraphConfig.HEIGHT;
                        
                       g.DrawString(num, Config.drawFont, Config.drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);
                        
                   }
                }

                g.DrawLine(Config.GraphPen, Oxpoints1[i], Oxpoints2[i]);
                
                if(Config.Grid == true)
                {
                    PointF StartLine, EndLine;
                    if (Config.CurrentAxesPos == AxesPosition.FirstQuarter)
                    {
                        StartLine = new PointF(Center.X + (i + 1) * Config.StepOX, Center.Y);
                        EndLine = new PointF(Center.X + (i + 1) * Config.StepOX, LastPointOY.Y);
                        g.DrawLine(new Pen (Config.GridColor), StartLine, EndLine);
                    }
                    else if (Config.CurrentAxesPos == AxesPosition.AllQuarters)
                    {
                        if (i <= HalfAxisOX - 1)
                        {
                            StartLine = new PointF(Center.X - (i + 1) * Config.StepOX, placeToDraw.Height);
                            EndLine = new PointF(Center.X - (i + 1) * Config.StepOX, 0);
                            g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                        }
                        else if ( i > HalfAxisOX - 1)
                        {
                            StartLine = new PointF(Center.X + (i + 1 - (int)HalfAxisOX) * Config.StepOX, placeToDraw.Height);
                            EndLine = new PointF(Center.X + (i + 1 - (int)HalfAxisOX) * Config.StepOX, 0);
                            g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                        }
                    }
                }
                
            }
            #endregion
            
            #region Прорисовка делений OY
            Point[] Oypoints1 = null;
            Point[] Oypoints2 = null;

            Oypoints1 = new Point[Config.NumberOfSepOY];
            Oypoints2 = new Point[Config.NumberOfSepOY];

            HalfAxisOY = Oypoints1.Length / 2;

            for (int i = 0; i < Oypoints1.Length; i++)
            {
                if (Config.CurrentAxesPos == AxesPosition.FirstQuarter)
                {
                    string num = Convert.ToString(i * Config.PriceForPointOY + Config.PriceForPointOY);
                    if (i == 0)
                    {
                        Oypoints1[i].X = Center.X - PointsGraphConfig.HEIGHT;
                        Oypoints1[i].Y = Center.Y - Config.StepOY;

                        Oypoints2[i].X = Center.X + PointsGraphConfig.HEIGHT;
                        Oypoints2[i].Y = Center.Y - Config.StepOY;
                        g.DrawString(num, Config.drawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                    }
                    else
                    {
                        Oypoints1[i].X = Center.X - PointsGraphConfig.HEIGHT;
                        Oypoints1[i].Y = Oypoints1[i - 1].Y - Config.StepOY;

                        Oypoints2[i].X = Center.X + PointsGraphConfig.HEIGHT;
                        Oypoints2[i].Y = Oypoints2[i - 1].Y - Config.StepOY;
                        g.DrawString(num, Config.drawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                    }
                }
                else if (Config.CurrentAxesPos == AxesPosition.AllQuarters)
                {
                    if (i <= HalfAxisOY - 1)
                    {
                        string num = "-" + Convert.ToString((i+1) * Config.PriceForPointOY);
                        Oypoints1[i].X = Center.X - PointsGraphConfig.HEIGHT;
                        Oypoints1[i].Y = Center.Y + (i + 1) * Config.StepOY;

                        Oypoints2[i].X = Center.X + PointsGraphConfig.HEIGHT;
                        Oypoints2[i].Y = Center.Y + (i + 1)* Config.StepOY;
                        g.DrawString(num, Config.drawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                    }
                    else if (i > HalfAxisOY - 1)
                    {
                        string num = Convert.ToString((i + 1 - HalfAxisOY) * Config.PriceForPointOY);
                        Oypoints1[i].X = Center.X - PointsGraphConfig.HEIGHT;
                        Oypoints1[i].Y = Center.Y - (i + 1 - (int)HalfAxisOY) * Config.StepOY;

                        Oypoints2[i].X = Center.X + PointsGraphConfig.HEIGHT;
                        Oypoints2[i].Y = Center.Y - (i + 1 - (int)HalfAxisOY) * Config.StepOY;

                        g.DrawString(num, Config.drawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                    }
                }

                g.DrawLine(Config.GraphPen, Oypoints1[i], Oypoints2[i]);

                if (Config.Grid == true)
                {
                    PointF StartLine, EndLine;
                    if (Config.CurrentAxesPos == AxesPosition.FirstQuarter)
                    {
                        StartLine = new PointF(Center.X, Center.Y - (i + 1) * Config.StepOY);
                        EndLine = new PointF(LastPointOX.X, Center.Y - (i + 1) * Config.StepOY);
                        g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                    }
                    else if (Config.CurrentAxesPos == AxesPosition.AllQuarters)
                    {
                        if (i <= HalfAxisOY - 1)
                        {
                            StartLine = new PointF(0, Center.Y + (i + 1) * Config.StepOY);
                            EndLine = new PointF(placeToDraw.Width, Center.Y + (i + 1) * Config.StepOY);
                            g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                        }
                        else if (i > HalfAxisOY - 1)
                        {
                            StartLine = new PointF(0, Center.Y - (i + 1 - (int)HalfAxisOY) * Config.StepOY);
                            EndLine = new PointF(placeToDraw.Width, Center.Y - (i + 1 - (int)HalfAxisOY) * Config.StepOY);
                            g.DrawLine(new Pen(Config.GridColor), StartLine, EndLine);
                        }
                    }
                }

            }
            #endregion 
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

        private void DrawDiagramLegend()
        {
            int lineLength = 15;
            PointF StartPoint = new PointF(LastPointOX.X + 10, LastPointOX.Y / 2);
            PointF EndPoint = new PointF(StartPoint.X + lineLength, StartPoint.Y);
            foreach(Curves crrCurve in GraphCurves)
            {
                g.DrawLine(new Pen(crrCurve.CurveColor, 2), StartPoint, EndPoint);
                string str = " - " + crrCurve.Legend;
                g.DrawString(str, new Font("Arial", 7), new SolidBrush(Color.Black), EndPoint.X, EndPoint.Y - 7);

                StartPoint.Y += 25;
                EndPoint.Y += 25;
            }
        }

        private void DrawCurrentCurve(Curves currentCurve)
        {
            Pen grafpen = new Pen(currentCurve.CurveColor, currentCurve.CurveThickness);
            PointF[] points = new PointF[currentCurve.PointsToDraw.Length];
            for (int i = 0; i < currentCurve.PointsToDraw.Length; i++)
            {

                float x = (float)(Center.X + currentCurve.PointsToDraw[i].X * Config.StepOX / Config.PriceForPointOX);
                float y = (float)(Center.Y - currentCurve.PointsToDraw[i].Y * Config.StepOY / Config.PriceForPointOY);
                
                points[i].X = x;
                points[i].Y = y;
            }
            
            if(Config.SmoothAngles == true) g.DrawCurve(grafpen, points);
            else if(Config.SmoothAngles == false) g.DrawLines(grafpen, points);

            if(Config.DrawPoints == true)
            {
                int r = 4;
                foreach(PointF pt in points)
                {
                    g.FillEllipse(new SolidBrush(currentCurve.CurveColor), pt.X - r / 2, pt.Y - r / 2, r, r);
                }
            }

        }
        /// <summary>
        /// Рисует: график, с добавленными кривыми, названия осей и диаграммы, легенду. 
        /// </summary>
        public override void DrawDiagram()
        {
            if (GraphCurves.Count != 0)
            {
                DrawAxes();
                
                if (Config.OXName != "" || Config.OYName != "")
                {
                    if (Config.SizeOX == 0) Config.SizeOX = 9;
                    if (Config.SizeOY == 0) Config.SizeOY = 9;
                    DrawAxesNames();
                }

                if (Title != "")
                {
                    if (TitleSize == 0) TitleSize = 10;
                    DrawTitle();
                }


                if (AddDiagramLegend == true)
                {
                    DrawDiagramLegend();
                }

                foreach (Curves crrCurve in GraphCurves)
                {
                    DrawCurrentCurve(crrCurve);
                }

            }
            else MessageBox.Show("Отсутствуют кривые для рисования.", "Внимание",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Добавляет кривую в коллекцию для построения.
        /// </summary>
        /// <param name="curve"></param>
        public void AddCurve(Curves curve)
        {
            bool Exist = false; // есть ли уже кривая с таким же массивом точек
            foreach(Curves cr in GraphCurves)
            {
                if (cr.PointsToDraw == curve.PointsToDraw || cr.Legend == curve.Legend)
                {
                    Exist = true;
                    break;
                }

            }
            
            if (Exist) MessageBox.Show("Добавляемая кривая: \"" + curve.Legend + "\" уже содержится в коллекции.", "Попытка добавления кривой",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            else
            {
                GraphCurves.Add(curve);
            }
        }
    }
    /// <summary>
    /// Представляет структуру для инициализации кривой.
    /// </summary>
    public struct Curves
    {
        /// <summary>
        /// Массив точек кривой.
        /// </summary>
        public PointF[] PointsToDraw { get; set; } 
        /// <summary>
        /// Толщина линии кривой.
        /// </summary>
        public int CurveThickness { get; set; } 
        /// <summary>
        /// Устанавливает цвет кривой графика.
        /// </summary>
        public Color CurveColor { get; set; }
        /// <summary>
        /// Легенда кривой.
        /// </summary>
        public string Legend { get; set; } 

        public Curves(PointF[] pt, Color CurveColor, int CurveThickness = 1, string Legend = "Пусто") 
        {
            PointsToDraw = pt;
            this.CurveColor = CurveColor;
            this.CurveThickness = CurveThickness;
            this.Legend = Legend;
        }
    }


    
}
