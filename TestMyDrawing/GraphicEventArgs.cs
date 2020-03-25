using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TestMyDrawing
{
    public enum EventType
    {
        ResizePlot, 
        MovePlot
    }
    public class GraphicEventArgs : EventArgs
    {
        public EventType EventType { get; set; }

        //Параметры для перемещения по графику
        public Point mouseLocation { get; set; }
        public GraphicEventArgs(EventType type)
        {
            EventType = type;
        }
    }
}
