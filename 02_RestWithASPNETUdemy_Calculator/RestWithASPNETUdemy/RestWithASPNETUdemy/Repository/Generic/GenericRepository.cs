using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> dataset;
        //------------------------------------------------------------------------------------------- Buscar o Contexto dos Dados
        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }
        //------------------------------------------------------------------------------------------- Criar Novo Registro
        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //------------------------------------------------------------------------------------------- Atualizar Registro
        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            } 
            else
            {
                return null;
            }
        }
        //------------------------------------------------------------------------------------------- Buscar Todos Registrados
        public List<T> FindAll()
        {
            return dataset.ToList();
        }
        //------------------------------------------------------------------------------------------- Buscar ID Registrado
        public T FindByID(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }
        //------------------------------------------------------------------------------------------- Deletar Registro
        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
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
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}
