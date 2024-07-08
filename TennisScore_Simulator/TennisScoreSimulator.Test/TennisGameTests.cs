using NUnit.Framework;
using TennisScoreSimulator.TennisScoreSimulator;

[TestFixture]

    public class TennisGameTests
    {
        private TennisGame  game;
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
    public void TennisGame_GetScore_Advantage()
        {
            // Assign
            Assert.AreEqual("0-0", game.GetCurrentGameScore ());

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
        System.Console.WriteLine("Game over! "+ player1.Name +" wins!", game.GetCurrentGameScore());

      
       
    }
}


