using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}