using System;
using System.Collections.Generic;

namespace Basic_Performance_Tests
{
    public static class ListOperations
    {
        static ListOperations()
        {
        }

        public static void RunIntegerListTests()
        {
            Console.WriteLine($"ListOperations.RunIntegerListTests()");

            // setup
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            long elapsedTimeToListInit;
            long elapsedTimeToListPopulation;
            long elapsedTimeToListSummed;
            long elapsedTimeToListCleared;

            int total = 0;
            int listCount = 1000;

            stopwatch.Start();

            // initialize our list
            List<int> intList = new List<int>();
            elapsedTimeToListInit = stopwatch.ElapsedMilliseconds;

            // add some numbers to it
            for (int i = 0; i < listCount; i++) {
                intList.Add(i);
            }
            elapsedTimeToListPopulation = stopwatch.ElapsedMilliseconds;

            // add them up
            foreach (int n in intList) {
                total += n;
            }
            elapsedTimeToListSummed = stopwatch.ElapsedMilliseconds;

            // remove them
            for (int i = intList.Count; i >= 0; i--) {
                intList.Remove(i);
            }
            elapsedTimeToListCleared = stopwatch.ElapsedMilliseconds;

            // calculate times.
            long timeToPopulate = elapsedTimeToListPopulation - elapsedTimeToListInit;
            long timeToSum = elapsedTimeToListSummed - elapsedTimeToListPopulation;
            long timeToClear = elapsedTimeToListCleared - elapsedTimeToListSummed;

            // output
            Console.WriteLine("=======================================");
            Console.WriteLine($"Integer List Test Results, int count: {listCount}:");
            Console.WriteLine($"| List instantiation | {elapsedTimeToListInit}ms |");
            Console.WriteLine($"| List population | {timeToPopulate}ms |");
            Console.WriteLine($"| List summation | {timeToSum}ms |");
            Console.WriteLine($"| List clearing | {timeToClear}ms |");
            Console.WriteLine("=======================================");
        }

    }
}
