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

        public Color DiagramColor { get; set; }
        public Pen DiagramPen { get; set; }
        public Font drawFont { get; set; }
    }

    /// <summary>
    /// Представляет структуру для инициализации столбцов гистограммы.
    /// </summary>
    public struct Bars
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

        public Bars(string name, double value, Color internalColor)
        {
            BarName = name;
            BarValue = value;
            BarColor = internalColor;
        }
    }

    public class BarChart : Diagram
    {
        List<Bars> BarCollection = new List<Bars>();
        BarChartConfig Config;

        public BarChart(PictureBox picture)
        {
            placeToDraw = picture;
            Config.DiagramColor = Color.Black;
            Config.DiagramPen = new Pen(Config.DiagramColor);
            Config.drawFont = new Font("Arial", 8);
            Config.BarWidth = 30;
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

        public void SetDefaultParams()
        {
            if(BarCollection.Count != 0)
            {

            }
        }

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
            }
        }

    }
}
