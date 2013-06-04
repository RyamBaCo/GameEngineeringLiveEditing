using System.ComponentModel;
using System.Threading;

namespace Editor.UndoRedo
{
    internal class WorkingActionModify : WorkingAction
    {
        // a copy of the old shape storing the original values
        private Shape storedShape;

        public WorkingActionModify(Shape shape, Shape storedShape, BindingList<Shape> shapes)
            : base(shape, shapes)
        {
            this.storedShape = storedShape;
        }

        public override void Undo()
        {
            shapes[listIndex] = Interlocked.Exchange(ref storedShape, shapes[listIndex]);
            shapes[listIndex].Control.UpdateControlView();
        }

        public override void Redo()
        {
            shapes[listIndex] = Interlocked.Exchange(ref storedShape, shapes[listIndex]);
            shapes[listIndex].Control.UpdateControlView();
        }
    }
}