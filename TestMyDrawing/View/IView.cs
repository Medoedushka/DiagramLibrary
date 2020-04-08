using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using MyDrawing;

namespace TestMyDrawing.View
{
    public enum DashStyle
    {
        Dash,
        DashDot,
        DashDotDot,
        Dot, 
        Solid
    }
    public enum DrawState
    {
        None,
        Rectangle,
        Circle,
        Line,
        Arrow,
        Text
    }
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
        DashStyle dashStyle { get; set; }

        // Свойства, относящиеся к редактированию диаграммы
        bool Grid { get; set; }
        bool Smooth { get; set; }
        //
        //Свойства заголовка
        //
        string Title { get; set; }
        TextPosition TitlePos { get; set; }
        double TitleSize { get; set; }
        //
        //Свойства оси абсцисс
        //
        string  OXName { get; set; }
        TextPosition OXPos { get; set; }
        double OXSize { get; set; }
        double OXPrice { get; set; }
        //
        //Свойства оси ординат
        //
        string OYName { get; set; }
        TextPosition OYPos { get; set; }
        double OYSize { get; set; }
        double OYPrice { get; set; }

        //Свойства для генерации спирали
        int StartSpiral { get; set; }
        int LenghtSpiral { get; set; }
        double OmegaSpiral { get; set; }
        double CoefSpiral { get; set; }
        bool SaveToFile { get; set; }

        //Свойства фигур
        DrawState DrawState { get; set; }
        Color FillColor { get; set; }
        Color StrokeColor { get; set; }
        bool SmoothAngles { get; set; }
        double StrokeWidth { get; set; }
        bool EnableDeleteFigure { get; set; }
        bool EnableApdateFigure { get; set; }
        //
        // Свойства текста
        //
        Font LableFont { get; set; }
        Color LableColor { get; set; }
        Color LableBackColor { get; set; }
        string LableValue { get; set; }

        event EventHandler<EventArgs> ApdateFigure;
        event EventHandler<EventArgs> DeleteFigure;
        event EventHandler<EventArgs> CreateNewFile;
        event Func<bool> SaveCreatedFile;
        event Action<bool> CloseFile;
        event EventHandler<EventArgs> LoadFile;
        event EventHandler<EventArgs> InitGraphic;
        event EventHandler<EventArgs> InitDiagramParams;
        event EventHandler<EventArgs> ApdateDiagramParams;
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
        event Action<bool> DrawSpiral;
        event Action<bool> SpiralAction;

        bool ValidateSpiralParams();
    }
}
