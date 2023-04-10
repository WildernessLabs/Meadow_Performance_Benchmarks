using System;
using System.Text.Json;

namespace Basic_Performance_Tests
{
    public static class JsonTests
    {
        public class SampleData
        {
            public string s { get; set; }
            public int i { get; set; }
            public decimal d { get; set; }
        }

        public static void RunJsonTests()
        {
            string json = "{\"s\" : \"string\",\"i\" : 420,\"d\" : 420.68}";
            var iterations = 10;
            long elapsedTimeDeserialize;

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            stopwatch.Start();
            for (var iteration = 0;iteration < iterations;++iteration)
            {
                var result = JsonSerializer.Deserialize<SampleData>(json);
            }
            elapsedTimeDeserialize = stopwatch.ElapsedMilliseconds;
            var timeToDeserialize = elapsedTimeDeserialize;

            stopwatch.Stop();

            var averageDeserializeTime = (float) timeToDeserialize / (float) iterations;

            Console.WriteLine("=======================================");
            Console.WriteLine($"JSON Deserialize Results:");
            Console.WriteLine($"| {iterations} Deserializations | {timeToDeserialize}ms |");
            Console.WriteLine($"| Average time per deserialization | {averageDeserializeTime}ms |");
            Console.WriteLine("=======================================");
        }
    }
}
