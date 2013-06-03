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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStripEdit = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogJSON = new System.Windows.Forms.SaveFileDialog();
            this.panelShapeValues = new System.Windows.Forms.Panel();
            this.groupBoxShape.SuspendLayout();
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
            this.groupBoxShape.Controls.Add(this.panelShapeValues);
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
            // panelShapeValues
            // 
            this.panelShapeValues.Location = new System.Drawing.Point(9, 54);
            this.panelShapeValues.Name = "panelShapeValues";
            this.panelShapeValues.Size = new System.Drawing.Size(373, 99);
            this.panelShapeValues.TabIndex = 9;
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
        private System.Windows.Forms.MenuStrip menuStripEdit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToJSONToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogJSON;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.Panel panelShapeValues;
    }
}

