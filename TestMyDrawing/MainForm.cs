using System;
using System.IO;
using System.Drawing;
using MyDrawing;
using MAC_Dll;
using System.Windows.Forms;
using TestMyDrawing.View;
using TestMyDrawing.ElementsOfStrip;

namespace TestMyDrawing
{
    public partial class MainForm : Form
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
        public event Action<string> ShowCurvePoints;
        public event EventHandler<GraphicEventArgs> AddNewCurve;
        public event EventHandler<GraphicEventArgs> Zoom;
        public event EventHandler<EventArgs> Print;
        public event EventHandler<EventArgs> Preview;

        Color lblChecked = Color.FromArgb(5, 89, 107);
        Color lblFree = Color.FromArgb(9, 154, 185);

        public MainForm()
        {
            InitializeComponent();
            //graph = pictureBox1;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbl_File_Click(object sender, EventArgs e)
        {
            lbl_Service.BackColor = lblFree;
            lbl_Edit.BackColor = lblFree;
            lbl_File.BackColor = lblChecked;
            if (!pnl_StripElements.Controls.ContainsKey("FileUC"))
            {
                FileUC uc = new FileUC();
                uc.Dock = DockStyle.Fill;
                uc.BackColor = lblChecked;
                pnl_StripElements.Controls.Add(uc);
            }
            pnl_StripElements.Controls["FileUC"].BringToFront();
        }

        private void lbl_Service_Click(object sender, EventArgs e)
        {
            lbl_File.BackColor = lblFree;
            lbl_Edit.BackColor = lblFree;
            lbl_Service.BackColor = lblChecked;
            if (!pnl_StripElements.Controls.ContainsKey("ServiceUC"))
            {
                ServiceUC uc = new ServiceUC();
                uc.Dock = DockStyle.Fill;
                uc.BackColor = lblChecked;
                pnl_StripElements.Controls.Add(uc);
            }
            pnl_StripElements.Controls["ServiceUC"].BringToFront();
        }

        private void lbl_Edit_Click(object sender, EventArgs e)
        {
            lbl_File.BackColor = lblFree;
            lbl_Service.BackColor = lblFree;
            lbl_Edit.BackColor = lblChecked;
            if (!pnl_StripElements.Controls.ContainsKey("EditUC"))
            {
                EditUC uc = new EditUC();
                uc.Dock = DockStyle.Fill;
                uc.BackColor = lblChecked;
                pnl_StripElements.Controls.Add(uc);
            }
            pnl_StripElements.Controls["EditUC"].BringToFront();
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = lblFree;
        }
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(177, 5, 89, 107);
        }

        private void lbl_File_MouseLeave(object sender, EventArgs e)
        {
            if (lbl_File.BackColor != lblChecked)
                lbl_File.BackColor = lblFree;
        }
        private void lbl_File_MouseEnter(object sender, EventArgs e)
        {
            if (lbl_File.BackColor != lblChecked)
                lbl_File.BackColor = Color.FromArgb(177, 5, 89, 107);
        }

        private void lbl_Service_MouseEnter(object sender, EventArgs e)
        {
            if (lbl_Service.BackColor != lblChecked)
                lbl_Service.BackColor = Color.FromArgb(177, 5, 89, 107);
        }
        private void lbl_Service_MouseLeave(object sender, EventArgs e)
        {
            if (lbl_Service.BackColor != lblChecked)
                lbl_Service.BackColor = lblFree;
        }

        private void lbl_Edit_MouseEnter(object sender, EventArgs e)
        {
            if (lbl_Edit.BackColor != lblChecked)
                lbl_Edit.BackColor = Color.FromArgb(177, 5, 89, 107);
        }

