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
        BindingList<Shape> shapes = new BindingList<Shape>();

        public Editor()
        {
            InitializeComponent();
        }

        private void UpdateSettingControls()
        {
            if(listBoxShapes.SelectedItem is RectangleShape)
            {
                groupBoxShape.Text = Constants.HEADING_RECTANGLE;
                panelRectangleSettings.Visible = true;
                panelCircleSettings.Visible = false;
                radioButtonTopLeft.Checked = true;
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

        private int GetActiveEdgeIndex()
        { 
            return  0 + (radioButtonTopRight.Checked ? 1 : 0) + 
                    (radioButtonBottomLeft.Checked ? 2 : 0) + 
                    (radioButtonBottomRight.Checked ? 3 : 0); 
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
            groupBoxShape.Enabled = true;

            // when adding the very first shape selectedindexchanged event is not called so we need to update setting controls manually
            if (shapes.Count == 1)
                UpdateSettingControls();
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
            // refresh listbox when new text has been typed
            // since RefreshItems is declared as private we need to do a little hack here to call this function
            typeof(ListBox).InvokeMember("RefreshItems",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, listBoxShapes, new object[] { });
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            shapes.RemoveAt(listBoxShapes.SelectedIndex);

            if (listBoxShapes.Items.Count <= 0)
            {
                buttonRemove.Enabled = false;
                groupBoxShape.Enabled = false;
                groupBoxShape.Text = Constants.HEADING_SHAPE;
                panelCircleSettings.Visible = false;
                panelRectangleSettings.Visible = false;
            }
        }

        private void numericUpDownEdge_ValueChanged(object sender, EventArgs e)
        {
            if (!(shapes[listBoxShapes.SelectedIndex] is RectangleShape))
            {
                MessageBox.Show(Constants.ERROR_NO_RECTANGLE);
                return;
            }

            (shapes[listBoxShapes.SelectedIndex] as RectangleShape).EdgePoints[GetActiveEdgeIndex()] = 
                new Point(Convert.ToInt32(numericUpDownEdgeX.Value), Convert.ToInt32(numericUpDownEdgeY.Value));
        }

        private void radioButtonEdge_CheckedChanged(object sender, EventArgs e)
        {
            if (!(shapes[listBoxShapes.SelectedIndex] is RectangleShape))
            {
                MessageBox.Show(Constants.ERROR_NO_RECTANGLE);
                return;
            }

            Point selectedEdgePoint = (shapes[listBoxShapes.SelectedIndex] as RectangleShape).EdgePoints[GetActiveEdgeIndex()];
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
    }
}
