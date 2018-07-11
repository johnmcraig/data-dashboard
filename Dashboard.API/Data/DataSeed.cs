using System;
using System.Collections.Generic;
using System.Linq;
using Dashboard.API.Data;
using Dashboard.API.Models;

namespace Dashboard.API
{
    public class DataSeed
    {
        private readonly ApiContext _context;
        public DataSeed(ApiContext context)
        {
            _context = context;
        }
        public void SeeData(int nCustomers, int nOrders)
        {
            if (!_context.Customers.Any())
            {
                SeedCustomers(nCustomers);
            }

            if (!_context.Customers.Any())
            {
                SeedOrders(nOrders);
            }

            if (!_context.Servers.Any())
            {
                SeedServers();
            }

            _context.SaveChanges();
        }
        private void SeedCustomers(int n)
        {
            List<Customer> customers = BuildCustomerList(n);

            foreach (var customer in customers)
            {
                _context.Customers.Add(customer);
            }
        }
        private void SeedOrders(int n)
        {
            List<Order> orders = BuildOrderList(n);

            foreach (var order in orders)
            {
                _context.Orders.Add(order);
            }
        }
        private void SeedServers()
        {
            List<Server> servers = BuildServerList();

            foreach (var server in servers)
            {
                _context.Servers.Add(server);
            }
        }
        private List<Customer> BuildCustomerList(int nCustomers)
        {
            var customers = new List<Customer>();
            var names = new List<string>();

            //set primary key id and generate the properties in the db
            for (var i = 1; i <= nCustomers; i++)
            {
                // when we make a customer name, we pass it as a list of names
                var name = Helpers.MakeUniqueCustomerName(names);
                //brute force a list of names and states calling them recusively
                names.Add(name);

                customers.Add(new Customer
                {
                    Id = i,
                    Name = name,
                    Email = Helpers.MakeCustomerEmail(name),
                    State = Helpers.GetRandomState()
                });
            }

            return customers;
        }
        private List<Order> BuildOrderList(int nOrders)
        {
            var orders = new List<Order>();
            var rand = new Random();

            for (var i = 1; i <= nOrders; i++)
            {
                var randCustomerId = rand.Next(_context.Customers.Count());
                var placed = Helpers.GetRandomOrderPlaced();
                var completed = Helpers.GetRandomOrderCompleted(placed); //completed only happens when an order was already placed

                orders.Add(new Order
                {
                    Id = 1,
                    Customer = _context.Customers.First(c => c.Id == randCustomerId),
                    Total = Helpers.GetRandomOrderTotal(),
                    Placed = placed,
                    Completed = completed
                });
            }

            return orders;
        }

        private List<Server> BuildServerList()
        {
            var servers = new List<Server>()
            {
                new Server
                {
                    Id = 1,
                    Name = "Dev-Web",
                    IsOnline = true
                },
                new Server
                {
                    Id = 2,
                    Name = "Dev-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Id = 3,
                    Name = "Dev-Services",
                    IsOnline = true
                },
                new Server
                {
                    Id = 4,
                    Name = "QA-Web",
                    IsOnline = true
                },
                new Server
                {
                    Id = 5,
                    Name = "QA-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Id = 6,
                    Name = "QA-Services",
                    IsOnline = true
                },
                new Server
                {
                    Id = 7,
                    Name = "Prod-Web",
                    IsOnline = true
                },
                new Server
                {
                    Id = 8,
                    Name = "Prod-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Id = 9,
                    Name = "Prod-Services",
                    IsOnline = true
                },
            };

            return servers;
        }
    }
}
