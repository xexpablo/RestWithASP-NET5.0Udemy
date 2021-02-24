using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        //------------------------------------------------------------------------------------------- Buscar o Contexto dos Dados
        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        //------------------------------------------------------------------------------------------- Buscar ID Registrado
        public Book FindByID(long id)
        {
            return _repository.FindByID(id);
        }
        //------------------------------------------------------------------------------------------- Buscar Todos Registrados
        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }
        //------------------------------------------------------------------------------------------- Criar Novo Registro
        public Book Create(Book book)
        {
            return _repository.Create(book);
        }
        //------------------------------------------------------------------------------------------- Atualizar Registro
        public Book Update(Book book)
        {
            return _repository.Update(book);
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
