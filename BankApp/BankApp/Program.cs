using System;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp
{
    class Program
    {
        static private BankRepository _bankRepository = new BankRepository();
        static void Main(string[] args)
        {
            PrintBanks();
        }

        static void PrintBanks()
        {
            var banks = _bankRepository.ReadBank();

            foreach(var b in banks)
            {
                Console.WriteLine(b.Name);
            }
        }
    }
}
