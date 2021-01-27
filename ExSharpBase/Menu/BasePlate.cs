using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ExSharpBase.Modules;
using ExSharpBase.Events;
using ExSharpBase.Game.Spells;

namespace ExSharpBase.Menu
{
    public partial class BasePlate : Form
    {
        public BasePlate()
        {
            InitializeComponent();
        }

        private void BasePlate_Load(object sender, EventArgs e)
        {
            DrawRangeCheckBox_CheckedChanged(null, null);
            MoveToMouseCheckBox_CheckedChanged(null, null);
            DrawTurretRangeCheckBox_CheckedChanged(null, null);
            DrawExecutionCheckBox_CheckedChanged(null, null);
            DrawMinionExecutionCheckBox_CheckedChanged(null, null);
            DrawEnemyWarningCheckBox_CheckedChanged(null, null);
            DrawEnemyWarningRangeNumericUpDown_ValueChanged(null, null);
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeImport.ReleaseCapture();
                NativeImport.SendMessage(Handle, NativeImport.WM_NCLBUTTONDOWN, NativeImport.HTCAPTION, 0);
            }
        }

        private void DrawRangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Drawing.DrawingProperties.DrawRange = DrawRangeCheckBox.Checked;
        }

        private void MoveToMouseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MoveToMouseCheckBox.Checked)
            {
                this.Hide();

                NativeImport.SetForegroundWindow(Utils.GetLeagueProcess().MainWindowHandle);

                Thread.Sleep(1000); //Prevents instant IssueOrder when League window isn't active.

                Game.Engine.IssueOrder(Enums.GameObjectOrder.MoveTo);
            }
        }

        private void DrawTurretRangeCheckBox_CheckedChanged(object sender, EventArgs e) {
            Drawing.DrawingProperties.DrawTurretRange = DrawTurretRangeCheckBox.Checked;
        }

        private void DrawExecutionCheckBox_CheckedChanged(object sender, EventArgs e) {
            Drawing.DrawingProperties.DrawExecution = DrawExecutionCheckBox.Checked;
        }

        private void DrawMinionExecutionCheckBox_CheckedChanged(object sender, EventArgs e) {
            Drawing.DrawingProperties.DrawMinionExecution = DrawMinionExecutionCheckBox.Checked;
        }

        private void DrawEnemyWarningCheckBox_CheckedChanged(object sender, EventArgs e) {
            Drawing.DrawingProperties.DrawEnemyWarning = DrawEnemyWarningCheckBox.Checked;
        }

        private void DrawEnemyWarningRangeNumericUpDown_ValueChanged(object sender, EventArgs e) {
            Drawing.DrawingProperties.DrawEnemyWarningRange = (int) DrawEnemyWarningRangeNumericUpDown.Value;
        }
    }
}
