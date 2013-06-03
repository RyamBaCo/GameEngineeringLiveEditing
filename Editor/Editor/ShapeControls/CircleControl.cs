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
    public partial class CircleControl : ShapeControl
    {
        static readonly CircleControl instance = new CircleControl();
        public static CircleControl Instance { get { return instance; } }

        private CircleControl()
        {
            InitializeComponent();
        }

        public override void UpdateControlView()
        {
            ModificationObserver.IsActionTrackingDisabled = true;

            Point newCenterPoint = (CurrentShape as CircleShape).Center;

            numericUpDownRadius.Value = (CurrentShape as CircleShape).Radius;
            numericUpDownCenterX.Value = newCenterPoint.X;
            numericUpDownCenterY.Value = newCenterPoint.Y;

            ModificationObserver.IsActionTrackingDisabled = false;
        }

        private void numericUpDownCenter_ValueChanged(object sender, EventArgs e)
        {
            ModificationObserver.AddModifyAction(new CircleShape(CurrentShape as CircleShape));
            (CurrentShape as CircleShape).Center = new Point(Convert.ToInt32(numericUpDownCenterX.Value), Convert.ToInt32(numericUpDownCenterY.Value));
        }

        private void numericUpDownRadius_ValueChanged(object sender, EventArgs e)
        {
            ModificationObserver.AddModifyAction(new CircleShape(CurrentShape as CircleShape));
            (CurrentShape as CircleShape).Radius = Convert.ToUInt32(numericUpDownRadius.Value);
        }
    }
}
