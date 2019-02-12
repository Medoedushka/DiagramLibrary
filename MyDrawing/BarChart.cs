using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyDrawing
{


    public struct BarChartConfig
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

        public bool RandomBarColor { get; set; }
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
        public BarChartConfig Config;
        private string[] UsedColors;


        public BarChart(PictureBox picture)
        {
            placeToDraw = picture;
            Config.DiagramColor = Color.Black;
            Config.DiagramPen = new Pen(Config.DiagramColor);
            Config.drawFont = new Font("Arial", 8);
            Config.drawBrush = new SolidBrush(Config.DiagramColor);
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
                //надпись названия колонки
                SizeF size = g.MeasureString(BarCollection[i].BarName, Config.drawFont);
                PointF StringPoint = new PointF();
                StringPoint.Y = Center.Y;
                StringPoint.X = BarPoint.X + Config.BarWidth / 2 - size.Width / 2;

                g.DrawString(BarCollection[i].BarName, Config.drawFont, Config.drawBrush, StringPoint);
            }
        }
        /// <summary>
        /// Рисует гистограмму.
        /// </summary>
        public override void DrawGraphic()
        {
           
            DrawAxes();
            if (BarCollection.Count != 0) DrawCurrentBar();
        }

    }
}
