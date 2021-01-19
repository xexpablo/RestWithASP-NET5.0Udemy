﻿using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public Person Update(Person person)
        {
            return person;
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Pablo",
                LastName = "Caun",
                Address = "São Paulo",
                Gender = "Male"
            };
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person First Name " + i,
                LastName = "Person Last Name " + i,
                Address = "Country, City " + i,
                Gender = "Male"
             };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        
    }
}
