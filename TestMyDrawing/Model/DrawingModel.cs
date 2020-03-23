using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAC_Dll;
using System.IO;

namespace TestMyDrawing.Model
{
    public class DrawingModel
    {
        TableOfData data;
        FileStream crrStream;
        public DrawingModel()
        {

        }

        public string LoadData(string dataFilePath)
        {
            crrStream?.Close();
            FileInfo fl = new FileInfo(dataFilePath);
            data = new TableOfData(dataFilePath, fl.Name);
            crrStream = new FileStream(dataFilePath, FileMode.Open, FileAccess.ReadWrite);
            return data.Table_of_Function();
        }

        public string CreateNewFile(string pathToCreate)
        {
            DirectoryInfo di = Directory.CreateDirectory(pathToCreate);
            string txtName = pathToCreate + "\\" + di.Name + ".txt";
            crrStream = File.Create(txtName);
            return txtName;
        }
    }
}
