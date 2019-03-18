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
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Update(long id, Person person)
        {
            throw new NotImplementedException();
        }
    }
}
