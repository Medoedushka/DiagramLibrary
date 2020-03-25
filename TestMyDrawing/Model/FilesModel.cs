using System;
using System.Collections.Generic;
using System.Linq;
using MyDrawing;
using System.Drawing;
using MAC_Dll;
using System.IO;

namespace TestMyDrawing.Model
{
    public partial class DrawingModel
    {
        TableOfData data;
        public FileStream crrStream;
        PointF[] crrPoints;
        int everCreatedCurvesCounter; //Содержит кол-во когда-либо, созданных кривых

        public string ShowCurvePoints(string curveLegend)
        {
            string table = "";
            foreach(Curves c in gr.GraphCurves)
            {
                if (c.Legend == curveLegend)
                {
                    TableOfData d = new TableOfData(c.PointsToDraw, c.Legend, false);
                    return d.Table_of_Function();
                }
            }
            return table;
        }
        
        public void LoadTXTData(string dataFilePath, bool sort = true)
        {
            FileInfo fl = new FileInfo(dataFilePath);
            data = new TableOfData(dataFilePath, fl.Name, sort);

            crrPoints = new PointF[data.Length];
            for(int  i = 0; i < crrPoints.Length; i++)
            {
                crrPoints[i].X = (float)data.Points[i].X;
                crrPoints[i].Y = (float)data.Points[i].F;
            }
            everCreatedCurvesCounter++;
            string legend = "График" + everCreatedCurvesCounter;
            Curves curve = new Curves(crrPoints, BaseColors[colorCounter], Legend: legend);
            if (++colorCounter == BaseColors.Length) colorCounter = 0;

            gr.AddCurve(curve);
            gr.DrawDiagram();
        }

        public string CreateNewFile(string pathToCreate)
        {
            DirectoryInfo di = Directory.CreateDirectory(pathToCreate);
            string txtName = pathToCreate + "\\" + di.Name + ".txt";
            crrStream = File.Create(txtName);
            return txtName;
        }

        public void SaveFile()
        {
            string saveStr = "";
            string path = crrStream.Name;
            crrStream.Close();
            for(int i = 0; i < crrPoints.Length; i++)
            {
                saveStr += crrPoints[i].X + " " + crrPoints[i].Y + "\n";
            }
                            
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.Write(saveStr);
            }
            crrStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
        }
    }
}
