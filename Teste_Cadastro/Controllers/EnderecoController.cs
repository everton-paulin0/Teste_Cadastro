using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_Cadastro.Data;
using Teste_Cadastro.Models;

namespace Teste_Cadastro.Controllers
{
    [Route("api/endereco")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EnderecoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(string search = "")
        {
            var enderecos = _context.Enderecos
                .Where(d => !d.IsDeleted)                
                .AsNoTracking()
                .ToList();

            var model = enderecos
                .Select(d => EnderecoItemViewModel.FromEntityEndereco(d))
                .ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var enderecos = _context.Enderecos               
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == id);

            if (enderecos is null)
            {
                return NotFound();
            }

            var model = EnderecoItemViewModel.FromEntityEndereco(enderecos);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateEnderecoInputModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var enderecos = model.ToEntityEndereco();
            _context.Enderecos.Add(enderecos);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = enderecos.Id }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateEnderecoInputModel model)
        {
            var enderecos = _context.Enderecos.SingleOrDefault(l => l.Id == id);

            if (enderecos is null)
            {
                return NotFound();
            }

            enderecos.UpdateEnderecos(model.Logradouro, model.Municipio, model.Estados);

            _context.Enderecos.Update(enderecos);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var enderecos = _context.Enderecos.SingleOrDefault(l => l.Id == id);

            if (enderecos is null)
            {
                return NotFound();
            }

            enderecos.SetAsDeleted();
            _context.SaveChanges();
            _context.Enderecos.Update(enderecos);
            return NoContent();
        }
    }
}
