using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface ITransactionRepository
    {
        void CreateTransaction(Transaction transaction);
        List<Transaction> ReadTransactions();
    }
}
