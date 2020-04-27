using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics_editor
{
    class Model
    {
        Factory factory;
        Store store;
        Graph graph;
        Scene scene;
        SelectionList selections;
        UndoRedoManager manager;

        public Model()
        {
            this.store = new Store();
            this.graph = new Graph();
            this.factory = new Factory(store);
            this.selections = new SelectionList();
            this.scene = new Scene(store, graph, selections);
            this.manager = new UndoRedoManager();
        }
        public void ViewPort(int x0, int y0, int w, int h, PictureBox pb)
        {
            graph.ViewPort(x0, y0, w, h, pb);
        }
        public bool TrySelect(Point point)
        {
            for (int i = store.Count - 1; i >= 0; i--)
            {
                if (store[i].isInBody(point) && store[i].Selected == false)
                {
                    store[i].Selected = true;
                    selections.Add(store[i].CreateSelection());
                    scene.RePaint();
                    return true;
                }
            }
            return false;
        }
        public void ClearSelections()
        {
            if (selections.Count > 0)
            {
                selections.Clear();
                foreach (Item item in store)
                    item.Selected = false;
                scene.RePaint();
            }
        }
        int operationNumber;
        public bool TryGrab(Point point)
        {
            operationNumber++;

            bool grabbed = false;
            int changerIndex = 0;
            foreach (Selection s in selections)
            {
                if (s.TryGrab(point))
                {
                    grabbed = true;
                    changerIndex = s.changerIndex;
                }
            }
            foreach (Selection s in selections)
            {
                s.ChangeChanger(changerIndex);
            }
            return grabbed;
        }
        public void DragTo(Point point)
        {
            var command = new DragCommand(selections, point, operationNumber);
            manager.Execute(command);
            scene.RePaint();
        }
        public void Release()
        {
            foreach (Selection s in selections)
            {
                s.Release();
            }
        }
        public void SetPenProps(int penColor, int penWidth)
        {
            factory.SetPenProps(penColor, penWidth);
        }
        public void SetBrushProps(int brushColor)
        {
            factory.SetBrushProps(brushColor);
        }
        public void SetCreatedObjType(int createdObjType)
        {
            factory.SetCreatedObjType(createdObjType);
        }
        public void CreateObj(Point point)
        {
            operationNumber++;
            var command = new CreateObjCommand(factory, store, selections, point, operationNumber);
            operationNumber--;
            manager.Execute(command);
            scene.RePaint();
        }
        public void Group()
        {
            if (selections.Count > 1)
            {
                selections.Clear();
                Group group = store.Group();
                group.ClearSelectionsForItems();
                group.Selected = true;
                selections.Add(group.CreateSelection());
                scene.RePaint();
            }
        }
        public void UnGroup()
        {
            if (selections.Count == 1 && selections[0].Item.GetType() == typeof(Group))
            {
                List<Item> ungrouppedItems = store.UnGroup((Group)selections[0].Item);
                selections.Clear();
                foreach (Item item in ungrouppedItems)
                {
                    item.Selected = true;
                    selections.Add(item.CreateSelection());
                }
                scene.RePaint();

            }
        }
        public void RePaint()
        {
            scene.RePaint();
        }
        public void Wipe()
        {
            operationNumber++;
            var command = new WipeCommand(store, selections, operationNumber);
            manager.Execute(command);
            scene.RePaint();
        }
        public void Undo()
        {
            manager.Undo();
            scene.RePaint();
        }
        public void Redo()
        {
            manager.Redo();
            scene.RePaint();
        }
    }
}
