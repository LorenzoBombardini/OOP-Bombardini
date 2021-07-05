using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Bombardini
{
    class Weapon
    {
        public const int MOVE_LIST_SIZE = 4;

        internal string Name { get; set; }
        internal double DamageMultiplier { get; set; }
        internal List<Move> MoveList = new List<Move>();

        public enum WeaponType
        {
            MELEE, RANGED
        }

        internal WeaponType Type { get; set; }
        internal Weapon(String name, WeaponType type, double damageMultiplier, List<Move> moveList)
        {
            Name = name;
            DamageMultiplier = damageMultiplier;
            Type = Type;
            SetMoveList(moveList);
        }

        internal Weapon(String name, double damageMultiplier)
        {
            Name = name;
            DamageMultiplier = damageMultiplier;
        }

        public List<Move> GetMoveList()
        {
            return MoveList;
        }
        public void SetMoveList(List<Move> moveList)
        {
            if (moveList.Count() == MOVE_LIST_SIZE)
                MoveList = moveList;
            else
                Console.Error.WriteLine("moveList ERROR");
        }

    }
}
