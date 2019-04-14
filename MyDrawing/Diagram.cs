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
    /// Определяет выравнивание текста.
    /// </summary>
    public enum TextPosition
    {
        Left,
        Centre,
        Right
    }

    public abstract class Diagram
    {
        public Graphics g;

        public PictureBox placeToDraw; //область для рисования диаграмм

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
        protected int Space_From_Top = 25;
        protected int Space_From_Right = 25;
        protected int Space_From_Bottom = 25;
        protected int Space_From_Left = 25;

        public abstract void DrawDiagram(); //рисует диаграмму внутри рамке построения


    }
}
