using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Context;
using DAL.Entities;


namespace Example
{
    public class SomeService
    {
        public void DoSmth()
        {
            using (var context = new AppDbContext())
            {
                var customers = context.Customers
                    .Include(c => c.Orders.Select(o => o.OrderItems.Select(oi => oi.Item)))
                    .ToList();

                PrintCustomers(customers);
            }
        }

        private void PrintCustomers(List<Customer> customers)
        {
            Console.WriteLine($"Customers number {customers.Count}{Environment.NewLine}");

            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer: {customer.Id} - {customer.Name} - {customer.Address} - {customer.City} - {customer.State}");
                Console.WriteLine("His orders:");

                PrintOrders(customer.Orders.ToList());
                Console.WriteLine();
            }
        }

        private void PrintOrders(List<Order> orders)
        {
            Console.WriteLine($"Orders number: {orders.Count}");

            foreach (var order in orders)
            {
                Console.WriteLine($"Order: {order.Id} - {order.Date}");
                Console.WriteLine("Order items:");

                PrintItems(order.OrderItems.ToList());
            }
        }

        private void PrintItems(List<OrderItem> orderItems)
        {
            Console.WriteLine($"Items number: {orderItems.Count}");

            foreach (var orderItem in orderItems)
            {
                Console.WriteLine($"Order item: {orderItem.Item.Description} - {orderItem.Item.Price} - {orderItem.Quantity} items");
            }
        }
    }
}