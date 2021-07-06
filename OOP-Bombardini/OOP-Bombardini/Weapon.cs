using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Bombardini
{
    public class Weapon
    {
        public const int MOVE_LIST_SIZE = 4;

        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private double _damageMultiplier;
        public double DamageMultiplier
        {
            get => _damageMultiplier;
            set => _damageMultiplier = value;
        }
        internal List<Move> MoveList = new List<Move>();

        public enum WeaponType
        {
            MELEE, RANGED
        }

        private WeaponType _type;
        public WeaponType Type
        {
            get => _type;
            set => _type = value;
        }
        internal Weapon(String name, WeaponType type, double damageMultiplier, List<Move> moveList)
        {
            Name = name;
            DamageMultiplier = damageMultiplier;
            Type = type;
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
