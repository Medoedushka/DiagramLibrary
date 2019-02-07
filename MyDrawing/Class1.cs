using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyDrawing
{

    public struct Config
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
        /// Перечисление возможных выравниваний названия графика.
        /// </summary>
        public TextPosition TitlePosition { get; set; }
        /// <summary>
        /// Перечисление возможных выравниваний оси абсцисс.
        /// </summary>
        public TextPosition OXNamePosition { get; set; }
        /// <summary>
        /// Перечисление возможных выравниваний оси ординат
        /// </summary>
        public TextPosition OYNamePosition { get; set; }
        /// <summary>
        /// Добавление сетки на график.
        /// </summary>
        public bool Grid { get; set; }

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
                else throw new ArgumentOutOfRangeException();
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
                else throw new ArgumentOutOfRangeException();
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
                else throw new ArgumentOutOfRangeException();
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

                else throw new ArgumentOutOfRangeException();
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
                else throw new ArgumentOutOfRangeException();
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
                else throw new ArgumentOutOfRangeException();
            }
        }
        
        #endregion;
    }

    public enum TextPosition
    {
        Left,
        Centre,
        Right
    }

    public abstract class Diagram
    {
        protected Graphics g;
        
        protected PictureBox placeToDraw; //область для рисования диаграмм
        public string Title { get; set; } //описание диаграммы
        
        public bool AddDiagramLegend { get; set; } //добавить ли легенду диаграммы
        public Point Center; // точка пересечения осей(график, гистограмма), центр окружности(круговая диаграмма)
        
        //точки рамки построение графика
        protected Point pt1; //левая нижняя точка
        protected Point pt2; //левая верхняя точка
        protected Point pt3; //правая нижняя точка
        protected Point pt4; //правая верхняя точка
        public PointF LastPointOX; //последняя точка на оси OX, определяющая рамку
        public PointF LastPointOY; //последняя точка на оси OY, определяющая рамку 

        protected int Space_From_Top { get; set; }     //
        protected int Space_From_Right { get; set; }   //параметры отступа границ рамки 
        protected int Space_From_Bottom { get; set; }  //от границ pictureBox
        protected int Space_From_Left { get; set; }    // 

        
        

        //public abstract void DrawGraphic(int thickness); //рисует диаграмму внутри рамке построения
        /// <summary>
        /// Добавляет указанный график в список графиков легенды
        /// </summary>
        /// <param name="diagram">объект добавляемого графика</param>
        /// <param name="legend">пояснение к графику кривой</param>
        //public static void SetLegend(Diagram diagram, string legend = "Пусто")
        //{
        //    CreatedGraphics.Add(diagram);
        //    diagram.Legend = legend;
        //}
        
    }

    /// <summary>
    /// Предоставляет свойства и методы для рисования графика на элементе управления pictureBox.
    /// </summary>
    public class PointsGraphic : Diagram
    {
        // PointF[] pointsToDraw; //массив точек, по которым будет строится график
        public Config Config;//структура, содержащая настройки осей и рамки для построения графика
        public List<Curves> GraphCurves = new List<Curves>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture">область для рисования графика</param>
        public PointsGraphic(PictureBox picture)
        {
            placeToDraw = picture;
            Config.GraphColor = Color.FromArgb(120, 120, 120);
            Config.GraphPen = new Pen(Config.GraphColor);
            Config.drawFont = new Font("Arial", 8);
            Config.drawBrush = new SolidBrush(Config.GraphColor);
            //параметры задают максимальные размеры рамки для рисования графика
            Space_From_Top = 35;
            Space_From_Right = 25;
            Space_From_Bottom = 35;
            Space_From_Left = 35;

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
        /// Устанавливает параметры Ox по умолчанию.
        /// </summary>
        public void SetDefaultOX()
        {
            
            if (GraphCurves.Count != 0)
            {
                double[] MaxFromEachMass = new double[GraphCurves.Count];
                double maxValue = 0; //максимальное значение среди массивов точек для каждой кривой
                //поиск максимального значения оси ОХ для каждой кривой 
                for (int i = 0; i< GraphCurves.Count; i++)
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
                Config.PriceForPointOX = Math.Round(maxValue * 0.25);

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
                //поиск максимального значения оси ОХ для каждой кривой 
                for (int i = 0; i < GraphCurves.Count; i++)
                {
                    for (int j = 0; j < GraphCurves[i].PointsToDraw.Length; j++)
                    {
                        if (MaxFromEachMass[i] < GraphCurves[i].PointsToDraw[j].Y)
                        {
                            MaxFromEachMass[i] = GraphCurves[i].PointsToDraw[j].Y;
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
                Config.PriceForPointOY = Math.Round(maxValue * 0.25);
            }
            else MessageBox.Show("Недостаточно данных для оптимального построения области диагрммы", "Внимание",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
       
        //рисует оси координат
        private void DrawAxes()
        {

            SetDefaultOX();
            SetDefaultOY();

            g = placeToDraw.CreateGraphics();
            g.Clear(Color.White);
            //рисует линию сглаженной
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //рисует оси
            
            LastPointOX = new PointF(Center.X + Config.StepOX * Config.NumberOfSepOX, Center.Y);
            LastPointOY = new PointF(Center.X, Center.Y - Config.StepOY * Config.NumberOfSepOY);

            g.DrawLine(Config.GraphPen, Center, LastPointOX);//ось ординат
            g.DrawLine(Config.GraphPen, Center, LastPointOY);//ось абсцисс
            g.DrawString("0", Config.drawFont, Config.drawBrush, Center.X - 6, Center.Y);


            //прорисовка делений оси Ох
            Point[] Oxpoints1 = new Point[Config.NumberOfSepOX];
            Point[] Oxpoints2 = new Point[Config.NumberOfSepOX];

            for (int i = 0; i < Oxpoints1.Length; i++)
            {
                string num = Convert.ToString(i * Config.PriceForPointOX + Config.PriceForPointOX);
                if (i == 0)
                {
                    Oxpoints1[i].X = Center.X + Config.StepOX;
                    Oxpoints1[i].Y = Center.Y - Config.HEIGHT;
                    Oxpoints2[i].X = Center.X + Config.StepOX;
                    Oxpoints2[i].Y = Center.Y + Config.HEIGHT;

                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);
                }
                else
                {
                    Oxpoints1[i].X = Oxpoints1[i - 1].X + Config.StepOX;
                    Oxpoints1[i].Y = Center.Y - Config.HEIGHT;

                    Oxpoints2[i].X = Oxpoints2[i - 1].X + Config.StepOX;
                    Oxpoints2[i].Y = Center.Y + Config.HEIGHT;
                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);

                   

                }
                g.DrawLine(Config.GraphPen, Oxpoints1[i], Oxpoints2[i]);
                if(Config.Grid == true)
                {
                    PointF StartLine, EndLine;
                    StartLine = new PointF(Center.X + (i * Config.StepOX + Config.StepOX), Center.Y);
                    EndLine = new PointF(Center.X + (i * Config.StepOX + Config.StepOX), LastPointOY.Y);
                    g.DrawLine(Config.GraphPen, StartLine, EndLine);
                }
                
            }
            //прорисовка делений оси Оу
            Point[] Oypoints1 = new Point[Config.NumberOfSepOY];
            Point[] Oypoints2 = new Point[Config.NumberOfSepOY];

            for (int i = 0; i < Oypoints1.Length; i++)
            {
                string num = Convert.ToString(i * Config.PriceForPointOY + Config.PriceForPointOY);
                if (i == 0)
                {
                    Oypoints1[i].X = Center.X - Config.HEIGHT;
                    Oypoints1[i].Y = Center.Y - Config.StepOY;

                    Oypoints2[i].X = Center.X + Config.HEIGHT;
                    Oypoints2[i].Y = Center.Y - Config.StepOY;
                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                }
                else
                {
                    Oypoints1[i].X = Center.X - Config.HEIGHT;
                    Oypoints1[i].Y = Oypoints1[i - 1].Y - Config.StepOY;

                    Oypoints2[i].X = Center.X + Config.HEIGHT;
                    Oypoints2[i].Y = Oypoints2[i - 1].Y - Config.StepOY;
                    g.DrawString(num, Config.drawFont, Config.drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                }
                g.DrawLine(Config.GraphPen, Oypoints1[i], Oypoints2[i]);
                if(Config.Grid == true)
                {
                    PointF StartLine, EndLine;
                    StartLine = new PointF(Center.X, Center.Y - i * Config.StepOY - Config.StepOY);
                    EndLine = new PointF(LastPointOX.X, Center.Y - i * Config.StepOY - Config.StepOY);
                    g.DrawLine(Config.GraphPen, StartLine, EndLine);
                }
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
            Font font = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.Black);
            SizeF size = g.MeasureString(Title, font);

            float x = 0, y = 0;
            if (Config.TitlePosition == TextPosition.Left)
            {
                x = LastPointOY.X; y = LastPointOY.Y - 20;
            }
            else if (Config.TitlePosition == TextPosition.Centre)
            {
                x = LastPointOY.X + (LastPointOX.X - LastPointOY.X) / 2 - size.Width / 2;
                y = LastPointOY.Y - 20;
            }
            else if (Config.TitlePosition == TextPosition.Right)
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

        private void DrawCurrentCurve(Curves currentCurve)
        {
            int pointExist = 0; //содержит кол-во точек с ненулевыми координатами на пикчербоксе
            Pen grafpen = new Pen(currentCurve.CurveColor, currentCurve.CurveThickness);
            PointF[] points = new PointF[currentCurve.PointsToDraw.Length];
            for (int i = 0; i < currentCurve.PointsToDraw.Length; i++)
            {

                float x = (float)(Center.X + currentCurve.PointsToDraw[i].X * Config.StepOX / Config.PriceForPointOX);
                float y = (float)(Center.Y - currentCurve.PointsToDraw[i].Y * Config.StepOY / Config.PriceForPointOY);
                if (x <= LastPointOX.X && y >= LastPointOY.Y) //если координаты точки находятся внутри рамки 
                {
                    points[i].X = x;
                    points[i].Y = y;
                    pointExist++;
                }
                else break;
            }
            PointF[] drawpt = new PointF[pointExist]; //массив, содержащий точки с ненулевыми координатами

            for (int i = 0; i < pointExist; i++)
            {
                if (points[i].X != 0 && points[i].Y != 0)
                {
                    drawpt[i].X = points[i].X;
                    drawpt[i].Y = points[i].Y;
                }
            }
            g.DrawCurve(grafpen, drawpt);
        }

        public void DrawCurves()
        {
            if (GraphCurves.Count != 0)
            {
                DrawAxes();
                if ((Config.OXName != "" && Config.SizeOX != 0) || (Config.OYName != "" && Config.SizeOY != 0))
                {
                    DrawAxesNames();
                }
                else MessageBox.Show("При указании названия осей необходимо также указать размер шрифта хотя бы одного названия.\n" +
                     "(SizeOX, SizeOY)", "Попытка добавить название осей.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if(Title != "")
                {
                    DrawTitle();
                }

                foreach (Curves crrCurve in GraphCurves)
                {
                    DrawCurrentCurve(crrCurve);
                }

            }
            else MessageBox.Show("Отсутствуют кривые для рисования.", "Внимание",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
     
        //public void DrawDiagramLegend()
        //{

        //    PointF StartPoint = new PointF();
        //    StartPoint.X = LastPointOX.X + 15;
        //    StartPoint.Y = LastPointOY.Y + 150;
        //    int lineLengh = 15;
        //    PointF EndPoint = new PointF(StartPoint.X + lineLengh, StartPoint.Y);

        //    for (int i = 0; i < CreatedGraphics.Count; i++)
        //    {
        //        g.DrawLine(new Pen(CreatedGraphics[i].CurveColor,2), StartPoint, EndPoint);
        //        string str = "-" + CreatedGraphics[i].Legend;
        //        g.DrawString(str, new Font("Arial", 8), new SolidBrush(Color.Black), EndPoint.X + 3, EndPoint.Y - 8);

        //        StartPoint.Y += 25;
        //        EndPoint.Y += 25;
        //    }

        //}
    }

    public class Curves
    {
        public PointF[] PointsToDraw { get; set; } //массив точек, по которым будет строится график
        public int CurveThickness { get; set; } //толщина кривой графика
        /// <summary>
        /// Устанавливает цвет кривой графика.
        /// </summary>
        public Color CurveColor { get; set; }
        public string Legend { get; set; } //легенда кривой

        public Curves(PointF[] pt, Color CurveColor, int CurveThickness = 1, string Legend = "Пусто") 
        {
            PointsToDraw = pt;
            this.CurveColor = CurveColor;
            this.CurveThickness = CurveThickness;
            this.Legend = Legend;
        }
    }


    
}
