namespace Editor.ShapeControls
{
    partial class CircleControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxCenterPoint = new System.Windows.Forms.GroupBox();
            this.numericUpDownCenterX = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownCenterY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRadius = new System.Windows.Forms.NumericUpDown();
            this.groupBoxCenterPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 27);
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
            this.groupBoxCenterPoint.Location = new System.Drawing.Point(3, 3);
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
            this.numericUpDownRadius.Location = new System.Drawing.Point(226, 25);
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
            // CircleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownRadius);
            this.Controls.Add(this.groupBoxCenterPoint);
            this.Name = "CircleControl";
            this.Size = new System.Drawing.Size(289, 71);
            this.groupBoxCenterPoint.ResumeLayout(false);
            this.groupBoxCenterPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxCenterPoint;
        private System.Windows.Forms.NumericUpDown numericUpDownCenterX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownCenterY;
        private System.Windows.Forms.NumericUpDown numericUpDownRadius;
    }
}
