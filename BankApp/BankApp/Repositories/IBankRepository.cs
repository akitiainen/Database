using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface IBankRepository
    {
        void CreateBank(Bank bank);
        List<Bank> ReadBank();
        void UpdateBank();
        void DeleteBank();
    }
}
