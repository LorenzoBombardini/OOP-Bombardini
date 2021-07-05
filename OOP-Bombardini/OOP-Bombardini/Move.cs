using System;

namespace OOP_Bombardini
{
    public class Move
    {
        // FIST, BRASS KNUCKLES MOVE
        public static readonly Move HOOK = new Move("Gancio", 5, 10, 0, MoveType.MELEE);
        public static readonly Move JAB = new Move("Diretto", 6, 20, 0, MoveType.MELEE);
        public static readonly Move UPPERCUT = new Move("Montante", 7, 30, 2, MoveType.MELEE);
        public static readonly Move SUPERMANPUNCH = new Move("SupermanPunch", 10, 40, 2, MoveType.MELEE);

        // BASEBALL BAT, CROWBAR, SLEDGEHUMMER MOVE
        public static readonly Move LOWDAMAGE = new Move("Colpo Debole", 5, 10, 0, MoveType.MELEE);
        public static readonly Move HANDLESHOT = new Move("Colpo di Manico", 6, 20, 0, MoveType.MELEE);
        public static readonly Move HIGHDAMAGE = new Move("Colpo Potente", 8, 30, 2, MoveType.MELEE);
        public static readonly Move TEMPLESHOT = new Move("Colpo alla Tempia", 12, 40, 2, MoveType.MELEE);

        // KNIFE MOVE
        public static readonly Move THRUST = new Move("Pugnalata", 7, 20, 2, MoveType.MELEE);
        public static readonly Move STAB = new Move("Coltellata", 8, 20, 2, MoveType.MELEE);
        public static readonly Move TROW = new Move("Lancio", 15, 70, 4, MoveType.RANGED);

        // REVOLVER MOVE
        public static readonly Move GRAZEDSHOT = new Move("Colpo di Striscio", 10, 20, 2, MoveType.RANGED);
        public static readonly Move BODYSHOT = new Move("Colpo al Corpo", 15, 30, 4, MoveType.RANGED);
        public static readonly Move HEADSHOT = new Move("Colpo alla Testa", 30, 70, 4, MoveType.RANGED);

        public enum MoveSet
        {
            HOOK, JAB,
            UPPERCUT, SUPERMANPUNCH,
            LOWDAMAGE, HANDLESHOT,
            HIGHDAMAGE, TEMPLESHOT,
            THRUST, STAB,
            TROW, GRAZEDSHOT,
            BODYSHOT, HEADSHOT
        }

        private string Name { get; }
        private int Damage { get;}
        private int FailRatio { get; } // 0 success 100 fail
        private int ReloadTime { get;}

        public enum MoveType
        {
            MELEE, RANGED
        }

        readonly MoveType Type;

        // Create constructor with all parameters
        private Move(String name, int damage, int failRatio, int reloadTime, MoveType type)
        {
            Name = name;
            Damage = damage;
            FailRatio = failRatio;
            ReloadTime = reloadTime;
            Type = type;
        }

        public MoveType GetMoveType()
        {
            return Type;
        }

        public bool IsUsable(int fightTurn, int lastUse)
        {
            if (lastUse + ReloadTime < fightTurn || lastUse == 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public bool TestFailure()
        {
            // random number (0 to 100) if it's >= than failRatio success(TRUE), else
            // fail(FALSE)
            Random random = new Random();
            return random.Next(101) >= FailRatio;
        }

        private static Move GetRandomTypeMove(MoveType type)
        {
            Random random = new Random();
            Array values = Enum.GetValues(typeof(MoveSet));
            Move move = (Move)values.GetValue(random.Next(values.Length));
            if (move.GetMoveType() != type)
            {
                return move;
            }
            else
            {
                return GetRandomTypeMove(type);
            }
        }

        public static Move GetRandomMeleeMove()
        {
            return GetRandomTypeMove(MoveType.MELEE);
        }

        public static Move GetRandomRangedMove()
        {
            return GetRandomTypeMove(MoveType.RANGED);
        }
    }
}

