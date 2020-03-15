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
    class Factory
    {
        int x1, y1, x2, y2;
        PenProps penProps;
        BrushProps brushProps;
        Props props;
        Store store;

        int createdObjType;
        public Factory(Store store)
        {
            this.store = store;
        }
        public void SetCreatedObjType(int createdObjType)
        {
            this.createdObjType = createdObjType;
        }
        public void SetPenProps(int penColor, int penWidth)
        {
            penProps = new PenProps(penColor, penWidth);
        }
        public void SetBrushProps(int brushColor)
        {
            brushProps = new BrushProps(brushColor);
        }
        public void SetStartPoint(int x1, int y1)
        {
            this.x1 = x1;
            this.y1 = y1;
        }
        public void CreateObj(int x2, int y2)
        {
            this.x2 = x2;
            this.y2 = y2;
            Frame frame = new Frame(x1, y1, x2, y2);
            switch (createdObjType)
            {
                case 0:
                    props = new Props { penProps };
                    Line line = new Line(frame, props);
                    store.Add(line);
                    break;
                case 1:
                    props = new Props { penProps, brushProps };
                    Rectangle rect = new Rectangle(frame, props);
                    store.Add(rect);
                    break;
                case 2:
                    props = new Props { penProps, brushProps };
                    Ellipse ellipse = new Ellipse(frame, props);
                    store.Add(ellipse);
                    break;

            }
        }
    }
    class Store : List<Item> { }
    class Scene
    {
        Store store;
        Graph graph;
        public Scene(Store store, Graph graph)
        {
            this.store = store;
            this.graph = graph;
        }
        public void RePaint()
        {
            graph.Wipe();
            foreach (Item item in store)
            {
                item.Paint(graph);
            }
        }
        public void PaintLast()
        {
            store.Last().Paint(graph);
        }
    }
}
