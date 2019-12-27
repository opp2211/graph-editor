using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    class Frame : ICloneable
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public bool Enabled { get; }

        public Frame (int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;

            Enabled = true;
        }
        public Frame()
        {
            Enabled = false;
        }
        
        public void JoinFrame (Frame frame)
        {
            X1 = (frame.X1 < X1) ? frame.X1 : X1;
            X2 = (frame.X2 > X2) ? frame.X2 : X2;
            Y1 = (frame.Y1 < Y1) ? frame.Y1 : Y1;
            Y2 = (frame.Y2 > Y2) ? frame.Y2 : Y2;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
