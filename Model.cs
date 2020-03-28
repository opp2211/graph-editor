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
        
        public Model()
        {
            this.store = new Store();
            this.graph = new Graph();
            this.factory = new Factory(store);
            this.scene = new Scene(store, graph);
        }
        public void ViewPort(int x0, int y0, int w, int h, Graphics graphics)
        {
            graph.ViewPort(x0, y0, w, h, graphics);
        }
        //public void RePaint()
        //{
        //    scene.RePaint();
        //}
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
        public void SetStartPoint(int x1, int y1)
        {
            factory.SetStartPoint(x1, y1);
        }
        public void CreateObj(int x2, int y2)
        {
            factory.CreateObj(x2, y2);
            scene.RePaint();
        }
        public void Wipe()
        {
            store.Clear();
            scene.RePaint();
        }
    }
}
