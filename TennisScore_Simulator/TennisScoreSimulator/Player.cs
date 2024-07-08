using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TennisScoreSimulator.TennisScoreSimulator
{
    public class Player : IPlayer
    {
        public string Name { get; }
        public int Points { get; set; }
        public int Games { get; set; }
        public int Sets { get; set; }
        public int TieBrakerPoints { get; set; }


        public Player(string name)
        {
            Name = name;
            
        }       

        public void WinPoint()
        {
            Points++;
        }

        public void WinGame()
        {
            Games++;                  
        }

        public void WinSet()
        {
            Sets++;       
        }

        public void WinTieBreakerPoints()
        {
            TieBrakerPoints++;
        }

        public void ResetScore()
        {
            Points = 0;
            Games = 0;
            Sets = 0;           
        }

        public void ResetPoint()
        {
            Points = 0;
        }
        public void ResetGame()
        {
            Games = 0;
        }
            
    }
}
