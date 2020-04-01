using System;
using System.IO;
using System.Drawing;
using MyDrawing;
using MAC_Dll;
using System.Windows.Forms;
using TestMyDrawing.View;
using TestMyDrawing.ElementsOfStrip;
using System.Drawing.Text;

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
        public event Action<string> ShowCurvePoints;
        public event EventHandler<GraphicEventArgs> AddNewCurve;
        public event EventHandler<GraphicEventArgs> Zoom;
        public event EventHandler<EventArgs> Print;
        public event EventHandler<EventArgs> Preview;


        public string TableTxt { get => rtb_TableTxt.Text; set => rtb_TableTxt.Text = value; }
        public string CurrentFileName { get => lbl_CurrentFile.Text; set => lbl_CurrentFile.Text = value; }
        public PictureBox graph { get; set; }
        public bool MousePressed { get; set; } = false;

        public string[] CurvesNames
        {
            get => new string[] { cmb_Curves.Items.ToString() }; set
            {
                cmb_Curves.Items.Clear(); cmb_Curves.Items.AddRange(value);
                cmb_CurvesDots.Items.Clear(); cmb_CurvesDots.Items.AddRange(value);
            }
        }
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

        static MainForm _obj;
        public static MainForm Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new MainForm();
                }
                return _obj;
            }
        }
        public Panel PnlCurvesSettings
        {
            get { return pnl_CurveSettings; }
        }
        public ComboBox cmbDotCurves
        {
            get { return cmb_CurvesDots; }
        }
        public Button btnBack
        {
            get { return btn_Back; }
        }

        Color lblChecked = Color.FromArgb(9, 154, 185);
        Color lblFree = Color.FromArgb(5, 89, 107);
        Color controlEnter = Color.FromArgb(177, 34, 207, 244);

        public MainForm()
        {
            InitializeComponent();
            _obj = this;
            graph = pictureBox1;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            lbl_File_Click(this, EventArgs.Empty);
            InitGraphic?.Invoke(this, EventArgs.Empty);
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            PlotAction?.Invoke(this, new GraphicEventArgs(EventType.ResizePlot));
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                PlotAction?.Invoke(this, new GraphicEventArgs(EventType.ResizePlot));
            }
        }

        #region<---Обработка ленты-->
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

        private void pcb_CloseApp_MouseLeave(object sender, EventArgs e)
        {
            pcb_CloseApp.BackColor = lblFree;
        }
        private void pcb_CloseApp_MouseEnter(object sender, EventArgs e)
        {
            pcb_CloseApp.BackColor = controlEnter;
        }
        private void pcb_CloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool workArea = true;
        private void pcb_Normalize_Click(object sender, EventArgs e)
        {
            if (workArea)
            {
                pcb_Normalize.BackgroundImage = Properties.Resources.maximize;
                this.Size = new Size(800, 600);
                this.Location = new Point(this.Location.X + (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                    this.Location.Y + (Screen.PrimaryScreen.WorkingArea.Height - this.Height / 2)/ 2);
                workArea = false;
            }
            else
            {
                pcb_Normalize.BackgroundImage = Properties.Resources.normalize;
                this.Location = Screen.PrimaryScreen.WorkingArea.Location;
                this.Size = this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                workArea = true;
            }
        }
        private void pcb_Normalize_MouseEnter(object sender, EventArgs e)
        {
            pcb_Normalize.BackColor = controlEnter;
        }
        private void pcb_Normalize_MouseLeave(object sender, EventArgs e)
        {
            pcb_Normalize.BackColor = lblFree;
        }

        private void pcb_Minimize_MouseEnter(object sender, EventArgs e)
        {
            pcb_Minimize.BackColor = controlEnter;
        }
        private void pcb_Minimize_MouseLeave(object sender, EventArgs e)
        {
            pcb_Minimize.BackColor = lblFree;
        }
        private void pcb_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lbl_File_MouseLeave(object sender, EventArgs e)
        {
            if (lbl_File.BackColor != lblChecked)
                lbl_File.BackColor = lblFree;
        }
        private void lbl_File_MouseEnter(object sender, EventArgs e)
        {
            if (lbl_File.BackColor != lblChecked)
                lbl_File.BackColor = controlEnter;
        }

        private void lbl_Service_MouseEnter(object sender, EventArgs e)
        {
            if (lbl_Service.BackColor != lblChecked)
                lbl_Service.BackColor = controlEnter;
        }
        private void lbl_Service_MouseLeave(object sender, EventArgs e)
        {
            if (lbl_Service.BackColor != lblChecked)
                lbl_Service.BackColor = lblFree;
        }

        private void lbl_Edit_MouseEnter(object sender, EventArgs e)
        {
            if (lbl_Edit.BackColor != lblChecked)
                lbl_Edit.BackColor = controlEnter;
        }
        private void lbl_Edit_MouseLeave(object sender, EventArgs e)
        {
            if (lbl_Edit.BackColor != lblChecked)
                lbl_Edit.BackColor = lblFree;
        }
        #endregion
        
        #region<---Элементы ленты "Файл"--->
        public void OpenFile(object sender, EventArgs e)
        {
            LoadFile?.Invoke(this, EventArgs.Empty);
        }
        public void CreateFile(object sender, EventArgs e)
        {
            CreateNewFile?.Invoke(this, EventArgs.Empty);
        }
        public void SaveFile(object sender, EventArgs e)
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
        public void CloseCrrFile(object sender, EventArgs e)
        {
            CloseFile?.Invoke();
        }
        public void PrintDiagram(object sender, EventArgs e)
        {
            Print?.Invoke(this, EventArgs.Empty);
        }
        public void ShowPreview(object sender, EventArgs e)
        {
            Preview?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_Back_Click(object sender, EventArgs e)
        {

            pnl_CurveSettings.Location = new Point(this.Width + 10, pnl_CurveSettings.Location.Y);
            btn_Back.Visible = false;
        }


        public void ZoomIn(object sender, EventArgs e)
        {
            GraphicEventArgs graphicEvent = new GraphicEventArgs(EventType.Zoom);
            graphicEvent.Zoom = true;
            Zoom?.Invoke(this, graphicEvent);
        }

        public void ZoomOut(object sender, EventArgs e)
        {
            GraphicEventArgs graphicEvent = new GraphicEventArgs(EventType.Zoom);
            graphicEvent.Zoom = false;
            Zoom?.Invoke(this, graphicEvent);
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

            Curves newCurve = new Curves(new PointF[] { }, pcb_CurveColor.BackColor, style, (int)nud_Thickness.Value, cmb_Curves.Text, txb_DotsString.Text);
            GraphicEventArgs graphicEvent = new GraphicEventArgs(EventType.AdpdateCurve);
            graphicEvent.newCurve = newCurve;
            graphicEvent.Delete = false;
            if (txb_CurveLegend.Text != "") graphicEvent.NewName = txb_CurveLegend.Text;
            ApdateCurvesList?.Invoke(this, graphicEvent);

            cmb_Curves.Text = "";
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
            Curves newCurve = new Curves(new PointF[] { }, pcb_CurveColor.BackColor, CurveThickness: (int)nud_Thickness.Value, Legend: cmb_Curves.Text, dotsType: txb_DotsString.Text);
            GraphicEventArgs graphicEvent = new GraphicEventArgs(EventType.AdpdateCurve);
            graphicEvent.newCurve = newCurve;
            graphicEvent.Delete = true;
            ApdateCurvesList?.Invoke(this, graphicEvent);

            cmb_Curves.Text = "";
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

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
                ZoomIn(this, EventArgs.Empty);
            if (e.Control && e.KeyCode == Keys.X)
                ZoomOut(this, EventArgs.Empty);
        }

        
    }
}
