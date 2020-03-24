using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMyDrawing
{
    public enum EventType
    {
        ResizePlot
    }
    public class GraphicEventArgs : EventArgs
    {
        public EventType EventType { get; set; }

        //параметры для изменения размеров области построения
        public int NewHeight { get; set; }
        public int NewWidth { get; set; }

        public GraphicEventArgs(EventType type)
        {
            EventType = type;
        }
    }
}
