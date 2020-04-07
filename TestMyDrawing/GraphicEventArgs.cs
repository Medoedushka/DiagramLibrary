using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDrawing;
using MyDrawing.Figures;
using System.Drawing;

namespace TestMyDrawing
{
    public enum EventType
    {
        ResizePlot, 
        MovePlot, 
        AdpdateCurve, 
        AddNewCurve,
        Zoom, 
        DrawFigure
    }
    public class GraphicEventArgs : EventArgs
    {
        public EventType EventType { get; set; }

        //Параметры для перемещения по графику
        public Point mouseLocation { get; set; }

        //Параметры для обновления кривой
        public Curves newCurve { get; set; }
        public bool Delete { get; set; } = false;
        public string NewName { get; set; }

        //Параметры для добавления новой кривой
        public bool SortValues { get; set; } = true;

        //Параметры для масштабирования графика
        public bool Zoom { get; set; }

        //Параметр для рисования фигуры
        public Figure figure { get; set; }

        public GraphicEventArgs(EventType type)
        {
            EventType = type;
        }
    }
}
