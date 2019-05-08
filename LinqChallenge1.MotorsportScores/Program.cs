using System;
using System.Linq;

namespace LinqChallange1.MotorsportScores
{
	class Program
	{
		static void Main(string[] args)
		{
			// Given the scores for the season, calculate the total score.
			// The three worst performances should not count in total score calculation.

			string racesScores = "10,5,0,8,10,1,4,0,10,1";

			int totalScore = racesScores.Split(',')
				.Select(s=>int.Parse(s))
				//.Select(s => ToInt(s))
				.OrderBy(score => score)
				.Skip(3)
				.Sum();

			Console.WriteLine($"Total score for the season: {totalScore}");
		}

		static int ToInt(string s)
		{
			bool _ = int.TryParse(s, out int i);
			return i;
		}
	}
}
