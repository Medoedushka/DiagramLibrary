using MyDrawing;
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
        protected Pen LinePen { get; set; }
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
            LinePen = new Pen(StrokeColor, StrokeWidth);
            LinePen.StartCap = LinePen.EndCap = lineCap;

            GraphPlace.DrawLine(LinePen, DotA, DotB);
        }
    }

    public class Arrow : Line
    {
        public Arrow(PointF a, PointF b, Graphics g) : base(a, b, g) { }

        public override void DrawFigure()
        {
            base.DrawFigure();

            PointF vector = new PointF(DotB.X - DotA.X, DotB.Y - DotA.Y);
            float mod_v = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            float mod = 10;

            float rotang = (float)(-160 * Math.PI / 180);
            PointF e_v = new PointF(mod * vector.X / mod_v, mod * vector.Y / mod_v);
            PointF pt1 = new PointF((float)(e_v.X * Math.Cos(rotang) - e_v.Y * Math.Sin(rotang)),
                (float)(e_v.X * Math.Sin(rotang) + e_v.Y * Math.Cos(rotang)));
            GraphPlace.DrawLine(LinePen, DotB.X, DotB.Y, DotB.X + pt1.X, DotB.Y + pt1.Y);

            rotang = (float)(160 * Math.PI / 180);
            e_v = new PointF(mod * vector.X / mod_v, mod * vector.Y / mod_v);
            pt1 = new PointF((float)(e_v.X * Math.Cos(rotang) - e_v.Y * Math.Sin(rotang)),
                (float)(e_v.X * Math.Sin(rotang) + e_v.Y * Math.Cos(rotang)));
            GraphPlace.DrawLine(LinePen, DotB.X, DotB.Y, DotB.X + pt1.X, DotB.Y + pt1.Y);
        }
    }
}
