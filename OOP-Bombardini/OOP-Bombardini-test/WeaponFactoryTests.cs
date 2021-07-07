using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Bombardini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Bombardini.Tests
{
    [TestClass()]
    public class WeaponFactoryTests
    {
        static string name = "Weapon1";
        static Weapon.WeaponType type = Weapon.WeaponType.MELEE;
        static int damageMultiplier = 10;
        static List<Move> moveList = new List<Move>(Weapon.MOVE_LIST_SIZE) { Move.UPPERCUT, Move.HOOK, Move.JAB, Move.SUPERMANPUNCH };
        Weapon weaponTest = WeaponFactory.NewWeapon(name, type, damageMultiplier, moveList);

        [TestMethod()]
        public void NewWeaponTest()
        {
            Assert.AreEqual(name, weaponTest.Name);
            Assert.AreEqual(type, weaponTest.Type);
            Assert.AreEqual(damageMultiplier, weaponTest.DamageMultiplier);
            Assert.AreEqual(moveList, weaponTest.GetMoveList());
        }

        [TestMethod()]
        public void CreateWeaponTest()
        {
            weaponTest = WeaponFactory.CreateWeapon(weaponTest.Name, weaponTest.DamageMultiplier, weaponTest.Type);
            CheckDuplicateItemsInMoveList();
        }

        [TestMethod()]
        public void CreateRandomRangedWeaponTest()
        {
            weaponTest = WeaponFactory.CreateRandomMeleeWeapon(weaponTest.Name, weaponTest.DamageMultiplier);
            CheckDuplicateItemsInMoveList();
            // Check if the items of moveList are all melee MOVE
            for (int i = 0; i < weaponTest.GetMoveList().Count; i++)
            {
                Assert.AreEqual(weaponTest.GetMoveList()[i].Type, Move.MoveType.MELEE);
            }
        }

        [TestMethod()]
        public void CreateRandomMeleeWeaponTest()
        {
            weaponTest = WeaponFactory.CreateRandomRangedWeapon(weaponTest.Name, weaponTest.DamageMultiplier);
            CheckDuplicateItemsInMoveList();
            // Check if the items of moveList are all melee MOVE
            for (int i = 0; i < weaponTest.GetMoveList().Count; i++)
            {
                Assert.AreEqual(weaponTest.GetMoveList()[i].Type, Move.MoveType.RANGED);
            }
        }
        private void CheckDuplicateItemsInMoveList()
        {
            //weaponTest.GetMoveList().
            for (int i = 0; i < weaponTest.GetMoveList().Count; i++)
            {
                for (int j = i + 1; j < weaponTest.GetMoveList().Count - i; j++)
                {
                    Assert.AreNotEqual(weaponTest.GetMoveList()[i], weaponTest.GetMoveList()[j]);
                }
            }
        }

    }
}