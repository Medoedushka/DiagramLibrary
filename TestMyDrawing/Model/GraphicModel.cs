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

        public void Init(PictureBox picture)
        {
            gr = new PointsGraphic(picture);
            gr.DrawDiagram();
        }
    }
}
