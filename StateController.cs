using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphics_editor
{
    class StateController
    {
        Model model;
        State state;
        int lastState;
        int currentState;
        public bool IsCtrl { get; set; } = false;
        public StateController(Model model)
        {
            this.model = model;
            state = new EmptyState(model, this);
        }
        public void ChangeState(int stateNum)
        {
            lastState = currentState != stateNum ? currentState : lastState;
            currentState = stateNum;
            switch (stateNum)
            {
                case 0:
                    state = new EmptyState(model, this);
                    break;
                case 1:
                    state = new ObjectCreationState(model, this);
                    break;
                case 2:
                    state = new SingleSelectState(model, this);
                    break;
                case 4:
                    state = new DragState(model, this);
                    break;
            }
        }
        public void ChangeToLastState()
        {
            ChangeState(lastState);
        }
        public void MouseDown(Point point)
        {
            state.MouseDown(point);
        }
        public void MouseUp(Point point)
        {
            state.MouseUp(point);
        }
        public void MouseMove(Point point)
        {
            state.MouseMove(point);
        }
        public void ControlOn()
        {
            IsCtrl = true;
            state.ControlOn();
        }
        public void ControlOff()
        {
            IsCtrl = false;
            state.ControlOff();
        }
    }
}
