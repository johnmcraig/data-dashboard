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

            if (!_context.Customers.Any())
            {
                SeedServers(nCustomers);
            }

            _context.SaveChanges();
        }
        private void SeedCustomers(int n)
        {
            List<Customer> customers = BuildCustomerList(n);

            foreach(var customer in customers)
            {
                _context.Customers.Add(customer);
            }
        }
        private List<Customer> BuildCustomerList(int nCustomers)
        {
            var customers = new List<Customer>();
            var names = new List<string>();
            
            //set primary key id and generate the properties in the db
            for( var i = 1; i<= nCustomers; i++)
            {
                // when we make a customer name, we pass it as a list of names
                var name = Helpers.MakeUniqueCustomerName(names);
                //brute force a list of names and states calling them recusively
                names.Add(name);
                
                customers.Add(new Customer {
                    Id = i,
                    Name = name,
                    Email = Helpers.MakeCustomerEmail(name),
                    State = Helpers.GetRandomState()
                });
            }
        }
    }
}
