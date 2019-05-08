using BankApp.Models;
using BankApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp.Views
{
    class UIModelAccount
    {
        private static readonly AccountRepository _accountRepository = new AccountRepository();
        private static readonly CustomerRepository _customerRepository = new CustomerRepository();

        Customer customer = _customerRepository.ReadCustomers().FirstOrDefault(name => name.Firstname == "Katto");

        public void CreateAccount()
        {
            Account account = new Account()
            {
                Iban = "FI5912341234123412",
                BankId = 3,
                CustomerId = customer.Id,
                Balance = 12000
            };

            _accountRepository.CreateAccount(account);
        }
        
        public void DeleteAccount()
        {
            _accountRepository.DeleteAccount("FI5912341234123412");
        }
    }
}
