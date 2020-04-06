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
        public bool FillArrowEnd { get; set; }
        public Arrow(PointF a, PointF b, Graphics g) : base(a, b, g) { FillArrowEnd = false; }

        public override void DrawFigure()
        {
            base.DrawFigure();

            PointF vector = new PointF(DotB.X - DotA.X, DotB.Y - DotA.Y);
            float mod_v = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            float mod = 10;
            PointF[] pts = new PointF[3];
            pts[0] = DotB;
            float rotang = (float)(-160 * Math.PI / 180);
            PointF e_v = new PointF(mod * vector.X / mod_v, mod * vector.Y / mod_v);
            PointF pt1 = new PointF((float)(e_v.X * Math.Cos(rotang) - e_v.Y * Math.Sin(rotang)),
                (float)(e_v.X * Math.Sin(rotang) + e_v.Y * Math.Cos(rotang)));
            GraphPlace.DrawLine(LinePen, DotB.X, DotB.Y, DotB.X + pt1.X, DotB.Y + pt1.Y);
            pts[1] = new PointF(DotB.X + pt1.X, DotB.Y + pt1.Y);

            rotang = (float)(160 * Math.PI / 180);
            e_v = new PointF(mod * vector.X / mod_v, mod * vector.Y / mod_v);
            pt1 = new PointF((float)(e_v.X * Math.Cos(rotang) - e_v.Y * Math.Sin(rotang)),
                (float)(e_v.X * Math.Sin(rotang) + e_v.Y * Math.Cos(rotang)));
            GraphPlace.DrawLine(LinePen, DotB.X, DotB.Y, DotB.X + pt1.X, DotB.Y + pt1.Y);
            pts[2] = new PointF(DotB.X + pt1.X, DotB.Y + pt1.Y);

            if (FillArrowEnd)
            GraphPlace.FillPolygon(Brushes.Red, pts);
        }
    }

    public class Rectangle : Figure
    {
        public Rectangle(PointF a, PointF b, Graphics g)
        {
            FillColor = Color.Black;
            StrokeColor = Color.Black;
            GraphPlace = g;
            GraphPlace.SmoothingMode = SmoothingMode.AntiAlias;
            StrokeWidth = 3;
            DotA = a;
            DotB = b;
        }

        protected void InitRectParams(out PointF pt, out float w, out float h)
        {
            w = Math.Abs(DotB.X - DotA.X) * 2;
            h = Math.Abs(DotB.Y - DotA.Y) * 2;
            pt = new PointF();
            if (DotB.X < DotA.X && DotB.Y < DotA.Y)
                pt = DotB;
            else if (DotB.X < DotA.X && DotB.Y > DotA.Y)
                pt = new PointF(DotB.X, DotB.Y - h);
            else if (DotB.X > DotA.X && DotB.Y < DotA.Y)
                pt = new PointF(DotB.X - w, DotB.Y);
            else if (DotB.X > DotA.X && DotB.Y > DotA.Y)
                pt = new PointF(DotB.X - w, DotB.Y - h);
        }

        public override void DrawFigure()
        {
            float w, h;
            PointF pt;
            InitRectParams(out pt, out w, out h);

            //рисование контура
            if (StrokeWidth > 0)
            {
                Pen pen = new Pen(StrokeColor, StrokeWidth);
                GraphPlace.DrawRectangle(pen, new System.Drawing.Rectangle((int)pt.X, (int)pt.Y, (int)w, (int)h));
            }
            //Рисование заливки
            GraphPlace.FillRectangle(new SolidBrush(FillColor), new RectangleF(pt.X, pt.Y, w, h));
        }
    }

    public class Circle : Rectangle
    {
        public Circle(PointF a, PointF b, Graphics g) : base(a, b, g) {}

        public override void DrawFigure()
        {
            float w, h;
            PointF pt;
            InitRectParams(out pt, out w, out h);
            //контур
            if (StrokeWidth > 0)
            {
                Pen pen = new Pen(StrokeColor, StrokeWidth);
                GraphPlace.DrawEllipse(pen, new System.Drawing.Rectangle((int)pt.X, (int)pt.Y, (int)w, (int)h));
            }
            //Рисование заливки
            GraphPlace.FillEllipse(new SolidBrush(FillColor), new RectangleF(pt.X, pt.Y, w, h));
        }
    }

    public class Text : Figure
    {
        public string Value { get; set; }
        public Font Font { get; set; }
        public Color TextColor { get; set; }
        public bool Background { get; set; }

        public Text(PointF a, Graphics g, string text = "")
        {
            DotA = a;
            GraphPlace = g;
            Value = text;
            TextColor = Color.Black;
            Font = new Font("Arial", 12);
            FillColor = Color.White;
        }

        public override void DrawFigure()
        {
            if (Background)
            {
                SizeF size = GraphPlace.MeasureString(Value, Font);
                GraphPlace.FillRectangle(new SolidBrush(FillColor), new RectangleF(DotA, size));
            }
            GraphPlace.DrawString(Value, Font, new SolidBrush(TextColor), DotA);
        }
    }
}
