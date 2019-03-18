using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonPhoneExample.Models;

namespace PersonPhoneExample.Repositories
{
    public interface IPersonRepository
    {
        //CRUD
        void Create(Person person);

        List<Person> Read();
        Person Read(long id);

        void Update(long id, Person person);

        void Delete(long id);
    }
}
