using BankApp.Models;
using BankApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp.Views
{
    class UIModelCustomer
    {
        private static readonly CustomerRepository _customerRepository = new CustomerRepository();
        private static readonly BankRepository _bankRepository = new BankRepository();

        public void CreateCustomer()
        {
            Customer customer = new Customer()
            {
                Firstname = "Katto",
                Lastname = "Kassinen",
                BankId = 4
            };

            _customerRepository.CreateCustomer(customer);
        }

        public void UpdateCustomer()
        {
            var customer = _customerRepository.ReadCustomers().FirstOrDefault(name => name.Firstname == "Katto");
            customer.Firstname = "Katto";
            customer.Lastname = "Katala";

            _customerRepository.UpdateCustomer(customer.Id, customer);
        }

        public void DeleteCustomer()
        {
            var customer = _customerRepository.ReadCustomers().FirstOrDefault(name => name.Firstname == "Katto");
            _customerRepository.DeleteCustomer(customer.Id);
        }

        public void PrintCustomers()
        {
            var customers = _bankRepository.ReadBanks();

            foreach (var b in customers)
            {
                Console.WriteLine("Pankki:  " + b.Name + "  BIC:  " + b.Bic);
                Console.Write("Asiakkaat:  ");
                foreach (var customer in b.Customer)
                {
                    Console.Write(customer.Firstname + " " + customer.Lastname + ", ");
                }
                Console.WriteLine("\n_______________________\n");
            }
        }
    }
}
