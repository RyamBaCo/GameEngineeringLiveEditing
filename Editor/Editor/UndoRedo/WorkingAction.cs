using System.ComponentModel;
using System.Linq;

namespace Editor
{
    internal abstract class WorkingAction
    {
        protected Shape shape;
        protected BindingList<Shape> shapes;
        protected int listIndex;

        public WorkingAction(Shape shape, BindingList<Shape> shapes)
        {
            this.shape = shape;
            this.shapes = shapes;
            listIndex = shapes.TakeWhile(s => s != shape).Count();
        }

        public abstract void Undo();

        public abstract void Redo();
    }
}