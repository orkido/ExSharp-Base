using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using ExSharpBase.Modules;
using ExSharpBase.Enums;
using ExSharpBase.Devices;

namespace ExSharpBase.Game
{
    class Engine
    {
        public static int GetLocalPlayer { get; } = Memory.Read<int>(OffsetManager.Instances.LocalPlayer);

        public static int GetPlayer(int id) {
            var ListStruct = Memory.Read<int>(OffsetManager.Instances.HeroList);
            var ListLength = Memory.Read<int>(ListStruct + 8);

            if(id >= ListLength)
                throw new IndexOutOfRangeException($"player: {id} is not available");

            var List = Memory.Read<int>(ListStruct + 4);
            return Memory.Read<int>(List + 4 * id);
        }

        public static int GetPlayerCount() {
            var ListStruct = Memory.Read<int>(OffsetManager.Instances.HeroList);
            var ListLength = Memory.Read<int>(ListStruct + 8);

            return ListLength;
        }

        public static int GetMinion(int id) {
            var ListStruct = Memory.Read<int>(OffsetManager.Instances.MinionList);
            var ListLength = Memory.Read<int>(ListStruct + 8);

            if(id >= ListLength)
                throw new IndexOutOfRangeException($"minion: {id} is not available");

            var List = Memory.Read<int>(ListStruct + 4);
            return Memory.Read<int>(List + 4 * id);
        }

        public static int GetMinionCount() {
            var ListStruct = Memory.Read<int>(OffsetManager.Instances.MinionList);
            var ListLength = Memory.Read<int>(ListStruct + 8);

            return ListLength;
        }

        public static int GetTurret(int id) {
            var ListStruct = Memory.Read<int>(OffsetManager.Instances.TurretList);
            var ListLength = Memory.Read<int>(ListStruct + 8);

            if(id >= ListLength)
                throw new IndexOutOfRangeException($"turret: {id} is not available");

            var List = Memory.Read<int>(ListStruct + 4);
            return Memory.Read<int>(List + 4 * id);
        }

        public static int GetTurretCount() {
            var ListStruct = Memory.Read<int>(OffsetManager.Instances.TurretList);
            var ListLength = Memory.Read<int>(ListStruct + 8);

            return ListLength;
        }

        public static float GetGameTime()
        {
            return API.GameStats.GetGameTime();
        }

        public static int GetObjectUnderMouse() //Use at risk [Possible Detection?]
        {
            return Memory.Read<int>(OffsetManager.Instances.UnderMouseObject);
        }

        public static void IssueOrder(GameObjectOrder Order, Point Vector2D = new Point())
        {
            if (Utils.IsGameOnDisplay())
            {
                switch (Order)
                {
                    case GameObjectOrder.HoldPosition:
                        Keyboard.SendKey((short)Keyboard.KeyBoardScanCodes.KEY_S);
                        break;
                    case GameObjectOrder.MoveTo:
                        if (Vector2D.X == 0 && Vector2D.Y == 0)
                        {
                            Mouse.MouseClickRight();
                            break;
                        }
                        if (Vector2D == new Point(Cursor.Position.X, Cursor.Position.Y))
                        {
                            Mouse.MouseClickRight();
                            break;
                        }
                        Mouse.MouseMove(Vector2D.X, Vector2D.Y);
                        Mouse.MouseClickRight();
                        break;
                    case GameObjectOrder.AttackUnit:
                        if (Vector2D.X == 0 && Vector2D.Y == 0)
                        {
                            Mouse.MouseMove(Cursor.Position.X, Cursor.Position.Y);
                            Mouse.MouseClickRight();
                            break;
                        }
                        Mouse.MouseMove(Vector2D.X, Vector2D.Y);
                        Mouse.MouseClickRight();
                        break;
                    case GameObjectOrder.AutoAttack:
                        Keyboard.SendKey((short)Keyboard.KeyBoardScanCodes.KEY_OPENING_BRACKETS);
                        break;
                    case GameObjectOrder.Stop:
                        Keyboard.SendKey((short)Keyboard.KeyBoardScanCodes.KEY_S);
                        break;
                }
            }
        }
    }
}
