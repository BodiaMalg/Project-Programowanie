using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;

namespace XO
{
    [TestClass]
    public class Form1Test
    {


        [TestMethod]
        public void TestSnakeDie()
        {

            Form1 game = new Snake.Form1();
            int maxXPos = 27;
            int maxYPos = 26;

            game.Snake[0].X = maxXPos;
            game.Snake[0].Y = maxYPos;

            Assert.IsTrue(game.Die() == "You're dead");
        }
    }
}