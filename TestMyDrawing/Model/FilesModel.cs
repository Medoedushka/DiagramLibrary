using System;
using System.Collections.Generic;
using System.Linq;
using MyDrawing;
using System.Drawing;
using MAC_Dll;
using System.IO;
using Newtonsoft.Json;

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
            Curves curve = new Curves(crrPoints, BaseColors[colorCounter], CurveThickness: 2 ,Legend: legend);
            if (++colorCounter == BaseColors.Length)
            {
                colorCounter = 0;
            }

            gr.AddCurve(curve);
            gr.Config.PriceForPointOX = gr.Config.PriceForPointOY;
            gr.DrawDiagram();
        }

        public void LoadJSONData(string path)
        {
            string jsonData = "";
            crrStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            using (StreamReader sr = new StreamReader(crrStream))
            {
                jsonData = sr.ReadToEnd();
            }

            if (jsonData != "")
            {
                var list = JsonConvert.DeserializeObject<List<Curves>>(jsonData);
                gr.GraphCurves = list;
                gr.DrawDiagram();
            }
        }

        public string CreateNewFile(string pathToCreate)
        {
            DirectoryInfo di = Directory.CreateDirectory(pathToCreate);
            string txtName = pathToCreate + "\\" + di.Name + ".json";
            crrStream = File.Create(txtName);
            return txtName;
        }

        public void SaveFile()
        {
            string saveStr = "";
            string path = crrStream.Name;
            crrStream.Close();

            saveStr = JsonConvert.SerializeObject(gr.GraphCurves, Formatting.Indented);

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.Write(saveStr);
            }
            string dirPath = path.Remove(path.LastIndexOf('.'));
            gr.placeToDraw.Image.Save(dirPath + ".png", System.Drawing.Imaging.ImageFormat.Png);
            crrStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
        }

        public PointF[] GenerateSpiral(double omega, double k, int start, int numsek, bool save_into_file)
        {
            double delta = 0.01;
            PointF[] pointsArray = new PointF[(int)(numsek/delta) - start];
            //start - point of starting spiral
            start = start < 0 ? (-1) * start : start;
            //numsek - the length of spiral
            numsek = numsek < 0 ? (-1) * numsek : numsek;
            numsek += start;
            //k - koef of spiral
            //omega a hui eye znaet nahua tupa koeff
           
            int counter = 0;
            for (double t = start; t < numsek; t += delta)
            {

                
                double omt = omega * t;
                double x = (double)(k * omt * Math.Cos(omt) / 4),
                    y = (double)(k * omt * Math.Sin(omt));
                
                if (counter < pointsArray.Length)
                {
                    pointsArray[counter].X = (float)x;
                    pointsArray[counter].Y = (float)y;
                }
                else throw new Exception("Прoсти, медоед, я идиот. Передай мне, что тут говно");
                counter++;
            }

            counter = 0;
            if (save_into_file)
            {
                FileStream file_bin = File.OpenWrite("dots" + omega + "_" + k + "_" + start + "_" + numsek + ".bin");
                FileStream file_txt = File.OpenWrite("dots" + omega + "_" + k + "_" + start + "_" + numsek + ".txt");
                BinaryWriter br = new BinaryWriter(file_bin);
                StreamWriter sw = new StreamWriter(file_txt);

                for (double t = start; t < numsek; t += delta)
                {
                    br.Write(t);
                    br.Write(pointsArray[counter].X);
                    br.Write(pointsArray[counter].Y);
                    sw.Write(pointsArray[counter].X + " " + pointsArray[counter].Y + "\n");
                    counter++;
                }
                
                file_txt.Close();
                file_bin.Close();
            }

            return pointsArray;
        }
    }
}
