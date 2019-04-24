using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using System.Linq;

namespace BankApp.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void CreateCustomer(Customer customer)
        {
            _bankdbContext.Customer.Add(customer);
            _bankdbContext.SaveChanges();
            Console.WriteLine("Asiakas lisätty tietokantaan");
        }

        public void DeleteCustomer(long id)
        {
            var deletedCustomer = Read(id);
            if (deletedCustomer != null)
            {
                _bankdbContext.Customer.Remove(deletedCustomer);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti!");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut - ID tuntematon");
            }
        }

        public Customer Read(long id)
        {
            var customer = _bankdbContext.Customer.FirstOrDefault(p => p.Id == id);
            return customer;
        }

        public List<Customer> ReadCustomers()
        {
            var customers = _bankdbContext.Customer.ToList();
            return customers;
        }

        public void UpdateCustomer(long id, Customer customer)
        {
            var isCustomerOkay = Read(id);
            if (isCustomerOkay != null)
            {
                _bankdbContext.Update(customer);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Tiedot päivitetty onnistuneesti!");
            }
            else
            {
                Console.WriteLine("Tietojen päivitys epäonnistui - asiakasta ei ole olemassa!");
            }
        }
    }
}
