using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    class Model
    {
        Factory factory;
        Store store;
        Graph graph;
        Scene scene;
        SelectionList selections;

        public Model()
        {
            this.store = new Store();
            this.graph = new Graph();
            this.factory = new Factory(store);
            this.selections = new SelectionList();
            this.scene = new Scene(store, graph, selections);
        }
        public void ViewPort(int x0, int y0, int w, int h, Graphics graphics)
        {
            graph.ViewPort(x0, y0, w, h, graphics);
        }
        //public void RePaint()
        //{
        //    scene.RePaint();
        //}
        public bool TryGrab(Point point)
        {
            bool grabbed = false;
            foreach (Selection s in selections)
            {
                if (s.TryGrab(point))
                    grabbed = true;
            }
            return grabbed;
        }
        public void DragTo(Point point)
        {
            bool repaint = false;
            foreach (Selection s in selections)
            {
                s.DragTo(point);
                repaint = true;
            }
            selections[0].SetGrabbedPoint(point);
            if (repaint) scene.RePaint();
        }
        public void Release()
        {
            foreach (Selection s in selections)
            {
                s.Release();
            }
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
        public void SetCreatedObjType(int createdObjType)
        {
            factory.SetCreatedObjType(createdObjType);
        }
        public void SetPenProps(int penColor, int penWidth)
        {
            factory.SetPenProps(penColor, penWidth);
        }
        public void SetBrushProps(int brushColor)
        {
            factory.SetBrushProps(brushColor);
        }
        public void SetStartPoint(Point point)
        {
            factory.SetStartPoint(point);
        }
        public void CreateObj(Point point2)
        {
            factory.CreateObj(point2);
            scene.RePaint();
        }
        public void ClearSelections()
        {
            selections.Clear();
            foreach (Item item in store)
                item.Selected = false;
            scene.RePaint();
        }
        public void Wipe()
        {
            store.Clear();
            selections.Clear();
            scene.RePaint();
        }
    }
}