        private void lbl_Edit_MouseLeave(object sender, EventArgs e)
        {
            if (lbl_Edit.BackColor != lblChecked)
                lbl_Edit.BackColor = lblFree;
        }
        /*
public string TableTxt { get => rtb_TableTxt.Text; set => rtb_TableTxt.Text = value; }
public string CurrentFileName { get => lbl_CurrentFile.Text; set => lbl_CurrentFile.Text = value; }
public PictureBox graph { get; set; }
public bool MousePressed { get; set; } = false;

public string[] CurvesNames { get => new string[] { cmb_Curves.Items.ToString() }; set {
cmb_Curves.Items.Clear(); cmb_Curves.Items.AddRange(value);
cmb_CurvesDots.Items.Clear(); cmb_CurvesDots.Items.AddRange(value);
} }
public Color CurveColor { get => pcb_CurveColor.BackColor; set => pcb_CurveColor.BackColor = value; }
public string DotsSettings { get => txb_DotsString.Text; set => txb_DotsString.Text = value; }
public int Thikness { get => (int)nud_Thickness.Value; set => nud_Thickness.Value = value; }
public DashStyle dashStyle
{
get => dashStyle; set
{
if (value == DashStyle.Dash)
{
rb_Dash.Checked = true;
rb_DashDot.Checked = false;
rb_DashDotDot.Checked = false;
rb_Dot.Checked = false;
rb_Solid.Checked = false;
}
else if (value == DashStyle.DashDot)
{
rb_Dash.Checked = false;
rb_DashDot.Checked = true;
rb_DashDotDot.Checked = false;
rb_Dot.Checked = false;
rb_Solid.Checked = false;
}
else if (value == DashStyle.DashDotDot)
{
rb_Dash.Checked = false;
rb_DashDot.Checked = false;
rb_DashDotDot.Checked = true;
rb_Dot.Checked = false;
rb_Solid.Checked = false;
}
else if (value == DashStyle.Dot)
{
rb_Dash.Checked = false;
rb_DashDot.Checked = false;
rb_DashDotDot.Checked = false;
rb_Dot.Checked = true;
rb_Solid.Checked = false;
}
else
{
rb_Dash.Checked = false;
rb_DashDot.Checked = false;
rb_DashDotDot.Checked = false;
rb_Dot.Checked = false;
rb_Solid.Checked = true;
}
}
}

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
{
if (MessageBox.Show("Файл успешно сохранён! Желаете просмотреть файлы?", 
"Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
{
string dirOpen = lbl_CurrentFile.Text.Remove(lbl_CurrentFile.Text.LastIndexOf("\\"));
System.Diagnostics.Process.Start(dirOpen);
}
}
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
System.Drawing.Drawing2D.DashStyle style;
if (rb_Dash.Checked)
style = System.Drawing.Drawing2D.DashStyle.Dash;
else if (rb_DashDot.Checked)
style = System.Drawing.Drawing2D.DashStyle.DashDot;
else if (rb_DashDotDot.Checked)
style = System.Drawing.Drawing2D.DashStyle.DashDotDot;
else if (rb_Dot.Checked)
style = System.Drawing.Drawing2D.DashStyle.Dot;
else style = System.Drawing.Drawing2D.DashStyle.Solid;

Curves newCurve = new Curves(new PointF[] { }, pcb_CurveColor.BackColor, style, (int)nud_Thickness.Value ,cmb_Curves.Text, txb_DotsString.Text);
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
Curves newCurve = new Curves(new PointF[] { }, pcb_CurveColor.BackColor, CurveThickness:(int)nud_Thickness.Value,Legend:cmb_Curves.Text, dotsType: txb_DotsString.Text);
GraphicEventArgs graphicEvent = new GraphicEventArgs(EventType.AdpdateCurve);
graphicEvent.newCurve = newCurve;
graphicEvent.Delete = true;
ApdateCurvesList?.Invoke(this, graphicEvent);

cmb_Curves.SelectedItem = null;
txb_CurveLegend.Text = "";
pcb_CurveColor.BackColor = Color.Transparent;
txb_DotsString.Text = "";
nud_Thickness.Value = 1;
}

private void brn_SetCurveColor_Click(object sender, EventArgs e)
{
SetCurveColor?.Invoke(this, EventArgs.Empty);
}

private void cmb_CurvesDots_SelectedIndexChanged(object sender, EventArgs e)
{
ShowCurvePoints?.Invoke(cmb_CurvesDots.Text);
}

private void btn_AddNewCurve_Click(object sender, EventArgs e)
{
GraphicEventArgs graphicEvent = new GraphicEventArgs(EventType.AddNewCurve);
if (MessageBox.Show("Отсортировать данные в файле по возрастанию аргумента?", "Добавление кривой", MessageBoxButtons.YesNo,
MessageBoxIcon.Question) == DialogResult.Yes)
graphicEvent.SortValues = true;
else graphicEvent.SortValues = false;

AddNewCurve?.Invoke(this, graphicEvent);
}

private void отменадействияToolStripMenuItem_Click(object sender, EventArgs e)
{
GraphicEventArgs graphicEvent = new GraphicEventArgs(EventType.Zoom);
graphicEvent.Zoom = true;
Zoom?.Invoke(this, graphicEvent);
}

private void отменадействияToolStripMenuItem1_Click(object sender, EventArgs e)
{
GraphicEventArgs graphicEvent = new GraphicEventArgs(EventType.Zoom);
graphicEvent.Zoom = false;
Zoom?.Invoke(this, graphicEvent);
}

private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
{
Print?.Invoke(this, EventArgs.Empty);
}

private void предварительныйПросмотрToolStripMenuItem_Click(object sender, EventArgs e)
{
Preview?.Invoke(this, EventArgs.Empty);
}
*/
    }
}
