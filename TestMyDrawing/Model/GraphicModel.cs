using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MyDrawing;
using System.Windows.Forms;

namespace TestMyDrawing.Model
{
    public partial class DrawingModel
    {
        public PointsGraphic gr;

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
            gr.Config.Grid = true;
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
