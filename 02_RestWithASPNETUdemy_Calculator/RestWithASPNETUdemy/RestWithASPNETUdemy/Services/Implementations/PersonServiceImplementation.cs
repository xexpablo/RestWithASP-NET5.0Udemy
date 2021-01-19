﻿using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;
        //------------------------------------------------------------------------------------------- Buscar o Contexto dos Dados
        public PersonServiceImplementation(MySQLContext context)
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
            if (!Exists(person.Id)) return new Person();

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
        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

    }
}
