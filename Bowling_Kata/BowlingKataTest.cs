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
            Roll(0, result, 17);

            ScoreShouldBe(12, result);
        }

        [TestMethod]
        public void Rolls_all_5_return_150()
        {
            var result = new ArrayList();
            Roll(5, result, 21);

            ScoreShouldBe(150, result);
        }

        [TestMethod]
        public void Rolls_all_strike_return_300()
        {
            var result = new ArrayList();
            Roll(10, result, 12);

            ScoreShouldBe(300, result);
        }

        [TestMethod]
        public void Rolls_13_times_strike_return_minus1()
        {
            var result = new ArrayList();
            Roll(10, result, 13);

            ScoreShouldBe(-1, result);
        }

        [TestMethod]
        public void Rolls_only_10_frame_strike_return_160()
        {
            var result = new ArrayList();
            Roll(5, result, 18);
            Roll(10, result);
            Roll(5, result, 2);

            ScoreShouldBe(160, result);
        }

        [TestMethod]
        public void Rolls_all_frame_9_0_return_90()
        {
            var result = new ArrayList();
            for (var i = 0; i < 10; i++)
            {
                Roll(9, result);
                Roll(0, result);
            }

            ScoreShouldBe(90, result);
        }

        [TestMethod]
        public void Rolls_10_frame_5_4_3_return_minus1()
        {
            var result = new ArrayList();
            for (var i = 0; i < 9; i++)
            {
                Roll(9, result);
                Roll(0, result);
            }
            Roll(5, result);
            Roll(4, result);
            Roll(3, result);

            ScoreShouldBe(-1, result);
        }

        [TestMethod]
        public void Rolls_out_of_frame_return_minus1()
        {
            var result = new ArrayList();
            Roll(1, result, 22);

            ScoreShouldBe(-1, result);
        }

        [TestMethod]
        public void Rolls_no_complete_all_frame_return_minus1()
        {
            var result = new ArrayList();
            Roll(1, result, 4);

            ScoreShouldBe(-1, result);
        }

        [TestMethod]
        public void Sample_All_cases()
        {
            var result = new ArrayList();

            Roll(1, result);
            Roll(4, result);
            Roll(4, result);
            Roll(5, result);
            Roll(6, result);
            Roll(4, result);
            Roll(5, result);
            Roll(5, result);
            Roll(10, result);
            Roll(0, result);
            Roll(1, result);
            Roll(7, result);
            Roll(3, result);
            Roll(6, result);
            Roll(4, result);
            Roll(10, result);
            Roll(2, result);
            Roll(8, result);
            Roll(6, result);
            ScoreShouldBe(133, result);
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