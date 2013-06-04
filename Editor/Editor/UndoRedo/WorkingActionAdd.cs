using System.ComponentModel;
using System.Windows.Forms;

namespace Editor.UndoRedo
{
    internal class WorkingActionAdd : WorkingAction
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
            shapes.RemoveAt(listIndex);

            if (shapes.Count == 0)
                groupBoxShape.Visible = false;
        }

        public override void Redo()
        {
            shapes.Insert(listIndex, shape);
            shapeList.SelectedIndex = listIndex;
            groupBoxShape.Visible = true;
        }
    }
}