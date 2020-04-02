using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMyDrawing.ElementsOfStrip
{
    public partial class ServiceUC : UserControl
    {
        Timer timer;
        bool curveSettings = true;
        int step = 20;
        public ServiceUC()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (curveSettings)
            {
                if (MainForm.Instance.PnlCurvesSettings.Location.X > MainForm.Instance.cmbDotCurves.Location.X)
                {
                    MainForm.Instance.PnlCurvesSettings.Location = new Point(MainForm.Instance.PnlCurvesSettings.Location.X - step,
                        MainForm.Instance.PnlCurvesSettings.Location.Y);
                }
                else
                {
                    MainForm.Instance.PnlCurvesSettings.Location = MainForm.Instance.cmbDotCurves.Location;
                    timer.Stop();
                }
            }
            else
            {
                if (MainForm.Instance.PnlDiagramSettings.Location.X > MainForm.Instance.cmbDotCurves.Location.X)
                {
                    MainForm.Instance.PnlDiagramSettings.Location = new Point(MainForm.Instance.PnlDiagramSettings.Location.X - step,
                        MainForm.Instance.PnlDiagramSettings.Location.Y);
                }
                else
                {
                    MainForm.Instance.PnlDiagramSettings.Location = MainForm.Instance.cmbDotCurves.Location;
                    timer.Stop();
                }
            }
            
            
        }

        private void btn_CurveParams_Click(object sender, EventArgs e)
        {
            MainForm.Instance.PnlCurvesSettings.BringToFront();
            MainForm.Instance.btnBack.Visible = true;
            curveSettings = true;
            timer.Start();
           
        }

        private void btn_DiagrammParams_Click(object sender, EventArgs e)
        {
            MainForm.Instance.PnlDiagramSettings.BringToFront();
            MainForm.Instance.InitDiagramFields(this, EventArgs.Empty);
            MainForm.Instance.btnBack.Visible = true;
            curveSettings = false;
            timer.Start();
        }
    }
}
