using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;
        //------------------------------------------------------------------------------------------- Buscar o Contexto dos Dados
        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        //------------------------------------------------------------------------------------------- Buscar ID Registrado
        public BookVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }
        //------------------------------------------------------------------------------------------- Buscar Todos Registrados
        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }
        //------------------------------------------------------------------------------------------- Criar Novo Registro
        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }
        //------------------------------------------------------------------------------------------- Atualizar Registro
        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
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
