using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotThePattern6.GroupingThings
{
	class Order
	{
		public int Id { get; set; }
		public decimal Amount { get; set; }
		public string CustomerId { get; set; }
		public string Status { get; set; }

		public override string ToString() =>
			$"(Id: {this.Id}, Amount: {this.Amount}, CustomerId: {this.CustomerId}, Status: {this.Status})";
	}

	class Program
	{
		static List<Order> orders = new List<Order>()
		{
		new Order { Id = 123, Amount = 29.95m, CustomerId = "Mark", Status = "Delivered" },
		new Order { Id = 456, Amount = 45.00m, CustomerId = "Steph", Status = "Refunded" },
		new Order { Id = 768, Amount = 32.50m, CustomerId = "Claire", Status = "Delivered" },
		new Order { Id = 222, Amount = 300.00m, CustomerId = "Mark", Status = "Delivered" },
		new Order { Id = 333, Amount = 465.00m, CustomerId = "Steph", Status = "Awaiting Stock" },
		};

		// Objective: populate dictionary with lists of all the orders by customer
		static Dictionary<string, List<Order>> OrdersByCustomer()
		{
			Dictionary<string, List<Order>> dict = new Dictionary<string, List<Order>>();
			foreach (Order order in orders)
			{
				if (!dict.ContainsKey(order.CustomerId))
				{
					dict[order.CustomerId] = new List<Order>();
				}
				dict[order.CustomerId].Add(order);
			}
			return dict;
		}

		// Using LINQ:
		static Dictionary<string, List<Order>> OrdersByCustomerLinq() =>
			orders.GroupBy(o => o.CustomerId).ToDictionary(g => g.Key, g => g.ToList());

		static void Main(string[] args)
		{
			OrdersByCustomer().ToList()
				.ForEach(kvp => Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}"));

			Console.WriteLine("\nNow using linq:\n");


			OrdersByCustomerLinq().ToList()
				.ForEach(kvp => Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}"));
		}
	}
}
