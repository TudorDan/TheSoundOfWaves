using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.Models
{
    public interface IPersonRepository
    {
        Person GetPerson(int id);
        IEnumerable<Person> GetAllPersons();
        Person Add(Person person);
    }
}
