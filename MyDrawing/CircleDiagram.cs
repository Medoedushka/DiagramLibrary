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
        
        public CircleDiagramConfig Config { get; set; }
        double Side { get; set; } //сторона квадрата, в которого вписана окружность 

        public CircleDiagram(PictureBox picture)
        {
            Config = new CircleDiagramConfig();
            placeToDraw = picture;
            Config.CircleColor = Color.Black;
            SetDefaultParams();
        }

        public void SetDefaultParams()
        {
            if (placeToDraw.Width > placeToDraw.Height) Config.DiagramSize = placeToDraw.Height - Space_From_Top;
            if (placeToDraw.Height > placeToDraw.Width) Config.DiagramSize = placeToDraw.Width - Space_From_Top;
            
        }

        public void DrawCircle()
        {
            g = placeToDraw.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Center.X = (int)Config.X + Config.DiagramSize / 2;
            Center.Y = (int)Config.Y + Config.DiagramSize / 2;
            Config.X = placeToDraw.Width / 2 - Config.DiagramSize / 2;
            Config.Y = placeToDraw.Height / 2 - Config.DiagramSize / 2;

            RectangleF rect = new RectangleF((float)Config.X, (float)Config.Y, Config.DiagramSize, Config.DiagramSize);
            g.DrawEllipse(new Pen(Config.CircleColor), rect);
        }

        public override void DrawGraphic()
        {
            
        }

    }
}
