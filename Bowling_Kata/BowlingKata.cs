using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bowling_Kata
{
    public class BowlingKata
    {
        private int _rollIndex;
        private int _frame = 1;
        private bool _firstRoll = true;
        private const int MaxFrame = 10;
        private readonly int[] _pinsPerRoll = new int[21];

        public int Frame
        {
            get => _frame > MaxFrame ? MaxFrame : _frame;
            set => _frame = value;
        }

        public int Score()
        {
            var score = 0;
            var rollIndex = 0;
            for (var i = 0; i < Frame; i++)
            {
                if (IsStrike(rollIndex))
                {
                    score += StrikeScore(rollIndex);
                    rollIndex += 1;
                }
                else if (IsSpare(rollIndex))
                {
                    score += SpareScore(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += NormalScore(rollIndex);
                    rollIndex += 2;
                }
            }
            return score;
        }

        public void Roll(int pins)
        {
            if (_firstRoll)
            {
                if (pins == 10)
                {
                    Frame++;
                }
                else
                {
                    _firstRoll = false;
                }
            }
            else
            {
                _firstRoll = true;
                Frame++;
            }

            _pinsPerRoll[_rollIndex++] = pins;
        }

        private int NormalScore(int rollIndex)
        {
            return _pinsPerRoll[rollIndex] + _pinsPerRoll[rollIndex + 1];
        }

        private int SpareScore(int rollIndex)
        {
            return 10 + _pinsPerRoll[rollIndex + 2];
        }

        private bool IsSpare(int rollIndex)
        {
            return _pinsPerRoll[rollIndex] + _pinsPerRoll[rollIndex + 1] == 10;
        }

        private int StrikeScore(int rollIndex)
        {
            return 10 + _pinsPerRoll[rollIndex + 1] + _pinsPerRoll[rollIndex + 2];
        }

        private bool IsStrike(int rollIndex)
        {
            return _pinsPerRoll[rollIndex] == 10;
        }
    }
}