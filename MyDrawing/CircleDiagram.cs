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
        public bool ValuePersent { get; set; }
        

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
        Bitmap bm;
        public CircleDiagramConfig Config { get; set; }
        double Side { get; set; } //сторона квадрата, в которого вписана окружность 
        


        public CircleDiagram(PictureBox picture)
        {
            Config = new CircleDiagramConfig();
            placeToDraw = picture;
            Config.CircleColor = Color.Black;
            Config.ValuePersent = true;
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
                    sc.Persent = Convert.ToString(persent) + "%";
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

                if (Config.ValuePersent == true)
                {
                    PointF str = new PointF();
                    double PercentAngle = ((previousAngle + crrSector.Angle / 2) * Math.PI) / 180;
                    str.X = (float)(Center.X + (Config.DiagramSize * 3 / 8) * Math.Cos(PercentAngle));
                    str.Y = (float)(Center.Y + (Config.DiagramSize * 3 / 8) * Math.Sin(PercentAngle));
                    g.DrawString(crrSector.Persent, new Font("Arial", 10), new SolidBrush(Color.Black), str);
                }
                previousAngle += crrSector.Angle;

            }
        }

        private void DrawTitle()
        {
            Font font = new Font("Arial", TitleSize);
            SolidBrush brush = new SolidBrush(Color.Black);
            SizeF size = g.MeasureString(Title, font);

            Point Titlept = new Point();
            Titlept.X = (int)(Center.X - size.Width / 2);
            Titlept.Y = (int)(Config.Y / 2 - 10);
            g.DrawString(Title, font, brush, Titlept);
        }

        private void DrawLegend()
        {
            //стороны прямоугольника
            int SideA = 20;
            int SideB = 10;
            PointF StrPoint = new PointF((float)Config.X + Config.DiagramSize + 15, (float)(Config.Y * 2));
            foreach(Sectors crrSector in SectorCollection)
            {
                RectangleF rect = new RectangleF(StrPoint.X, StrPoint.Y, SideA, SideB);
                g.FillRectangle(new SolidBrush(crrSector.SectorColor), rect);
                string str = " - " + crrSector.Legend + "(" + crrSector.Persent + ")";
                SizeF size = g.MeasureString(str, new Font("Arial", 8));
                g.DrawString(str, new Font("Arial", 8), new SolidBrush(Color.Black), StrPoint.X + SideA, StrPoint.Y - 5);
                StrPoint.Y += size.Height + 5;
            }
        }

        public void SetDefaultParams()
        {
            if (placeToDraw.Width > placeToDraw.Height) Config.DiagramSize = placeToDraw.Height - 65;
            else if (placeToDraw.Height > placeToDraw.Width) Config.DiagramSize = placeToDraw.Width - 65;
            else Config.DiagramSize = placeToDraw.Height - Space_From_Top;
            Config.X = placeToDraw.Width / 2 - Config.DiagramSize / 2;
            Config.Y = placeToDraw.Height / 2 - Config.DiagramSize / 2;
        }

        private void DrawCircle()
        {
            bm = new Bitmap(placeToDraw.Width, placeToDraw.Height);
            g = Graphics.FromImage(bm);
            g.Clear(placeToDraw.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Center = new Point((int)Config.X + Config.DiagramSize / 2, (int)Config.Y + Config.DiagramSize / 2);
        }

        public override void DrawDiagram()
        {
            DrawCircle();

            if(AddDiagramLegend == true)
            {
                DrawLegend();
            }
           
            if (Title != "")
            {
                if (TitleSize == 0) TitleSize = 10;
                DrawTitle();
            }
            
            DrawSectors();
            placeToDraw.Image = bm;
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
