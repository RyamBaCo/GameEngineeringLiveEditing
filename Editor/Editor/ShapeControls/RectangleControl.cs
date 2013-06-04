using System;
using System.Drawing;
using System.Windows.Forms;

namespace Editor.ShapeControls
{
    public partial class RectangleControl : ShapeControl
    {
        private static readonly RectangleControl instance = new RectangleControl();

        public static RectangleControl Instance { get { return instance; } }

        private NumericUpDown[,] edgeValues;

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
            ModificationObserver.AddModifyAction(CurrentShape, new RectangleShape(CurrentShape as RectangleShape));
            (CurrentShape as RectangleShape).EdgePoints[index] = new Point(Convert.ToInt32(edgeValues[index, 0].Value), Convert.ToInt32(edgeValues[index, 1].Value));

            if (ModificationObserver.UpdateTCPClientNotifier != null)
                ModificationObserver.UpdateTCPClientNotifier();
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