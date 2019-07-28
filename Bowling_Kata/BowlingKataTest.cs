using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bowling_Kata
{
    [TestClass]
    public class BowlingKataTest
    {
        private readonly BowlingKata _bowlingKata = new BowlingKata();

        [TestMethod]
        public void Rolls_all_0_return_0()
        {
            RollManyTimes(0, 20);

            ScoreShouldBe(0);
        }

        [TestMethod]
        public void Rolls_1_return_1()
        {
            _bowlingKata.Roll(1);

            ScoreShouldBe(1);
        }

        [TestMethod]
        public void Rolls_spare_then_1_return_12()
        {
            _bowlingKata.Roll(5);
            _bowlingKata.Roll(5);
            _bowlingKata.Roll(1);

            ScoreShouldBe(12);
        }

        [TestMethod]
        public void Rolls_strike_then_1_return_12()
        {
            _bowlingKata.Roll(10);
            _bowlingKata.Roll(1);

            ScoreShouldBe(12);
        }

        [TestMethod]
        public void Rolls_all_5_return_150()
        {
            RollManyTimes(5, 21);

            ScoreShouldBe(150);
        }

        [TestMethod]
        public void Rolls_all_strike_return_300()
        {
            RollManyTimes(10, 12);

            ScoreShouldBe(300);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Rolls_out_of_range_expected_outOfRangeException()
        {
            RollManyTimes(10, 25);
        }

        [TestMethod]
        public void Rolls_all_frame_9_0_return_90()
        {
            for (var i = 0; i < 10; i++)
            {
                _bowlingKata.Roll(9);
                _bowlingKata.Roll(0);
            }

            ScoreShouldBe(90);
        }

        [TestMethod]
        public void Sample_All_cases()
        {
            _bowlingKata.Roll(1);
            _bowlingKata.Roll(4);
            _bowlingKata.Roll(4);
            _bowlingKata.Roll(5);
            _bowlingKata.Roll(6);
            _bowlingKata.Roll(4);
            _bowlingKata.Roll(5);
            _bowlingKata.Roll(5);
            _bowlingKata.Roll(10);
            _bowlingKata.Roll(0);
            _bowlingKata.Roll(1);
            _bowlingKata.Roll(7);
            _bowlingKata.Roll(3);
            _bowlingKata.Roll(6);
            _bowlingKata.Roll(4);
            _bowlingKata.Roll(10);
            _bowlingKata.Roll(2);
            _bowlingKata.Roll(8);
            _bowlingKata.Roll(6);

            ScoreShouldBe(133);
        }

        private void RollManyTimes(int pins, int times)
        {
            for (var i = 0; i < times; i++)
            {
                _bowlingKata.Roll(pins);
            }
        }

        private void ScoreShouldBe(int expected)
        {
            Assert.AreEqual(expected, _bowlingKata.Score());
        }
    }
}