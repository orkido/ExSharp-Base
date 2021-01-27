using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExSharpBase.Modules;
using ExSharpBase.Game.Objects;
using SharpDX;
using ExSharpBase.Game;

namespace ExSharpBase.Events
{
    class Drawing
    {
        public class DrawingConfig
        {
            public bool DrawRange;
            public bool DrawMarker = true; // TODO: Add GUI setting
            public bool DrawTurretRange;
            public bool DrawExecution;
            public bool DrawMinionExecution;
            public bool DrawEnemyWarning;
            public int DrawEnemyWarningRange;
        }
        public static DrawingConfig DrawingProperties = new DrawingConfig();

        public static bool IsMenuBeingDrawn = false;

        public static void OnDeviceDraw()
        {
            if (true || Utils.IsGameOnDisplay())
            {
                //When ~ key is pressed...
                DrawMenu();

                if (DrawingProperties.DrawRange == true)
                {
                    LocalPlayer.DrawAttackRange(Color.Cyan, 2.5f);

                    LocalPlayer.DrawAllSpellRange(Color.OrangeRed);
                }

                if(DrawingProperties.DrawMarker) {
                    var players = Player.GetAllObjects();
                    foreach(var player in players) {
                        player.DrawMarker();
                    }
                }

                if (DrawingProperties.DrawTurretRange) {
                    var turrets = Turret.GetAllObjects();
                    foreach(var turret in turrets) {
                        turret.DrawAttackRange(Color.Red, 5.0f);
                    }
                }

                if (DrawingProperties.DrawExecution) {
                    var players = Player.GetAllObjects();
                    foreach(var player in players) {
                        player.DrawExecution();
                    }
                }

                if (DrawingProperties.DrawMinionExecution) {
                    var minions = Minion.GetAllObjects();
                    foreach (var minion in minions) {
                        minion.DrawExecution();
                    }
                }

                if (DrawingProperties.DrawEnemyWarning) {
                    var players = Player.GetAllObjects();
                    foreach(var player in players) {
                        player.SetNearEnemiesList(DrawingProperties.DrawEnemyWarningRange);
                    }
                    Player.LocalPlayer.DrawEnemyWarning(DrawingProperties.DrawEnemyWarningRange);
                }
            }
        }

        private static void DrawMenu()
        {
            if (Utils.IsKeyPressed(System.Windows.Forms.Keys.Oemplus))
            {
                Program.MenuBasePlate.Show();
                IsMenuBeingDrawn = true;
            }
            else
            {
                Program.MenuBasePlate.Hide();
            }
        }
    }
}
