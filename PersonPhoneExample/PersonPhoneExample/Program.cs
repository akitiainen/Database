using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonPhoneExample.Models;
using PersonPhoneExample.Repositories;
using PersonPhoneExample.Views;

namespace PersonPhoneExample
{
    class Program
    {
        static void Main(string[] args)
        {
            UIModel uiModel = new UIModel();

            string msg = "";
            ConsoleKeyInfo cki;
            do
            {
                cki = UserInterface();
                switch (cki.Key)
                {
                    case ConsoleKey.C:
                        Console.Clear();
                        uiModel.CreatePerson();
                        msg = "_________________________________\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.R:
                        Console.Clear();
                        uiModel.ReadById(UserInputId());
                        msg = "_________________________________\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.E:
                        Console.Clear();
                        uiModel.ReadList();
                        msg = "_________________________________\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.U:
                        Console.Clear();
                        uiModel.UpdatePerson();
                        msg = "_________________________________\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.D:
                        Console.Clear();
                        uiModel.DeletePerson(UserInputId());
                        msg = "_________________________________\nPaina Enter jatkaaksesi!";
                        break;

                    case ConsoleKey.X:
                        Console.Clear();
                        msg = "Ohjelma sulkeutuu, kiitti ku käytit.";
                        break;

                    default:
                        Console.Clear();
                        msg = "Painoit väärää nappulaa - Paina Enter jatkaaksesi!";
                        break;
                }
                Console.WriteLine(msg);
                Console.ReadKey();
                Console.Clear();
            } while (cki.Key != ConsoleKey.X);


        }

        private static ConsoleKeyInfo UserInterface()
        {
            Console.WriteLine("Tietokantaohjelmointitehtävä 1!\n");
            Console.WriteLine("[C] Lisää tietokantaan uusi tietue");
            Console.WriteLine("[R] Lue tietokannasta tietoja");
            Console.WriteLine("[E] Tulosta kaikki henkilöt ja numerot");
            Console.WriteLine("[U] Päivitä henkilön tiedot");
            Console.WriteLine("[D] Poista henkilö tietokannasta");
            Console.WriteLine("[X] Lopeta ohjelmansuoritus");

            return Console.ReadKey();
        }

        public static long UserInputId()
        {
            Console.WriteLine("Syötä ID:");
            while (true)
            {
                if (long.TryParse(Console.ReadLine(), out long id))
                {
                    return id;
                }
                
                Console.WriteLine("Nyt kävi niin, että siun kirjottama luku ei ollukkaa numero!");
            }
        }
    }
}
