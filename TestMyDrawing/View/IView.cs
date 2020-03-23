using System;
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
        event EventHandler<EventArgs> SaveCreatedFile;
        event EventHandler<EventArgs> SaveAS;
        event EventHandler<EventArgs> LoadFile;
        event EventHandler<EventArgs> Exit;
    }
}
