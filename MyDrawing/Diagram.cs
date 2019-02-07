﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyDrawing
{
    public abstract class Diagram
    {
        protected Graphics g;

        protected PictureBox placeToDraw; //область для рисования диаграмм
        public string Title { get; set; } //описание диаграммы
        public int TitleSize { get; set; } //размер описания диаграммы
        public bool AddDiagramLegend { get; set; } //добавить ли легенду диаграммы
        public Point Center; // точка пересечения осей(график, гистограмма), центр окружности(круговая диаграмма)

        //точки рамки построение графика
        protected Point pt1; //левая нижняя точка
        protected Point pt2; //левая верхняя точка
        protected Point pt3; //правая нижняя точка
        protected Point pt4; //правая верхняя точка
        public PointF LastPointOX; //последняя точка на оси OX, определяющая рамку
        public PointF LastPointOY; //последняя точка на оси OY, определяющая рамку 

        protected int Space_From_Top { get; set; }     //
        protected int Space_From_Right { get; set; }   //параметры отступа границ рамки 
        protected int Space_From_Bottom { get; set; }  //от границ pictureBox
        protected int Space_From_Left { get; set; }    // 

        public abstract void DrawGraphic(); //рисует диаграмму внутри рамке построения


    }
}