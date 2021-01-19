using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api-{version:ApiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;
        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }
        //------------------------------------------------------------------------------------------
        [HttpGet] // Pegar todos

        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }
        //------------------------------------------------------------------------------------------
        [HttpGet("{id}")] // Busca Individual

        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);
            if (person == null) return NotFound("Não encontramos! Tente um ID valido");
            return Ok(person);
        }
        //------------------------------------------------------------------------------------------
        [HttpPost] // Criar Perfil Person

        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }
        //------------------------------------------------------------------------------------------
        [HttpPut] // Atualizar Perfil Person

        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }
        //------------------------------------------------------------------------------------------
        [HttpDelete("{id}")] // Deleta Perfil Person

        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
