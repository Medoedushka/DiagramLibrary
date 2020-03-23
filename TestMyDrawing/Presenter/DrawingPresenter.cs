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
