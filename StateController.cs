﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    class StateController
    {
        Model model;
        State state;
        public bool IsCtrl { get; set; } = false;
        public StateController(Model model)
        {
            this.model = model;
            state = new EmptyState(model, this);
        }
        public void ChangeState(int stateNum)
        {
            switch (stateNum)
            {
                case 0:
                    state = new EmptyState(model, this);
                    break;
                case 1:
                    state = new ObjectCreationState(model, this);
                    break;
            }
        }
        public void MouseDown(int x, int y)
        {
            state.MouseDown(x, y);
        }
        public void MouseUp(int x, int y)
        {
            state.MouseUp(x, y);
        }
        public void MouseMove(int x, int y)
        {
            state.MouseMove(x, y);
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
