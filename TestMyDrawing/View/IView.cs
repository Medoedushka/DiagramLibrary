﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TestMyDrawing.View
{
    public interface IView
    {
        string TableTxt { get; set; }
        string CurrentFileName { get; set; }
        PictureBox grpah { get; set; }

        event EventHandler<EventArgs> CreateNewFile;
        event Func<bool> SaveCreatedFile;
        event Action CloseFile;
        event EventHandler<EventArgs> LoadFile;
        event EventHandler<EventArgs> InitGraphic;
    }
}
