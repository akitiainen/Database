using System;
using BankApp.Models;
using BankApp.Repositories;
using BankApp.Views;

namespace BankApp
{
    class Program
    {
        

        static private BankRepository _bankRepository = new BankRepository();
        static private CustomerRepository _customerRepository = new CustomerRepository();
        static private AccountRepository _accountRepository = new AccountRepository();
        static private TransactionRepository _trasactionsRepository = new TransactionRepository();

        static void Main(string[] args)
        {
            UIModelBank bankModel = new UIModelBank();
            UIModelCustomer customerModel = new UIModelCustomer();
            UIModelAccount accountModel = new UIModelAccount();

            ConsoleKeyInfo cki;
            do
            {
                string msg = "";
                cki = UserInterface();
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        bankModel.PrintBanks();
                        msg = "Paina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        PrintCustomers();
                        msg = "Paina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        PrintAccounts();
                        msg = "Paina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        bankModel.CreateBank();
                        msg = "Paina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        bankModel.UpdateBank();
                        msg = "Paina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D6:
                        Console.Clear();
                        customerModel.CreateCustomer();
                        accountModel.CreateAccount();
                        msg = "Paina Enter jatkaaksesi!";
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

        

        static void PrintCustomers()
        {
            var customers = _bankRepository.ReadBanks();

            foreach (var b in customers)
            {
                Console.WriteLine("Pankki:  " + b.Name + "  BIC:  " + b.Bic);
                Console.Write("Asiakkaat:  ");
                foreach (var customer in b.Customer)
                {
                    Console.Write(customer.Firstname + " " + customer.Lastname + ", ");
                }
                Console.WriteLine("\n_______________________\n");
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

            int i = 0;
            foreach (var a in accounts)
            {
                Console.WriteLine(a.Iban);
                Console.WriteLine("Saldo:  " + a.Balance);
                Console.Write("Tapahtumat:  ");
                foreach (var transaction in a.Transaction)
                {
                    i++;
                    Console.Write(transaction.Amount + ", ");
                }
                Console.WriteLine("\n________________________\n");
            }
        }

        static void PrintTransactions()
        {
            var transactions = _trasactionsRepository.ReadTransactions();

            foreach (var t in transactions)
            {
                Console.WriteLine($"IBAN: {t.Iban}  Amount: {t.Amount}");
            }
        }

        private static ConsoleKeyInfo UserInterface()
        {
            Console.WriteLine("Tietokantaohjelmointitehtävä 1!\n");
            Console.WriteLine("[1] Tulosta pankit");
            Console.WriteLine("[2] Tulosta henkilöt");
            Console.WriteLine("[3] Tulosta kaikki tilit");
            Console.WriteLine("[4] Luo uusi pankki");
            Console.WriteLine("[5] Päivitä pankin tiedot");
            Console.WriteLine("[6] Lisää asiakas ja hänelle tili");
            Console.WriteLine("[ESC] Lopeta ohjelmansuoritus");

            return Console.ReadKey();
        }
    }
}
