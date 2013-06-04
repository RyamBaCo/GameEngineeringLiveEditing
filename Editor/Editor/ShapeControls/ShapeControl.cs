using System.Windows.Forms;

namespace Editor.ShapeControls
{
    public abstract class ShapeControl : UserControl
    {
        public Shape CurrentShape { get; set; }

        public abstract void UpdateControlView();
    }
}