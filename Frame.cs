using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    class Frame : ICloneable
    {
        public float X1 { get; set; }
        public float Y1 { get; set; }
        public float X2 { get; set; }
        public float Y2 { get; set; }

        public bool Enabled { get; }

        public Frame(float x1, float y1, float x2, float y2)
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

        public void JoinFrame(Frame frame)
        {
            float x1 = X1;
            float x2 = X2;
            float y1 = Y1;
            float y2 = Y2;

            X1 = Math.Min(Math.Min(x1, x2), Math.Min(frame.X1, frame.X2));
            X2 = Math.Max(Math.Max(x1, x2), Math.Max(frame.X1, frame.X2));
            Y1 = Math.Min(Math.Min(y1, y2), Math.Min(frame.Y1, frame.Y2));
            Y2 = Math.Max(Math.Max(y1, y2), Math.Max(frame.Y1, frame.Y2));

        }
        public void Move(int dx, int dy)
        {
            X1 += dx;
            X2 += dx;
            Y1 += dy;
            Y2 += dy;
        }
        public void Resize_1(int dx, int dy)
        {
            X1 += dx;
            Y1 += dy;
        }
        public void Resize_2(int dx, int dy)
        {
            X2 += dx;
            Y1 += dy;
        }
        public void Resize_3(int dx, int dy)
        {
            X2 += dx;
            Y2 += dy;
        }
        public void Resize_4(int dx, int dy)
        {
            X1 += dx;
            Y2 += dy;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
