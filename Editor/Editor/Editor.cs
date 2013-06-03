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
        public static BindingList<Shape> Shapes { get; set; }
        
        public Editor()
        {
            InitializeComponent();
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            Shapes = new BindingList<Shape>();

            listBoxShapes.DisplayMember = Constants.DISPLAY_MEMBER;
            listBoxShapes.DataSource = Shapes;
            textBoxName.DataBindings.Add(Constants.BINDING_TEXT, Shapes, Constants.BINDING_NAME);
        }

        private void buttonAddShape_Click(object sender, EventArgs e)
        {
            if (sender == buttonAddRectangle)
                Shapes.Add(new RectangleShape());
            else
                Shapes.Add(new CircleShape());

            // select the last element in the listbox
            listBoxShapes.SelectedIndex = listBoxShapes.Items.Count - 1;
            buttonRemove.Enabled = true;
            groupBoxShape.Visible = true;

            // when adding the very first shape selectedindexchanged event is not called so we need to update setting controls manually
            if (Shapes.Count == 1)
                UpdateShapePanel(listBoxShapes.SelectedItem as Shape);

            ModificationObserver.AddAddAction(listBoxShapes.SelectedItem as Shape, ref listBoxShapes, ref groupBoxShape);
            undoToolStripMenuItem.Enabled = true;
        }

        private void listBoxShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // when nothing is selected do nothing
            if(listBoxShapes.SelectedIndex < 0)
                return;

            UpdateShapePanel(listBoxShapes.SelectedItem as Shape);
        }

        private void UpdateShapePanel(Shape selectedShape)
        {
            panelShapeValues.Controls.Clear();
            ShapeControls.ShapeControl newControl = selectedShape.Control;
            newControl.CurrentShape = selectedShape;
            panelShapeValues.Controls.Add(newControl);
            newControl.Show();
            selectedShape.Select();
        }

        private void textBoxName_Validated(object sender, EventArgs e)
        {
            // refresh listbox when new text has been typed
            // since RefreshItems is declared as private we need to do a little hack here to call this function
            typeof(ListBox).InvokeMember("RefreshItems",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, listBoxShapes, new object[] { });
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            ModificationObserver.AddDeleteAction(listBoxShapes.SelectedItem as Shape, ref listBoxShapes, ref groupBoxShape);

            Shapes.RemoveAt(listBoxShapes.SelectedIndex);

            if (listBoxShapes.Items.Count <= 0)
            {
                buttonRemove.Enabled = false;
                groupBoxShape.Visible = false;
            }
        }

        private void exportToJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogJSON.ShowDialog() == DialogResult.OK)
            {
                using (TextWriter textWriter = new StreamWriter(saveFileDialogJSON.FileName))
                    textWriter.Write(JsonConvert.SerializeObject(Shapes));
            }
        }
 
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificationObserver.PerformUndo(ref undoToolStripMenuItem, ref redoToolStripMenuItem);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificationObserver.PerformRedo(ref undoToolStripMenuItem, ref redoToolStripMenuItem);
        }
    }
}
