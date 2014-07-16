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
            KingSurvivalGame game = new KingSurvivalGame();
            try
            {
                GameUtilities.Display(game);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.IsTrue(true);
        }

        /// <summary>
        /// test display facade game by passing null parameter
        /// </summary>
        [TestMethod]
        public void TestDisplayWithNullReference() 
        {
            try
            {
                GameUtilities.Display(null);
            }
            catch (Exception)
            {                
                throw;
            }            
        }
    }   
}