using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyDrawing.Figures
{
    /// <summary>
    /// Абстрактный класс, представляющий характеристики рисуемых фигур.
    /// </summary>
    public abstract class Figure
    {
        public Color FillColor { get; set; }
        public Color StrokeColor { get; set; }
        public int StrokeWidth { get; set; }
        public bool Smooth { get; set; } = false;

        public PointF DotA { get; set; }
        public PointF DotB { get; set; }

        public abstract void DrawFigure(Graphics GraphPlace);

        public virtual void DrawCheckedFigure(Graphics GraphPlace)
        {
            DrawFigure(GraphPlace);
            float shift = StrokeWidth + 3;
            GraphPlace.DrawEllipse(new Pen(Color.Gray, 3), new RectangleF(DotA.X - shift, DotA.Y - shift, 2 * shift, 2 * shift));
            GraphPlace.DrawEllipse(new Pen(Color.Gray, 3), new RectangleF(DotB.X - shift, DotB.Y - shift, 2 * shift, 2 * shift));
            GraphPlace.FillEllipse(new SolidBrush(Color.White), new RectangleF(DotA.X - shift, DotA.Y - shift, 2 * shift, 2 * shift));
            GraphPlace.FillEllipse(new SolidBrush(Color.White), new RectangleF(DotB.X - shift, DotB.Y - shift, 2 * shift, 2 * shift));
        }

        public virtual bool FigureChecked(PointF cursor)
        {
            if (Math.Abs(cursor.X - DotA.X) <= 5 && Math.Abs(cursor.Y - DotA.Y) <= 5 ||
                Math.Abs(cursor.X - DotB.X) <= 5 && Math.Abs(cursor.Y - DotB.Y) <= 5)
            {
                return true;
            }
            return false;
        }
    }
    /// <summary>
    /// Наследник класса Figure для отрисовки обычной прямой линии.
    /// </summary>
    public class Line : Figure
    {
        LineCap lineCap;
        protected Pen LinePen { get; set; }
        /// <summary>
        /// Создание эземпляра линии, которая содержит точки построения в системе координат области построения класса Graphics.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Line(PointF a, PointF b)
        {
            StrokeColor = Color.Black;
            StrokeWidth = 3;
            DotA = a;
            DotB = b;
        }

        public override void DrawFigure(Graphics GraphPlace)
        {
            if (Smooth)
                lineCap = LineCap.Round;
            else lineCap = LineCap.Flat;
            GraphPlace.SmoothingMode = SmoothingMode.AntiAlias;
            LinePen = new Pen(StrokeColor, StrokeWidth);
            LinePen.StartCap = LinePen.EndCap = lineCap;

            GraphPlace.DrawLine(LinePen, DotA, DotB);
        }

        
    }
    /// <summary>
    /// Наследник класса Line для отрисовки прямой стрелки.
    /// </summary>
    public class Arrow : Line
    {
        public bool FillArrowEnd { get; set; }
        public Arrow(PointF a, PointF b) : base(a, b) { FillArrowEnd = false; }

        public override void DrawFigure(Graphics GraphPlace)
        {
            base.DrawFigure(GraphPlace);

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
                GraphPlace.FillPolygon(new SolidBrush(LinePen.Color), pts);
        }
    }
    /// <summary>
    /// Наследник класса Figure для отрисовки прямоугольника.
    /// </summary>
    public class Rectangle : Figure
    {
        public Rectangle(PointF a, PointF b)
        {
            FillColor = Color.Black;
            StrokeColor = Color.Black;
            StrokeWidth = 3;
            DotA = a;
            DotB = b;
        }

        protected void InitRectParams(out PointF pt, out float w, out float h)
        {
            w = Math.Abs(DotB.X - DotA.X);
            h = Math.Abs(DotB.Y - DotA.Y);
            if (DotA.X < DotB.X && DotA.Y < DotB.Y)
                pt = new PointF(DotA.X + w / 2, DotA.Y + h / 2);
            else if (DotA.X > DotB.X && DotA.Y > DotB.Y)
                pt = new PointF(DotA.X - w / 2, DotA.Y - h / 2);
            else if (DotA.X < DotB.X && DotA.Y > DotB.Y)
                pt = new PointF(DotA.X + w / 2, DotA.Y - h / 2);
            else pt = new PointF(DotA.X - w / 2, DotA.Y + h / 2);
        }

        public override void DrawFigure(Graphics GraphPlace)
        {
            float w, h;
            PointF pt;
            InitRectParams(out pt, out w, out h);
            GraphPlace.SmoothingMode = SmoothingMode.AntiAlias;
            //рисование контура
            if (StrokeWidth > 0 && StrokeColor != Color.Transparent)
            {
                Pen pen = new Pen(StrokeColor, StrokeWidth);
                if(Smooth)
                    pen.LineJoin = LineJoin.Round;
                
                GraphPlace.DrawRectangle(pen, new System.Drawing.Rectangle((int)(pt.X - w / 2), (int)(pt.Y - h /2), (int)w, (int)h));
            }
            //Рисование заливки
            if (FillColor != Color.Transparent)
                GraphPlace.FillRectangle(new SolidBrush(FillColor), new RectangleF(pt.X - w / 2, pt.Y - h / 2, w, h));
        }

        public override bool FigureChecked(PointF cursor)
        {
            float w, h;
            PointF pt;
            InitRectParams(out pt, out w, out h);

            if (FillColor != Color.Transparent)
            {
                if (cursor.X >= pt.X - w / 2 && cursor.X <= pt.X + w / 2 && cursor.Y >= pt.Y - h / 2 && cursor.Y <= pt.Y + h / 2)
                    return true;
                else return false;
            }
            else
            {
                double shift = StrokeWidth;
                if (Math.Abs(pt.X - w/2 - cursor.X) <= shift || Math.Abs(pt.X + w / 2 - cursor.X) <= shift ||
                    Math.Abs(pt.Y - h / 2 - cursor.Y) <= shift || Math.Abs(pt.Y + h / 2 - cursor.Y) <= shift)
                    return true;
                else return false;
            }
        }
    }
    /// <summary>
    /// Наследник класса Rectangle для отрисовки окружност или круга.
    /// </summary>
    public class Circle : Rectangle
    {
        public Circle(PointF a, PointF b) : base(a, b) { }

        public override void DrawFigure(Graphics GraphPlace)
        {
            GraphPlace.SmoothingMode = SmoothingMode.AntiAlias;
            float w, h;
            PointF pt;
            InitRectParams(out pt, out w, out h);
            //контур
            if (StrokeWidth > 0 && StrokeColor != Color.Transparent)
            {
                Pen pen = new Pen(StrokeColor, StrokeWidth);
                GraphPlace.DrawEllipse(pen, new System.Drawing.Rectangle((int)(pt.X - w / 2), (int)(pt.Y - h / 2), (int)w, (int)h));
            }
            //Рисование заливки
            if (FillColor != Color.Transparent)
                GraphPlace.FillEllipse(new SolidBrush(FillColor), new RectangleF(pt.X - w / 2, pt.Y - h / 2, w, h));
        }

        public override bool FigureChecked(PointF cursor)
        {
            float w, h;
            PointF pt;
            InitRectParams(out pt, out w, out h);
            if (FillColor != Color.Transparent)
            {
                if (cursor.X >= pt.X - w / 2 && cursor.X <= pt.X + w / 2 && cursor.Y >= pt.Y - h / 2 && cursor.Y <= pt.Y + h / 2)
                    return true;
                else return false;
            }
            else
            {
                double shift = 0.05;
                double val = Math.Pow((pt.X - cursor.X) * 2 / w, 2) + Math.Pow((pt.Y - cursor.Y) * 2 / h, 2);
                if (Math.Abs(1 - val) <= shift)
                    return true;
                else return false;
            }
        }
    }
    /// <summary>
    /// Наследник класса Figure для отрисовки текста.
    /// </summary>
    public class Text : Figure
    {
        public string Value { get; set; }
        public Font Font { get; set; }
        public Color TextColor { get; set; }
        public bool Background { get; set; }

        public Text(PointF a, string text = "")
        {
            DotA = a;
            Value = text;
            TextColor = Color.Black;
            Font = new Font("Arial", 12);
            FillColor = Color.White;
        }

        public override void DrawFigure(Graphics GraphPlace)
        {
            GraphPlace.SmoothingMode = SmoothingMode.AntiAlias;
            if (Background)
            {
                SizeF size = GraphPlace.MeasureString(Value, Font);
                GraphPlace.FillRectangle(new SolidBrush(FillColor), new RectangleF(DotA, size));
            }
            GraphPlace.DrawString(Value, Font, new SolidBrush(TextColor), DotA);
        }

        public override void DrawCheckedFigure(Graphics GraphPlace)
        {
            DrawFigure(GraphPlace);
            float shift = 5;
            GraphPlace.DrawEllipse(new Pen(Color.Gray, 3), new RectangleF(DotA.X - shift, DotA.Y - shift, 2 * shift, 2 * shift));
            GraphPlace.FillEllipse(new SolidBrush(Color.White), new RectangleF(DotA.X - shift, DotA.Y - shift, 2 * shift, 2 * shift));
        }
    }
}
