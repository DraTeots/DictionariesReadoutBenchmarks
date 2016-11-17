using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DictTest
{
    class Cat
    {
        public int TailLength { get; set; }
        public override string ToString()
        {
            return $"My tail is {TailLength}";
        }
    }

    enum Indexes
    {
        One,
        Two,
        Three
    }


    class Program
    {
        static void PrintResult(string name, List<double> results, double emptyAverage)
        {
            double max = results.Max() - emptyAverage;
            double min = results.Min() - emptyAverage;
            double average = results.Average() - emptyAverage;
            Console.WriteLine($"Results for {name,15}: average = {average,5:#0.00}[ms]  min = {min,5:#0.0}[ms]  max = {max,5:#0.0}[ms]");
        }

        static void Main(string[] args)
        {
            var dictStrInt = new Dictionary<string, int> { { "One", 1}, {"Two", 2}, {"Three",3}};
            var dictLongStrInt = new Dictionary<string, int> { { "TheLongLongSameStringOne", 1 }, { "TheLongLongSameStringTwo", 2 }, { "TheLongLongSameStringThree", 3 } };
            var dictStrCat = new Dictionary<string, Cat> { { "One", new Cat {TailLength = 1} }, { "Two", new Cat { TailLength = 2 } }, { "Three", new Cat { TailLength = 3 } } };
            var dictIntInt = new Dictionary<int, int> { { 0, 1 }, { 1, 2 }, { 2, 3 } };
            var dictIntCat = new Dictionary<int, Cat> { { 0, new Cat { TailLength = 1 } }, { 1, new Cat { TailLength = 2 } }, { 2, new Cat { TailLength = 3 } } };
            var listInt = new List<int> {1, 2, 3};
            var listCat = new List<Cat> { new Cat { TailLength = 1 } , new Cat { TailLength = 2 }, new Cat { TailLength = 3 } };

            int len = 1000000;
            int repetitionCount = 10;
            var results = new Dictionary<string, List<double>>();
            var rnd = new Random(0);
            int sum = 0;            // Sum to disctract optimization

            results["dictStrInt"] = new List<double>();
            results["dictLongStrInt"] = new List<double>();
            results["dictStrCat"] = new List<double>();
            results["dictIntInt"] = new List<double>();
            results["dictIntCat"] = new List<double>();
            results["listInt"] = new List<double>();
            results["listInt(enum)"] = new List<double>();
            results["listCat"] = new List<double>();
            results["empty"] = new List<double>();



            for (int repetitionIndex = 0; repetitionIndex < repetitionCount; repetitionIndex++)
            {
                var stopwatch = new Stopwatch();
                Console.WriteLine($"Starting 'empty' benchmark {len} times");
                stopwatch.Start();
                for (int i = 0; i < len; i++)
                {
                    switch (rnd.Next(2))
                    {
                        case 0:
                            sum += 0;
                            break;
                        case 1:
                            sum += 1;
                            break;
                        default:
                            sum += 2;
                            break;
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"The result is {stopwatch.ElapsedMilliseconds} ms");
                long emptyBenchmarkMs = stopwatch.ElapsedMilliseconds;
                if (repetitionIndex > 0) results["empty"].Add(stopwatch.Elapsed.TotalMilliseconds); // Skip the first time


                // 
                stopwatch = new Stopwatch();
                Console.WriteLine($"Starting dictStrInt benchmark {len} times");
                sum = 0;
                stopwatch.Start();
                for (int i = 0; i < len; i++)
                {
                    switch (rnd.Next(2))
                    {
                        case 0:
                            sum += dictStrInt["One"];
                            break;
                        case 1:
                            sum += dictStrInt["Two"];
                            break;
                        default:
                            sum += dictStrInt["Three"];
                            break;
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"The result is {stopwatch.ElapsedMilliseconds - emptyBenchmarkMs} ms");
                if (repetitionIndex > 0) results["dictStrInt"].Add(stopwatch.Elapsed.TotalMilliseconds); // Skip the first time
                


                // dictLongStrInt
                stopwatch = new Stopwatch();
                Console.WriteLine($"Starting dictLongStrInt benchmark {len} times");
                sum = 0;
                stopwatch.Start();
                for (int i = 0; i < len; i++)
                {
                    switch (rnd.Next(2))
                    {
                        case 0:
                            sum += dictLongStrInt["TheLongLongSameStringOne"];
                            break;
                        case 1:
                            sum += dictLongStrInt["TheLongLongSameStringTwo"];
                            break;
                        default:
                            sum += dictLongStrInt["TheLongLongSameStringThree"];
                            break;
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"The result is {stopwatch.ElapsedMilliseconds - emptyBenchmarkMs} ms");
                if (repetitionIndex > 0) results["dictLongStrInt"].Add(stopwatch.Elapsed.TotalMilliseconds); // Skip the first time



                // dictStrCat
                stopwatch = new Stopwatch();
                Console.WriteLine($"Starting dictStrCat benchmark {len} times");
                sum = 0;
                stopwatch.Start();
                for (int i = 0; i < len; i++)
                {
                    switch (rnd.Next(2))
                    {
                        case 0:
                            sum += dictStrCat["One"].TailLength;
                            break;
                        case 1:
                            sum += dictStrCat["Two"].TailLength;
                            break;
                        default:
                            sum += dictStrCat["Three"].TailLength;
                            break;
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"The result is {stopwatch.ElapsedMilliseconds - emptyBenchmarkMs} ms");
                if (repetitionIndex > 0) results["dictStrCat"].Add(stopwatch.Elapsed.TotalMilliseconds); // Skip the first time



                // dictIntInt
                stopwatch = new Stopwatch();
                Console.WriteLine($"Starting dictIntInt benchmark {len} times");
                sum = 0;
                stopwatch.Start();
                for (int i = 0; i < len; i++)
                {
                    switch (rnd.Next(2))
                    {
                        case 0:
                            sum += dictIntInt[0];
                            break;
                        case 1:
                            sum += dictIntInt[1];
                            break;
                        default:
                            sum += dictIntInt[2];
                            break;
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"The result is {stopwatch.ElapsedMilliseconds - emptyBenchmarkMs} ms");
                if (repetitionIndex > 0) results["dictIntInt"].Add(stopwatch.Elapsed.TotalMilliseconds); // Skip the first time



                // dictIntCat
                stopwatch = new Stopwatch();
                Console.WriteLine($"Starting dictIntCat benchmark {len} times");
                sum = 0;
                stopwatch.Start();
                for (int i = 0; i < len; i++)
                {
                    switch (rnd.Next(2))
                    {
                        case 0:
                            sum += dictIntCat[0].TailLength;
                            break;
                        case 1:
                            sum += dictIntCat[1].TailLength;
                            break;
                        default:
                            sum += dictIntCat[2].TailLength;
                            break;
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"The result is {stopwatch.ElapsedMilliseconds - emptyBenchmarkMs} ms");
                if (repetitionIndex > 0) results["dictIntCat"].Add(stopwatch.Elapsed.TotalMilliseconds); // Skip the first time



                // listInt
                stopwatch = new Stopwatch();
                Console.WriteLine($"Starting listInt benchmark {len} times");
                sum = 0;
                stopwatch.Start();
                for (int i = 0; i < len; i++)
                {
                    switch (rnd.Next(2))
                    {
                        case 0:
                            sum += listInt[0];
                            break;
                        case 1:
                            sum += listInt[1];
                            break;
                        default:
                            sum += listInt[2];
                            break;
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"The result is {stopwatch.ElapsedMilliseconds - emptyBenchmarkMs} ms");
                if (repetitionIndex > 0) results["listInt"].Add(stopwatch.Elapsed.TotalMilliseconds); // Skip the first time



                // listInt(enum)
                stopwatch = new Stopwatch();
                Console.WriteLine($"Starting listInt(enum) benchmark {len} times");
                sum = 0;
                stopwatch.Start();
                for (int i = 0; i < len; i++)
                {
                    switch (rnd.Next(2))
                    {
                        case 0:
                            sum += listInt[(int)Indexes.One];
                            break;
                        case 1:
                            sum += listInt[(int)Indexes.Two];
                            break;
                        default:
                            sum += listInt[(int)Indexes.Three];
                            break;
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"The result is {stopwatch.ElapsedMilliseconds - emptyBenchmarkMs} ms");
                if (repetitionIndex > 0) results["listInt(enum)"].Add(stopwatch.Elapsed.TotalMilliseconds); // Skip the first time



                // listCat
                stopwatch = new Stopwatch();
                Console.WriteLine($"Starting listCat benchmark {len} times");
                sum = 0;
                stopwatch.Start();
                for (int i = 0; i < len; i++)
                {
                    switch (rnd.Next(2))
                    {
                        case 0:
                            sum += listCat[0].TailLength;
                            break;
                        case 1:
                            sum += listCat[1].TailLength;
                            break;
                        default:
                            sum += listCat[2].TailLength;
                            break;
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"The result is {stopwatch.ElapsedMilliseconds - emptyBenchmarkMs} ms");
                if (repetitionIndex > 0) results["listCat"].Add(stopwatch.Elapsed.TotalMilliseconds); // Skip the first time
                Console.WriteLine("---------------------------------------------------");
            }

            
            //--------------------------
            // PRINT THE RESULTS

            double emptyAverage = results["empty"].Average();

            foreach (var result in results)
            {
                PrintResult(result.Key, result.Value, result.Key == "empty"? 0: emptyAverage);
            }

            Console.WriteLine($"sum={sum}");

        }
    }
}
