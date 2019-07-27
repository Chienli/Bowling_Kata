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
                if (IsStrike(result, rollIndex))
                {
                    score += StrikeScore(result, rollIndex);
                    rollIndex += 1;
                }
                else if (IsSpare(result, rollIndex))
                {
                    score += SpareScore(result, rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += NormalScore(result, rollIndex);
                    rollIndex += 2;
                }
            }
            return score;
        }

        private static int NormalScore(IList result, int rollIndex)
        {
            return (int)result[rollIndex] + (int)result[rollIndex + 1];
        }

        private static int SpareScore(IList result, int rollIndex)
        {
            return 10 + (int)result[rollIndex + 2];
        }

        private static bool IsSpare(IList result, int rollIndex)
        {
            return (int)result[rollIndex] + (int)result[rollIndex + 1] == 10;
        }

        private static int StrikeScore(IList result, int rollIndex)
        {
            return 10 + (int)result[rollIndex + 1] + (int)result[rollIndex + 2];
        }

        private static bool IsStrike(IList result, int rollIndex)
        {
            return (int)result[rollIndex] == 10;
        }
    }
}