using System;
using System.Diagnostics;
using System.Linq;

namespace PerformanceComparison
{
	class Program
	{
		static void Main(string[] args)
		{
			// Objective: perform a speed test comparison 
			// between using LINQ, for loop and PLINQ on a large sequence

			var listSize = 10_000_000;

			// using Linq:
			var stopWatch = new Stopwatch();
			stopWatch.Start();

			var s = Enumerable.Range(1, listSize)
				.Select(n => n * 2)
				.Select(n => Math.Sin((2 * Math.PI * n) / 1000))
				.Select(n => Math.Pow(n, 2))
				.Sum();
			stopWatch.Stop();
			Console.WriteLine($"Processing {listSize} items using LINQ in {stopWatch.ElapsedMilliseconds} ms");


			// using for loop:
			stopWatch.Restart();
			double sum = 0;
			for (int n = 1; n < listSize; n++)
			{
				var a = n * 2;
				var b = Math.Sin((2 * Math.PI * a) / 1000);
				var c = Math.Pow(b, 2);
				sum += c;
			}
			stopWatch.Stop();
			Console.WriteLine($"Processing {listSize} items using for loop in {stopWatch.ElapsedMilliseconds} ms");

			// using PLINQ:
			stopWatch.Restart();
			var q = Enumerable.Range(1, listSize).AsParallel()
				.Select(n => n * 2)
				.Select(n => Math.Sin((2 * Math.PI * n) / 1000))
				.Select(n => Math.Pow(n, 2))
				.Sum();
			stopWatch.Stop();
			Console.WriteLine($"Processing {listSize} items using PLINQ in {stopWatch.ElapsedMilliseconds} ms");

		}
	}
}
