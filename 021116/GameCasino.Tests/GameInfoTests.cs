using System;
using GameCasino.Models;
using NUnit.Framework;

namespace GameCasino.Tests
{
    [TestFixture]
    public class GameInfoTest
    {
        [Test]
        public void ConnectPlayerShouldAddOnePlayer()
        {
            GameInfo gameInfo = new GameInfo();
            gameInfo.ConnectPlayer("Kiko");

            Assert.AreEqual(1, gameInfo.PlayersPlaying);
        }

        [Test]
        public void ConnectPlayerShouldAdd100Players()
        {
            GameInfo gameInfo = new GameInfo();
            for (int i = 0; i < 100; i++)
            {
                gameInfo.ConnectPlayer("Kiko" + i);
            }

            Assert.AreEqual(100, gameInfo.PlayersPlaying);
        }

        [Test]
        public void IdShouldNotBeEmpty()
        {
            GameInfo gameInfo = new GameInfo();
            Assert.AreNotEqual(gameInfo.Id, Guid.Empty);
        }
    }
}