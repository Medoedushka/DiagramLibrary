using System;
using System.Drawing;
using MyClassLibrary;
using MyDrawing;
using System.Windows.Forms;

namespace TestMyDrawing.Model
{
    
    public partial class DrawingModel
    {
        public PointsGraphic gr;

        Color[] BaseColors =
        {
            Color.FromArgb(237, 125, 49),
            Color.FromArgb(91, 155, 213),
            Color.FromArgb(165, 165, 165),
            Color.FromArgb(255, 192, 0),
            Color.FromArgb(68, 114, 196),
            Color.FromArgb(112, 173, 71),
            Color.FromArgb(158, 72, 14),
            Color.FromArgb(99, 99, 99),
            Color.FromArgb(153, 115, 0),
            Color.FromArgb(38, 68, 120),
        }; // Массив зарезервированных цветов.
        int colorCounter = 0; // Порядковый номер текущего цвета.

        public DrawingModel()
        {
            
        }

        public void Init(PictureBox picture)
        {
            gr = new PointsGraphic(picture);
            
            //инициализация параметров по умолчанию
            gr.Title = "Название диаграммы";
            gr.TitlePosition = TextPosition.Centre;
            gr.TitleSize = 15;

            gr.Config.OXName = "Ось X";
            gr.Config.OXNamePosition = TextPosition.Centre;
            gr.Config.OXNameSize = 12;

            gr.Config.OYName = "Ось Y";
            gr.Config.OYNamePosition = TextPosition.Centre;
            gr.Config.OYNameSize = 12;
            gr.AddDiagramLegend = true;
            gr.Config.Grid = false;
            gr.placeToDraw.BackColor = Color.White;
            LoadTXTData("defaultData3.txt", false);
            crrStream?.Close();
        }

        public void ResizePlot(PictureBox picture)
        {
            if (gr != null)
            {
                gr.SetPlaceToDrawSize(picture.Width, picture.Height);
                gr.DrawDiagram();
            }
        }

        Point mouseLoc;
        float d, angle;
        public void PrimaryParamsInit(Point firstMouseLoc)
        {
            mouseLoc = firstMouseLoc;
            d = (float)Math.Sqrt(Math.Pow(gr.RealCenter.X - firstMouseLoc.X, 2) + Math.Pow(gr.RealCenter.Y - firstMouseLoc.Y, 2));
            angle = (float)Math.Asin((gr.RealCenter.Y - firstMouseLoc.Y) / d);
        }

        public void RefreshPlotByMoving(Point crrMouseLoc)
        {
            if (mouseLoc.X > gr.RealCenter.X)
                gr.RealCenter = new Point(crrMouseLoc.X - (int)(d * Math.Cos(angle)), crrMouseLoc.Y + (int)(d * Math.Sin(angle)));
            else
                gr.RealCenter = new Point(crrMouseLoc.X + (int)(d * Math.Cos(angle)), crrMouseLoc.Y + (int)(d * Math.Sin(angle)));
            gr.DrawDiagram();
        }

        int counter = 0;
        public void ZoomPlot(bool zoom)
        {
            double k = 1.5;
            if (zoom)
            {
                counter++;

                PointF center0_cont = new PointF(gr.pt2.X + (gr.pt3.X - gr.pt2.X) / 2, gr.pt1.Y - (gr.pt1.Y - gr.pt2.Y) / 2);
                PointF center0_dec = gr.ConvertValues(center0_cont, CoordType.GetRectangleCoord);

                gr.Config.PriceForPointOX = gr.Config.PriceForPointOX / k;
                gr.Config.PriceForPointOY = gr.Config.PriceForPointOY / k;

                PointF center1_cont = gr.ConvertValues(center0_dec, CoordType.GetControlCoord);
                PointF vector = new PointF(center1_cont.X - center0_cont.X, center1_cont.Y - center0_cont.Y);
                gr.RealCenter = new Point(gr.RealCenter.X - (int)vector.X, gr.RealCenter.Y - (int)vector.Y);
                
                gr.DrawDiagram();
            }
            else
            {
                PointF center0_cont = new PointF(gr.pt2.X + (gr.pt3.X - gr.pt2.X) / 2, gr.pt1.Y - (gr.pt1.Y - gr.pt2.Y) / 2);
                PointF center0_dec = gr.ConvertValues(center0_cont, CoordType.GetRectangleCoord);

                gr.Config.PriceForPointOX = gr.Config.PriceForPointOX * k;
                gr.Config.PriceForPointOY = gr.Config.PriceForPointOY * k;

                PointF center1_cont = gr.ConvertValues(center0_dec, CoordType.GetControlCoord);
                PointF vector = new PointF(center1_cont.X - center0_cont.X, center1_cont.Y - center0_cont.Y);
                gr.RealCenter = new Point(gr.RealCenter.X - (int)vector.X, gr.RealCenter.Y - (int)vector.Y);
                gr.DrawDiagram();
            }
        }


        public void ApdateCurvesList(Curves curve, bool delete, string newName)
        {
            if (!delete)
            {
                for(int i = 0; i < gr.GraphCurves.Count; i++)
                {
                    if (gr.GraphCurves[i].Legend == curve.Legend)
                    {
                        if (newName == "")
                        {
                            gr.GraphCurves[i] = new Curves(gr.GraphCurves[i].PointsToDraw, curve.CurveColor,
                            curve.CurveThickness, curve.Legend, curve.DotsType);
                        }
                        else
                        {
                            gr.GraphCurves[i] = new Curves(gr.GraphCurves[i].PointsToDraw, curve.CurveColor,
                            curve.CurveThickness, newName, curve.DotsType);
                        }
                        
                    }
                }
            }
            else
            {
                foreach(Curves c in gr.GraphCurves)
                {
                    if (c.Legend == curve.Legend)
                    {
                        gr.GraphCurves.Remove(c);
                        break;
                    }
                        
                }
            }
            gr.DrawDiagram();
        }
    }
}
