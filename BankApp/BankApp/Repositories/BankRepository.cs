using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;
using System.Linq;

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

        public void DeleteBank()
        {
            throw new NotImplementedException();
        }

        public List<Bank> ReadBank()
        {
            var banks = _bankdbContext.Bank.ToList();
            return banks;
        }

        public void UpdateBank()
        {
            throw new NotImplementedException();
        }
    }
}
