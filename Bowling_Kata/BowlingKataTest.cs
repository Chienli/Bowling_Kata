﻿using System;
using System.Collections;
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
            var result = new ArrayList();
            Roll(0, result, 20);

            ScoreShouldBe(0, result);
        }

        [TestMethod]
        public void Rolls_1_return_1()
        {
            var result = new ArrayList();
            Roll(1, result);
            Roll(0, result, 19);

            ScoreShouldBe(1, result);
        }

        [TestMethod]
        public void Rolls_spare_then_1_return_12()
        {
            var result = new ArrayList();
            Roll(5, result);
            Roll(5, result);
            Roll(1, result);
            Roll(0, result, 17);

            ScoreShouldBe(12, result);
        }

        [TestMethod]
        public void Rolls_strike_then_1_return_12()
        {
            var result = new ArrayList();
            Roll(10, result);
            Roll(1, result);
            Roll(0, result, 18);

            ScoreShouldBe(12, result);
        }

        private void ScoreShouldBe(int expected, ArrayList result)
        {
            Assert.AreEqual(expected, _bowlingKata.Score(result));
        }

        private static void Roll(int pins, ArrayList result, int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                result.Add(pins);
            }
        }
    }
}