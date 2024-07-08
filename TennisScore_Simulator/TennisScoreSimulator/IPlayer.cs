using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoreSimulator.TennisScoreSimulator
{
    public interface IPlayer
    {
        string Name { get; }
         int Points { get;  }
         int Games { get;  }
         int Sets { get; }
         int TieBrakerPoints { get; }

        void WinPoint();
        void WinGame();
        void WinSet();
        void ResetScore();
        void WinTieBreakerPoints();
    }
}
