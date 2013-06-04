using System.Collections.Generic;
using System.Windows.Forms;

namespace Editor
{
    public delegate void EnableRedoHandler(bool value);

    public delegate void EnableUndoHandler(bool value);

    public delegate void UpdateTCPClientHandler();

    public static class ModificationObserver
    {
        public static EnableRedoHandler EnableRedoNotifier { get; set; }

        public static EnableUndoHandler EnableUndoNotifier { get; set; }

        public static UpdateTCPClientHandler UpdateTCPClientNotifier { get; set; }

        public static bool IsActionTrackingDisabled { get; set; }

        private static List<WorkingAction> actions = new List<WorkingAction>();
        private static int currentActionIndex = 0;

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

            if (UpdateTCPClientNotifier != null)
                UpdateTCPClientNotifier();
        }

        public static void AddDeleteAction(Shape shape, ref ListBox listBoxShapes, ref GroupBox groupBoxShape)
        {
            if (IsActionTrackingDisabled)
                return;
            UpdateUndoRedoValues();
            actions.Add(new UndoRedo.WorkingActionDelete(shape, Editor.Shapes, ref listBoxShapes, ref groupBoxShape));
        }

        public static void AddModifyAction(Shape shape, Shape storedShape)
        {
            if (IsActionTrackingDisabled)
                return;
            UpdateUndoRedoValues();
            actions.Add(new UndoRedo.WorkingActionModify(shape, storedShape, Editor.Shapes));
        }

        public static void PerformUndo()
        {
            IsActionTrackingDisabled = true;

            actions[currentActionIndex].Undo();

            if (currentActionIndex == 0 && EnableUndoNotifier != null)
                EnableUndoNotifier(false);
            --currentActionIndex;

            if (EnableRedoNotifier != null)
                EnableRedoNotifier(true);

            IsActionTrackingDisabled = false;
        }

        public static void PerformRedo()
        {
            IsActionTrackingDisabled = true;

            ++currentActionIndex;
            if (currentActionIndex == actions.Count - 1 && EnableRedoNotifier != null)
                EnableRedoNotifier(false);

            actions[currentActionIndex].Redo();

            if (EnableUndoNotifier != null)
                EnableUndoNotifier(true);

            IsActionTrackingDisabled = false;
        }

        private static void UpdateUndoRedoValues()
        {
            // when adding a new action to the list, discard all possible redo actions
            if (currentActionIndex < actions.Count - 1)
            {
                actions.RemoveRange(currentActionIndex + 1, actions.Count - currentActionIndex - 1);

                // raise event to disable redo functionality
                if (EnableRedoNotifier != null)
                    EnableRedoNotifier(false);
            }
            currentActionIndex = actions.Count;
        }
    }
}