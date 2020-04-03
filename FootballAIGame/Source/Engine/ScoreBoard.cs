using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace FootballAIGame { 
    public class ScoreBoard
    {
        public int HomeScore { get; set; }
        public int OutScore { get; set; }

        public ScoreBoard()
        {
            HomeScore = 0;
            OutScore = 0;
        }
    }
}
