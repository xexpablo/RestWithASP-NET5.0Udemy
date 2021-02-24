using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        //------------------------------------------------------------------------------------------- Buscar o Contexto dos Dados
        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
        }
        //------------------------------------------------------------------------------------------- Buscar ID Registrado
        public Person FindByID(long id)
        {
            return _repository.FindByID(id);
        }
        //------------------------------------------------------------------------------------------- Buscar Todos Registrados
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
        //------------------------------------------------------------------------------------------- Criar Novo Registro
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }
        //------------------------------------------------------------------------------------------- Atualizar Registro
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
        //------------------------------------------------------------------------------------------- Deletar Registro
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        //------------------------------------------------------------------------------------------- Confirmar a Existencia do ID
        private bool Exists(long id)
        {
            return _repository.ExistsID(id);
        }

    }
}
