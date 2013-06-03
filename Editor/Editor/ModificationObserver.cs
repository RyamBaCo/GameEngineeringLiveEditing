using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Editor
{
    public static class ModificationObserver
    {
        public static bool IsActionTrackingDisabled { get; set; }

        static List<WorkingAction> actions = new List<WorkingAction>();
        static int currentActionIndex = 0;
        static TCP.Server server = new TCP.Server();

        static ModificationObserver()
        {
            IsActionTrackingDisabled = false;
        }

        public static void AddAddAction(Shape shape, ref ListBox listBoxShapes, ref GroupBox groupBoxShape) 
        {
            if (IsActionTrackingDisabled)
                return;
            UpdateUndoRedoValues();
            actions.Add(new UndoRedo.WorkingActionAdd(shape, Editor.Shapes, ref listBoxShapes, ref groupBoxShape));
            server.MessageToSend = JsonConvert.SerializeObject(Editor.Shapes);
        }

        public static void AddDeleteAction(Shape shape, ref ListBox listBoxShapes, ref GroupBox groupBoxShape)
        {
            if (IsActionTrackingDisabled)
                return;
            UpdateUndoRedoValues();
            actions.Add(new UndoRedo.WorkingActionDelete(shape, Editor.Shapes, ref listBoxShapes, ref groupBoxShape));
            server.MessageToSend = JsonConvert.SerializeObject(Editor.Shapes);
        }

        public static void AddModifyAction(Shape shape)
        {
            if (IsActionTrackingDisabled)
                return;
            UpdateUndoRedoValues();
            actions.Add(new UndoRedo.WorkingActionModify(shape, Editor.Shapes));
            server.MessageToSend = JsonConvert.SerializeObject(Editor.Shapes);
        }

        public static void PerformUndo(ref ToolStripMenuItem undoToolStripMenuItem, ref ToolStripMenuItem redoToolStripMenuItem)
        {
            IsActionTrackingDisabled = true;

            actions[currentActionIndex].Undo();

            if (currentActionIndex == 0)
                undoToolStripMenuItem.Enabled = false;
            --currentActionIndex;

            redoToolStripMenuItem.Enabled = true;

            IsActionTrackingDisabled = false;
        }

        public static void PerformRedo(ref ToolStripMenuItem undoToolStripMenuItem, ref ToolStripMenuItem redoToolStripMenuItem)
        {
            IsActionTrackingDisabled = true;

            ++currentActionIndex;
            if (currentActionIndex == actions.Count - 1)
                redoToolStripMenuItem.Enabled = false;

            actions[currentActionIndex].Redo();

            undoToolStripMenuItem.Enabled = true;

            IsActionTrackingDisabled = false;
        }

        private static void UpdateUndoRedoValues()
        {
            // when adding a new action to the list, discard all possible redo actions
            if (currentActionIndex < actions.Count)
                actions.RemoveRange(currentActionIndex + 1, actions.Count - currentActionIndex - 1);
            currentActionIndex = actions.Count;
        }
    }
}
