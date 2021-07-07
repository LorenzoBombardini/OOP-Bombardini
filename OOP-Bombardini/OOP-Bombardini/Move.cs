using System;
using System.Collections.Generic;

namespace OOP_Bombardini
{
    public class Move
    {

        static Random random = new Random();
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
        private static readonly Move[] MoveSet = new Move[14] { HOOK, JAB, UPPERCUT, SUPERMANPUNCH, LOWDAMAGE, HANDLESHOT, HIGHDAMAGE, TEMPLESHOT, THRUST, STAB, TROW, GRAZEDSHOT, BODYSHOT, HEADSHOT };
        
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private int _damage;
        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }

        private readonly int _failRatio;
        public int FailRatio { get => _failRatio; } // 0 success 100 fail

        private readonly int _reloadTime;
        public int ReloadTime { get => _reloadTime; }

        public enum MoveType
        {
            MELEE, RANGED
        }

        private MoveType _type;
        public MoveType Type
        {
            get => _type;
            set => _type = value;
        }

        // Create constructor with all parameters
        private Move(String name, int damage, int failRatio, int reloadTime, MoveType type)
        {
            Name = name;
            Damage = damage;
            _failRatio = failRatio;
            _reloadTime = reloadTime;
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
            Move move;
            do
            {
                move = MoveSet[random.Next(MoveSet.Length)];
            } while (move.Type != type);

            return move;
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

