using BankApp.Models;
using BankApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace BankApp.Views
{
    class UIModelAccount
    {
        private static readonly AccountRepository _accountRepository = new AccountRepository();
        private static readonly CustomerRepository _customerRepository = new CustomerRepository();
        private static readonly TransactionRepository _transactionRepository = new TransactionRepository();

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

        public void PrintAccounts()
        {
            var accounts = _accountRepository.ReadAccounts(customer);
            foreach (var a in accounts)
            {
                Console.WriteLine("Iban:  " + a.Iban);
                Console.WriteLine("Saldo:  " + a.Balance.ToString("c", CultureInfo.CurrentCulture));
                Console.Write("Tapahtumat:  ");
                foreach (var t in a.Transaction)
                {
                    Console.WriteLine(t.TimeStamp + " " + t.Amount.ToString("C", CultureInfo.CurrentCulture));
                }
                Console.WriteLine("\n___________________________\n");
            }
        }

        public void CreateTransaction()
        {
            Transaction transaction = new Transaction()
            {
                Amount = 35.25M,
                Iban = "FI5912341234123412"
            };

            _transactionRepository.CreateTransaction(transaction);
        }
    }
}
