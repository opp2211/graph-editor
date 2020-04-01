using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        abstract public void MouseDown(int x, int y);
        abstract public void MouseUp(int x, int y);
        abstract public void MouseMove(int x, int y);
        public void ControlOn()
        {
            isCtrl = true;
            //MessageBox.Show("Нажат контрол");
        }
        public void ControlOff()
        {
            isCtrl = false;
            MessageBox.Show("Контрол отпущен");
        }
    }
    class EmptyState : State
    {
        public EmptyState(Model model, StateController stateController) : base(model, stateController) { }
        public override void MouseDown(int x, int y)
        {
            if (model.TrySelect(x, y)) ;
                //MessageBox.Show("EmptyState=>MouseDown(Попадание)");

            //stateController.ChangeState(2);
        }
        public override void MouseUp(int x, int y)
        {
            //MessageBox.Show("EmptyState=>MouseUp");
        }
        public override void MouseMove(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
    class ObjectCreationState : State
    {
        public ObjectCreationState(Model model, StateController stateController) : base(model, stateController) { }

        public override void MouseDown(int x, int y)
        {
            model.SetStartPoint(x, y);
        }
        public override void MouseUp(int x, int y)
        {
            model.CreateObj(x, y);
        }
        public override void MouseMove(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
