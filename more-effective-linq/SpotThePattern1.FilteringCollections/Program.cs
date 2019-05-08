using System;
using System.Linq;

namespace SpotThePattern1.FilteringCollections
{
	class Program
	{
		static void Main(string[] args)
		{
			var customers = new[]
			{
				new{Name = "Annie", Email = "annie@test.com"},
				new{Name = "Ben", Email = ""},
				new{Name = "Lily", Email = "lily@test.com"},
				new{Name = "Joel", Email = "joel@test.com"},
				new{Name = "Sam", Email = ""},
			};

			// Objective: loop through all the customers and only email the ones with a valid email

			// what LINQ method can help here?

			foreach (var customer in customers)
			{
				if (!string.IsNullOrEmpty(customer.Email))
				{
					Console.WriteLine("Sending email to {0}", customer.Name);
				}
			}

			// LINQ solution 1:

			customers.Where(c => !string.IsNullOrEmpty(c.Email))
				.ToList()
				.ForEach(c =>
					{
						Console.WriteLine($"Sending another email to {c.Name}");
					});

			// LINQ solution 2:

			foreach (var customer in customers.Where(c => !string.IsNullOrEmpty(c.Email)))
			{
				Console.WriteLine($"Sending yet another email to {customer.Name}");
			}

			// LINQ solution 2 - query syntax:

			foreach (var customer in 
				from c in customers
				where !string.IsNullOrEmpty(c.Email)
				select c)
			{
				Console.WriteLine($"Sending more email to {customer.Name}");
			}

		}
	}
}
