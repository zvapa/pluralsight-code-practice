using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqChallenge6.LongestBook
{
	class Program
	{
		static void Main(string[] args)
		{
			var books = new[]
			{
				new { Author = "Robert Martin", Title = "Clean Code", Pages = 464 },
				new { Author = "Oliver Sturm", Title = "Functional Programming in C#" , Pages = 270 },
				new { Author = "Martin Fowler", Title = "Patterns of Enterprise Application Architecture", Pages = 533 },
				new { Author = "Bill Wagner", Title = "Effective C#", Pages = 328 },
			};

			// Objective: get the book with the highest number of pages

			// Solution 1:
			int mostPages = books.Max(x => x.Pages);
			var book = books.First(b => b.Pages == mostPages);

			Console.WriteLine(book);

			// Solution 2:
			var book2 = books.OrderByDescending(b => b.Pages)
				.First();

			Console.WriteLine(book2);

			// Solution 3: 

			var book3 = books.Aggregate((x, y) => x.Pages > y.Pages ? x : y);

			Console.WriteLine(book3);
		}
	}
}
