using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Editor.UndoRedo
{
    class WorkingActionAdd : WorkingAction
    {
        private ListBox shapeList;
        private GroupBox groupBoxShape;

        public WorkingActionAdd(Shape shape, BindingList<Shape> shapes, ref ListBox shapeList, ref GroupBox groupBoxShape) 
            : base(shape, shapes)
        {
            this.shapeList = shapeList;
            this.groupBoxShape = groupBoxShape;
        }

        public override void Undo()
        {
            shapes.RemoveAt(listIndex + 1);

            if (shapes.Count == 0)
                groupBoxShape.Visible = false;
        }

        public override void Redo()
        {
            shapes.Add(shape);
            shapeList.SelectedIndex = shapes.Count - 1;
            groupBoxShape.Visible = true;
        }
    }
}
