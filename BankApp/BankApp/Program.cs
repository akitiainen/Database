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
            Console.OutputEncoding = System.Text.Encoding.UTF8;

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
                        bankModel.CreateBank();
                        msg = "Paina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        bankModel.UpdateBank();
                        msg = "Paina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        customerModel.PrintCustomers();
                        msg = "Paina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        customerModel.CreateCustomer();
                        accountModel.CreateAccount();
                        msg = "Paina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D6:
                        Console.Clear();
                        customerModel.UpdateCustomer();
                        msg = "Paina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D7:
                        Console.Clear();
                        customerModel.DeleteCustomer();
                        msg = "Paina enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D8:
                        Console.Clear();
                        accountModel.PrintAccounts();
                        msg = "Paina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D9:
                        Console.Clear();
                        accountModel.DeleteAccount();
                        msg = "Paina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D0:
                        Console.Clear();
                        accountModel.CreateTransaction();
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

        public static long UserInput()
        {
            long id;
            Console.Write("Anna sen henkilön, jonka tilit haluat tulostaa, ID: ");
            while (!long.TryParse(Console.ReadLine(), out id))
            {
                Console.Clear();
                Console.WriteLine("Virheellinen syöte, syötä numeroita!");
                Console.Write("Anna sen henkilön, jonka tilit haluat tulostaa, ID: ");
            }
            return id;
        }

        private static ConsoleKeyInfo UserInterface()
        {
            Console.WriteLine("PANKKIOHJELMA\n");
            Console.WriteLine("Pankkien toiminnot");
            Console.WriteLine("[1] Tulosta pankit");
            Console.WriteLine("[2] Luo uusi pankki");
            Console.WriteLine("[3] Päivitä pankin tiedot");
            Console.WriteLine("Asiakkaiden toiminnot");
            Console.WriteLine("[4] Tulosta asiakkaat");
            Console.WriteLine("[5] Lisää asiakas ja hänelle tili");
            Console.WriteLine("[6] Päivitä asiakkaan tiedot");
            Console.WriteLine("[7] Poista asiakkaan tiedot");
            Console.WriteLine("Tilien tominnot");
            Console.WriteLine("[8] Tulosta asiakkaan tilit ja tapahtumat");
            Console.WriteLine("[9] Poista asiakkaan tili");
            Console.WriteLine("[0] Lisää tapahtuma tilille");
            Console.WriteLine("[ESC] Lopeta ohjelmansuoritus");

            return Console.ReadKey();
        }
    }
}
