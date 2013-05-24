namespace Editor
{
    partial class Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxShapes = new System.Windows.Forms.ListBox();
            this.buttonAddRectangle = new System.Windows.Forms.Button();
            this.buttonAddCircle = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxShape = new System.Windows.Forms.GroupBox();
            this.panelCircleSettings = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxCenterPoint = new System.Windows.Forms.GroupBox();
            this.numericUpDownCenterX = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownCenterY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRadius = new System.Windows.Forms.NumericUpDown();
            this.panelRectangleSettings = new System.Windows.Forms.Panel();
            this.radioButtonBottomRight = new System.Windows.Forms.RadioButton();
            this.radioButtonBottomLeft = new System.Windows.Forms.RadioButton();
            this.radioButtonTopRight = new System.Windows.Forms.RadioButton();
            this.radioButtonTopLeft = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownEdgeY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownEdgeX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStripEdit = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogJSON = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxShape.SuspendLayout();
            this.panelCircleSettings.SuspendLayout();
            this.groupBoxCenterPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).BeginInit();
            this.panelRectangleSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEdgeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEdgeX)).BeginInit();
            this.menuStripEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxShapes
            // 
            this.listBoxShapes.FormattingEnabled = true;
            this.listBoxShapes.Location = new System.Drawing.Point(12, 64);
            this.listBoxShapes.Name = "listBoxShapes";
            this.listBoxShapes.Size = new System.Drawing.Size(310, 407);
            this.listBoxShapes.TabIndex = 0;
            this.listBoxShapes.SelectedIndexChanged += new System.EventHandler(this.listBoxShapes_SelectedIndexChanged);
            // 
            // buttonAddRectangle
            // 
            this.buttonAddRectangle.Location = new System.Drawing.Point(12, 34);
            this.buttonAddRectangle.Name = "buttonAddRectangle";
            this.buttonAddRectangle.Size = new System.Drawing.Size(96, 23);
            this.buttonAddRectangle.TabIndex = 1;
            this.buttonAddRectangle.Text = "Add Rectangle";
            this.buttonAddRectangle.UseVisualStyleBackColor = true;
            this.buttonAddRectangle.Click += new System.EventHandler(this.buttonAddShape_Click);
            // 
            // buttonAddCircle
            // 
            this.buttonAddCircle.Location = new System.Drawing.Point(114, 34);
            this.buttonAddCircle.Name = "buttonAddCircle";
            this.buttonAddCircle.Size = new System.Drawing.Size(96, 23);
            this.buttonAddCircle.TabIndex = 2;
            this.buttonAddCircle.Text = "Add Circle";
            this.buttonAddCircle.UseVisualStyleBackColor = true;
            this.buttonAddCircle.Click += new System.EventHandler(this.buttonAddShape_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(216, 34);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(106, 23);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "Remove Selection";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(50, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(332, 20);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.Validated += new System.EventHandler(this.textBoxName_Validated);
            // 
            // groupBoxShape
            // 
            this.groupBoxShape.Controls.Add(this.panelCircleSettings);
            this.groupBoxShape.Controls.Add(this.panelRectangleSettings);
            this.groupBoxShape.Controls.Add(this.label1);
            this.groupBoxShape.Controls.Add(this.textBoxName);
            this.groupBoxShape.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBoxShape.Location = new System.Drawing.Point(334, 64);
            this.groupBoxShape.Name = "groupBoxShape";
            this.groupBoxShape.Size = new System.Drawing.Size(388, 407);
            this.groupBoxShape.TabIndex = 5;
            this.groupBoxShape.TabStop = false;
            this.groupBoxShape.Text = "Shape";
            this.groupBoxShape.Visible = false;
            // 
            // panelCircleSettings
            // 
            this.panelCircleSettings.Controls.Add(this.label6);
            this.panelCircleSettings.Controls.Add(this.groupBoxCenterPoint);
            this.panelCircleSettings.Controls.Add(this.numericUpDownRadius);
            this.panelCircleSettings.Location = new System.Drawing.Point(6, 133);
            this.panelCircleSettings.Name = "panelCircleSettings";
            this.panelCircleSettings.Size = new System.Drawing.Size(375, 82);
            this.panelCircleSettings.TabIndex = 8;
            this.panelCircleSettings.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(236, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Radius";
            // 
            // groupBoxCenterPoint
            // 
            this.groupBoxCenterPoint.Controls.Add(this.numericUpDownCenterX);
            this.groupBoxCenterPoint.Controls.Add(this.label4);
            this.groupBoxCenterPoint.Controls.Add(this.label5);
            this.groupBoxCenterPoint.Controls.Add(this.numericUpDownCenterY);
            this.groupBoxCenterPoint.Location = new System.Drawing.Point(27, 12);
            this.groupBoxCenterPoint.Name = "groupBoxCenterPoint";
            this.groupBoxCenterPoint.Size = new System.Drawing.Size(175, 59);
            this.groupBoxCenterPoint.TabIndex = 4;
            this.groupBoxCenterPoint.TabStop = false;
            this.groupBoxCenterPoint.Text = "Center";
            // 
            // numericUpDownCenterX
            // 
            this.numericUpDownCenterX.Location = new System.Drawing.Point(32, 24);
            this.numericUpDownCenterX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCenterX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownCenterX.Name = "numericUpDownCenterX";
            this.numericUpDownCenterX.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownCenterX.TabIndex = 0;
            this.numericUpDownCenterX.ValueChanged += new System.EventHandler(this.numericUpDownCenter_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "X";
            // 
            // numericUpDownCenterY
            // 
            this.numericUpDownCenterY.Location = new System.Drawing.Point(109, 25);
            this.numericUpDownCenterY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCenterY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownCenterY.Name = "numericUpDownCenterY";
            this.numericUpDownCenterY.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownCenterY.TabIndex = 2;
            this.numericUpDownCenterY.ValueChanged += new System.EventHandler(this.numericUpDownCenter_ValueChanged);
            // 
            // numericUpDownRadius
            // 
            this.numericUpDownRadius.Location = new System.Drawing.Point(278, 35);
            this.numericUpDownRadius.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRadius.Name = "numericUpDownRadius";
            this.numericUpDownRadius.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownRadius.TabIndex = 4;
            this.numericUpDownRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRadius.ValueChanged += new System.EventHandler(this.numericUpDownRadius_ValueChanged);
            // 
            // panelRectangleSettings
            // 
            this.panelRectangleSettings.Controls.Add(this.radioButtonBottomRight);
            this.panelRectangleSettings.Controls.Add(this.radioButtonBottomLeft);
            this.panelRectangleSettings.Controls.Add(this.radioButtonTopRight);
            this.panelRectangleSettings.Controls.Add(this.radioButtonTopLeft);
            this.panelRectangleSettings.Controls.Add(this.label3);
            this.panelRectangleSettings.Controls.Add(this.numericUpDownEdgeY);
            this.panelRectangleSettings.Controls.Add(this.label2);
            this.panelRectangleSettings.Controls.Add(this.numericUpDownEdgeX);
            this.panelRectangleSettings.Location = new System.Drawing.Point(6, 45);
            this.panelRectangleSettings.Name = "panelRectangleSettings";
            this.panelRectangleSettings.Size = new System.Drawing.Size(375, 82);
            this.panelRectangleSettings.TabIndex = 6;
            this.panelRectangleSettings.Visible = false;
            // 
            // radioButtonBottomRight
            // 
            this.radioButtonBottomRight.AutoSize = true;
            this.radioButtonBottomRight.Location = new System.Drawing.Point(258, 12);
            this.radioButtonBottomRight.Name = "radioButtonBottomRight";
            this.radioButtonBottomRight.Size = new System.Drawing.Size(86, 17);
            this.radioButtonBottomRight.TabIndex = 7;
            this.radioButtonBottomRight.TabStop = true;
            this.radioButtonBottomRight.Text = "Bottom Right";
            this.radioButtonBottomRight.UseVisualStyleBackColor = true;
            this.radioButtonBottomRight.CheckedChanged += new System.EventHandler(this.radioButtonEdge_CheckedChanged);
            // 
            // radioButtonBottomLeft
            // 
            this.radioButtonBottomLeft.AutoSize = true;
            this.radioButtonBottomLeft.Location = new System.Drawing.Point(173, 12);
            this.radioButtonBottomLeft.Name = "radioButtonBottomLeft";
            this.radioButtonBottomLeft.Size = new System.Drawing.Size(79, 17);
            this.radioButtonBottomLeft.TabIndex = 6;
            this.radioButtonBottomLeft.TabStop = true;
            this.radioButtonBottomLeft.Text = "Bottom Left";
            this.radioButtonBottomLeft.UseVisualStyleBackColor = true;
            this.radioButtonBottomLeft.CheckedChanged += new System.EventHandler(this.radioButtonEdge_CheckedChanged);
            // 
            // radioButtonTopRight
            // 
            this.radioButtonTopRight.AutoSize = true;
            this.radioButtonTopRight.Location = new System.Drawing.Point(95, 12);
            this.radioButtonTopRight.Name = "radioButtonTopRight";
            this.radioButtonTopRight.Size = new System.Drawing.Size(72, 17);
            this.radioButtonTopRight.TabIndex = 5;
            this.radioButtonTopRight.TabStop = true;
            this.radioButtonTopRight.Text = "Top Right";
            this.radioButtonTopRight.UseVisualStyleBackColor = true;
            this.radioButtonTopRight.CheckedChanged += new System.EventHandler(this.radioButtonEdge_CheckedChanged);
            // 
            // radioButtonTopLeft
            // 
            this.radioButtonTopLeft.AutoSize = true;
            this.radioButtonTopLeft.Location = new System.Drawing.Point(24, 12);
            this.radioButtonTopLeft.Name = "radioButtonTopLeft";
            this.radioButtonTopLeft.Size = new System.Drawing.Size(65, 17);
            this.radioButtonTopLeft.TabIndex = 4;
            this.radioButtonTopLeft.TabStop = true;
            this.radioButtonTopLeft.Text = "Top Left";
            this.radioButtonTopLeft.UseVisualStyleBackColor = true;
            this.radioButtonTopLeft.CheckedChanged += new System.EventHandler(this.radioButtonEdge_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Y";
            // 
            // numericUpDownEdgeY
            // 
            this.numericUpDownEdgeY.Location = new System.Drawing.Point(188, 44);
            this.numericUpDownEdgeY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownEdgeY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownEdgeY.Name = "numericUpDownEdgeY";
            this.numericUpDownEdgeY.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownEdgeY.TabIndex = 2;
            this.numericUpDownEdgeY.ValueChanged += new System.EventHandler(this.numericUpDownEdge_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            // 
            // numericUpDownEdgeX
            // 
            this.numericUpDownEdgeX.Location = new System.Drawing.Point(111, 43);
            this.numericUpDownEdgeX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownEdgeX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownEdgeX.Name = "numericUpDownEdgeX";
            this.numericUpDownEdgeX.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownEdgeX.TabIndex = 0;
            this.numericUpDownEdgeX.ValueChanged += new System.EventHandler(this.numericUpDownEdge_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // menuStripEdit
            // 
            this.menuStripEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.menuStripEdit.Location = new System.Drawing.Point(0, 0);
            this.menuStripEdit.Name = "menuStripEdit";
            this.menuStripEdit.Size = new System.Drawing.Size(734, 24);
            this.menuStripEdit.TabIndex = 6;
            this.menuStripEdit.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.exportToJSONToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // exportToJSONToolStripMenuItem
            // 
            this.exportToJSONToolStripMenuItem.Name = "exportToJSONToolStripMenuItem";
            this.exportToJSONToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.exportToJSONToolStripMenuItem.Text = "Export to JSON...";
            this.exportToJSONToolStripMenuItem.Click += new System.EventHandler(this.exportToJSONToolStripMenuItem_Click);
            // 
            // saveFileDialogJSON
            // 
            this.saveFileDialogJSON.Filter = "JSON|*.json";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 487);
            this.Controls.Add(this.groupBoxShape);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAddCircle);
            this.Controls.Add(this.buttonAddRectangle);
            this.Controls.Add(this.listBoxShapes);
            this.Controls.Add(this.menuStripEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStripEdit;
            this.Name = "Editor";
            this.Text = "Circle/Rectangle Editor";
            this.Load += new System.EventHandler(this.Editor_Load);
            this.groupBoxShape.ResumeLayout(false);
            this.groupBoxShape.PerformLayout();
            this.panelCircleSettings.ResumeLayout(false);
            this.panelCircleSettings.PerformLayout();
            this.groupBoxCenterPoint.ResumeLayout(false);
            this.groupBoxCenterPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).EndInit();
            this.panelRectangleSettings.ResumeLayout(false);
            this.panelRectangleSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEdgeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEdgeX)).EndInit();
            this.menuStripEdit.ResumeLayout(false);
            this.menuStripEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxShapes;
        private System.Windows.Forms.Button buttonAddRectangle;
        private System.Windows.Forms.Button buttonAddCircle;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBoxShape;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelRectangleSettings;
        private System.Windows.Forms.NumericUpDown numericUpDownEdgeX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownEdgeY;
        private System.Windows.Forms.RadioButton radioButtonBottomRight;
        private System.Windows.Forms.RadioButton radioButtonBottomLeft;
        private System.Windows.Forms.RadioButton radioButtonTopRight;
        private System.Windows.Forms.RadioButton radioButtonTopLeft;
        private System.Windows.Forms.Panel panelCircleSettings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxCenterPoint;
        private System.Windows.Forms.NumericUpDown numericUpDownCenterX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownCenterY;
        private System.Windows.Forms.NumericUpDown numericUpDownRadius;
        private System.Windows.Forms.MenuStrip menuStripEdit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToJSONToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogJSON;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    }
}

