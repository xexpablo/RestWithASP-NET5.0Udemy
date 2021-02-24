using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api-{version:ApiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private IPersonBusiness _personBusiness;
        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }
        //------------------------------------------------------------------------------------------
        [HttpGet] // Pegar todos

        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }
        //------------------------------------------------------------------------------------------
        [HttpGet("{id}")] // Busca Individual

        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindByID(id);
            if (person == null) return NotFound("Não encontramos! Tente um ID valido");
            return Ok(person);
        }
        //------------------------------------------------------------------------------------------
        [HttpPost] // Criar Perfil PersonVO

        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }
        //------------------------------------------------------------------------------------------
        [HttpPut] // Atualizar Perfil PersonVO

        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }
        //------------------------------------------------------------------------------------------
        [HttpDelete("{id}")] // Deleta Perfil PersonVO

        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
