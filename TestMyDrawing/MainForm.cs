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
        public event EventHandler<EventArgs> LoadFile;
        public event Action CloseFile;
        public event EventHandler<EventArgs> InitGraphic;
        public event EventHandler<GraphicEventArgs> PlotAction;
        public event EventHandler<MouseEventArgs> PlotMouseDown;
        public event EventHandler<MouseEventArgs> PlotMouseUp;

        public MainForm()
        {
            InitializeComponent();
            graph = pictureBox1;
        }

        public string TableTxt { get => rtb_TableTxt.Text; set => rtb_TableTxt.Text = value; }
        public string CurrentFileName { get => lbl_CurrentFile.Text; set => lbl_CurrentFile.Text = value; }
        public PictureBox graph { get; set; }
        public bool MousePressed { get; set; } = false;

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

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseFile?.Invoke();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть приложение?", "Закрыть",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitGraphic?.Invoke(this, EventArgs.Empty);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            PlotAction?.Invoke(this, new GraphicEventArgs(EventType.ResizePlot));
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            PlotMouseDown?.Invoke(this, e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            GraphicEventArgs eventArgs = new GraphicEventArgs(EventType.MovePlot);
            eventArgs.mouseLocation = e.Location;
            PlotAction?.Invoke(this, eventArgs);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            PlotMouseUp?.Invoke(this, e);
        }
    }
}
