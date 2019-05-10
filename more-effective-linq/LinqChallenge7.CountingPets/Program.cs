using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq.Extensions;

namespace LinqChallenge7.CountingPets
{
	class Program
	{
		static void Main(string[] args)
		{
			string animals = "Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog";

			// Objective: count how many animals are of each type

			// Solution 1: 

			Dictionary<string, int> answer = animals.Split(',')
				.CountBy(a => a)
				.ToDictionary(g => g.Key, g => g.Value);

			Console.WriteLine("Solution 1:");
			foreach (KeyValuePair<string, int> kvp in answer)
			{
				Console.WriteLine((kvp.Key, kvp.Value));
			}

			// Solution 2:
			IEnumerable<(string Key, int)> answer2 = animals.Split(',')
				.GroupBy(a => a)
				.Select(g => (g.Key, g.Count()));

			Console.WriteLine("\nSolution 2:");
			foreach ((string Pet, int Count) in answer2)
			{
				Console.WriteLine((Pet, Count));
			}
		}
	}
}
