using CNB.Evaluation.Core.Common.Models;
using CNB.Evaluation.Core.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CNB.Evaluation
{
    class Program
    {
        public static void Main()
        {
            #region Dependency Injection Setup

            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IParenthesesValidationService, ParenthesesValidationService>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<IParenthesesValidationService>();

            #endregion Dependency Injection Setup

            
            TestLoadingMinStackViaArrays();

            TestGetMinOfMinStackViaArrays();


            
            TestLoadingMinStackViaLinkedLists();

            TestGetMinOfMinStackViaLinkedLists();



            TestLoadingMinStackViaGenericStacks();

            TestGetMinOfMinStackViaGenericStacks();



            Console.ReadLine();
        }
        
        public static void TestLoadingMinStackViaArrays()
        {
            var minStack = new MinStackViaArrays();
            var minimum = 0;

            var data = GenerateTestData(30000, out minimum);

            var sw = new Stopwatch();

            sw.Start();

            foreach (var item in data)
            {
                minStack.push(item);                
            }

            sw.Stop();

            var elapsed = sw.ElapsedTicks;

            Console.WriteLine($"MinStackViaArrays total load time: {elapsed} ticks");
            Console.WriteLine();
        }

        public static void TestGetMinOfMinStackViaArrays()
        {
            var minStack = new MinStackViaArrays();
            var minimum = 0;

            var data = GenerateTestData(30000, out minimum);

            var elapsed = new List<string>();

            Console.WriteLine($"MinStackViaArrays getMin() time in ticks:");

            foreach (var item in data)
            {
                minStack.push(item);

                var sw = new Stopwatch();

                sw.Start();

                var currentMinimum = minStack.getMin();

                sw.Stop();

                var ticks = sw.ElapsedTicks.ToString();

                if (!elapsed.Contains(ticks))
                {
                    elapsed.Add(ticks);
                }
            }

            foreach (var ticks in elapsed)
            {
                Console.Write(ticks + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void TestLoadingMinStackViaLinkedLists()
        {
            var minStack = new MinStackViaLinkedLists();
            var minimum = 0;

            var data = GenerateTestData(30000, out minimum);

            var sw = new Stopwatch();

            sw.Start();

            foreach (var item in data)
            {
                minStack.push(item);
            }

            sw.Stop();

            var elapsed = sw.ElapsedTicks;

            Console.WriteLine($"MinStackViaLinkedLists total load time: {elapsed} ticks");
            Console.WriteLine();
        }

        public static void TestGetMinOfMinStackViaLinkedLists()
        {
            var minStack = new MinStackViaLinkedLists();
            var minimum = 0;

            var data = GenerateTestData(30000, out minimum);

            var elapsed = new List<string>();

            Console.WriteLine($"MinStackViaLinkedLists getMin() time in ticks:");

            foreach (var item in data)
            {
                minStack.push(item);

                var sw = new Stopwatch();

                sw.Start();

                var currentMinimum = minStack.getMin();

                sw.Stop();

                var ticks = sw.ElapsedTicks.ToString();

                if (!elapsed.Contains(ticks))
                {
                    elapsed.Add(ticks);
                }
            }

            foreach (var ticks in elapsed)
            {
                Console.Write(ticks + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void TestLoadingMinStackViaGenericStacks()
        {
            var minStack = new MinStackViaGenericStacks();
            var minimum = 0;

            var data = GenerateTestData(30000, out minimum);

            var sw = new Stopwatch();

            sw.Start();

            foreach (var item in data)
            {
                minStack.push(item);
            }

            sw.Stop();

            var elapsed = sw.ElapsedTicks;

            Console.WriteLine($"MinStackViaGenericStacks total load time: {elapsed} ticks");
            Console.WriteLine();
        }

        public static void TestGetMinOfMinStackViaGenericStacks()
        {
            var minStack = new MinStackViaGenericStacks();
            var minimum = 0;

            var data = GenerateTestData(30000, out minimum);

            var elapsed = new List<string>();

            Console.WriteLine($"MinStackViaGenericStacks getMin() time in ticks:");

            foreach (var item in data)
            {
                minStack.push(item);

                var sw = new Stopwatch();

                sw.Start();

                var currentMinimum = minStack.getMin();

                sw.Stop();

                var ticks = sw.ElapsedTicks.ToString();

                if (!elapsed.Contains(ticks))
                {
                    elapsed.Add(ticks);
                }
            }

            foreach (var ticks in elapsed)
            {
                Console.Write(ticks + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }


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
}