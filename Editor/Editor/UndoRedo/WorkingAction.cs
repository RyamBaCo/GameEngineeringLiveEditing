using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Editor
{
    abstract class WorkingAction
    {
        protected Shape shape;
        protected BindingList<Shape> shapes;
        protected int listIndex;

        public WorkingAction(Shape shape, ref BindingList<Shape> shapes)
        {
            this.shape = shape;
            this.shapes = shapes;
            listIndex = shapes.TakeWhile(s => s != shape).Count() - 1;
        }

        public abstract void Undo();
        public abstract void Redo();
    }
}
