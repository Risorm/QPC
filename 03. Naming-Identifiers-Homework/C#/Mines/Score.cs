using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Score
    {
        public string Player { get; set; }

        public int Points { get; set; }

        public Score()
        {
        }

        public Score(string name, int points)
        {
            this.Player = name;
            this.Points = points;
        }
    }
}
