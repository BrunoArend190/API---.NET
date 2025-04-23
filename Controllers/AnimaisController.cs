using APIanimais.DataBase;
using APIanimais.DataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIanimais.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimaisController : ControllerBase
    {
        private readonly DBContext _dbContext;

        public AnimaisController(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("listar")]
        public ActionResult ListarTodos()
        {
            var animais = _dbContext.Animals;
            if (animais == null || animais.Count == 0)
                return NotFound("Nenhum animal encontrado.");

            return Ok(animais);
        }

        [HttpGet("buscar/{id}")]
        public ActionResult BuscarPorId(int id)
        {
            var animal = _dbContext.Animals.Find(a => a.Id.Equals(id));

            if (animal == null)
                return NotFound($"Animal com ID {id} não foi encontrado.");

            return Ok(animal);
        }

        [HttpPost("adicionar")]
        public ActionResult AdicionarAnimal([FromBody] Animal novoAnimal)
        {
            if (novoAnimal == null || string.IsNullOrWhiteSpace(novoAnimal.Name))
                return BadRequest("Informações inválidas.");

            if (_dbContext.Animals.Exists(a => a.Id == novoAnimal.Id))
                return Conflict($"Já existe um animal com ID {novoAnimal.Id}.");

            _dbContext.Animals.Add(novoAnimal);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novoAnimal.Id }, novoAnimal);
        }

        [HttpPut("atualizar/{id}")]
        public ActionResult AtualizarAnimal(int id, [FromBody] Animal dadosAtualizados)
        {
            var animal = _dbContext.Animals.Find(a => a.Id.Equals(id));

            if (animal == null)
                return NotFound($"Animal com ID {id} não encontrado.");

            if (dadosAtualizados == null)
                return BadRequest("Dados inválidos para atualização.");

            animal.Name = dadosAtualizados.Name ?? animal.Name;
            animal.Classification = dadosAtualizados.Classification ?? animal.Classification;
            animal.Origin = dadosAtualizados.Origin ?? animal.Origin;
            animal.Reprodution = dadosAtualizados.Reprodution ?? animal.Reprodution;
            animal.Feeding = dadosAtualizados.Feeding ?? animal.Feeding;

            return Ok(animal);
        }

        [HttpPatch("atualizar-nome/{id}")]
        public ActionResult AtualizarNome(int id, [FromBody] string novoNome)
        {
            var animal = _dbContext.Animals.Find(a => a.Id.Equals(id));

            if (animal == null)
                return NotFound($"Animal com ID {id} não foi encontrado.");

            if (string.IsNullOrWhiteSpace(novoNome))
                return BadRequest("Nome informado é inválido.");

            animal.Name = novoNome;

            return Ok(animal);
        }

        [HttpDelete("remover/{id}")]
        public ActionResult RemoverAnimal(int id)
        {
            var animal = _dbContext.Animals.Find(a => a.Id.Equals(id));

            if (animal == null)
                return NotFound($"Animal com ID {id} não foi encontrado.");

            _dbContext.Animals.Remove(animal);

            return NoContent();
        }
    }
}
