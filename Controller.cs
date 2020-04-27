using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics_editor
{
    class Controller
    {
        Model model;
        StateController stateController;
        public Controller(Model model)
        {
            this.model = model;
            this.stateController = new StateController(model);
        }
        public void ViewPort(int x0, int y0, int w, int h, PictureBox pb)
        {
            model.ViewPort(x0, y0, w, h, pb);
        }
        public void ChangeState(int stateNum)
        {
            stateController.ChangeState(stateNum);
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
        public void MouseDown(Point point)
        {
            stateController.MouseDown(point);
        }
        public void MouseUp(Point point)
        {
            stateController.MouseUp(point);
        }
        public void MouseMove(Point point)
        {
            stateController.MouseMove(point);
        }
        public void ControlOn()
        {
            stateController.ControlOn();
        }
        public void ControlOff()
        {
            stateController.ControlOff();
        }
        public void Group()
        {
            model.Group();
            stateController.ChangeState(2);
        }
        public void UnGroup()
        {
            model.UnGroup();
            stateController.ChangeState(3);
        }
        public void InitializeProps(int penColor, int penWidth, int brushColor)
        {
            SetPenProps(penColor, penWidth);
            SetBrushProps(brushColor);
        }
        public void RePaint()
        {
            model.RePaint();
        }
        public void Undo()
        {
            model.Undo();
            //todo изменение состояний
        }
        public void Redo()
        {
            model.Redo();
        }
    }
}
