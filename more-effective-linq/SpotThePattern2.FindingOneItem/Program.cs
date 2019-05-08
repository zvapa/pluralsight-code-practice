using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotThePattern2.FindingOneItem
{
	class Order
	{
		public int Id { get; set; }
		public decimal Amount { get; set; }
		public string CustomerName { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<Order> orders = new List<Order>()
			{
				new Order { Id = 123, Amount = 29.95m, CustomerName = "Mark" },
				new Order { Id = 456, Amount = 45.00m, CustomerName = "Steph" },
				new Order { Id = 768, Amount = 32.50m, CustomerName = "Claire" },
			};

			// Objective: loop through the orders to search for specific order to refund

			void RefundOrder(int orderId)
			{
				Order orderToRefund = null;
				foreach (Order order in orders)
				{
					if (order.Id == orderId)
					{
						orderToRefund = order;
						break;
					}
				}
				Console.WriteLine("Refunding {0} to {1}",
					orderToRefund.Amount,
					orderToRefund.CustomerName);
			}

			// LINQ solution:

			void RefundOrderLinq(int orderId)
			{
				Order orderToRefund = orders.FirstOrDefault(o => o.Id == orderId);
				var notification = orderToRefund != null
					? $"Refunding {orderToRefund.Amount} to {orderToRefund.CustomerName}"
					: $"No order found";
				Console.WriteLine(notification);
			}

			RefundOrder(456);
			RefundOrderLinq(999);
		}
	}
}
