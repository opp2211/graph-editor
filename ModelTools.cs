using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace graphics_editor
{
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
        public void SetStartPoint(Point point)
        {
            this.x1 = point.X;
            this.y1 = point.Y;
        }
        public void CreateObj(Point point2)
        {
            this.x2 = point2.X;
            this.y2 = point2.Y;
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
        SelectionList selections;
        Graph graph;
        public Scene(Store store, Graph graph, SelectionList selections)
        {
            this.store = store;
            this.selections = selections;
            this.graph = graph;
        }
        public void RePaint()
        {
            graph.Wipe();
            foreach (Item item in store)
            {
                item.Paint(graph);
            }
            foreach (Selection s in selections)
            {
                s.Draw(graph);
            }
        }
        public void PaintLast()
        {
            store.Last().Paint(graph);
        }
    }
}
