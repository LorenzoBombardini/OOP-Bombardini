using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Bombardini
{
    public class WeaponFactory
    {
        public const float LEVEL1 = 1;
        public const float LEVEL2 = 2;
        public const float LEVEL3 = 3;
        public const float MIN_DAMAGE_MULTIPLIER = 0.5f;
        public const float MAX_DAMAGE_MULTIPLIER = 1.5f;

        public static Weapon NewWeapon(String name, Weapon.WeaponType type, double damageMultiplier, List<Move> moveList)
        {
            Weapon weapon = new Weapon(name, type, damageMultiplier, moveList);
            return weapon;
        }

        public static Weapon SetWeaponMove(Weapon weapon, Move move1, Move move2, Move move3, Move move4)
        {
            List<Move> moveList = new List<Move>(Weapon.MOVE_LIST_SIZE) { move1, move2, move3, move4 };
            weapon.SetMoveList(moveList);
            return weapon;
        }

        public static Weapon CreateWeapon(String name, double damageMultiplier, Weapon.WeaponType type)
        {
            Weapon weapon = new Weapon(name, 0);
            List<Move> moveList = new List<Move>(Weapon.MOVE_LIST_SIZE);
            int i = 0;
            Move move;
            do
            {
                if (type == Weapon.WeaponType.MELEE)
                {
                    move = Move.GetRandomMeleeMove();
                }
                else
                {
                    move = Move.GetRandomRangedMove();
                }

                if (!moveList.Contains(move))
                {
                    moveList.Append(move);
                    i++;
                }
            } while (i < Weapon.MOVE_LIST_SIZE);
            weapon.DamageMultiplier = damageMultiplier;
            weapon.SetMoveList(moveList);
            weapon.Type = type;
            return weapon;
        }

        public static Weapon CreateRandomRangedWeapon(string name, double damageMultiplier)
        {
            return CreateWeapon(name, damageMultiplier, Weapon.WeaponType.RANGED);
        }

        public static Weapon CreateRandomMeleeWeapon(string name, double damageMultiplier)
        {
            return CreateWeapon(name, damageMultiplier, Weapon.WeaponType.MELEE);
        }

        /*
        public static Weapon CreateRandomWeaponLevel(String name, MapManager.Maps map, Weapon.WeaponType type)
        {
            switch (map)
            {
                case MAP1:
                    return CreateWeapon(name, (double)(RandomDamageMultiplier() * LEVEL1), type);
                case MAP2:
                    return CreateWeapon(name, (double)(RandomDamageMultiplier() * LEVEL2), type);
                case MAP3:
                    return CreateWeapon(name, (double)(RandomDamageMultiplier() * LEVEL3), type);
                default:
                    Console.Error.WriteLine("Wrong Map");
            }
        }*/

        public static float RandomDamageMultiplier()
        {
            Random random = new Random();
            return (float)((random.NextDouble() * MAX_DAMAGE_MULTIPLIER) - MIN_DAMAGE_MULTIPLIER);
        }

        private WeaponFactory() { }
    }
}
