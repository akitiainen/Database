using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class TransactionRepository : ITransactionRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();
        private static AccountRepository _accRepository = new AccountRepository();

        public void CreateTransaction(Transaction transaction)
        {
            _bankdbContext.Transaction.Add(transaction);
            var account = _accRepository.Read(transaction.Iban);
            account.Balance += transaction.Amount;

            _bankdbContext.Account.Update(account);
            _bankdbContext.SaveChanges();
        }

        public List<Transaction> ReadTransactions()
        {
            var transactions = _bankdbContext.Transaction.ToListAsync().Result;
            return transactions;
        }
    }
}
