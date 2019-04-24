using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface IBankRepository
    {
        void CreateBank(Bank bank);
        List<Bank> ReadBanks();
        Bank Read(long id);
        void UpdateBank(long id, Bank bank);
        void DeleteBank(long id);
    }
}
