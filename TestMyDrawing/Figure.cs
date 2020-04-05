using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMyDrawing
{
    
    public abstract class Figure
    {
        public Color FillColor { get; set; }
        public Color StrokeColor { get; set; }
        public int StrokeWidth { get; set; }
        public Graphics GraphPlace { get; set; }

        public PointF DotA { get; set; }
        public PointF DotB { get; set; }

        public abstract void DrawFigure();
    }

    public class Line : Figure
    {
        LineCap lineCap;
        public bool SmoothLine { get; set; }

        public Line(PointF a, PointF b, Graphics g)
        {
            StrokeColor = Color.Black;
            GraphPlace = g;
            GraphPlace.SmoothingMode = SmoothingMode.AntiAlias;
            StrokeWidth = 3;
            DotA = a;
            DotB = b;
            SmoothLine = false;
        }

        public override void DrawFigure()
        {
            if (SmoothLine)
                lineCap = LineCap.Round;
            else lineCap = LineCap.Flat;
            Pen pen = new Pen(StrokeColor, StrokeWidth);
            pen.StartCap = pen.EndCap = lineCap;

            GraphPlace.DrawLine(pen, DotA, DotB);
        }
    }
}
