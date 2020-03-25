using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestMyDrawing.Model;
using TestMyDrawing.View;

namespace TestMyDrawing.Presenter
{
    public class DrawingPresenter
    {
        DrawingModel _model;
        IView drawingView;

        public DrawingPresenter(IView _drawingView)
        {
            drawingView = _drawingView;
            _model = new DrawingModel();
            drawingView.LoadFile += DrawingView_LoadFile;
            drawingView.CreateNewFile += DrawingView_CreateNewFile;
            drawingView.SaveCreatedFile += DrawingView_SaveCreatedFile;
            drawingView.CloseFile += () =>
            {
                _model.crrStream?.Close();
                drawingView.CurrentFileName = "";
                drawingView.TableTxt = "";
            };
            drawingView.InitGraphic += (object s, EventArgs e) =>
            {
               drawingView.TableTxt =  _model.Init(drawingView.graph);
            };
            drawingView.PlotAction += DrawingView_PlotAction;
            drawingView.PlotMouseDown += (object o, MouseEventArgs e) =>
            {
                _model.PrimaryParamsInit(e.Location);
                drawingView.graph.Cursor = Cursors.SizeAll;
            };
            drawingView.PlotMouseUp += (object o, MouseEventArgs e) => drawingView.graph.Cursor = Cursors.Default;
        }

        private void DrawingView_PlotAction(object sender, GraphicEventArgs e)
        {
            if (e.EventType == EventType.ResizePlot)
                _model.ResizePlot(drawingView.graph);
            else if (e.EventType == EventType.MovePlot && drawingView.graph.Cursor == Cursors.SizeAll)
            {
                _model.RefreshPlotByMoving(e.mouseLocation);
            }
        }

        private bool DrawingView_SaveCreatedFile()
        {
            if (drawingView.CurrentFileName != "")
            {
                _model.SaveFile();
                return true;
            }
            return false;
        }

        private void DrawingView_CreateNewFile(object sender, EventArgs e)
        {
            string pathToCreate = "";
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                DialogResult res = sf.ShowDialog();
                if (res == DialogResult.OK)
                    pathToCreate = sf.FileName;
            }
            if (pathToCreate != "")
            {
                drawingView.CurrentFileName = _model.CreateNewFile(pathToCreate);
            }
        }

        private void DrawingView_LoadFile(object sender, EventArgs e)
        {
            string name = "";
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                DialogResult res = fd.ShowDialog();
                if (res == DialogResult.OK)
                    name = fd.FileName;
            }
            if (name != "")
            {
                drawingView.TableTxt = _model.LoadData(name);
                drawingView.CurrentFileName = name;
            }
            
        }
    }
}
