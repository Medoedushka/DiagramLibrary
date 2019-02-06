using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyDrawing
{

    struct Config
    {

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
        public string Legend { get; set; } //легенда графика
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

        //список всех созданных графиков
        public static List<Diagram> CreatedGraphics = new List<Diagram>();
        /// <summary>
        /// Устанавливает цвет кривой графика.
        /// </summary>
        public Color CurveColor { get; set; }

        public abstract void DrawGraphic(int thickness); //рисует диаграмму внутри рамке построения
        /// <summary>
        /// Добавляет указанный график в список графиков легенды
        /// </summary>
        /// <param name="diagram">объект добавляемого графика</param>
        /// <param name="legend">пояснение к графику кривой</param>
        public static void SetLegend(Diagram diagram, string legend = "Пусто")
        {
            CreatedGraphics.Add(diagram);
            diagram.Legend = legend;
        }
        
    }

    /// <summary>
    /// Предоставляет свойства и методы для рисования графика на элементе управления pictureBox.
    /// </summary>
    public class PointsGraphic : Diagram
    {
        PointF[] pointsToDraw; //массив точек, по которым будет строится график
        int stepOX;       //расстояние между делениями оси абсцисс
        int stepOY;       //расстояние между делениями оси ординат  
        int numberOfSepOx;//кол-во делений на оси Ох
        int numberOfSepOy;//кол-во делений на оси Оу
        const int HEIGHT = 4;  //длинна одного деления

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
        public bool Grid{ get; set; }
        
        double sizeOx, sizeOy; //размер шрифтов названия осей;
        double priceForPointOX; //цена деления на оси Ох 
        double priceForPointOY; //цена деления на оси Оу

        Color GraphColor; //
        Pen GraphPen;     //цвет для графика
                          //
        
        int CurveThickness { get; set; } //толщина кривой графика
        Font drawFont = new Font("Arial", 6);//параметры текста
        SolidBrush drawBrush = new SolidBrush(Color.Black);//цвет заливки

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
        //массив точек для рисования графика
        /// <summary>
        /// Свойство содержит массив точек для построения графика.
        /// </summary>
        public PointF[] PointsToDraw
        {
            get { return pointsToDraw; }
            set
            {
                if (value != null) pointsToDraw = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        #endregion;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture">название элемента управления pictureBox, на котором будет произведено построение</param>
        /// <param name="DrawPoints">массив точек, по которым будет построен график.</param>
        public PointsGraphic(PictureBox picture, PointF[] DrawPoints)
        {
            GraphColor = Color.FromArgb(120, 120, 120);
            GraphPen = new Pen(GraphColor, 1);
            placeToDraw = picture;
            PointsToDraw = DrawPoints;

            Space_From_Top = 35;
            Space_From_Right = 25;
            Space_From_Bottom = 35;
            Space_From_Left = 35;

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


            SetNormalOX();
            SetNormalOY();

        }
        
            
        //устанавливает параметры Ox по умолчанию
        /// <summary>
        /// Устанавливает параметры Ox по умолчанию.
        /// </summary>
        public void SetNormalOX()

        {
            //поиск максимального значения X
            double maxX = 0;

            for (int i = 0; i < pointsToDraw.Length; i++)
            {
                if (pointsToDraw[i].X > maxX) maxX = pointsToDraw[i].X;
            }

            NumberOfSepOX = 5;
            while(Center.X + NumberOfSepOX*StepOX <= pt3.X)
            {
                stepOX++;
            }
            priceForPointOX = Math.Round(maxX * 0.25);
        }
        //устанавливает параметры Oy по умолчанию
        /// <summary>
        /// Устанавливает параметры Oy по умолчанию.
        /// </summary>
        public void SetNormalOY()
        {
            //поиск максимального значения Y
            double maxY = 0;
            for (int i = 0; i < pointsToDraw.Length; i++)
            {
                if (pointsToDraw[i].X > maxY) maxY = pointsToDraw[i].Y;
            }

            NumberOfSepOY = 5;
            while(Center.Y - StepOY*NumberOfSepOY >= pt2.Y)
            {
                StepOY++;
            }
            
            priceForPointOY = Math.Round(maxY * 0.25);
        }

        //рисует оси координат
        private void DrawAxes()
        {
            g = placeToDraw.CreateGraphics();
            g.Clear(Color.White);
            //рисует линию сглаженной
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //рисует оси
            

            LastPointOX = new PointF(Center.X + StepOX * NumberOfSepOX, Center.Y);
            LastPointOY = new PointF(Center.X, Center.Y - StepOY * NumberOfSepOY);

            g.DrawLine(GraphPen, Center, LastPointOX);//ось ординат
            g.DrawLine(GraphPen, Center, LastPointOY);//ось абсцисс
            g.DrawString("0", drawFont, drawBrush, Center.X - 6, Center.Y);


            //прорисовка делений оси Ох
            Point[] Oxpoints1 = new Point[NumberOfSepOX];
            Point[] Oxpoints2 = new Point[NumberOfSepOX];

            for (int i = 0; i < Oxpoints1.Length; i++)
            {
                string num = Convert.ToString(i * PriceForPointOX + PriceForPointOX);
                if (i == 0)
                {
                    Oxpoints1[i].X = Center.X + StepOX;
                    Oxpoints1[i].Y = Center.Y - HEIGHT;
                    Oxpoints2[i].X = Center.X + StepOX;
                    Oxpoints2[i].Y = Center.Y + HEIGHT;

                    g.DrawString(num, drawFont, drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);
                }
                else
                {
                    Oxpoints1[i].X = Oxpoints1[i - 1].X + StepOX;
                    Oxpoints1[i].Y = Center.Y - HEIGHT;

                    Oxpoints2[i].X = Oxpoints2[i - 1].X + StepOX;
                    Oxpoints2[i].Y = Center.Y + HEIGHT;
                    g.DrawString(num, drawFont, drawBrush, Oxpoints2[i].X - 3, Oxpoints2[i].Y);

                    
                   // MessageBox.Show("meow");

                }
                g.DrawLine(GraphPen, Oxpoints1[i], Oxpoints2[i]);
                if(Grid == true)
                {
                    PointF StartLine, EndLine;
                    StartLine = new PointF(Center.X + (i * StepOX + StepOX), Center.Y);
                    EndLine = new PointF(Center.X + (i * StepOX + StepOX), LastPointOY.Y);
                    g.DrawLine(GraphPen, StartLine, EndLine);
                }
                
            }
            //прорисовка делений оси Оу
            Point[] Oypoints1 = new Point[NumberOfSepOY];
            Point[] Oypoints2 = new Point[NumberOfSepOY];

            for (int i = 0; i < Oypoints1.Length; i++)
            {
                string num = Convert.ToString(i * PriceForPointOY + PriceForPointOY);
                if (i == 0)
                {
                    Oypoints1[i].X = Center.X - HEIGHT;
                    Oypoints1[i].Y = Center.Y - StepOY;

                    Oypoints2[i].X = Center.X + HEIGHT;
                    Oypoints2[i].Y = Center.Y - StepOY;
                    g.DrawString(num, drawFont, drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                }
                else
                {
                    Oypoints1[i].X = Center.X - HEIGHT;
                    Oypoints1[i].Y = Oypoints1[i - 1].Y - StepOY;

                    Oypoints2[i].X = Center.X + HEIGHT;
                    Oypoints2[i].Y = Oypoints2[i - 1].Y - StepOY;
                    g.DrawString(num, drawFont, drawBrush, Oypoints1[i].X - 10, Oypoints1[i].Y);
                }
                g.DrawLine(GraphPen, Oypoints1[i], Oypoints2[i]);
                if(Grid == true)
                {
                    PointF StartLine, EndLine;
                    StartLine = new PointF(Center.X, Center.Y - i * StepOY - StepOY);
                    EndLine = new PointF(LastPointOX.X, Center.Y - i * StepOY - StepOY);
                    g.DrawLine(GraphPen, StartLine, EndLine);
                }
            }

        }

        //рисует указанный график
        /// <summary>
        /// Производит построение осей, графика и если указаны названия графика и осей.
        /// </summary>
        /// <param name="thickness">толщина кривой графика.</param>
        public override void DrawGraphic(int thickness)
        {
            
            DrawAxes();
            
            int pointExist = 0; //содержит кол-во точек с ненулевыми координатами на пикчербоксе
            Pen grafpen = new Pen(CurveColor, thickness);
            PointF[] points = new PointF[PointsToDraw.Length];
            for (int i = 0; i < pointsToDraw.Length; i++)
            {

                float x = (float)(Center.X + PointsToDraw[i].X * stepOX / priceForPointOX);
                float y = (float)(Center.Y - PointsToDraw[i].Y * stepOY / priceForPointOY);
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


            //рисование названия осей
            if ( (OXName != "" && SizeOX != 0) || (OYName != "" && SizeOY != 0) )
            {
                if (SizeOX == 0) SizeOX = 9;
                if (SizeOY == 0) SizeOY = 9;

                Font fontOX = new Font("Arial", (float)SizeOX);
                Font fontOY = new Font("Arial", (float)SizeOY);
                SolidBrush brush = new SolidBrush(Color.Black);
                StringFormat stringFormat = new StringFormat();
                stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                #region Координаты для строки названия оси Ох.
                SizeF size = g.MeasureString(OXName, fontOX);
                PointF pointOX = new PointF();
                if (OXNamePosition == TextPosition.Centre)
                {
                    pointOX.X = LastPointOY.X + (LastPointOX.X - LastPointOY.X) / 2 - size.Width / 2;
                    pointOX.Y = Center.Y + 15;
                }
                else if (OXNamePosition == TextPosition.Left)
                {
                    pointOX.X = Center.X;
                    pointOX.Y = Center.Y + 15;
                }
                else if (OXNamePosition == TextPosition.Right)
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
                size = g.MeasureString(OYName, fontOY);
                PointF pointOY = new PointF();
                if (OYNamePosition == TextPosition.Centre)
                {
                    pointOY.X = Center.X - 30;
                    pointOY.Y = Center.Y - (Center.Y - LastPointOY.Y) / 2 - size.Width / 2;
                }
                if (OYNamePosition == TextPosition.Left)
                {
                    pointOY.X = Center.X - 30;
                    pointOY.Y = LastPointOY.Y;
                }
                if (OYNamePosition == TextPosition.Right)
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
                g.DrawString(OXName, fontOX, brush, pointOX);
                //рисование названия Oy
                g.DrawString(OYName, fontOY, brush, pointOY, stringFormat);
            }

            //рисования названия графика
            if (Title != "")
            {
                Font font = new Font("Arial", 12);
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
        }

        public void DrawDiagramLegend()
        {

            PointF StartPoint = new PointF();
            StartPoint.X = LastPointOX.X + 15;
            StartPoint.Y = LastPointOY.Y + 150;
            int lineLengh = 15;
            PointF EndPoint = new PointF(StartPoint.X + lineLengh, StartPoint.Y);

            for (int i = 0; i < CreatedGraphics.Count; i++)
            {
                g.DrawLine(new Pen(CreatedGraphics[i].CurveColor,2), StartPoint, EndPoint);
                string str = "-" + CreatedGraphics[i].Legend;
                g.DrawString(str, new Font("Arial", 8), new SolidBrush(Color.Black), EndPoint.X + 3, EndPoint.Y - 8);

                StartPoint.Y += 25;
                EndPoint.Y += 25;
            }

        }
    }

    public class SecondaryPointsGraphic : Diagram
    {
        
        /// <summary>
        /// Свойство содержит массив точек для построения графика.
        /// </summary>
        public PointF[] PointsToDraw
        {
            get { return pointsToDraw; }
            set
            {
                if (value != null) pointsToDraw = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        PointF[] pointsToDraw; //массив точек, по которым будет строится график
        Pen GraphPen;     //цвет для графика
        PointsGraphic BaseGraph; //базовый график диаграммы, относительно параметров которого, 
                                 //строятся вторичные графики


        
        public SecondaryPointsGraphic(PictureBox picture, PointF[] points, PointsGraphic g1)
        { 
            placeToDraw = picture;
            PointsToDraw = points;
            CurveColor = Color.Black;
            BaseGraph = g1;
            g = placeToDraw.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
        }

        /// <summary>
        /// Производит построение осей, графика и если указаны названия графика и осей.
        /// </summary>
        /// <param name="thickness">толщина кривой графика.</param>
        public override void DrawGraphic(int thickness = 1)
        {

            int pointExist = 0; //содержит кол-во точек с ненулевыми координатами на пикчербоксе
            Pen grafpen = new Pen(CurveColor, thickness);

            PointF[] points = new PointF[PointsToDraw.Length];
            for (int i = 0; i < pointsToDraw.Length; i++)
            {

                float x = (float)(BaseGraph.Center.X + PointsToDraw[i].X * BaseGraph.StepOX / BaseGraph.PriceForPointOX);
                float y = (float)(BaseGraph.Center.Y - PointsToDraw[i].Y * BaseGraph.StepOY / BaseGraph.PriceForPointOY);
                if (x <= BaseGraph.LastPointOX.X && y >= BaseGraph.LastPointOY.Y) //если координаты точки находятся внутри рамки 
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
    }

    
}
