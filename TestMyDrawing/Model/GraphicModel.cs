﻿using System;
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
            gr.AddDiagramLegend = true;
            gr.Config.Grid = true;
            string str = LoadData("defaultData3.txt", false);
            crrStream?.Close();
            gr.AddCurve(new Curves(crrPoints, Color.DodgerBlue, Legend: "Default data"));
            gr.DrawDiagram();
            return str;
        }

        public void ResizePlot(PictureBox picture)
        {
            if (gr != null)
            {
                gr.SetPlaceToDrawSize(picture.Width, picture.Height);
                gr.DrawDiagram();
            }
        }
    }
}