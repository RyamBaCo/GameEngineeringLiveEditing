using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace Editor.UndoRedo
{
    class WorkingActionModify : WorkingAction
    {
        public WorkingActionModify(Shape shape, BindingList<Shape> shapes) : base(shape, shapes) { }

        public override void Undo()
        {
            shapes[listIndex] = Interlocked.Exchange(ref shape, shapes[listIndex]);
            shapes[listIndex].Control.UpdateControlView();
        }

        public override void Redo()
        {
            shapes[listIndex] = Interlocked.Exchange(ref shape, shapes[listIndex]);
            shapes[listIndex].Control.UpdateControlView();
        }
    }
}
