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
    public class MoveTests
    {
        private static Move HOOK1 = Move.HOOK;

        [TestMethod()]
        public void IsUsableTest()
        {
            Assert.IsFalse(HOOK1.IsUsable(2, 2));
            Assert.IsTrue(HOOK1.IsUsable(2, 1));
        }

        [TestMethod()]
        public void GetRandomMeleeMoveTest()
        {
            Assert.AreEqual(Move.MoveType.MELEE, Move.GetRandomMeleeMove().Type);
        }

        [TestMethod()]
        public void GetRandomRangedMoveTest()
        {
            Assert.AreEqual(Move.MoveType.RANGED, Move.GetRandomRangedMove().Type);
        }
    }
}