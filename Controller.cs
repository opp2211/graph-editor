using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    class Controller
    {
        Model model;
        public Controller(Model model)
        {
            this.model = model;
        }
        public void ViewPort(int x0, int y0, int w, int h, Graphics graphics)
        {
            model.ViewPort(x0, y0, w, h, graphics);
        }
        public void SetCreatedObjType(int createdObjType)
        {
            model.SetCreatedObjType(createdObjType);
        }
        public void SetPenProps(int penColor, int penWidth)
        {
            model.SetPenProps(penColor, penWidth);
        }
        public void SetBrushProps(int brushColor)
        {
            model.SetBrushProps(brushColor);
        }
        public void Wipe()
        {
            model.Wipe();
        }
        public void MouseDown(int x, int y)
        {
            model.SetStartPoint(x, y);
        }
        public void MouseUp(int x, int y)
        {
            model.CreateObj(x, y);
        }
        public void MouseMove(int x, int y)
        {

        }
        public void InitializeProps(int penColor, int penWidth, int brushColor)
        {
            SetPenProps(penColor, penWidth);
            SetBrushProps(brushColor);
        }
    }
}
