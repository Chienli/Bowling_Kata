using System;
using System.Collections;
using System.Linq;

namespace Bowling_Kata
{
    public class BowlingKata
    {
        private const int MaxFrame = 10;

        public int Score(ArrayList result)
        {
            var score = 0;
            var rollIndex = 0;
            for (var i = 0; i < MaxFrame; i++)
            {
                if ((int)result[rollIndex] + (int)result[rollIndex + 1] == 10)
                {
                    score += 10 + (int)result[rollIndex + 2];
                    rollIndex += 2;
                }
                else
                {
                    score += (int)result[rollIndex] + (int)result[rollIndex + 1];
                    rollIndex += 2;
                }
            }
            return score;
        }
    }
}