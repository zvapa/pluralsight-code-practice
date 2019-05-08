using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LinqChallenge4.SortByAge
{
	class Program
	{
		static void Main(string[] args)
		{
			string players = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976;" +
				" Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";

			// Objective: get name and age in years from the string list of players
			// while improving readability of the Linq pipeline;

			IEnumerable<(string name, int age)> solution = players.Split(';')
				.Select(s => GetNameAndBirthdayStringPairs(s))
				.Select(nameAndBirthdayStringPair => ConvertToNameAndBirthdayTuple(nameAndBirthdayStringPair))
				.Select(nameAndBirthdayTuple => ConvertToNameAndAgeTuple(nameAndBirthdayTuple))
				.OrderBy(nameAndAgeTuple => nameAndAgeTuple.age);

			// alternatively:
			var solution2 = players.Split(';')
				.Select(n => n.Split(','))
				.Select(n => new { Name = n[0].Trim(), DateOfBirth = ParseDoB(n[1]) })
				.OrderByDescending(n => n.DateOfBirth)
				.Select(n => new { Name = n.Name, Age = GetAge(n.DateOfBirth) });

			foreach ((string name, int age) item in solution)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine(Environment.NewLine);

			foreach (var item in solution2)
			{
				Console.WriteLine(item);
			}
		}

		private static (string name, int age) ConvertToNameAndAgeTuple((string name, DateTime birthday) nameAndBirthdayTuple) =>
			(nameAndBirthdayTuple.name, age: (int)(DateTime.Now - nameAndBirthdayTuple.birthday).TotalDays / 365);

		private static (string name, DateTime) ConvertToNameAndBirthdayTuple(string[] nameAndBirthdayStringPair) =>
			(name: nameAndBirthdayStringPair[0], DateTime.ParseExact(nameAndBirthdayStringPair[1], @"dd/mm/yyyy", null));

		private static string[] GetNameAndBirthdayStringPairs(string nameCommaBirthday) =>
			nameCommaBirthday.Split(',').Select(s => s.Trim()).ToArray();

		private static int GetAge(DateTime dateOfBirth)
		{
			DateTime today = DateTime.Today;
			int age = today.Year - dateOfBirth.Year;
			if (dateOfBirth > today.AddYears(-age)) age--;
			return age;
		}

		private static DateTime ParseDoB(string dob) => DateTime.ParseExact(dob.Trim(), @"dd/mm/yyyy", null);
	}
}
