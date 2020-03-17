using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyDrawing
{

    /// <summary>
    /// Определяет кол-во отображаемых четвертей графика.
    /// </summary>
    public enum AxesPosition
    {
        /// <summary>
        /// При построении отображается первая четверть.
        /// </summary>
        FirstQuarter,
        /// <summary>
        /// При построении отображаются все четверти.
        /// </summary>
        AllQuarters
    }

    /// <summary>
    /// Определяет выравнивание текста.
    /// </summary>
    public enum TextPosition
    {
        /// <summary>
        /// Выравнивание текста по левому краю.
        /// </summary>
        Left,
        /// <summary>
        /// Выравнивание текста по центру.
        /// </summary>
        Centre,
        /// <summary>
        /// Вырванивание текста по правому краю.
        /// </summary>
        Right
    }

    public abstract class Diagram
    {
        /// <summary>
        /// Объект класса Graphics, представляющий методы и свойства для рисования графики.
        /// </summary>
        public Graphics g { get; set; }
        /// <summary>
        /// Холст на котором производится рисование pictureBox, Panel и т.д.
        /// </summary>
        public PictureBox placeToDraw { get; set; } //область для рисования диаграмм
        

        public string Title { get; set; } //описание диаграммы
        public int TitleSize { get; set; } //размер описания диаграммы
        public TextPosition TitlePosition { get; set; }
        public bool AddDiagramLegend { get; set; } //добавить ли легенду диаграммы

        /// <summary>
        /// Точка начала отсчёта.
        /// </summary>
        public Point RealCenter { get; set; } // точка пересечения осей(график, гистограмма), центр окружности(круговая диаграмма)
        public Point ImiganaryCenter { get; set; }
        public Point Center { get; set; }
        //точки рамки построение графика
        public Point pt1; //левая нижняя точка
        public Point pt2; //левая верхняя точка
        public Point pt3; //правая нижняя точка
        public Point pt4; //правая верхняя точка

        protected PointF LastPointOX; //последняя точка на оси OX, определяющая рамку
        protected PointF LastPointOY; //последняя точка на оси OY, определяющая рамку 

        //параметры задают максимальные размеры рамки для рисования графика
        protected int Space_From_Top = 25;
        protected int Space_From_Right = 25;
        protected int Space_From_Bottom = 25;
        protected int Space_From_Left = 25;

        public abstract void DrawDiagram(); //рисует диаграмму внутри рамки построения


    }
}
