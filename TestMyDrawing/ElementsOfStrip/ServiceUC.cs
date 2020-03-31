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
        public ServiceUC()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            while (MainForm.Instance.PnlCurvesSettings.Location.X > MainForm.Instance.cmbDotCurves.Location.X)
            {
                MainForm.Instance.PnlCurvesSettings.Location = new Point(MainForm.Instance.PnlCurvesSettings.Location.X - 10,
                    MainForm.Instance.PnlCurvesSettings.Location.Y);
            }
            MainForm.Instance.PnlCurvesSettings.Location = MainForm.Instance.cmbDotCurves.Location;
            timer.Stop();
            
        }

        private void btn_CurveParams_Click(object sender, EventArgs e)
        {
            MainForm.Instance.btnBack.Visible = true;
            timer.Start();
           
        }
    }
}
