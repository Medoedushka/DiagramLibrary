using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TestMyDrawing.View
{
    public interface IView
    {
        string TableTxt { get; set; }
        string CurrentFileName { get; set; }
        bool MousePressed { get; set; }
        PictureBox graph { get; set; }

        //свойства, относящиеся к редактированию кривой
        string[] CurvesNames { get; set; }
        Color CurveColor { get; set; }
        string DotsSettings { get; set; }
        int Thikness { get; set; }

        event EventHandler<EventArgs> CreateNewFile;
        event Func<bool> SaveCreatedFile;
        event Action CloseFile;
        event EventHandler<EventArgs> LoadFile;
        event EventHandler<EventArgs> InitGraphic;
        event EventHandler<GraphicEventArgs> PlotAction;
        event EventHandler<MouseEventArgs> PlotMouseDown;
        event EventHandler<MouseEventArgs> PlotMouseUp;
        event EventHandler<GraphicEventArgs> ApdateCurvesList;
        event Action<string> FillCurveFields;
        event EventHandler<EventArgs> SetCurveColor;
        event Action<string> ShowCurvePoints;
        event EventHandler<GraphicEventArgs> AddNewCurve;
        event EventHandler<GraphicEventArgs> Zoom;
        event EventHandler<EventArgs> Print;
        event EventHandler<EventArgs> Preview;
    }
}
