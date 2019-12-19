using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    class Frame : ICloneable
    {
        public int X1 { get; }
        public int Y1 { get; }
        public int X2 { get; }
        public int Y2 { get; }

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
        
        public Frame JoinFrame (Frame frame)
        {
            //todo логика объединения фреймов
            throw new NotImplementedException();
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
