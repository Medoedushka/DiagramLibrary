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
        public event EventHandler<GraphicEventArgs> ApdateCurvesList;
        public event Action<string> FillCurveFields;
        public event EventHandler<EventArgs> SetCurveColor;

        public MainForm()
        {
            InitializeComponent();
            graph = pictureBox1;
        }

        public string TableTxt { get => rtb_TableTxt.Text; set => rtb_TableTxt.Text = value; }
        public string CurrentFileName { get => lbl_CurrentFile.Text; set => lbl_CurrentFile.Text = value; }
        public PictureBox graph { get; set; }
        public bool MousePressed { get; set; } = false;

        public string[] CurvesNames { get => new string[] { cmb_Curves.Items.ToString() }; set { cmb_Curves.Items.Clear(); cmb_Curves.Items.AddRange(value); } }
        public Color CurveColor { get => pcb_CurveColor.BackColor; set => pcb_CurveColor.BackColor = value; }
        public string DotsSettings { get => txb_DotsString.Text; set => txb_DotsString.Text = value; }
        public int Thikness { get => (int)nud_Thickness.Value; set => nud_Thickness.Value = value; }

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

        private void btn_RefreshCurve_Click(object sender, EventArgs e)
        {
            Curves newCurve = new Curves(new PointF[] { }, pcb_CurveColor.BackColor, (int)nud_Thickness.Value, cmb_Curves.Text, txb_DotsString.Text);
            GraphicEventArgs graphicEvent = new GraphicEventArgs(EventType.AdpdateCurve);
            graphicEvent.newCurve = newCurve;
            graphicEvent.Delete = false;
            if (txb_CurveLegend.Text != "") graphicEvent.NewName = txb_CurveLegend.Text;
            ApdateCurvesList?.Invoke(this, graphicEvent);
            
            cmb_Curves.SelectedItem = null;
            txb_CurveLegend.Text = "";
            pcb_CurveColor.BackColor = Color.Transparent;
            txb_DotsString.Text = "";
            nud_Thickness.Value = 1;
        }

        private void cmb_Curves_TextChanged(object sender, EventArgs e)
        {
            txb_CurveLegend.Text = cmb_Curves.Text;
            FillCurveFields?.Invoke(cmb_Curves.Text);
        }

        private void btn_DeleteCurve_Click(object sender, EventArgs e)
        {
            Curves newCurve = new Curves(new PointF[] { }, pcb_CurveColor.BackColor, (int)nud_Thickness.Value, cmb_Curves.Text, txb_DotsString.Text);
            GraphicEventArgs graphicEvent = new GraphicEventArgs(EventType.AdpdateCurve);
            graphicEvent.newCurve = newCurve;
            graphicEvent.Delete = true;
            ApdateCurvesList?.Invoke(this, graphicEvent);
        }

        private void brn_SetCurveColor_Click(object sender, EventArgs e)
        {
            SetCurveColor?.Invoke(this, EventArgs.Empty);
        }
    }
}
