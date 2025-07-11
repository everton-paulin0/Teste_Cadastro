using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_Cadastro.Data;
using Teste_Cadastro.Model;
using Teste_Cadastro.Models;

namespace Teste_Cadastro.Controllers
{
    [Route("api/pessoas")]
    [ApiController]
    public class DadosPessoalController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DadosPessoalController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]        
        public IActionResult GetAll(string search ="")
        {
            var dadosPessoais = _context.DadosPessoais                
                .Include(d => d.Endereco)
                .Where(d => !d.IsDeleted && (search == "" || d.Nome.Contains(search)))
                .AsNoTracking()
                .ToList();

            var model = dadosPessoais
                .Select(d => DadosPessoalItemViewModel.FromEntityDados(d))
                .ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]        
        public IActionResult GetById(int id)
        {
            var dadosPessoais =_context.DadosPessoais
                .Include(dp => dp.Endereco)
                .AsNoTracking()
                .SingleOrDefault(x=> x.Id == id);

            if (dadosPessoais is null)
            {
                return NotFound();
            }

            var model = DadosPessoalItemViewModel.FromEntityDados(dadosPessoais);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateDadosPessoalInputModel model)
        {
            if (!ModelState.IsValid) 
                return BadRequest();

            var dadosPessoal = model.ToEntityDadosPessoal();
            _context.DadosPessoais.Add(dadosPessoal);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new {id= dadosPessoal.Id},model);           
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateDadospessoalInputModel model)
        {
            var dadospessoal = _context.DadosPessoais.SingleOrDefault(l => l.Id == id);

            if (dadospessoal is null)
            {
                return NotFound();
            }

            dadospessoal.UpdateDados(model.Cpf, model.Nome, model.Genero, model.Idade, model.EnderecoId ,model.IsActive);

            _context.DadosPessoais.Update(dadospessoal);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dadosPessoais = _context.DadosPessoais.SingleOrDefault(l => l.Id == id);

            if (dadosPessoais is null)
            {
                return NotFound();
            }

            dadosPessoais.SetAsDeleted();
            _context.SaveChanges();
            _context.DadosPessoais.Update(dadosPessoais);
            return NoContent();
        }


    }
}
