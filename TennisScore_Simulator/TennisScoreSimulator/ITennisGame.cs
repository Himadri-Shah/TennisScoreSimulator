using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoreSimulator.TennisScoreSimulator
{
    public interface ITennisGame
    {
        string PlayPoint(int Point);
        string GetCurrentGameScore();
        string GetCurrentSetScore();
        string GetCurrentMatchScore();
              
        Player GetWinner();
        
        bool IsGameFinished();
        bool IsSetFinished();
        bool IsMatchFinished();
       
    }
}
