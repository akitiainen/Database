using System;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp
{
    class Program
    {
        static private BankRepository _bankRepository = new BankRepository();
        static private CustomerRepository _customerRepository = new CustomerRepository();
        static private AccountRepository _accountRepository = new AccountRepository();

        static void Main(string[] args)
        {
            
            ConsoleKeyInfo cki;
            do
            {
                string msg = "";
                cki = UserInterface();
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        PrintBanks();
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        PrintCustomers();
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        PrintAccounts();
                        break;

                    case ConsoleKey.Escape:
                        msg = "Ohjelma sulkeutuu, kiitti ku käytit.";
                        break;

                    default:
                        Console.Clear();
                        msg = "Painoit väärää nappulaa - paina Enter jatkaaksesi!";
                        break;
                }
                Console.WriteLine(msg);
                Console.ReadKey();
                Console.Clear();
            } while (cki.Key != ConsoleKey.Escape);
        }

        static void PrintBanks()
        {
            var banks = _bankRepository.ReadBanks();

            foreach(var b in banks)
            {
                Console.WriteLine(b.Name);
            }
        }

        static void PrintCustomers()
        {
            var customers = _customerRepository.ReadCustomers();

            foreach (var c in customers)
            {
                Console.WriteLine(c.Firstname + " " + c.Lastname);
            }
        }

        static void PrintAccounts()
        {
            long id;
            Console.WriteLine("Anna sen pankin, jonka tilit haluat tulostaa, ID");
            while (!long.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Yritäpä uusiks ja laita numeroita");
            }

            var accounts = _accountRepository.ReadAccounts(_bankRepository.Read(id));

            foreach (var a in accounts)
            {
                Console.WriteLine(a.Iban);
            }
        }

        private static ConsoleKeyInfo UserInterface()
        {
            Console.WriteLine("Tietokantaohjelmointitehtävä 1!\n");
            Console.WriteLine("[1] Tulosta pankit");
            Console.WriteLine("[2] Tulosta henkilöt");
            Console.WriteLine("[3] Tuosta kaikki tilit");
            Console.WriteLine("[4] ");
            Console.WriteLine("[5] ");
            Console.WriteLine("[ESC] Lopeta ohjelmansuoritus");

            return Console.ReadKey();
        }
    }
}
