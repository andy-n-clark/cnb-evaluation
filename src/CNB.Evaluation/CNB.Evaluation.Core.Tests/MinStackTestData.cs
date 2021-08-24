using CNB.Evaluation.Core.Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CNB.Evaluation.Core.Tests
{
    public class MinStackTestData
    {
        public static int RandomInt
        {
            get
            {
                Random random = new Random();
                return random.Next();
            }
        }

        public static bool CoinToss
        {
            get
            {
                Random random = new Random();
                return (random.Next(2) == 0);
            }
        }

        public static string ChooseAction
        {
            get
            {
                Random random = new Random();

                switch (random.Next(1,4))
                {
                    case 1:
                        return "push";
                    case 2:
                        return "pop";
                    case 3:
                        return "top";
                    case 4:
                        return "getMin";
                    default:
                        return "push";
                }
            }
        }

        public static int[] GenerateTestData(int size, out int minimum)
        {
            var array = new int[size];

            minimum = 0;

            for (int i = 0; i < size; i++)
            {
                var randomInt = RandomInt;

                randomInt = (CoinToss) ? randomInt : -randomInt;

                array[i] = randomInt;

                if (randomInt < minimum)
                {
                    minimum = randomInt;
                }
            }

            return array;
        }
    }

    public class TestData
    {
        public string Action { get; set; } // push, pop, top, getMin

        public int Value { get; set; }
    }
}
