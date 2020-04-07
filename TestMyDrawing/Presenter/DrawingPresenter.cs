using MyDrawing;
using MyDrawing.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
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

        PrintDialog printDialog;
        PrintDocument pd;
        PrintPreviewDialog ppd;

        public DrawingPresenter(IView _drawingView)
        {
            drawingView = _drawingView;
            _model = new DrawingModel();

            printDialog = new PrintDialog();
            pd = new PrintDocument();
            ppd = new PrintPreviewDialog();

            ppd.Document = pd;
            printDialog.Document = pd;

            pd.DefaultPageSettings.Landscape = true;
            pd.PrintPage += Pd_PrintPage;

            drawingView.graph.MouseEnter += (object o, EventArgs e) =>
            {
                if (drawingView.DrawState == DrawState.None)
                {
                    drawingView.graph.Cursor = Cursors.Default;
                }
                else
                {
                    drawingView.graph.Cursor = Cursors.Cross;
                }
            };
            drawingView.Print += (object o, EventArgs e) =>
            {
                if (printDialog.ShowDialog() == DialogResult.OK)
                    pd.Print();
            };
            drawingView.Preview += (object o, EventArgs e) => { ppd.ShowDialog(); };
            drawingView.LoadFile += DrawingView_LoadFile;
            drawingView.CreateNewFile += DrawingView_CreateNewFile;
            drawingView.SaveCreatedFile += DrawingView_SaveCreatedFile;
            drawingView.CloseFile += (bool b) =>
            {
                _model.crrStream?.Close();
                drawingView.CurrentFileName = "";
                drawingView.TableTxt = "";
                if (b == true)
                {
                    _model.gr.GraphCurves.Clear();
                    
                }
            };
            drawingView.InitGraphic += (object s, EventArgs e) =>
            {
               _model.Init(drawingView.graph);
                InitCurvesNames();
            };
            drawingView.PlotAction += DrawingView_PlotAction;
            drawingView.PlotMouseDown += (object o, MouseEventArgs e) =>
            {
                if (drawingView.DrawState == DrawState.None)
                {
                    drawingView.graph.Cursor = Cursors.SizeAll;
                    _model.PrimaryParamsInit(e.Location);
                }
                else
                {
                    _model.isDrawing = true;
                    _model.firstPt = e.Location;
                }
            };
            drawingView.PlotMouseUp += (object o, MouseEventArgs e) =>
            {
                if (drawingView.DrawState == DrawState.None)
                    drawingView.graph.Cursor = Cursors.Default;
                else
                {
                    _model.isDrawing = false;
                    _model.ApdateFiguresList();
                }
            };
            drawingView.ApdateCurvesList += DrawingView_PlotAction;
            drawingView.FillCurveFields += (string s) =>
            {
                foreach (Curves c in _model.gr.GraphCurves)
                {
                    if (c.Legend == s)
                    {
                        drawingView.CurveColor = c.CurveColor;
                        drawingView.DotsSettings = c.DotsType;
                        drawingView.Thikness = c.CurveThickness;

                        if (c.DashStyle == System.Drawing.Drawing2D.DashStyle.Dash)
                            drawingView.dashStyle = DashStyle.Dash;
                        else if (c.DashStyle == System.Drawing.Drawing2D.DashStyle.DashDot)
                            drawingView.dashStyle = DashStyle.DashDot;
                        else if (c.DashStyle == System.Drawing.Drawing2D.DashStyle.DashDotDot)
                            drawingView.dashStyle = DashStyle.DashDotDot;
                        else if (c.DashStyle == System.Drawing.Drawing2D.DashStyle.Dot)
                            drawingView.dashStyle = DashStyle.Dot;
                        else drawingView.dashStyle = DashStyle.Solid;
                    }
                }
            };
            drawingView.SetCurveColor += (object o, EventArgs e) =>
            {
                using (ColorDialog cd = new ColorDialog())
                {
                    cd.Color = drawingView.CurveColor;
                    DialogResult res = cd.ShowDialog();
                    if (res == DialogResult.OK)
                        drawingView.CurveColor = cd.Color;
                }
            };
            drawingView.ShowCurvePoints += (string s) => { drawingView.TableTxt = _model.ShowCurvePoints(s); };
            drawingView.AddNewCurve += DrawingView_PlotAction;
            drawingView.Zoom += DrawingView_PlotAction;
            drawingView.InitDiagramParams += (object s, EventArgs e) =>
            {
                drawingView.Title = _model.gr.Title;
                drawingView.TitlePos = _model.gr.TitlePosition;
                drawingView.TitleSize = _model.gr.TitleSize;

                drawingView.OXName = _model.gr.Config.OXName;
                drawingView.OXSize = _model.gr.Config.OXNameSize;
                drawingView.OXPos = _model.gr.Config.OXNamePosition;
                drawingView.OXPrice = _model.gr.Config.PriceForPointOX;

                drawingView.OYName = _model.gr.Config.OYName;
                drawingView.OYSize = _model.gr.Config.OYNameSize;
                drawingView.OYPos = _model.gr.Config.OYNamePosition;
                drawingView.OYPrice = _model.gr.Config.PriceForPointOY;

                drawingView.Grid = _model.gr.Config.Grid;
                drawingView.Smooth = _model.gr.Config.SmoothAngles;
            };
            drawingView.ApdateDiagramParams += (object s, EventArgs e) =>
            {
                _model.gr.Title = drawingView.Title;
                _model.gr.TitlePosition = drawingView.TitlePos;
                _model.gr.TitleSize = (int)drawingView.TitleSize;

                _model.gr.Config.OXName = drawingView.OXName;
                _model.gr.Config.OXNamePosition = drawingView.OXPos;
                _model.gr.Config.OXNameSize = drawingView.OXSize;
                _model.gr.Config.PriceForPointOX = drawingView.OXPrice;

                _model.gr.Config.OYName = drawingView.OYName;
                _model.gr.Config.OYNamePosition = drawingView.OYPos;
                _model.gr.Config.OYNameSize = drawingView.OYSize;
                _model.gr.Config.PriceForPointOY = drawingView.OYPrice;

                _model.gr.Config.Grid = drawingView.Grid;
                _model.gr.Config.SmoothAngles = drawingView.Smooth;
                
            };
            drawingView.DrawSpiral += (bool b) =>
            {
                PointF[] pt = _model.GenerateSpiral(drawingView.OmegaSpiral, drawingView.CoefSpiral, drawingView.StartSpiral, drawingView.LenghtSpiral, b);
                _model.ShowCreatedSpiral(pt);

            };
            drawingView.SpiralAction += (bool b) =>
            {
                _model.SpiralAction(b);
                if (b) InitCurvesNames();
            };
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Point pageCenter = new Point(e.PageBounds.Location.X + e.PageBounds.Width / 2, e.PageBounds.Location.Y + e.PageBounds.Height / 2);
            e.Graphics.DrawImage(_model.gr.placeToDraw.Image, pageCenter.X - _model.gr.placeToDraw.Width / 2, pageCenter.Y - _model.gr.placeToDraw.Height / 2);
        }

        private void DrawingView_PlotAction(object sender, GraphicEventArgs e)
        {
            if (e.EventType == EventType.ResizePlot)
                _model.ResizePlot(drawingView.graph);
            else if (e.EventType == EventType.MovePlot && drawingView.graph.Cursor == Cursors.SizeAll)
            {
                _model.RefreshPlotByMoving(e.mouseLocation);
            }
            else if (e.EventType == EventType.AdpdateCurve)
            {
                try
                {
                    _model.ApdateCurvesList(e.newCurve, e.Delete, e.NewName);
                    InitCurvesNames();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.EventType == EventType.AddNewCurve)
            {
                using (OpenFileDialog od = new OpenFileDialog())
                {
                    od.Filter = ".txt (*.txt)|*.txt";
                    if (od.ShowDialog() == DialogResult.Yes || od.FileName != "")
                    {
                        _model.LoadTXTData(od.FileName, e.SortValues);
                    }
                }
                InitCurvesNames();
            }
            else if (e.EventType == EventType.Zoom)
            {
                _model.ZoomPlot(e.Zoom);
            }
            else if (e.EventType == EventType.DrawFigure && _model.isDrawing)
            {
                Figure f;
                if (drawingView.DrawState == DrawState.Rectangle)
                {
                    f = new MyDrawing.Figures.Rectangle(_model.firstPt, e.mouseLocation);
                }
                else if (drawingView.DrawState == DrawState.Circle)
                {
                    f = new MyDrawing.Figures.Circle(_model.firstPt, e.mouseLocation);
                }
                else if (drawingView.DrawState == DrawState.Line)
                {
                    f = new MyDrawing.Figures.Line(_model.firstPt, e.mouseLocation);
                }
                else if (drawingView.DrawState == DrawState.Arrow)
                {
                    f = new MyDrawing.Figures.Arrow(_model.firstPt, e.mouseLocation);
                }
                else f = new MyDrawing.Figures.Text(_model.firstPt, "asfsdgsg");

                
                f.FillColor = drawingView.FillColor;
                f.StrokeColor = drawingView.StrokeColor;
                f.Smooth = drawingView.SmoothAngles;
                f.StrokeWidth = (int)drawingView.StrokeWidth;
                _model.crrFigure = f;
            }
        }

        private void InitCurvesNames()
        {
            string[] curvesNames = new string[_model.gr.GraphCurves.Count];
            int counter = 0;
            foreach (Curves c in _model.gr.GraphCurves)
            {
                curvesNames[counter] = c.Legend;
                counter++;
            }
            drawingView.CurvesNames = curvesNames;
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
                _model.LoadJSONData(name);
                drawingView.CurrentFileName = name;
                InitCurvesNames();
            }
            
        }
    }
}
