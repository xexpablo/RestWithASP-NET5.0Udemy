using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySQLContext _context;
        //------------------------------------------------------------------------------------------- Buscar o Contexto dos Dados
        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }
        //------------------------------------------------------------------------------------------- Buscar ID Registrado
        public Person FindByID(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }
        //------------------------------------------------------------------------------------------- Buscar Todos Registrados
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }
        //------------------------------------------------------------------------------------------- Criar Novo Registro
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }
        //------------------------------------------------------------------------------------------- Atualizar Registro
        public Person Update(Person person)
        {
            if (!ExistsID(person.Id)) return null;

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
            return person;
        }
        //------------------------------------------------------------------------------------------- Deletar Registro
        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        //------------------------------------------------------------------------------------------- Confirmar a Existencia do ID
        public bool ExistsID(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
