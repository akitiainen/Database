using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface IAccountRepository
    {
        void CreateAccount(Account account);
        List<Account> ReadAccounts(Customer customer);
        Account Read(string iban);
        void DeleteAccount(string iban);
    }
}
