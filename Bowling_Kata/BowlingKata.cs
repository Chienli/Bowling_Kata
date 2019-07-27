using System;
using System.Collections;
using System.Linq;

namespace Bowling_Kata
{
    public class BowlingKata
    {
        public int Score(ArrayList result)
        {
            var score = 0;
            foreach (var pins in result)
            {
                score += (int)pins;
            }

            return score;
        }
    }
}