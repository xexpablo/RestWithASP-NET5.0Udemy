using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api-{version:ApiVersion}/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        private IBookBusiness _bookBusiness;
        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }
        //------------------------------------------------------------------------------------------
        [HttpGet] // Pegar todos

        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }
        //------------------------------------------------------------------------------------------
        [HttpGet("{id}")] // Busca Individual

        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindByID(id);
            if (book == null) return NotFound("Não encontramos! Tente um ID valido");
            return Ok(book);
        }
        //------------------------------------------------------------------------------------------
        [HttpPost] // Criar Perfil Book

        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Create(book));
        }
        //------------------------------------------------------------------------------------------
        [HttpPut] // Atualizar Perfil Book

        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Update(book));
        }
        //------------------------------------------------------------------------------------------
        [HttpDelete("{id}")] // Deleta Perfil Book

        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
