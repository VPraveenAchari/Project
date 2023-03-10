using CustomerWebApplication.Models;
using System.Collections.Generic;

namespace CustomerWebApplication.Interfaces
{
    public interface ICustomersData
    {
        List<Customers> GetCustomers();

        public Customers CreateCustomer(Customers customer);
    }
}
