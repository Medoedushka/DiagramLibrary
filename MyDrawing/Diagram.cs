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
    /// Определяет возможность осей изменяеться в размерах при изменении шага деления.
    /// </summary>
    public enum AxesMode
    {
        /// <summary>
        /// При изменении шага деления ось размеров не меняет. Изменяется только количество делений на оси.
        /// </summary>
        Static,
        /// <summary>
        /// При изменении шага деления количество делений на оси неизменно, а меняется только длина оси.
        /// </summary>
        Dynamic
    }

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
        public Graphics g;
        protected PictureBox placeToDraw; //область для рисования диаграмм

        public string Title { get; set; } //описание диаграммы
        public int TitleSize { get; set; } //размер описания диаграммы
        public TextPosition TitlePosition { get; set; }
        public bool AddDiagramLegend { get; set; } //добавить ли легенду диаграммы

        /// <summary>
        /// Точка начала отсчёта.
        /// </summary>
        public Point Center { get; set; } // точка пересечения осей(график, гистограмма), центр окружности(круговая диаграмма)
        

        //точки рамки построение графика
        protected Point pt1; //левая нижняя точка
        protected Point pt2; //левая верхняя точка
        protected Point pt3; //правая нижняя точка
        protected Point pt4; //правая верхняя точка

        protected PointF LastPointOX; //последняя точка на оси OX, определяющая рамку
        protected PointF LastPointOY; //последняя точка на оси OY, определяющая рамку 

        //параметры задают максимальные размеры рамки для рисования графика
        protected int Space_From_Top = 35;
        protected int Space_From_Right = 25;
        protected int Space_From_Bottom = 35;
        protected int Space_From_Left = 35;

        public abstract void DrawDiagram(); //рисует диаграмму внутри рамке построения


    }
}
