using System;
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
            result = Roll(0, result, 20);

            ScoreShouldBe(0, result);
        }

        private void ScoreShouldBe(int expected, ArrayList result)
        {
            Assert.AreEqual(expected, _bowlingKata.Score(result));
        }

        private static ArrayList Roll(int pins, ArrayList result, int times = 1)
        {
            for (var i = 0; i < times; i++)
            {
                result.Add(pins);
            }
            return result;
        }
    }
}