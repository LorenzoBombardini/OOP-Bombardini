using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Bombardini
{
    class Character
    {
        internal string Name { get; set; }
        internal int Hp { get; set; }
        internal Weapon Weapon { get; set; }

        public Character(String name, int hp, Weapon weapon)
        {
            Name = name;
            Hp = hp;
            Weapon = weapon;
        }


    }

    class EnemyCharacter : Character
    {
        internal Weapon DropWeapon { get; set; }
        public EnemyCharacter(Character character, Weapon dropWeapon) : base(character.Name, character.Hp, character.Weapon)
        {
            DropWeapon = dropWeapon;
        }
    }

    class PlayerCharacter : Character
    {
        public PlayerCharacter(Character character) : base(character.Name, character.Hp, character.Weapon) { }
    }


}
