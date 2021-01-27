using ExSharpBase.Modules;

namespace ExSharpBase.Game
{
    internal class OffsetManager
    {
        public static int BaseAddress = Utils.GetLeagueProcess().MainModule.BaseAddress.ToInt32();

        public class Instances
        {
            //Version 10.20.337.6669 [PUBLIC] // 8B 44 24 04 BA ? ? ? ? 2B D0
            public static int LocalPlayer = BaseAddress + 0x34EEDE4; // string xref blueHero -> Above "hero" subrtn
            public static int Renderer = BaseAddress + 0x35179E4; // 8B 15 ? ? ? ? 83 EC 08 F3 // ["blurKernelSigma", +0x27F] // xref the string, move -0x27f there should be a dword.
            public static int ViewMatrix = BaseAddress + 0x3514BE8; // B9 ? ? ? ? E8 ? ? ? ? B9 ? ? ? ? E9 ? ? ? ? // First result: unk_0x...

            public static int SpellBook = 0x2720;

            public static int UnderMouseObject = BaseAddress + 0x323351; // 8B 0D ? ? ? ? 89 0D

            /*
             * List struct:
             * struct <Hero/Turret/Minion>List {
             *     int _unknown;
             *     Object** pList;
             *     int list_length;
             * }
             */
            public static int MinionList = BaseAddress + 0x289E8EC;
            public static int TurretList = BaseAddress + 0x34F12B8;
            public static int HeroList = BaseAddress + 0x1C50400;
        }

        public class Object
        {
            public static int ChampionName = 0x3134;
            public static int Pos = 0x1D8;
            public static int Name = 0x6C;
            public static int Visibility = 0x270;
            public static int Health = 0xD98;
            public static int MaxHealth = 0xDA8;
            public static int Armor = 0x1298;
            public static int MagicResist = 0x12A0;
            public static int AttackRange = 0x12B8;
        }
    }
}
