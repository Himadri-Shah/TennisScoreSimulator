using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoreSimulator.TennisScoreSimulator
{
    internal class TennisGame : ITennisGame
    {
        private Player _player1;
        private Player _player2;
        
        private bool _isTiebreaker; //check if there is a tiebreaker in the current set
       

        public TennisGame(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
            _isTiebreaker = false;            
        }

        public string  PlayPoint(int currentPoint)
        {
            //Display string to show who won this point 
            string PlayerWin="";
            if (currentPoint == 0 )
            {
                PlayerWin = _player1.Name + " wins";
            }
            else if (currentPoint == 1)
            {
                PlayerWin = _player2.Name + " wins";
            }

            if (_isTiebreaker)
            {
                CheckTiebreakerOutcome(currentPoint);
            }
            else
            {
                CheckGameOutcome(currentPoint);
            }


            return PlayerWin;
        }

        public string GetCurrentGameScore()
        {
            if (_player1.Points >= 4 && _player1.Points >= _player2.Points + 2 )
            {
                //if player wint the game then reset the points for both players for next game
                _player1.ResetPoint();
                _player2.ResetPoint();
                return $"{_player1.Name} wins";
            }
            else if (_player2.Points >= 4 && _player2.Points >= _player1.Points + 2 )
            {
                //if player wint the game then reset the points for both players for next game
                _player1.ResetPoint();
                _player2.ResetPoint();
                return $"{_player2.Name} wins";
            }
            else if (_player1.Points >= 3 && _player2.Points >= 3 )
            {
                if (_player1.Points == _player2.Points)
                {
                    return "Deuce";
                }
                else if (_player1.Points > _player2.Points)
                {
                    return $"Advantage {_player1.Name}";
                }
                else
                {
                    return $"Advantage {_player2.Name}";
                }
            }
            else
            {
                if (!_isTiebreaker )
                    return $"{GetScoreName(_player1.Points)}-{GetScoreName(_player2.Points)}";
                else
                    return $"{_player1.TieBrakerPoints }-{_player2.TieBrakerPoints }";
            }
                        
        }

        private string GetScoreName(int score)
        {
            switch (score)
            {
                case 0:
                    return "0";
                case 1:
                    return "15";
                case 2:
                    return "30";
                case 3:
                    return "40";
                default:
                    throw new InvalidOperationException("Invalid score");
            }
        }

        private void CheckGameOutcome(int currentPoint)
        {
            if (currentPoint == 0)
            {
                _player1.WinPoint();               
            }
            else if (currentPoint == 1)
            {
                _player2.WinPoint();              
            }

            int pointsDiff = _player1.Points - _player2.Points;

            if (_player1.Points >= 4 && pointsDiff >= 2 )
            {
                _player1.WinGame();
                CheckSetOutcome();
            }
            else if (_player2.Points >= 4 && -pointsDiff >= 2 )
            {
                _player2.WinGame();
                CheckSetOutcome();
            }
           
        }

        public void CheckSetOutcome()
        {
            if (_player1.Games >= 6 && _player1.Games >= _player2.Games + 2)
            {
                _player1.WinSet();
               
              
            }
            else if (_player2.Games >= 6 && _player2.Games >= _player1.Games + 2)
            {
                _player2.WinSet();
              

            }
            else if (_player1.Games == 6 && _player2.Games == 6)
            {
                _isTiebreaker  = true;
            }
        }

        private void CheckTiebreakerOutcome(int point)
        {

            if (point == 0)
            {
                _player1.WinTieBreakerPoints();
            }
            else if (point == 1)
            {
                _player2.WinTieBreakerPoints ();
            }

            //check whether tie break has finished
            if (_player1.TieBrakerPoints  >= 7 && _player1.TieBrakerPoints >= _player2.TieBrakerPoints  + 2)
            {
                _player1.WinSet();
                _player1.ResetPoint();
                _player1.ResetGame();
                _player2.ResetPoint();
                _player2.ResetGame();
                _isTiebreaker = false;
            }
            else if (_player2.TieBrakerPoints >= 7 && _player2.TieBrakerPoints >= _player1.TieBrakerPoints + 2)
            {
                _player2.WinSet();
                _player1.ResetPoint();
                _player1.ResetGame();
                _player2.ResetPoint();
                _player2.ResetGame();
                _isTiebreaker = false;
            }           
            
        }

        public string GetCurrentSetScore()
        {
            return $"{_player1.Games}  - {_player2.Games } ";
        }

        public string GetCurrentMatchScore()
        {
            return $" {_player1.Sets} sets to  {_player2.Sets} sets";
        }

        public bool IsGameFinished()
        {
            //  game finish condition
            return (_player1.Points  >= 4 || _player2.Points >= 4) ;
        }

        public bool IsSetFinished()
        {
            //  set finish condition 
            return (_player1.Games >= 6 || _player2.Games >= 6) && Math.Abs(_player1.Games - _player2.Games) >= 2;
        }

        public bool IsMatchFinished()
        {
            //  match finish condition
            return _player1.Sets >= 3 || _player2.Sets >= 3;
        }


        public Player GetWinner()
        {
            return _player1.Sets >= 3 ? _player1 : _player2 ;
        }

    }
}
