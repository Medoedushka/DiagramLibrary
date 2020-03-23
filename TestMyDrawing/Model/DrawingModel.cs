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
        public string DataFilePath { get; set; }
        public string DataTableTxt { get; set; }

        public DrawingModel()
        {

        }

        public string LoadData(string dataFilePath)
        {
            FileInfo fl = new FileInfo(dataFilePath);
            data = new TableOfData(dataFilePath, fl.Name);
            return data.Table_of_Function();
        }
    }
}
