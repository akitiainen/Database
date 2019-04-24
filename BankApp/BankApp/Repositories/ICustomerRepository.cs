using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        List<Customer> ReadCustomers();
        Customer Read(long id);
        void UpdateCustomer(long id, Customer customer);
        void DeleteCustomer(long id);
    }
}
