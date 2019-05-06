using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.Views
{
    class UIModel
    {
        private static readonly BankRepository _bankRepository = new BankRepository();
        private static readonly CustomerRepository _customerRepository = new CustomerRepository();
        private static readonly AccountRepository _accountRepository = new AccountRepository();
        private static readonly TransactionRepository _trasactionsRepository = new TransactionRepository();

        public void CreateBank()
        {
            Bank bank = new Bank
            {
                Name = "Danske Bank",
                Bic = "DABAFIHH"
            };

            _bankRepository.CreateBank(bank);
        }

        public void DeleteBank(long id)
        {
            _bankRepository.DeleteBank(id);
        }

        public void UpdateBank()
        {
            long id;
            Console.WriteLine("Syötä sen pankin, jonka tiedot haluat päivittää, ID:");
            while(!long.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Väärä syöte, kirjoita numero!");
            }
            Bank updateBank = _bankRepository.Read(id);
            updateBank.Name = "Nordea";
            updateBank.Bic = "NDEAFIHH";
            _bankRepository.UpdateBank(id, updateBank);
        }
    }
}
