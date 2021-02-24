using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;
        //------------------------------------------------------------------------------------------- Buscar o Contexto dos Dados
        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        //------------------------------------------------------------------------------------------- Buscar ID Registrado
        public PersonVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }
        //------------------------------------------------------------------------------------------- Buscar Todos Registrados
        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }
        //------------------------------------------------------------------------------------------- Criar Novo Registro
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }
        //------------------------------------------------------------------------------------------- Atualizar Registro
        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
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
