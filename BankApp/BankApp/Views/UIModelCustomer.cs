using BankApp.Models;
using BankApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Views
{
    class UIModelCustomer
    {
        private static readonly CustomerRepository _customerRepository = new CustomerRepository();

        public void CreateCustomer()
        {
            Customer customer = new Customer()
            {
                Firstname = "Katto",
                Lastname = "Kassinen",
                BankId = 3
            };

            _customerRepository.CreateCustomer(customer);
        }
    }
}
