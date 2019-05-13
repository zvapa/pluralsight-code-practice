using System;
using System.Collections.Generic;
using System.Linq;
using static MoreLinq.Extensions.PairwiseExtension;

namespace LinqChallenge8.SwimLengthTimes
{
	class Program
	{
		static void Main(string[] args)
		{
			// Given the times at which a swimmer finishes each length of the pool
			string swimLengthTimes = "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35";

			//"00:00,00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35"
			//"00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35"

			// (Objective:) calculate swim length times, by turning the above sequence into
			// a sequence of the time it took to swim each length

			// Solution 1:
			IEnumerable<TimeSpan> solution = swimLengthTimes.Split(',')
				.Prepend("00:00")
				.Zip(swimLengthTimes.Split(','), (s, f) =>
						(start: TimeSpan.Parse("00:" + s), finish: TimeSpan.Parse("00:" + f)))
				.Select(t => t.finish - t.start);

			Console.WriteLine("Solution 1:");
			foreach (TimeSpan time in solution)
			{
				Console.WriteLine(time);
			}

			// Solution 2 (using MoreLinq's Pairwize):
			IEnumerable<TimeSpan> solution2 = swimLengthTimes.Split(',')
				.Select(t => TimeSpan.Parse("00:" + t))
				.Pairwise((a, b) => b - a);

			Console.WriteLine("\nSolution 2:");
			foreach (TimeSpan time in solution2)
			{
				Console.WriteLine(time);
			}
		}
	}
}
