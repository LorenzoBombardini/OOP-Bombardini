using System;

namespace OOP_Bombardini
{
    public class Character
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private int _hp;
        public int Hp 
        {
            get => _hp;
            set => _hp = value;
        }

        private Weapon _weapon;
        public Weapon Weapon
        {
            get => _weapon;
            set => _weapon = value;
        }

        public Character(String name, int hp, Weapon weapon)
        {
            Name = name;
            Hp = hp;
            Weapon = weapon;
        }
        public string GetName()
        {
            return Name;
        }
    }

    public class EnemyCharacter : Character
    {
        internal Weapon DropWeapon { get; set; }
        public EnemyCharacter(Character character, Weapon dropWeapon) : base(character.Name, character.Hp, character.Weapon)
        {
            DropWeapon = dropWeapon;
        }
    }

    public class PlayerCharacter : Character
    {
        public PlayerCharacter(Character character) : base(character.Name, character.Hp, character.Weapon) { }
    }



}
