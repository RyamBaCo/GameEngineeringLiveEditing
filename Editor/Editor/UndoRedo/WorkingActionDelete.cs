using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Editor.UndoRedo
{
    class WorkingActionDelete : WorkingActionAdd
    {
        public WorkingActionDelete(Shape shape, BindingList<Shape> shapes, ref ListBox shapeList, ref GroupBox groupBoxShape) : base(shape, shapes, ref shapeList, ref groupBoxShape) { }

        public override void Undo()
        {
            base.Redo();
        }

        public override void Redo()
        {
            base.Undo();
        }
    }
}
