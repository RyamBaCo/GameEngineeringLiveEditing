using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace Editor
{
    public partial class Editor : Form
    {
        public int ActiveEdgeIndex
        {
            get
            {
                return 0 + (radioButtonTopRight.Checked ? 1 : 0) +
                    (radioButtonBottomLeft.Checked ? 2 : 0) +
                    (radioButtonBottomRight.Checked ? 3 : 0); 
            }

            private set
            {
                radioButtonTopLeft.Checked = value <= 0;
                radioButtonTopRight.Checked = value == 1;
                radioButtonBottomLeft.Checked = value == 2;
                radioButtonBottomRight.Checked = value >= 3;
            }
        }

        BindingList<Shape> shapes = new BindingList<Shape>();
        List<WorkingAction> actions = new List<WorkingAction>();
        int currentActionIndex = 0;
        bool isActionTrackingDisabled = false;

        public Editor()
        {
            InitializeComponent();
        }

        private void UpdateSettingControls(int activeEdgeIndex)
        {
            if (listBoxShapes.SelectedItem is RectangleShape)
            {
                groupBoxShape.Text = Constants.HEADING_RECTANGLE;
                panelRectangleSettings.Visible = true;
                panelCircleSettings.Visible = false;
                ActiveEdgeIndex = activeEdgeIndex;
            }
            else
            {
                groupBoxShape.Text = Constants.HEADING_CIRCLE;
                panelRectangleSettings.Visible = false;
                panelCircleSettings.Visible = true;
                Point centerPoint = (listBoxShapes.SelectedItem as CircleShape).Center;
                numericUpDownCenterX.Value = centerPoint.X;
                numericUpDownCenterY.Value = centerPoint.Y;
                numericUpDownRadius.Value = (listBoxShapes.SelectedItem as CircleShape).Radius;
            }
        }

        private void UpdateSettingControls()
        {
            // by default display top left point of rectangle
            UpdateSettingControls(0);
        }

        private void AddModifyAction()
        {
            if(isActionTrackingDisabled)
                return;
            UpdateUndoRedoValues();

            if (listBoxShapes.SelectedItem is RectangleShape)
                actions.Add(new UndoRedo.WorkingActionModifyRectangle(new RectangleShape(listBoxShapes.SelectedItem as RectangleShape), ref shapes, ActiveEdgeIndex));
            else
                actions.Add(new UndoRedo.WorkingActionModify(new CircleShape(listBoxShapes.SelectedItem as CircleShape), ref shapes));
        }

        private void AddAddAction()
        {
            if (isActionTrackingDisabled)
                return;
            UpdateUndoRedoValues();
            actions.Add(new UndoRedo.WorkingActionAdd(shapes[listBoxShapes.SelectedIndex], ref shapes, ref listBoxShapes, ref groupBoxShape));
        }

        private void AddDeleteAction()
        {
            if (isActionTrackingDisabled)
                return;
            UpdateUndoRedoValues();
            actions.Add(new UndoRedo.WorkingActionDelete(shapes[listBoxShapes.SelectedIndex], ref shapes, ref listBoxShapes, ref groupBoxShape));
        }

        private void UpdateUndoRedoValues()
        {
            if (currentActionIndex < actions.Count)
                actions.RemoveRange(currentActionIndex + 1, actions.Count - currentActionIndex - 1);
            currentActionIndex = actions.Count;

            undoToolStripMenuItem.Enabled = true;
            redoToolStripMenuItem.Enabled = false;
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            listBoxShapes.DisplayMember = Constants.DISPLAY_MEMBER;
            listBoxShapes.DataSource = shapes;
            textBoxName.DataBindings.Add(Constants.BINDING_TEXT, shapes, Constants.BINDING_NAME);
            panelCircleSettings.Location = panelRectangleSettings.Location;
        }

        private void buttonAddShape_Click(object sender, EventArgs e)
        {
            if (sender == buttonAddRectangle)
                shapes.Add(new RectangleShape());
            else
                shapes.Add(new CircleShape());

            // select the last element in the listbox
            listBoxShapes.SelectedIndex = listBoxShapes.Items.Count - 1;
            buttonRemove.Enabled = true;
            groupBoxShape.Visible = true;

            // when adding the very first shape selectedindexchanged event is not called so we need to update setting controls manually
            if (shapes.Count == 1)
                UpdateSettingControls();

            AddAddAction();
        }

        private void listBoxShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // when nothing is selected do nothing
            if(listBoxShapes.SelectedIndex < 0)
                return;

            if(!(listBoxShapes.SelectedItem is Shape))
            {
                MessageBox.Show(Constants.ERROR_NO_SHAPE);
                return;
            }

            UpdateSettingControls();
            textBoxName.Text = (listBoxShapes.SelectedItem as Shape).Name;
        }

        private void textBoxName_Validated(object sender, EventArgs e)
        {
            if(listBoxShapes.Items.Count > 0)
                AddModifyAction();
            // refresh listbox when new text has been typed
            // since RefreshItems is declared as private we need to do a little hack here to call this function
            typeof(ListBox).InvokeMember("RefreshItems",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, listBoxShapes, new object[] { });
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            AddDeleteAction();
            shapes.RemoveAt(listBoxShapes.SelectedIndex);

            if (listBoxShapes.Items.Count <= 0)
            {
                buttonRemove.Enabled = false;
                groupBoxShape.Visible = false;
            }
        }

        private void numericUpDownEdge_ValueChanged(object sender, EventArgs e)
        {
            if (!(shapes[listBoxShapes.SelectedIndex] is RectangleShape))
            {
                MessageBox.Show(Constants.ERROR_NO_RECTANGLE);
                return;
            }

            AddModifyAction();

            (shapes[listBoxShapes.SelectedIndex] as RectangleShape).EdgePoints[ActiveEdgeIndex] = 
                new Point(Convert.ToInt32(numericUpDownEdgeX.Value), Convert.ToInt32(numericUpDownEdgeY.Value));
        }

        private void radioButtonEdge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEdgePointValues();
        }

        private void UpdateEdgePointValues()
        {
            if (!(shapes[listBoxShapes.SelectedIndex] is RectangleShape))
            {
                MessageBox.Show(Constants.ERROR_NO_RECTANGLE);
                return;
            }

            Point selectedEdgePoint = (shapes[listBoxShapes.SelectedIndex] as RectangleShape).EdgePoints[ActiveEdgeIndex];
            numericUpDownEdgeX.Value = selectedEdgePoint.X;
            numericUpDownEdgeY.Value = selectedEdgePoint.Y;
        }

        private void numericUpDownCenter_ValueChanged(object sender, EventArgs e)
        {
            if (!(shapes[listBoxShapes.SelectedIndex] is CircleShape))
            {
                MessageBox.Show(Constants.ERROR_NO_CIRCLE);
                return;
            }

            AddModifyAction();

            (shapes[listBoxShapes.SelectedIndex] as CircleShape).Center =
               new Point(Convert.ToInt32(numericUpDownCenterX.Value), Convert.ToInt32(numericUpDownCenterY.Value));
        }

        private void numericUpDownRadius_ValueChanged(object sender, EventArgs e)
        {
            if (!(shapes[listBoxShapes.SelectedIndex] is CircleShape))
            {
                MessageBox.Show(Constants.ERROR_NO_CIRCLE);
                return;
            }

            AddModifyAction();

            (shapes[listBoxShapes.SelectedIndex] as CircleShape).Radius = Convert.ToUInt32(numericUpDownRadius.Value);
        }

        private void exportToJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogJSON.ShowDialog() == DialogResult.OK)
            {
                using (TextWriter textWriter = new StreamWriter(saveFileDialogJSON.FileName))
                    textWriter.Write(JsonConvert.SerializeObject(shapes));
            }
        }

        private void UpdateShapeValuesAfterUndoRedo()
        {
            // when there are no values there is nothing to update
            if (listBoxShapes.Items.Count == 0)
                return;

            if (actions[currentActionIndex] is UndoRedo.WorkingActionModifyRectangle)
            {
                int currentEdgeIndex = (actions[currentActionIndex] as UndoRedo.WorkingActionModifyRectangle).ActiveEdgeIndex;
                if (currentEdgeIndex == ActiveEdgeIndex)
                    UpdateEdgePointValues();
                UpdateSettingControls(currentEdgeIndex);
            }
            else
                UpdateSettingControls();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isActionTrackingDisabled = true;

            actions[currentActionIndex].Undo();
            UpdateShapeValuesAfterUndoRedo();

            if (currentActionIndex == 0)
                undoToolStripMenuItem.Enabled = false;
            --currentActionIndex;
            
            redoToolStripMenuItem.Enabled = true;

            isActionTrackingDisabled = false;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isActionTrackingDisabled = true;

            ++currentActionIndex;
            if (currentActionIndex == actions.Count - 1)
                redoToolStripMenuItem.Enabled = false;

            actions[currentActionIndex].Redo();
            UpdateShapeValuesAfterUndoRedo();
            
            undoToolStripMenuItem.Enabled = true;

            isActionTrackingDisabled = false;
        }
    }
}
