using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotThePattern5.HowManyLikeThis
{
	class Order
	{
		public int Id { get; set; }
		public decimal Amount { get; set; }
		public string CustomerName { get; set; }
		public string Status { get; set; }
	}

	class Program
	{
		static List<Order> orders = new List<Order>()
		{
			new Order { Id = 123, Amount = 29.95m, CustomerName = "Mark", Status = "Delivered" },
			new Order { Id = 456, Amount = 45.00m, CustomerName = "Steph", Status = "Refunded" },
			new Order { Id = 768, Amount = 32.50m, CustomerName = "Claire", Status = "Delivered" },
		};

		// Objective 1: count the orders that have been refunded
		static int CountRefundedOrders()
		{
			int refundedCount = 0;
			foreach (var order in orders)
			{
				if (order.Status == "Refunded")
					refundedCount++;
			}
			return refundedCount;
		}

		// Objective 2: calculating the total value of all the orders in the collection
		static decimal GetOrderTotal()
		{
			decimal total = 0;
			foreach (var order in orders)
			{
				total += order.Amount;
			}
			return total;
		}

		// Using LINQ:
		// Objective 1: count the orders that have been refunded
		static int CountRefundedOrdersLinq() => orders.Count(o => o.Status == "Refunded");

		// Objective 2: calculating the total value of all the orders in the collection
		static decimal GetOrderTotalLinq() => orders.Select(o => o.Amount).Sum();

		// or
		static decimal GetOrderTotalLinq2() => orders.Sum(o => o.Amount);

		static void Main(string[] args)
		{
			Console.WriteLine("Refunded Orders: " + CountRefundedOrders());
			Console.WriteLine("Order Total: " + GetOrderTotal());
			Console.WriteLine("\nUsing LINQ:\n");
			Console.WriteLine("Refunded Orders LINQ: " + CountRefundedOrdersLinq());
			Console.WriteLine("Order Total LINQ: " + GetOrderTotalLinq());
		}
	}
}
