using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotThePattern3.TrueForEverything
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
		static void Main(string[] args)
		{
			List<Order> orders = new List<Order>()
				{
					new Order { Id = 123, Amount = 29.95m, CustomerName = "Mark", Status = "Delivered" },
					new Order { Id = 456, Amount = 45.00m, CustomerName = "Steph", Status = "Refunded" },
					new Order { Id = 768, Amount = 32.50m, CustomerName = "Claire", Status = "Delivered" },
				};

			// Objective1: check if any order was refunded, using a boolean flag;
			void CheckOrdersForRefunds()
			{
				bool anyRefunded = false;
				foreach (Order order in orders)
				{
					if (order.Status == "Refunded")
					{
						anyRefunded = true;
						break;
					}
				}
				if (anyRefunded)
					Console.WriteLine("There are refunded orders");
				else
					Console.WriteLine("No refunds");
			}

			// Objective2: check if all orders were delivered, using a boolean flag;
			void CheckOrdersAreDelivered()
			{
				bool allDelivered = true;
				foreach (Order order in orders)
				{
					if (order.Status != "Delivered")
					{
						allDelivered = false;
						break;
					}
				}
				if (allDelivered)
					Console.WriteLine("Everything was delivered");
				else
					Console.WriteLine("Not everything was delivered");
			}

			// Using LINQ:

			// Check if any order was refunded, using a boolean flag:
			void CheckOrdersForRefundsLinq()
			{
				string notification = orders.Any(o => o.Status == "Refunded")
					? "There are refunded orders"
					: "No refunds";
				Console.WriteLine(notification);
			}

			// Check if all orders were delivered, using a boolean flag:
			void CheckOrdersAreDeliveredLinq()
			{
				string notification = orders.All(o => o.Status == "Delivered")
					? "Everything was delivered"
					: "Not everything was delivered";
				Console.WriteLine(notification);
			}

			CheckOrdersForRefunds();
			CheckOrdersAreDelivered();
			Console.WriteLine("\n");
			CheckOrdersForRefundsLinq();
			CheckOrdersAreDeliveredLinq();
		}
	}
}
