namespace ExSharpBase.Menu
{
    partial class BasePlate
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DrawRangeCheckBox = new System.Windows.Forms.CheckBox();
            this.MoveToMouseCheckBox = new System.Windows.Forms.CheckBox();
            this.DrawTurretRangeCheckBox = new System.Windows.Forms.CheckBox();
            this.DrawExecutionCheckBox = new System.Windows.Forms.CheckBox();
            this.DrawEnemyWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.DrawEnemyWarningRangeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.DrawMinionExecutionCheckBox = new System.Windows.Forms.CheckBox();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawEnemyWarningRangeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(299, 30);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu";
            // 
            // DrawRangeCheckBox
            // 
            this.DrawRangeCheckBox.AutoSize = true;
            this.DrawRangeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawRangeCheckBox.ForeColor = System.Drawing.Color.White;
            this.DrawRangeCheckBox.Location = new System.Drawing.Point(26, 64);
            this.DrawRangeCheckBox.Name = "DrawRangeCheckBox";
            this.DrawRangeCheckBox.Size = new System.Drawing.Size(117, 24);
            this.DrawRangeCheckBox.TabIndex = 1;
            this.DrawRangeCheckBox.Text = "Draw Range";
            this.DrawRangeCheckBox.UseVisualStyleBackColor = true;
            this.DrawRangeCheckBox.CheckedChanged += new System.EventHandler(this.DrawRangeCheckBox_CheckedChanged);
            // 
            // MoveToMouseCheckBox
            // 
            this.MoveToMouseCheckBox.AutoSize = true;
            this.MoveToMouseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveToMouseCheckBox.ForeColor = System.Drawing.Color.White;
            this.MoveToMouseCheckBox.Location = new System.Drawing.Point(26, 109);
            this.MoveToMouseCheckBox.Name = "MoveToMouseCheckBox";
            this.MoveToMouseCheckBox.Size = new System.Drawing.Size(132, 24);
            this.MoveToMouseCheckBox.TabIndex = 2;
            this.MoveToMouseCheckBox.Text = "MoveToMouse";
            this.MoveToMouseCheckBox.UseVisualStyleBackColor = true;
            this.MoveToMouseCheckBox.CheckedChanged += new System.EventHandler(this.MoveToMouseCheckBox_CheckedChanged);
            // 
            // DrawTurretRangeCheckBox
            // 
            this.DrawTurretRangeCheckBox.AutoSize = true;
            this.DrawTurretRangeCheckBox.Checked = true;
            this.DrawTurretRangeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DrawTurretRangeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawTurretRangeCheckBox.ForeColor = System.Drawing.Color.White;
            this.DrawTurretRangeCheckBox.Location = new System.Drawing.Point(26, 154);
            this.DrawTurretRangeCheckBox.Name = "DrawTurretRangeCheckBox";
            this.DrawTurretRangeCheckBox.Size = new System.Drawing.Size(163, 24);
            this.DrawTurretRangeCheckBox.TabIndex = 3;
            this.DrawTurretRangeCheckBox.Text = "Draw Turret Range";
            this.DrawTurretRangeCheckBox.UseVisualStyleBackColor = true;
            this.DrawTurretRangeCheckBox.CheckedChanged += new System.EventHandler(this.DrawTurretRangeCheckBox_CheckedChanged);
            // 
            // DrawExecutionCheckBox
            // 
            this.DrawExecutionCheckBox.AutoSize = true;
            this.DrawExecutionCheckBox.Checked = true;
            this.DrawExecutionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DrawExecutionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawExecutionCheckBox.ForeColor = System.Drawing.Color.White;
            this.DrawExecutionCheckBox.Location = new System.Drawing.Point(26, 199);
            this.DrawExecutionCheckBox.Name = "DrawExecutionCheckBox";
            this.DrawExecutionCheckBox.Size = new System.Drawing.Size(139, 24);
            this.DrawExecutionCheckBox.TabIndex = 3;
            this.DrawExecutionCheckBox.Text = "Draw Execution";
            this.DrawExecutionCheckBox.UseVisualStyleBackColor = true;
            this.DrawExecutionCheckBox.CheckedChanged += new System.EventHandler(this.DrawExecutionCheckBox_CheckedChanged);
            // 
            // DrawEnemyWarningCheckBox
            // 
            this.DrawEnemyWarningCheckBox.AutoSize = true;
            this.DrawEnemyWarningCheckBox.Checked = true;
            this.DrawEnemyWarningCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DrawEnemyWarningCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawEnemyWarningCheckBox.ForeColor = System.Drawing.Color.White;
            this.DrawEnemyWarningCheckBox.Location = new System.Drawing.Point(26, 289);
            this.DrawEnemyWarningCheckBox.Name = "DrawEnemyWarningCheckBox";
            this.DrawEnemyWarningCheckBox.Size = new System.Drawing.Size(181, 24);
            this.DrawEnemyWarningCheckBox.TabIndex = 4;
            this.DrawEnemyWarningCheckBox.Text = "Draw Enemy Warning";
            this.DrawEnemyWarningCheckBox.UseVisualStyleBackColor = true;
            this.DrawEnemyWarningCheckBox.CheckedChanged += new System.EventHandler(this.DrawEnemyWarningCheckBox_CheckedChanged);
            // 
            // DrawEnemyWarningRangeNumericUpDown
            // 
            this.DrawEnemyWarningRangeNumericUpDown.Location = new System.Drawing.Point(117, 319);
            this.DrawEnemyWarningRangeNumericUpDown.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.DrawEnemyWarningRangeNumericUpDown.Name = "DrawEnemyWarningRangeNumericUpDown";
            this.DrawEnemyWarningRangeNumericUpDown.Size = new System.Drawing.Size(67, 20);
            this.DrawEnemyWarningRangeNumericUpDown.TabIndex = 5;
            this.DrawEnemyWarningRangeNumericUpDown.ThousandsSeparator = true;
            this.DrawEnemyWarningRangeNumericUpDown.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.DrawEnemyWarningRangeNumericUpDown.ValueChanged += new System.EventHandler(this.DrawEnemyWarningRangeNumericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(50, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Range:";
            // 
            // DrawMinionExecutionCheckBox
            // 
            this.DrawMinionExecutionCheckBox.AutoSize = true;
            this.DrawMinionExecutionCheckBox.Checked = true;
            this.DrawMinionExecutionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DrawMinionExecutionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawMinionExecutionCheckBox.ForeColor = System.Drawing.Color.White;
            this.DrawMinionExecutionCheckBox.Location = new System.Drawing.Point(26, 244);
            this.DrawMinionExecutionCheckBox.Name = "DrawMinionExecutionCheckBox";
            this.DrawMinionExecutionCheckBox.Size = new System.Drawing.Size(189, 24);
            this.DrawMinionExecutionCheckBox.TabIndex = 7;
            this.DrawMinionExecutionCheckBox.Text = "Draw Minion Execution";
            this.DrawMinionExecutionCheckBox.UseVisualStyleBackColor = true;
            this.DrawMinionExecutionCheckBox.CheckedChanged += new System.EventHandler(this.DrawMinionExecutionCheckBox_CheckedChanged);
            // 
            // BasePlate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(33)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(299, 384);
            this.Controls.Add(this.DrawMinionExecutionCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DrawEnemyWarningRangeNumericUpDown);
            this.Controls.Add(this.DrawEnemyWarningCheckBox);
            this.Controls.Add(this.DrawExecutionCheckBox);
            this.Controls.Add(this.DrawTurretRangeCheckBox);
            this.Controls.Add(this.MoveToMouseCheckBox);
            this.Controls.Add(this.DrawRangeCheckBox);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BasePlate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BasePlate_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawEnemyWarningRangeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox DrawRangeCheckBox;
        private System.Windows.Forms.CheckBox MoveToMouseCheckBox;
        private System.Windows.Forms.CheckBox DrawTurretRangeCheckBox;
        private System.Windows.Forms.CheckBox DrawExecutionCheckBox;
        private System.Windows.Forms.CheckBox DrawEnemyWarningCheckBox;
        private System.Windows.Forms.NumericUpDown DrawEnemyWarningRangeNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox DrawMinionExecutionCheckBox;
    }
}