using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MAC_Dll;
using System.IO;

namespace TestMyDrawing.Model
{
    public class DrawingModel
    {
        TableOfData data;
        FileStream crrStream;
        PointF[] crrPoints;

        public DrawingModel()
        {
            
        }

        public string LoadData(string dataFilePath)
        {
            crrStream?.Close();
            FileInfo fl = new FileInfo(dataFilePath);
            data = new TableOfData(dataFilePath, fl.Name);
            crrStream = new FileStream(dataFilePath, FileMode.Open, FileAccess.ReadWrite);

            crrPoints = new PointF[data.Length];
            for(int  i = 0; i < crrPoints.Length; i++)
            {
                crrPoints[i].X = (float)data.Points[i].X;
                crrPoints[i].Y = (float)data.Points[i].F;
            }

            return data.Table_of_Function();
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
