﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMyDrawing.View
{
    public interface IView
    {
        string TableTxt { get; set; }
        string CurrentFileName { get; set; }
        
        event EventHandler<EventArgs> CreateNewFile;
        event Func<bool> SaveCreatedFile;
        event EventHandler<EventArgs> LoadFile;
        event EventHandler<EventArgs> Exit;
    }
}
