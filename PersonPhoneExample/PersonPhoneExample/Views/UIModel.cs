using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonPhoneExample.Models;
using PersonPhoneExample.Repositories;

namespace PersonPhoneExample.Views
{
    class UIModel
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();

        public void CreatePerson()
        {
            Person person = new Person
            {
                Name = "Tero",
                Age = 25,
                Phone = new List<Phone>
                {
                    new Phone {Number = "0501400300", Type = "Koti"},
                    new Phone {Number = "12 kaljaa", Type = "Työ"}
                }
            };

            _personRepository.Create(person);
        }

        public void UpdatePerson()
        {
            Console.WriteLine("Syötä sen henkilön ID, jonka tiedot haluat päivittää:");
            string id = Console.ReadLine();
            Person updatePerson = _personRepository.Read(long.Parse(id));
            updatePerson.Name = "Turo";
            updatePerson.Age = 35;
            updatePerson.Phone = new List<Phone>
            {
                new Phone {Number = "0200123456", Type = "Koti"}
            };
        }

        public void DeletePerson(long id)
        {
            ReadById(id);
            _personRepository.Delete(id);
            ReadById(id);
        }

        public void ReadById(long id)
        {
            var person = _personRepository.Read(id);

            if (person == null)
                Console.WriteLine($"Henkilöä numerolla {id} ei löydy!");
            else
                Console.WriteLine($"{person.Id} {person.Name} {person.Phone}");
        }

        public void ReadList()
        {
            var persons = _personRepository.Read();

            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Id} {p.Name} {p.Phone}");
            }
        }
    }
}
