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
        public void CreateObj(Point point)
        {
            Frame frame = new Frame(point.X, point.Y, point.X, point.Y);
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
    class Store : List<Item> 
    { 
        public Group Group()
        {
            List<Item> list = new List<Item>();
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Selected)
                {
                    list.Add(this[i]);
                    this.RemoveAt(i);
                    i--;
                }
            }
            Group group = new Group(list);
            this.Add(group);
            return group;
        }
        public List<Item> UnGroup(Group group)
        {
            List<Item> list = new List<Item>();

            this.Remove(group);
            foreach(Item item in group.GetItems)
            {
                this.Add(item);
                list.Add(item);
            }
            return list;
        }
    }
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
            graph.Refresh();
        }
    }
}
