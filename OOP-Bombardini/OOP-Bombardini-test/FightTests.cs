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
    public class FightTests
    {

        private static PlayerCharacter player = new PlayerCharacter(new Character("Marty", 150, WeaponFactory.CreateRandomMeleeWeapon("Mazza", WeaponFactory.RandomDamageMultiplier())));
        private static EnemyCharacter enemy = new EnemyCharacter(new Character("Biff", 150, WeaponFactory.CreateRandomMeleeWeapon("Pugnale", WeaponFactory.RandomDamageMultiplier())), WeaponFactory.CreateRandomMeleeWeapon("Mazza", WeaponFactory.RandomDamageMultiplier()));
        Fight testFight = new Fight(player, enemy);

        [TestMethod()]
        public void FightTest()
        {
            Assert.AreEqual(player, testFight.Player);
            Assert.AreEqual(enemy, testFight.Enemy);
            Assert.AreEqual(1, testFight.TurnCount);
        }

        [TestMethod()]
        public void PlayerAttackTest()
        {
            int turnCount = testFight.TurnCount + 2;
            int enemyHp = testFight.Enemy.Hp;
            int damage = (int)(testFight.Player.Weapon.DamageMultiplier
                    * player.Weapon.GetMoveList()[0].Damage);

            testFight.PlayerAttack(player.Weapon.GetMoveList()[0]);
            if (enemyHp != enemy.Hp)
            {
                Assert.AreEqual(enemyHp - damage, enemy.Hp);
            }
            Assert.AreEqual(turnCount, testFight.TurnCount);
        }

        [TestMethod()]
        public void SetLastUseTest()
        {
            int lastUse = 0;
            testFight.SetLastUse(player, player.Weapon.GetMoveList()[0], lastUse);
            Assert.IsTrue(player.Weapon.GetMoveList()[0].IsUsable(0, lastUse));

            lastUse++;
            testFight.SetLastUse(player, player.Weapon.GetMoveList()[0], lastUse);
            Assert.IsFalse(player.Weapon.GetMoveList()[0].IsUsable(1, lastUse));
        }

        [TestMethod()]
        public void IsMoveUsableTest()
        {
            player.Weapon.GetMoveList()[0] = Move.HEADSHOT;;
            Assert.IsTrue(testFight.IsMoveUsable(player, Move.HEADSHOT));
            testFight.SetLastUse(player, Move.HEADSHOT, 1);
            Assert.IsFalse(testFight.IsMoveUsable(player, Move.HEADSHOT));
        }
    }
}