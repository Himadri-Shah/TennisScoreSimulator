using NUnit.Framework;
using TennisScoreSimulator.TennisScoreSimulator;
using System;




namespace TennisScoreSimulator.TennisScoreSimulator.Test
{

    [TestFixture]
    public class TennisGameTests
    {
        private TennisGame game;
        private Player player1;
        private Player player2;

        [SetUp]
        public void Setup()
        {
            player1 = new Player("Player 1");
            player2 = new Player("Player 2");
            game = new TennisGame(player1, player2);

        }


       

       

        [Test]
        public void TennisGame_InitialScoreShouldBeLoveAll()
        {
             Assert.AreEqual("0-0", game.GetCurrentGameScore());
        }

        [Test]
        public void TennisGame_ShouldBeFifteenLove()
        {

            game.PlayPoint(0); // 15-0
            Assert.AreEqual("15-0", game.GetCurrentGameScore());
        }

        [Test]
        public void TennisGame_ShouldBeLoveFifteen()
        {

            game.PlayPoint(1);// 0-15
            Assert.AreEqual("0-15", game.GetCurrentGameScore());
        }

        [Test]
        public void TennisGame_WonByPlayer1()
        {

            game.PlayPoint(0); // 15-0
            game.PlayPoint(0); // 30-0
            game.PlayPoint(0); // 40-0
            game.PlayPoint(0); // Player 1 wins
            Assert.AreEqual("Player 1 wins", game.GetCurrentGameScore());
        }

        [Test]
        public void TennisGame_WonByPlayer2()
        {

            game.PlayPoint(1);// 0-15
            game.PlayPoint(1);// 0-30
            game.PlayPoint(1);// 0-40
            game.PlayPoint(1);// Player 2 wins
            Assert.AreEqual("Player 2 wins", game.GetCurrentGameScore());
        }

        [Test]
        public void TennisGame_ShouldHandleCorrectly()
        {
           
            game.PlayPoint(0); // 15-0
            game.PlayPoint(1); // 15-15
            game.PlayPoint(0);  // 30-15
            game.PlayPoint(1);// 30-30
            game.PlayPoint(0);  // 40-30
            game.PlayPoint(1);  // Deuce
            game.PlayPoint(0);  // Advantage Player 1
            game.PlayPoint(1); // Deuce
            game.PlayPoint(1); // Advantage Player 2
            game.PlayPoint(0); // Deuce
            game.PlayPoint(0);  // Advantage Player 1
            game.PlayPoint(1); // Deuce
            Assert.AreEqual("Deuce", game.GetCurrentGameScore());
        }

        [Test]
        public void TennisGame_GetScore_Advantage()
        {
            // Assign
            Assert.AreEqual("0-0", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(0);
            game.PlayPoint(0);

            // Assert
            Assert.AreEqual("30-0", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(1);

            // Assert
            Assert.AreEqual("30-15", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(1);
            game.PlayPoint(1);

            // Assert
            Assert.AreEqual("30-40", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(0);


            // Assert
            Assert.AreEqual("Deuce", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(0);

            // Assert
            Assert.AreEqual("Advantage Player 1", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(1);

            // Assert
            Assert.AreEqual("Deuce", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(1);


            // Assert
            Assert.AreEqual("Advantage Player 2", game.GetCurrentGameScore());
            // Act
            game.PlayPoint(1);

            // Assert
            Assert.AreEqual("Player 2 wins", game.GetCurrentGameScore());
        }

        [Test]
        public void TennisGame_GetScore_TieBreaker()
        {

            // Assign
            Assert.AreEqual("0-0", game.GetCurrentGameScore());

            // Act

            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);

            // Assert
            Assert.AreEqual("Player 1 wins", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);

            // Assert
            Assert.AreEqual("Player 2 wins", game.GetCurrentGameScore());

            // Act        
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);

            // Assert
            Assert.AreEqual("Player 1 wins", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);

            // Assert
            Assert.AreEqual("Player 2 wins", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);

            // Assert
            Assert.AreEqual("Player 1 wins", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);

            // Assert
            Assert.AreEqual("Player 2 wins", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);

            // Assert
            Assert.AreEqual("Player 1 wins", game.GetCurrentGameScore());
            // Act
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);

            // Assert
            Assert.AreEqual("Player 2 wins", game.GetCurrentGameScore());

            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);
            // Assert
            Assert.AreEqual("Player 1 wins", game.GetCurrentGameScore());

            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);
            // Assert
            Assert.AreEqual("Player 2 wins", game.GetCurrentGameScore());

            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);
            // Assert
            Assert.AreEqual("Player 1 wins", game.GetCurrentGameScore());

            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);
            // Assert
            Assert.AreEqual("Player 2 wins", game.GetCurrentGameScore());


            game.PlayPoint(0);

            // Assert
            Assert.AreEqual("1-0", game.GetCurrentGameScore());

            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);


            player1.WinPoint();
            // Assert
            Assert.AreEqual("1-4", game.GetCurrentGameScore());
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);

            // Assert
            Assert.AreEqual("0-0", game.GetCurrentGameScore());
        }

        [Test]
        public void TennisGame_GetScore_WinningGame()
        {
            // Assign
            Assert.AreEqual("0-0", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);

            // Assert
            Assert.AreEqual("Player 1 wins", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);

            // Assert
            Assert.AreEqual("Player 1 wins", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);
            game.PlayPoint(1);

            // Assert
            Assert.AreEqual("Player 2 wins", game.GetCurrentGameScore());

            // Act
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);

            // Assert
            Assert.AreEqual("40-0", game.GetCurrentGameScore());

            game.PlayPoint(0);

            Assert.AreEqual("Player 1 wins", game.GetCurrentGameScore());

            // Assert
            System.Console.WriteLine("Game over! " + player1.Name + " wins!", game.GetCurrentGameScore());



        }

        [Test]
        public void TennisGame_CheckIfGameStillgoingon()
        {

            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);
            game.PlayPoint(0);

            game.PlayPoint(1);
            game.PlayPoint(1);

            // Act
            bool isMatchFinished = game.IsMatchFinished ();

            // Assert
            Assert.IsFalse (isMatchFinished, "Expected the match to be in progress.");


        }

        [Test]
        public void TennisGame_RandomizedScoreSequence()
        {

            Random random = new Random();
            int maxPoints = 50;

            for (int i = 0; i < maxPoints; i++)
            {
                if (random.Next(2) == 0)
                {
                    game.PlayPoint(0);
                }
                else
                {
                    game.PlayPoint(1);

                }
            }

            // Ensure the score retrieval does not throw exceptions
            Assert.DoesNotThrow(() => game.GetCurrentGameScore());
        }

      
    }
}


