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
    public partial class ToolsUC : UserControl
    {
        Timer timer;
        int step = 20;
        public ToolsUC()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (MainForm.Instance.PnlSpiralSettings.Location.X > MainForm.Instance.cmbDotCurves.Location.X)
            {
                MainForm.Instance.PnlSpiralSettings.Location = new Point(MainForm.Instance.PnlSpiralSettings.Location.X - step,
                    MainForm.Instance.PnlSpiralSettings.Location.Y);
            }
            else
            {
                MainForm.Instance.PnlSpiralSettings.Location = MainForm.Instance.cmbDotCurves.Location;
                timer.Stop();
            }
        }

        private void btn_CreateSpiral_Click(object sender, EventArgs e)
        {
            MainForm.Instance.PnlSpiralSettings.BringToFront();
            MainForm.Instance.btnBack.Visible = true;
            timer.Start();
        }
    }
}
