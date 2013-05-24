using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Editor.UndoRedo
{
    // modify rectangle needs the current radio button as additional information for storing the right edge value
    class WorkingActionModifyRectangle : WorkingActionModify
    {
        public int ActiveEdgeIndex { get; private set; }

        public WorkingActionModifyRectangle(RectangleShape shape, ref BindingList<Shape> shapes, int activeEdgeIndex)
            : base(shape, ref shapes)
        {
            ActiveEdgeIndex = activeEdgeIndex;
        }
    }
}
