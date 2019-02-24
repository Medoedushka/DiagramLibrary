using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyDrawing
{
    public class CircleDiagramConfig
    {
        int diagramSize;
        public double X { get; set; } //Абсцисса верхней левой точки квадрата
        public double Y { get; set; } //Ордината верхней левой точки квадрата
        public Color CircleColor { get; set; }


        /// <summary>
        /// Регулировка размеров диаграммы.
        /// </summary>
        public int DiagramSize
        {
            get { return diagramSize; }
            set
            {
                if (value > 0) diagramSize = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
    }

    public class CircleDiagram : Diagram
    {
        public List<Sectors> SectorCollection = new List<Sectors>();
        public CircleDiagramConfig Config { get; set; }
        double Side { get; set; } //сторона квадрата, в которого вписана окружность 
        


        public CircleDiagram(PictureBox picture)
        {
            Config = new CircleDiagramConfig();
            placeToDraw = picture;
            Config.CircleColor = Color.Black;
            SetDefaultParams();
        }

        public void AddSector(Sectors sect)
        {
            bool Exist = false;
            foreach(Sectors sc in SectorCollection)
            {
                if(sc.Legend == sect.Legend && sect.Legend != "Пусто")
                {
                    Exist = true;
                    break;
                }
            }
            if (Exist) MessageBox.Show("Элмент с такой легендой уже существует.", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            else
            {
                SectorCollection.Add(sect);
                double SumValues = 0;
                foreach(Sectors sc in SectorCollection)
                {
                    SumValues += sc.Value;
                }
           
                foreach (Sectors sc in SectorCollection)
                {
                    double persent = Math.Round(sc.Value * 100 / SumValues, 2);
                    sc.Persent = Convert.ToString(persent);
                    sc.Angle = Math.Round(persent * 360 / 100, 1);
                }

            }
        }

        private void DrawSectors()
        {
            double previousAngle = 0;
            foreach (Sectors crrSector in SectorCollection)
            {
                g.FillPie(new SolidBrush(crrSector.SectorColor), (float)Config.X, (float)Config.Y, Config.DiagramSize,
                    Config.DiagramSize, (float)previousAngle, (float)crrSector.Angle);
                previousAngle += crrSector.Angle;
                PointF str = new PointF();

                str.X = (float)(Center.X + Config.DiagramSize / 4 * Math.Cos((previousAngle + crrSector.Angle / 2) * Math.PI / 180));
                str.Y = (float)(Center.Y - Config.DiagramSize / 4 * Math.Sin((previousAngle + crrSector.Angle / 2) * Math.PI / 180));
                g.DrawString(crrSector.Persent, new Font("Arial", 10), new SolidBrush(Color.Black), str);
            }
        }

        public void SetDefaultParams()
        {
            if (placeToDraw.Width > placeToDraw.Height) Config.DiagramSize = placeToDraw.Height - Space_From_Top;
            if (placeToDraw.Height > placeToDraw.Width) Config.DiagramSize = placeToDraw.Width - Space_From_Top;
            else Config.DiagramSize = placeToDraw.Height - Space_From_Top;
            Config.X = placeToDraw.Width / 2 - Config.DiagramSize / 2;
            Config.Y = placeToDraw.Height / 2 - Config.DiagramSize / 2;
        }

        private void DrawCircle()
        {
            g = placeToDraw.CreateGraphics();
            g.Clear(placeToDraw.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Center.X = (int)Config.X + Config.DiagramSize / 2;
            Center.Y = (int)Config.Y + Config.DiagramSize / 2;
            
            RectangleF rect = new RectangleF((float)Config.X, (float)Config.Y, Config.DiagramSize, Config.DiagramSize);
            g.DrawEllipse(new Pen(Config.CircleColor), rect);
        }

        public override void DrawGraphic()
        {
            DrawCircle();
            DrawSectors();
        }

    }

    public class Sectors
    {
        public double Value { get; set; }
        public double Angle { get; set; }
        public string Persent { get; set; }
        public Color SectorColor { get; set; }
        public string Legend { get; set; }

        public Sectors(double value, Color color, string legend = "Пусто")
        {
            Value = value;
            SectorColor = color;
            Legend = legend;
        }
    }
}
