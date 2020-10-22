using E_LearningSite.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningSite.API.InMemoryDatabase
{
    public class InMemoryPersonDatabase : IPersonRepository
    {
        private readonly List<Person> _personDatabase;

        public InMemoryPersonDatabase()
        {
            _personDatabase = new List<Person>();
        }

        public Person Add(Person person)
        {
            person.Id = _personDatabase.Max(s => s.Id) + 1;
            _personDatabase.Add(person);
            return person;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _personDatabase;
        }

        public Person GetPerson(int id)
        {
            return _personDatabase.FirstOrDefault(p => p.Id == id);
        }
    }
}
