// <copyright file="GameTester.cs" company="www.telerikacademy.com">for educational purposes only</copyright>
// <author>King Survival 2 Team</author>

namespace KingSurvival2Game.Tests
{
    using System;
    using KingSurvivalGame;
    using Microsoft.VisualStudio.QualityTools.UnitTestFramework;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// provides testing functionality for the King Survival game
    /// </summary>
    [TestClass]
    public class GameTester
    {
        /// <summary>
        /// test kill game
        /// </summary>
        [TestMethod]
        public void TestInteractWithFinishedGame()
        {
            KingSurvivalGame.MovementsCounter = 0;
            GameUtilities.Interact(true, 0);
            Assert.AreEqual(KingSurvivalGame.GameIsFinished, true);
        }
                
        /// <summary>
        /// test display facade game
        /// </summary>
        [TestMethod]
        public void TestDisplay()
        {            
            try
            {
                GameUtilities.Display();
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.IsTrue(true);
        }        

        /// <summary>
        /// tests TestGetXFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetXFromOriginalCoord00()
        {
            var result = GameUtilities.GetXFromOriginalCoordinate(4);
            if (result != 2)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetXFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetXFromOriginalCoord01()
        {
            var result = GameUtilities.GetXFromOriginalCoordinate(6);
            if (result != 7)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetXFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetXFromOriginalCoord02()
        {
            var result = GameUtilities.GetXFromOriginalCoordinate(8);
            if (result != 12)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetXFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetXFromOriginalCoord03()
        {
            var result = GameUtilities.GetXFromOriginalCoordinate(10);
            if (result != 17)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetXFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetXFromOriginalCoord04()
        {
            var result = GameUtilities.GetXFromOriginalCoordinate(12);
            if (result != 22)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetXFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetXFromOriginalCoord05()
        {
            var result = GameUtilities.GetXFromOriginalCoordinate(14);
            if (result != 27)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetXFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetXFromOriginalCoord06()
        {
            var result = GameUtilities.GetXFromOriginalCoordinate(16);
            if (result != 32)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetXFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetXFromOriginalCoord07()
        {
            var result = GameUtilities.GetXFromOriginalCoordinate(18);
            if (result != 37)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetXFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetXFromOriginalCoord08()
        {
            try
            {
                var result = GameUtilities.GetXFromOriginalCoordinate(15);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.AreEqual(1, 1);
                return;
            }

            Assert.Fail();
        }

        /// <summary>
        /// tests TestGetXFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetXFromOriginalCoord09()
        {
            try
            {
                var result = GameUtilities.GetXFromOriginalCoordinate(-15);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.AreEqual(1, 1);
                return;
            }

            Assert.Fail();
        }

        /// <summary>
        /// tests TestGetYFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetYFromOriginalCoord00()
        {
            var result = GameUtilities.GetYFromOriginalCoordinate(2);
            if (result != 1)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetYFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetYFromOriginalCoord01()
        {
            var result = GameUtilities.GetYFromOriginalCoordinate(3);
            if (result != 4)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetYFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetYFromOriginalCoord02()
        {
            var result = GameUtilities.GetYFromOriginalCoordinate(4);
            if (result != 7)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetYFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetYFromOriginalCoord03()
        {
            var result = GameUtilities.GetYFromOriginalCoordinate(5);
            if (result != 10)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetYFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetYFromOriginalCoord04()
        {
            var result = GameUtilities.GetYFromOriginalCoordinate(6);
            if (result != 13)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetYFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetYFromOriginalCoord05()
        {
            var result = GameUtilities.GetYFromOriginalCoordinate(7);
            if (result != 16)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetYFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetYFromOriginalCoord06()
        {
            var result = GameUtilities.GetYFromOriginalCoordinate(8);
            if (result != 19)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetYFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetYFromOriginalCoord07()
        {
            var result = GameUtilities.GetYFromOriginalCoordinate(9);
            if (result != 22)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(1, 1);
            }
        }

        /// <summary>
        /// tests TestGetYFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetYFromOriginalCoord08()
        {
            try
            {
                var result = GameUtilities.GetYFromOriginalCoordinate(15);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.AreEqual(1, 1);
                return;
            }

            Assert.Fail();
        }

        /// <summary>
        /// tests TestGetYFromOriginalCoordinate for expected behavior
        /// </summary>
        [TestMethod]
        public void TestGetYFromOriginalCoord09()
        {
            try
            {
                var result = GameUtilities.GetYFromOriginalCoordinate(-5);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.AreEqual(1, 1);
                return;
            }

            Assert.Fail();
        }
    }   
}