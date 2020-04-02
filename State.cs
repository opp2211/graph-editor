using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace graphics_editor
{
    abstract class State
    {
        protected Model model;
        protected StateController stateController;
        protected bool isCtrl = false;
        protected State(Model model, StateController stateController)
        {
            this.model = model;
            this.stateController = stateController;
            isCtrl = stateController.IsCtrl;
        }
        abstract public void MouseDown(Point point);
        abstract public void MouseUp(Point point);
        abstract public void MouseMove(Point point);
        public void ControlOn()
        {
            isCtrl = true;
        }
        public void ControlOff()
        {
            isCtrl = false;
        }
    }
    class EmptyState : State
    {
        public EmptyState(Model model, StateController stateController) : base(model, stateController) 
        {
            model.ClearSelections();
        }
        public override void MouseDown(Point point)
        {
            if (model.TrySelect(point))
            {
                stateController.ChangeState(2);
                model.TryGrab(point);
                stateController.ChangeState(4);
            }
        }
        public override void MouseUp(Point point)
        {

        }
        public override void MouseMove(Point point)
        {

        }
    }
    class ObjectCreationState : State
    {
        public ObjectCreationState(Model model, StateController stateController) : base(model, stateController) { }

        public override void MouseDown(Point point)
        {
            model.SetStartPoint(point);
        }
        public override void MouseUp(Point point)
        {
            model.CreateObj(point);
        }
        public override void MouseMove(Point point)
        {
            //throw new NotImplementedException();
        }
    }
    class SingleSelectState : State
    {
        public SingleSelectState(Model model, StateController stateController) : base(model, stateController) { }
        public override void MouseDown(Point point)
        {

        }
        public override void MouseUp(Point point)
        {

        }
        public override void MouseMove(Point point)
        {

        }
    }
    class DragState : State
    {
        public DragState(Model model, StateController stateController) : base(model, stateController) { }

        public override void MouseDown(Point point)
        {

        }
        public override void MouseUp(Point point)
        {
            model.Release();
            stateController.ChangeToLastState();
        }
        public override void MouseMove(Point point)
        {
            model.DragTo(point);
        }
    }
}
