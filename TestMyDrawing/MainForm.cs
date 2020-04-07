using System;
using System.IO;
using System.Drawing;
using MyDrawing;
using MAC_Dll;
using System.Windows.Forms;
using TestMyDrawing.View;
using TestMyDrawing.ElementsOfStrip;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace TestMyDrawing
{
    public partial class MainForm : Form, IView
    {
        // Код, позволяющий перемещать плоское окно.
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool ReleaseCapture();
        const uint WM_SYSCOMMAND = 0x0112;
        const uint DOMOVE = 0xF012;
        const uint DOSIZE = 0xF008;

        #region<---События формы--->
        public event EventHandler<EventArgs> CreateNewFile;
        public event Func<bool> SaveCreatedFile;
        public event EventHandler<EventArgs> LoadFile;
        public event Action<bool> CloseFile;
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
        public event EventHandler<EventArgs> InitDiagramParams;
        public event EventHandler<EventArgs> ApdateDiagramParams;
        public event Action<bool> DrawSpiral;
        public event Action<bool> SpiralAction;
        #endregion
        #region<---Свойства для изменения параметров кривой--->
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
        public string DotsSettings
        {
            get
            {
                if (chb_ShowDots.Checked)
                {
                    string dotsType = "";
                    Color color = pcb_DotColor.BackColor;

                    string type = "";
                    if (cmb_DotType.Text == cmb_DotType.Items[0].ToString())
                        type = "c";
                    else if (cmb_DotType.Text == cmb_DotType.Items[1].ToString())
                        type = "t";
                    else if (cmb_DotType.Text == cmb_DotType.Items[2].ToString())
                        type = "s";
                    else if (cmb_DotType.Text == cmb_DotType.Items[3].ToString())
                        type = "r";
                    else if (cmb_DotType.Text == cmb_DotType.Items[4].ToString())
                        type = "st";
                    int v = 0;
                    if (txb_DotSize.Text != "d")
                    {
                        if (!int.TryParse(txb_DotSize.Text, out v))
                            throw new FormatException("Введённый размер точки не соответствует требуемому формату.");
                        else if (int.Parse(txb_DotSize.Text) > 20)
                            throw new ArgumentOutOfRangeException("Введёное значение размера точки превышает максимально допустимое значение(20).", new Exception());
                    }
                        

                   dotsType = String.Format($"[{color.R},{color.G},{color.B}]-{type}-{(chb_FillDot.Checked ? true : false)}-{txb_DotSize.Text}");
                    dotsType = dotsType.Replace("True", "t");
                    dotsType = dotsType.Replace("False", "f");
                    return dotsType;
                }
                else return "";
            }
            set
            {
                if (value == "")
                {
                    chb_ShowDots.Checked = false;
                }
                else
                {
                    chb_ShowDots.Checked = true;

                    string[] el = value.Split('-');
                    el[0] = el[0].Remove(0, 1).Remove(el[0].Length - 2, 1);
                    string[] rgb = el[0].Split(',');
                    Color color = Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
                    pcb_DotColor.BackColor = color;

                    if (el[1] == "c")
                        cmb_DotType.Text = cmb_DotType.Items[0].ToString();
                    else if (el[1] == "t")
                        cmb_DotType.Text = cmb_DotType.Items[1].ToString();
                    else if (el[1] == "s")
                        cmb_DotType.Text = cmb_DotType.Items[2].ToString();
                    else if (el[1] == "r")
                        cmb_DotType.Text = cmb_DotType.Items[3].ToString();
                    else if (el[1] == "st")
                        cmb_DotType.Text = cmb_DotType.Items[4].ToString();

                    if (el[2] == "t")
                        chb_FillDot.Checked = true;
                    else if (el[2] == "f")
                        chb_FillDot.Checked = false;

                    txb_DotSize.Text = el[3];
                }
            }
        }
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
        #endregion
        #region<---Свойства для изменения параметров диаграммы--->
        public bool Grid { get => chb_Grid.Checked; set => chb_Grid.Checked = value; }
        public bool Smooth { get => chb_Smooth.Checked; set => chb_Smooth.Checked = value; }
        public string Title { get => txb_Title.Text; set => txb_Title.Text = value; }
        public TextPosition TitlePos
        {
            get
            {
                if (cmb_TitlePos.Text == cmb_TitlePos.Items[0].ToString())
                    return TextPosition.Right;
                else if (cmb_TitlePos.Text == cmb_TitlePos.Items[1].ToString())
                    return TextPosition.Left;
                else return TextPosition.Centre;
            }
            set
            {
                if (value == TextPosition.Right)
                    cmb_TitlePos.Text = cmb_TitlePos.Items[0].ToString();
                else if (value == TextPosition.Left)
                    cmb_TitlePos.Text = cmb_TitlePos.Items[1].ToString();
                else cmb_TitlePos.Text = cmb_TitlePos.Items[2].ToString();
            }
        }
        public double TitleSize { get => (double)nud_TitleSize.Value; set => nud_TitleSize.Value = (decimal)value; }
        public string OXName { get => txb_OXName.Text; set => txb_OXName.Text = value; }
        public TextPosition OXPos
        {
            get
            {
                if (cmb_OXPos.Text == cmb_OXPos.Items[0].ToString())
                    return TextPosition.Right;
                else if (cmb_OXPos.Text == cmb_OXPos.Items[1].ToString())
                    return TextPosition.Left;
                else return TextPosition.Centre;
            }
            set
            {
                if (value == TextPosition.Right)
                    cmb_OXPos.Text = cmb_OXPos.Items[0].ToString();
                else if (value == TextPosition.Left)
                    cmb_OXPos.Text = cmb_OXPos.Items[1].ToString();
                else cmb_OXPos.Text = cmb_OXPos.Items[2].ToString();
            }
        }
        public double OXSize { get => (double)nud_OXSize.Value; set => nud_OXSize.Value = (decimal)value; }
        public double OXPrice { get => double.Parse(txb_OXPrice.Text); set => txb_OXPrice.Text = value.ToString(); }
        public string OYName { get => txb_OYName.Text; set => txb_OYName.Text = value; }
        public TextPosition OYPos
        {
            get
            {
                if (cmb_OYPos.Text == cmb_OYPos.Items[0].ToString())
                    return TextPosition.Right;
                else if (cmb_OYPos.Text == cmb_OYPos.Items[1].ToString())
                    return TextPosition.Left;
                else return TextPosition.Centre;
            }
            set
            {
                if (value == TextPosition.Right)
                    cmb_OYPos.Text = cmb_OYPos.Items[0].ToString();
                else if (value == TextPosition.Left)
                    cmb_OYPos.Text = cmb_OYPos.Items[1].ToString();
                else cmb_OYPos.Text = cmb_OYPos.Items[2].ToString();
            }
        }
        public double OYSize { get => (double)nud_OYSize.Value; set => nud_OYSize.Value = (decimal)value; }
        public double OYPrice { get => double.Parse(txb_OYPrice.Text); set => txb_OYPrice.Text = value.ToString(); }
        #endregion
        #region<---Свойства для генерации спирали--->
        public int StartSpiral { get => int.Parse(txb_SpiralStart.Text); set => txb_SpiralStart.Text = value.ToString(); }
        public int LenghtSpiral { get => int.Parse(txb_SpiralLenght.Text); set => txb_SpiralLenght.Text = value.ToString(); }
        public double OmegaSpiral { get => double.Parse(txb_SpiralOmega.Text); set => txb_SpiralOmega.Text = value.ToString(); }
        public double CoefSpiral { get => double.Parse(txb_SpiralCoef.Text); set => txb_SpiralCoef.Text = value.ToString(); }
        public bool SaveToFile { get => chb_SaveToFile.Checked; set => chb_SaveToFile.Checked = value; }
        #endregion
        private static MainForm _obj;
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
        public Panel PnlDiagramSettings
        {
            get { return pnl_DiagramParams; }
        }
        public Panel PnlSpiralSettings
        {
            get { return pnl_CreateSpiral; }
        }
        public ComboBox cmbDotCurves
        {
            get { return cmb_CurvesDots; }
        }
        public Button btnBack
        {
            get { return btn_Back; }
        }

        public Color FillColor { get => pcb_FillColor.BackColor; set => pcb_FillColor.BackColor = value; }
        public Color StrokeColor { get => pcb_StrokeColor.BackColor; set => pcb_StrokeColor.BackColor = value; }
        public bool SmoothAngles { get => chb_SmoothFigure.Checked; set => chb_SmoothFigure.Checked = value; }
        public double StrokeWidth { get => (double)nud_StrokeWidth.Value; set => nud_StrokeWidth.Value = (decimal)value; }

        Color lblChecked = Color.FromArgb(9, 154, 185);
        Color lblFree = Color.FromArgb(5, 89, 107);
        Color controlEnter = Color.FromArgb(177, 34, 207, 244);

        public MainForm()
        {
            InitializeComponent();
            _obj = this;
            graph = pictureBox1;
        }

        // Метод для перемещения формы.
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
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
        // Горячие клавиши для приближения и отдаления.
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
                ZoomIn(this, EventArgs.Empty);
            if (e.Control && e.KeyCode == Keys.X)
                ZoomOut(this, EventArgs.Empty);
        }

        #region<---Обработка ленты-->
        private void lbl_File_Click(object sender, EventArgs e)
        {
            lbl_Service.BackColor = lblFree;
            lbl_Tools.BackColor = lblFree;
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
            lbl_Tools.BackColor = lblFree;
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
            lbl_Tools.BackColor = lblFree;
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

        private void lbl_Tools_Click(object sender, EventArgs e)
        {
            lbl_File.BackColor = lblFree;
            lbl_Service.BackColor = lblFree;
            lbl_Edit.BackColor = lblFree;
            lbl_Tools.BackColor = lblChecked;
            if (!pnl_StripElements.Controls.ContainsKey("ToolsUC"))
            {
                ToolsUC uc = new ToolsUC();
                uc.Dock = DockStyle.Fill;
                uc.BackColor = lblChecked;
                pnl_StripElements.Controls.Add(uc);
            }
            pnl_StripElements.Controls["ToolsUC"].BringToFront();
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

        private void lbl_Tools_MouseEnter(object sender, EventArgs e)
        {
            if (lbl_Tools.BackColor != lblChecked)
                lbl_Tools.BackColor = controlEnter;
        }
        private void lbl_Tools_MouseLeave(object sender, EventArgs e)
        {
            if (lbl_Tools.BackColor != lblChecked)
                lbl_Tools.BackColor = lblFree;
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
            bool val = false;
            if (MessageBox.Show("Очистить спискок созданных кривых?", "Закрытие файла",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                val = true;

            CloseFile?.Invoke(val);
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

        private void btn_Back_Click(object sender, EventArgs e)
        {

            pnl_CurveSettings.Location = new Point(this.Width + 10, pnl_CurveSettings.Location.Y);
            pnl_DiagramParams.Location = new Point(this.Width + 10, pnl_CurveSettings.Location.Y);
            pnl_CreateSpiral.Location = new Point(this.Width + 10, pnl_CurveSettings.Location.Y);
            btn_Back.Visible = false;
        }

        // Изменение масштаба области посмтроения.
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

        // Инициализация диаграммы и построение графика по умолчанию.
        public void InitDiagramFields(object sender, EventArgs e)
        {
            InitDiagramParams?.Invoke(this, EventArgs.Empty);
        }

        // Перемещение по области построения.
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
        
        // Методы для редактирования кривой.
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
            try
            {
                Curves newCurve = new Curves(new PointF[] { }, pcb_CurveColor.BackColor, style, (int)nud_Thickness.Value, cmb_Curves.Text, DotsSettings);
            
                GraphicEventArgs graphicEvent = new GraphicEventArgs(EventType.AdpdateCurve);
                graphicEvent.newCurve = newCurve;
                graphicEvent.Delete = false;
                if (txb_CurveLegend.Text != "") graphicEvent.NewName = txb_CurveLegend.Text;
                ApdateCurvesList?.Invoke(this, graphicEvent);

                cmb_Curves.Text = "";
                txb_CurveLegend.Text = "";
                pcb_CurveColor.BackColor = Color.Transparent;
                nud_Thickness.Value = 1;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Превышен предел", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmb_Curves_TextChanged(object sender, EventArgs e)
        {
            txb_CurveLegend.Text = cmb_Curves.Text;
            FillCurveFields?.Invoke(cmb_Curves.Text);
        }
        private void btn_DeleteCurve_Click(object sender, EventArgs e)
        {
            Curves newCurve = new Curves(new PointF[] { }, pcb_CurveColor.BackColor, CurveThickness: (int)nud_Thickness.Value, Legend: cmb_Curves.Text, dotsType: "");
            GraphicEventArgs graphicEvent = new GraphicEventArgs(EventType.AdpdateCurve);
            graphicEvent.newCurve = newCurve;
            graphicEvent.Delete = true;
            ApdateCurvesList?.Invoke(this, graphicEvent);

            cmb_Curves.Text = "";
            txb_CurveLegend.Text = "";
            pcb_CurveColor.BackColor = Color.Transparent;
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
        
        // Применить новые параметры диаграммы.
        private void btn_Apply_Click(object sender, EventArgs e)
        {
            ApdateDiagramParams?.Invoke(this, EventArgs.Empty);
        }

        // Методы для создание спирали.
        public bool ValidateSpiralParams()
        {
            int a = 0; double b = 0;
            if (int.TryParse(txb_SpiralStart.Text, out a) && int.TryParse(txb_SpiralLenght.Text, out a) &&
                double.TryParse(txb_SpiralOmega.Text, out b) && double.TryParse(txb_SpiralCoef.Text, out b))
                return true;
            else return false;
        }
        private void btn_BuildSpiral_Click(object sender, EventArgs e)
        {
            if (ValidateSpiralParams())
                DrawSpiral?.Invoke(chb_SaveToFile.Checked);
            else MessageBox.Show("Недопустимое значение параметров.", "Неверный формат данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btn_AddSpiralToMainList_Click(object sender, EventArgs e)
        {
            SpiralAction?.Invoke(true);
        }
        private void btn_DeleteSpiral_Click(object sender, EventArgs e)
        {
            SpiralAction?.Invoke(false);
        }

        private void chb_ShowDots_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chb_ShowDots.Checked)
            {
                groupBox5.Enabled = true;
            }
            else groupBox5.Enabled = false;

            chb_ShowDots.Enabled = true;
        }

        private void pcb_DotColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    pcb_DotColor.BackColor = cd.Color;
                }
            }
        }

        Color pcbFigureChecked = Color.FromArgb(130, 175, 255);
        Color onPcbFigure = Color.FromArgb(177, 204, 222, 255);
        private void pcb_Rectangle_Click(object sender, EventArgs e)
        {
            pcb_Rectangle.BackColor = pcbFigureChecked;
            pcb_Circle.BackColor = pcb_Line.BackColor = pcb_Arrow.BackColor = pcb_Text.BackColor = 
                Color.LightCyan;
        }
        private void pcb_Circle_Click(object sender, EventArgs e)
        {
            pcb_Circle.BackColor = pcbFigureChecked;
            pcb_Rectangle.BackColor = pcb_Line.BackColor = pcb_Arrow.BackColor = pcb_Text.BackColor =
                Color.LightCyan;
        }

        private void pcb_Line_Click(object sender, EventArgs e)
        {
            pcb_Line.BackColor = pcbFigureChecked;
            pcb_Rectangle.BackColor = pcb_Circle.BackColor = pcb_Arrow.BackColor = pcb_Text.BackColor =
                Color.LightCyan;
        }

        private void pcb_Arrow_Click(object sender, EventArgs e)
        {
            pcb_Arrow.BackColor = pcbFigureChecked;
            pcb_Rectangle.BackColor = pcb_Line.BackColor = pcb_Circle.BackColor = pcb_Text.BackColor =
                Color.LightCyan;
        }

        private void pcb_Text_Click(object sender, EventArgs e)
        {
            pcb_Text.BackColor = pcbFigureChecked;
            pcb_Rectangle.BackColor = pcb_Line.BackColor = pcb_Arrow.BackColor = pcb_Circle.BackColor =
                Color.LightCyan;
        }

        private void pcb_Rectangle_MouseEnter(object sender, EventArgs e)
        {
            if (pcb_Rectangle.BackColor != pcbFigureChecked)
                pcb_Rectangle.BackColor = onPcbFigure;
        }
        private void pcb_Rectangle_MouseLeave(object sender, EventArgs e)
        {
            if (pcb_Rectangle.BackColor != pcbFigureChecked)
                pcb_Rectangle.BackColor = Color.LightCyan;
        }
        private void pcb_Circle_MouseEnter(object sender, EventArgs e)
        {
            if (pcb_Circle.BackColor != pcbFigureChecked)
                pcb_Circle.BackColor = onPcbFigure;
        }
        private void pcb_Circle_MouseLeave(object sender, EventArgs e)
        {
            if (pcb_Circle.BackColor != pcbFigureChecked)
                pcb_Circle.BackColor = Color.LightCyan;
        }
        private void pcb_Line_MouseEnter(object sender, EventArgs e)
        {
            if (pcb_Line.BackColor != pcbFigureChecked)
                pcb_Line.BackColor = onPcbFigure;
        }
        private void pcb_Line_MouseLeave(object sender, EventArgs e)
        {
            if (pcb_Line.BackColor != pcbFigureChecked)
                pcb_Line.BackColor = Color.LightCyan;
        }
        private void pcb_Arrow_MouseEnter(object sender, EventArgs e)
        {
            if (pcb_Arrow.BackColor != pcbFigureChecked)
                pcb_Arrow.BackColor = onPcbFigure;
        }
        private void pcb_Arrow_MouseLeave(object sender, EventArgs e)
        {
            if (pcb_Arrow.BackColor != pcbFigureChecked)
                pcb_Arrow.BackColor = Color.LightCyan;
        }

        private void pcb_Text_MouseEnter(object sender, EventArgs e)
        {
            if (pcb_Text.BackColor != pcbFigureChecked)
                pcb_Text.BackColor = onPcbFigure;
        }
        private void pcb_Text_MouseLeave(object sender, EventArgs e)
        {
            if (pcb_Text.BackColor != pcbFigureChecked)
                pcb_Text.BackColor = Color.LightCyan;
        }

        private void chb_EnableFillColor_CheckedChanged(object sender, EventArgs e)
        {
            pcb_FillColor.Enabled = chb_EnableFillColor.Checked;
            if (!pcb_FillColor.Enabled)
            {
                pcb_FillColor.BackgroundImage = Properties.Resources.pcb_disable;
            }
            else pcb_FillColor.BackgroundImage = null;
        }

        private void chb_EnableStrokeColor_CheckedChanged(object sender, EventArgs e)
        {
            pcb_StrokeColor.Enabled = chb_EnableStrokeColor.Checked;
            if (!pcb_StrokeColor.Enabled)
            {
                pcb_StrokeColor.BackgroundImage = Properties.Resources.pcb_disable;
            }
            else pcb_StrokeColor.BackgroundImage = null;
        }
    }
}
