using ExSharpBase.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExSharpBase.Game.Objects
{
    class Turret : GameObject
    {
        private int id;

        public static IList<Turret> GetAllObjects() {
            var turrets = new List<Turret>();

            var objCount = Engine.GetTurretCount();
            for(int i = 0; i < objCount; ++i) {
                var turret = new Turret(i);
                turrets.Add(turret);
            }

            return turrets;
        }

        public Turret(int id) {
            this.id = id;

            // This throws an error if id is not valid
            GetMemoryAddress();
        }

        public override int GetBoundingRadius() {
            return 140;
        }

        public override float GetAttackRange() {
            // Memory value is always 1.0f
            return 750.0f;
        }

        override public int GetMemoryAddress() {
            return Engine.GetTurret(id);
        }

        override public void DrawExecution() {
            CanExecute(false);
        }

    }
}
