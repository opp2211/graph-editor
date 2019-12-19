﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_editor
{
    abstract class Item : ICloneable
    {
        public Frame Frame { get; set; }
        protected Item (Frame frame)
        {
            Frame = frame;
        }
        protected Item()
        {
            Frame = new Frame();
        }
        public abstract void Paint(Graph graph);
        abstract public object Clone();

    }
    abstract class Figure : Item
    {
        public Props Props;
        protected Figure (Frame frame, Props props) : base(frame)
        {
            Props = (Props)props.Clone();
        }
        public override void Paint(Graph graph)
        {
            Props.Apply(graph);
            PaintGeom(graph);
        }
        abstract protected void PaintGeom(Graph graph);
        
    }
    class Group : Item
    {
        List<Item> list;
        public Group(List<Item> items)
        {
            list = new List<Item>();
            foreach (Item item in items)
            {
                list.Add((Item)item.Clone());
            }
            //todo Фрейм для группы
            //foreach (Item item in list)
            //{
            //    Frame = item.Frame.JoinFrame(Frame);
            //}
        }
        public override void Paint(Graph graph)
        {
            foreach (Item item in list)
            {
                item.Paint(graph);
            }
        }
        public override object Clone()
        {
            return new Group(list);
        }
    }
}
