using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerWebApplication.Context;
using CustomerWebApplication.Interfaces;
using CustomerWebApplication.Models;

namespace CustomerWebApplication.Services
{
    public class CustomersService : ICustomersData
    {
        private DBContext _customerContext;
        public CustomersService(DBContext customerContext)
        {
            _customerContext = customerContext;
        }

        public Customers CreateCustomer(Customers customer)
        {
            customer.UpdatedAt = DateTime.Now;
            customer.CreatedAt = DateTime.Now;
            _customerContext.Customers.Add(customer);
            _customerContext.SaveChanges();
            return customer;
        }

        public List<Customers> GetCustomers()
        {
            List<Customers> list = new();
            list=_customerContext.Customers.ToList();
            return list;
        }
    }
}
