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
    public partial class FileUC : UserControl
    {
        public FileUC()
        {
            InitializeComponent();
        }

        private void btn_CreateNewFile_Click(object sender, EventArgs e)
        {
            MainForm.Instance.CreateFile(this, EventArgs.Empty);
        }

        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            MainForm.Instance.OpenFile(this, EventArgs.Empty);
        }

        private void btn_SaveFile_Click(object sender, EventArgs e)
        {
            MainForm.Instance.SaveFile(this, EventArgs.Empty);
        }

        private void btn_CloseCurrentFile_Click(object sender, EventArgs e)
        {
            MainForm.Instance.CloseCrrFile(this, EventArgs.Empty);
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            MainForm.Instance.PrintDiagram(this, EventArgs.Empty);
        }

        private void btn_Prev_Click(object sender, EventArgs e)
        {
            MainForm.Instance.ShowPreview(this, EventArgs.Empty);
        }
    }
}
