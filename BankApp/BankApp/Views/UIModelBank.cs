using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.Views
{
    class UIModelBank
    {
        private static readonly BankRepository _bankRepository = new BankRepository();
        
        
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
            updateBank.Name = "S-Pankki";
            updateBank.Bic = "SBANFIHH";
            _bankRepository.UpdateBank(id, updateBank);
        }

        public void PrintBanks()
        {
            var banks = _bankRepository.ReadBanks();

            foreach (var b in banks)
            {
                Console.WriteLine("Pankki:  " + b.Name.PadRight(15) + "  BIC:  " + b.Bic);
            }
        }
    }
}
