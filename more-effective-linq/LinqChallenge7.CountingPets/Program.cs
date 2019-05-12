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

			// Objective 1: count how many animals are of each type

			// Solution 1: 
			IEnumerable<KeyValuePair<string, int>> answer = animals.Split(',')
				.CountBy(a => a);

			Console.WriteLine("Objective 1 - Solution 1:");
			foreach (KeyValuePair<string, int> kvp in answer)
			{
				Console.WriteLine((kvp.Key, kvp.Value));
			}

			// Solution 2:
			IEnumerable<(string Key, int)> answer2 = animals.Split(',')
				.GroupBy(a => a)
				.Select(g => (g.Key, g.Count()));

			Console.WriteLine("\nObjective 1 - Solution 2:");
			foreach ((string Pet, int Count) in answer2)
			{
				Console.WriteLine((Pet, Count));
			}

			// Objective 2: count only dogs and cats explicitly; 
			// create a third group "Other" for the rest

			// Solution 1:
			IEnumerable<KeyValuePair<string, int>> answerDogsCats = animals.Split(',')
				.CountBy(a => a != "Dog" && a != "Cat" ? "Other" : a);

			Console.WriteLine("\nObjective 2 - Solution 1:");
			foreach (KeyValuePair<string, int> kvp in answerDogsCats)
			{
				Console.WriteLine((kvp.Key, kvp.Value));
			}

			// Solution 2:
			Dictionary<string, int> answerDogsCats2 = animals.Split(',')
				.GroupBy(a => a != "Dog" && a != "Cat" ? "Other" : a)
				.ToDictionary(g => g.Key, g => g.ToList().Count);

			Console.WriteLine("\nObjective 2 - Solution 2:");
			foreach (KeyValuePair<string, int> kvp in answerDogsCats2)
			{
				Console.WriteLine((kvp.Key, kvp.Value));
			}
		}
	}
}
