using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class BankRepository : IBankRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void CreateBank(Bank bank)
        {
            _bankdbContext.Bank.Add(bank);
            _bankdbContext.SaveChanges();
        }

        public void DeleteBank(long id)
        {
            var deletedBank = Read(id);
            if (deletedBank != null)
            {
                _bankdbContext.Bank.Remove(deletedBank);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti!");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut - ID tuntematon");
            }
        }

        public Bank Read(long id)
        {
            var bank = _bankdbContext.
                Bank.FirstOrDefault(b => b.Id == id);

            return bank;
        }

        public List<Bank> ReadBanks()
        {
            var banks = _bankdbContext.Bank.Include(b => b.Customer).ToList();
            return banks;
        }

        public void UpdateBank(long id, Bank bank)
        {
            var isBankOkay = Read(id);
            if (isBankOkay != null)
            {
                _bankdbContext.Update(bank);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti!");
            }
            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui - pankkia ei ole olemassa!");
            }
        }
    }
}
