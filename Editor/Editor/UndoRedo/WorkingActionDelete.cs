﻿using System.ComponentModel;
using System.Windows.Forms;

namespace Editor.UndoRedo
{
    internal class WorkingActionDelete : WorkingActionAdd
    {
        public WorkingActionDelete(Shape shape, BindingList<Shape> shapes, ref ListBox shapeList, ref GroupBox groupBoxShape)
            : base(shape, shapes, ref shapeList, ref groupBoxShape)
        {
        }

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