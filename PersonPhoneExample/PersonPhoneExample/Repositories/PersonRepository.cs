using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonPhoneExample.Models;

namespace PersonPhoneExample.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _personContext = new PersonContext();

        public void Create(Person person)
        {
            _personContext.Person.Add(person);
            _personContext.SaveChanges();
            Console.WriteLine("Henkilö lisätty tietokantaan!");
        }

        public void Delete(long id)
        {
            var deletedPerson = Read(id);
            if (deletedPerson != null)
            {
                _personContext.Person.Remove(deletedPerson);
                _personContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti!");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut - ID tuntematon");
            }
        }

        public List<Person> Read()
        {

            var persons = _personContext.Person
                .Include(p=>p.Phone)
                .ToList();
            return persons;
        }

        public Person Read(long id)
        {
            var person = _personContext.
                Person
                .Include(p => p.Phone)
                .FirstOrDefault(p => p.Id == id);

            return person;
        }

        public void Update(long id, Person person)
        {
            var isPersonAlive = Read(id);
            if (isPersonAlive != null)
            {
                _personContext.Update(person);
                _personContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti!");
            }
            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui - henkilöä ei ole olemassa!");
            }
        }
    }
}
