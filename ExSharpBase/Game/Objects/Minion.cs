using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExSharpBase.Game.Objects
{
    class Minion : GameObject
    {
        private int nativeId;

        public static IList<Minion> GetAllObjects() {
            var minions = new List<Minion>();

            var objCount = Engine.GetMinionCount();
            for(int i = 0; i < objCount; ++i) {
                var minion = new Minion(i);
                minions.Add(minion);
            }

            return minions;
        }

        private Minion(int nativeId) {
            this.nativeId = nativeId;

            // This throws an error if id is not valid
            GetMemoryAddress();
        }

        public override int GetBoundingRadius() {
            return 140;
        }

        public override float GetAttackRange() {
            return 750.0f;
        }

        override public int GetMemoryAddress() {
            try {
                return Engine.GetMinion(nativeId);
            } catch (IndexOutOfRangeException) {
                // Minions spawn and die very often, this Exception happens often
                return Engine.GetMinion(0);
            }
        }

        override public void DrawExecution() {
            if(CanExecute(false))
                Overlay.Drawing.DrawFactory.DrawCircleRange(GetPosition(), 80.0f, Color.Orange, 5.0f);
        }
    }
}
