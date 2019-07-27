using System;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace Bowling_Kata
{
    public class BowlingKata
    {
        private const int MaxFrame = 10;

        public int Score(ArrayList result)
        {
            //總球數不能大於21球
            if (result.Count > 21)
            {
                return -1;
            }
            // 任一球不能大於10瓶
            foreach (var pins in result)
            {
                if ((int)pins > 10)
                {
                    return -1;
                }
            }

            var frameIndex = 0;
            var rollCount = 0;
            var accumulatedPins = 0;
            var index = 0;
            // 測資意外處理
            foreach (var pins in result)
            {
                if (frameIndex == 10)
                {
                    if (result.Count - index == 2)
                    {
                        if ((int)result[index] == 10)
                        {
                            break;
                        }
                        else if ((int)result[index] + (int)result[index + 1] == 10)
                        {
                            break;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else if (result.Count - index == 1)
                    {
                        if ((int)result[index - 2] == 10)
                        {
                            break;
                        }
                        else if ((int)result[index - 2] + (int)result[index - 1] == 10)
                        {
                            break;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }

                if ((int)pins == 10 && frameIndex != 10)
                {
                    frameIndex += 1;
                }
                else
                {
                    accumulatedPins += (int)pins;
                    rollCount += 1;
                    if (accumulatedPins == 10)
                    {
                        frameIndex += 1;
                        accumulatedPins = 0;
                        rollCount = 0;
                    }
                    else if (rollCount == 2 && accumulatedPins != 10)
                    {
                        frameIndex += 1;
                        accumulatedPins = 0;
                        rollCount = 0;
                    }
                }
                index++;
            }

            if (frameIndex != 10)
            {
                return -1;
            }

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
            if (frameIndex != 10)
            {
                score = -1;
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