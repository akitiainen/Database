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

            Person newPerson = new Person();
            newPerson.Name = "Pöllö Peloton";
            newPerson.Age = 69;
            newPerson.Phone = new List<Phone>
            {
                new Phone {Number = "ÖÖÖÖÖÖÖ", Type = "Kotipuhelin"},
                new Phone {Number = "010101", Type = "Työ"}
            };

            personRepository.Create(newPerson);
            personRepository.Read();
        }
    }
}
