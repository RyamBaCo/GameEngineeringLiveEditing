using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Editor.ShapeControls
{
    public partial class RectangleControl : ShapeControl
    {
        static readonly RectangleControl instance = new RectangleControl();
        public static RectangleControl Instance { get { return instance; } }

        NumericUpDown[,] edgeValues;

        public RectangleControl()
        {
            InitializeComponent();

            edgeValues = new NumericUpDown[,] { 
                { numericUpDownTopLeftX, numericUpDownTopLeftY },  
                { numericUpDownTopRightX, numericUpDownTopRightY },  
                { numericUpDownBottomRightX, numericUpDownBottomRightY },  
                { numericUpDownBottomLeftX, numericUpDownBottomLeftY },  
            };
        }

        public override void UpdateControlView()
        {
            ModificationObserver.IsActionTrackingDisabled = true;

            for (int i = 0; i < Constants.RECTANGLE_EDGES; ++i)
            {
                Point currentEdgePoint = (CurrentShape as RectangleShape).EdgePoints[i];
                edgeValues[i, 0].Value = currentEdgePoint.X;
                edgeValues[i, 1].Value = currentEdgePoint.Y;
            }

            ModificationObserver.IsActionTrackingDisabled = false;
        }

        private void UpdateEdgeValuesAt(int index)
        {
            ModificationObserver.AddModifyAction(new RectangleShape(CurrentShape as RectangleShape));
            (CurrentShape as RectangleShape).EdgePoints[index] = new Point(Convert.ToInt32(edgeValues[index, 0].Value), Convert.ToInt32(edgeValues[index, 1].Value));
        }

        private void numericUpDownTopLeft_ValueChanged(object sender, EventArgs e)
        {
            UpdateEdgeValuesAt(0);
        }

        private void numericUpDownTopRight_ValueChanged(object sender, EventArgs e)
        {
            UpdateEdgeValuesAt(1);
        }

        private void numericUpDownBottomRight_ValueChanged(object sender, EventArgs e)
        {
            UpdateEdgeValuesAt(2);
        }

        private void numericUpDownBottomLeft_ValueChanged(object sender, EventArgs e)
        {
            UpdateEdgeValuesAt(3);
        }
    }
}
