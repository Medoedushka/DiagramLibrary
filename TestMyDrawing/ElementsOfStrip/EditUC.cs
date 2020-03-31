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
    public partial class EditUC : UserControl
    {
        public EditUC()
        {
            InitializeComponent();
        }

        private void btn_ZoomIn_Click(object sender, EventArgs e)
        {
            MainForm.Instance.ZoomIn(this, EventArgs.Empty);
        }

        private void btn_ZoomOut_Click(object sender, EventArgs e)
        {
            MainForm.Instance.ZoomOut(this, EventArgs.Empty);
        }
    }
}
