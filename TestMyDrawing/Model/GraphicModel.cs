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
        PointsGraphic gr;

        public DrawingModel()
        {
            
        }

        public string Init(PictureBox picture)
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

            gr.Config.Grid = true;

            string str = LoadData("defaultData3.txt", false);
            crrStream?.Close();
            gr.AddCurve(new Curves(crrPoints, Color.DodgerBlue));
            gr.DrawDiagram();
            return str;
        }
    }
}
