using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Cosmos.System.Graphics;
namespace fixbuild.ChaseGraphicsAPI
{
    class WindowComponent
    {
        private static List<Window> windows = new List<Window>();
        private static Pen outlinePen = new Pen(Color.White);
        internal const Int32 defaultwindowSize = 400, windowTopPartSize = 25, xBtnSize = 25;
        public Int32 x
        {
            get;
            private set;
        }
        public Int32 y
        {
            get;
            private set;
        }
        private readonly Byte Size;
        public WindowComponent(Int32 X, Int32 Y, Byte size)
        {
            x = X;
            y = Y;
            Size = size;
        }
        public virtual void draw (Window sender)
        {
            
        }
    }
}
