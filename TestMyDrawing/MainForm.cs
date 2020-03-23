using System;
using System.IO;
using System.Drawing;
using MyDrawing;
using MAC_Dll;
using System.Windows.Forms;
using TestMyDrawing.View;

namespace TestMyDrawing
{
    public partial class MainForm : Form, IView
    {
        public event EventHandler<EventArgs> CreateNewFile;
        public event Func<bool> SaveCreatedFile;
        public event EventHandler<EventArgs> SaveAS;
        public event EventHandler<EventArgs> LoadFile;
        public event EventHandler<EventArgs> Exit;

        public MainForm()
        {
            InitializeComponent();
            
           
        }

        public string TableTxt { get => rtb_TableTxt.Text; set => rtb_TableTxt.Text = value; }
        public string CurrentFileName { get => lbl_CurrentFile.Text; set => lbl_CurrentFile.Text = value; }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile?.Invoke(this, EventArgs.Empty);
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewFile?.Invoke(this, EventArgs.Empty);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool? b = SaveCreatedFile?.Invoke();
            if (b == true)
                MessageBox.Show("Файл успешно сохранён!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
