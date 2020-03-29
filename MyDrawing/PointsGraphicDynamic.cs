using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyDrawing
{

    /// <summary>
    /// Содержит свойства для настройки графика.
    /// </summary>
    public class PointsGraphConfig
    {
        int stepOX;       //расстояние между делениями оси абсцисс
        int stepOY;       //расстояние между делениями оси ординат  
        int numberOfSepOx;//кол-во делений на оси Ох
        int numberOfSepOy;//кол-во делений на оси Оу
        public const int HEIGHT = 6;  //длинна основного деления
        public const int subHEIGHT = 4; //длина промежуточного деления

        double sizeOx, sizeOy; //размер шрифтов названия осей;
        double priceForPointOX; //цена деления на оси Ох 
        double priceForPointOY; //цена деления на оси Оу


        public Color GraphColor; //
        public Pen GraphPen;     //цвет для графика
                                 //
        
        public Color GridColor { get; set; }
        public Font DrawFont { get; set; } // парметры шрифта текста на области построения
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
        /// Добавление сетки на график.
        /// </summary>
        public bool Grid { get; set; }
        /// <summary>
        /// Сглаживание углов кривой.
        /// </summary>
        public bool SmoothAngles { get; set; }
        /// <summary>
        /// Явная отрисовка точек кривой.
        /// </summary>
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
        public double OXNameSize
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
        public double OYNameSize
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
    public partial class PointsGraphic : Diagram
    {
        /// <summary>
        /// Содержит свойства для настройки графика.
        /// </summary>
        public PointsGraphConfig Config { get; set; }//структура, содержащая настройки осей и рамки для построения графика
        /// <summary>
        /// Список созданных кривых для построения.
        /// </summary>
        public List<Curves> GraphCurves { get; set; }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture">область для рисования графика</param>
        /// <param name="axesPos">количесвто отображаемых четвертей</param>
        public PointsGraphic(PictureBox picture)
        {
            placeToDraw = picture;
            GraphCurves = new List<Curves>();
            Config = new PointsGraphConfig();
            Config.GraphColor = Color.Black;
            Config.GridColor = Color.FromArgb(213, 209, 200);
            Config.GraphPen = new Pen(Config.GraphColor);
            Config.DrawFont = new Font("Arial", 6);
            Config.drawBrush = new SolidBrush(Config.GraphColor);
            Config.DrawPoints = false;
            g = placeToDraw.CreateGraphics();
            
            //координаты угловых точек рамки
            SetPlaceToDrawSize(placeToDraw.Width, placeToDraw.Height);
            Config.StepOX = 30;
            Config.StepOY = 30;
            Config.PriceForPointOX = 1;
            Config.PriceForPointOY = 1;
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
                    for (int j = 0; j < GraphCurves[i].PointsToDraw.Length; j++)
                    {
                        if (MaxFromEachMass[i] < Math.Abs(GraphCurves[i].PointsToDraw[j].X))
                        {
                            MaxFromEachMass[i] = Math.Abs(GraphCurves[i].PointsToDraw[j].X);
                        }
                    }
                }
                //поиск максимального значения среди полученных максимальных значений
                for (int i = 0; i < MaxFromEachMass.Length; i++)
                {
                    if (maxValue < MaxFromEachMass[i]) maxValue = MaxFromEachMass[i];
                }

                Config.NumberOfSepOX = 5;
                while (RealCenter.X + Config.NumberOfSepOX * Config.StepOX < pt3.X)
                {
                    Config.StepOX++;
                }
                Config.PriceForPointOX = Math.Round(maxValue * 0.35, 1);

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
                while (RealCenter.Y - Config.StepOY * Config.NumberOfSepOY > pt2.Y)
                {
                    Config.StepOY++;
                }
                Config.PriceForPointOY = Math.Round(maxValue * 0.35, 1);
            }
            else MessageBox.Show("Недостаточно данных для оптимального построения области диагрммы", "Внимание",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        /// <summary>
        /// Рассчёт координат центра в зависимости от размеров пикчербокса.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetPlaceToDrawSize(int width, int height, bool defCenter = true)
        {
            int n = 30, m = 15;
            Space_From_Left = 25 + n;
            Space_From_Bottom = 25 + m;
            //левая нижняя точка
            pt1 = new Point(Space_From_Left, height - Space_From_Bottom);
            //левая верхняя точка
            pt2 = new Point(Space_From_Left, Space_From_Top);
            //правая верхняя точка
            pt3 = new Point(width - Space_From_Right, Space_From_Top);
            //правая нижняя точка
            pt4 = new Point(width - Space_From_Right, height - Space_From_Bottom);

            if (defCenter)
            {
                int X = pt2.X + (pt3.X - pt2.X) / 2;
                int Y = pt1.Y - (pt1.Y - pt2.Y) / 2;
                RealCenter = new Point(X, Y);
            }
            
        }
        /// <summary>
        /// Рисует: график, с добавленными кривыми, названия осей и диаграммы, легенду. 
        /// </summary>
        /// 
        public override void DrawDiagram()
        {
           
            Bitmap bm = new Bitmap(placeToDraw.Width, placeToDraw.Height);
            using (g = Graphics.FromImage(bm))
            {
                g.Clear(placeToDraw.BackColor);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                DrawAxes(true);
                foreach (Curves curve in GraphCurves)
                {
                    StaticDrawCurrentCurve(curve);
                }

                if (Title != "")
                {
                    if (TitleSize == 0)
                        TitleSize = 10;
                    DrawTitle();

                }

                if (Config.OXName != "" || Config.OYName != "")
                {
                    if (Config.OXNameSize == 0) Config.OXNameSize = 10;
                    if (Config.OYNameSize == 0) Config.OYNameSize = 10;
                    //Space_From_Bottom = 45;
                    //Space_From_Left = 45;
                    SetPlaceToDrawSize(placeToDraw.Width, placeToDraw.Height, false);

                    DrawAxesNames();
                }
                else
                {
                    Space_From_Bottom = 25;
                    Space_From_Left = 25;
                    SetPlaceToDrawSize(placeToDraw.Width, placeToDraw.Height);
                }

                if (AddDiagramLegend == true)
                {
                    DrawDiagramLegend();
                }
            }
                    placeToDraw.Image = bm;
        }

        /// <summary>
        /// Добавляет кривую в коллекцию для построения.
        /// </summary>
        /// <param name="curve"></param>
        public void AddCurve(Curves curve)
        {
            bool Exist = false; // есть ли уже кривая с таким же массивом точек
            foreach (Curves cr in GraphCurves)
            {
                if (cr.PointsToDraw == curve.PointsToDraw || (cr.Legend == curve.Legend && curve.Legend != "Пусто"))
                {
                    Exist = true;
                    break;
                }

            }

            if (Exist) throw new ArgumentException("Добавляемая кривая: \"" + curve.Legend + "\" уже содержится в коллекции.",
                "Попытка добавления кривой");
            else GraphCurves.Add(curve);

            SetDefaultOX();
            SetDefaultOY();
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
        /// <summary>
        /// Строка, характеризующая наличие, цвет и тип отображаемых точек кривой.
        /// </summary>
        public string DotsType { get; set; }
        /// <summary>
        /// Задаёт стиль рисования кривой.
        /// </summary>
        public DashStyle DashStyle { get; set; }

        public Curves(PointF[] pt, Color CurveColor, DashStyle style = DashStyle.Solid, int CurveThickness = 1, string Legend = "Пусто", string dotsType = "")
        {
            PointsToDraw = pt;
            this.CurveColor = CurveColor;
            this.CurveThickness = CurveThickness;
            this.Legend = Legend;
            this.DotsType = dotsType;
            DashStyle = style;
        }
    }



}
