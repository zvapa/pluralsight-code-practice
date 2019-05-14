using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace LinqChallenge9.CountingConsecutiveSales
{
	class Program
	{
		static void Main(string[] args)
		{
			// Objective: given an array representing the number of sales
			// made each day by a sales person, find the longest streak of 
			// consecutive days in which something was sold.

			int[] sales = new[] { 0, 1, 3, 0, 0, 2, 1, 5, 4, 0, 0, 0, 3 };

			// Solution 1:
			int solution = sales.Aggregate((curentValue: 0, currentStreak: 0, maxSoFar: 0),
				(acc, next) => next > 0
					? (next, acc.currentStreak + 1, Math.Max(acc.currentStreak + 1, acc.maxSoFar))
					: (next, 0, acc.maxSoFar)).maxSoFar;

			Console.WriteLine("Solution 1: " + solution);

			// Solution 2:
			int solution2 = sales.GroupAdjacent(n => n > 0)
				.Where(g => g.Key)
				.Max(g => g.Count());

			Console.WriteLine("Solution 2: " + solution2);
		}
	}
}
