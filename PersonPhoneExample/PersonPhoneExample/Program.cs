using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonPhoneExample.Models;
using PersonPhoneExample.Repositories;

namespace PersonPhoneExample
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonRepository personRepository = new PersonRepository();

            Person newPerson = new Person
            {
                Name = "Jack Bauer",
                Age = 45,
                Phone = new List<Phone>
                {
                    new Phone {Number = "0501235423", Type = "Koti"},
                    new Phone {Number = "020202", Type = "Työ"}
                }
            };

            ConsoleKeyInfo cki;
            do
            {
                cki = UserInterface();
                switch (cki.Key)
                {
                    case ConsoleKey.C:
                        Console.Clear();
                        personRepository.Create(newPerson);
                        break;

                    case ConsoleKey.R:
                        Console.Clear();
                        Console.WriteLine(personRepository.Read(UserInputId()));
                        break;

                    case ConsoleKey.U:
                        Console.Clear();
                        personRepository.Update(UserInputId(), newPerson);
                        break;

                    case ConsoleKey.D:
                        Console.Clear();
                        personRepository.Delete(UserInputId());
                        break;

                    case ConsoleKey.X:
                        Console.Clear();
                        Console.WriteLine("Ohjelma sulkeutuu, kiitti ku käytit.");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Väärä syöte");
                        break;
                }
                Console.WriteLine("");
            } while (cki.Key != ConsoleKey.X);


        }

        private static ConsoleKeyInfo UserInterface()
        {
            Console.WriteLine("Tietokantaohjelmointitehtävä 1!\n");
            Console.WriteLine("[C] Lisää tietokantaan uusi tietue");
            Console.WriteLine("[R] Lue tietokannasta tietoja");
            Console.WriteLine("[U] Päivitä henkilön tiedot");
            Console.WriteLine("[D] Poista henkilö tietokannasta");
            Console.WriteLine("[X] Lopeta ohjelmansuoritus");

            return Console.ReadKey();
        }

        private static long UserInputId()
        {
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
