using Teste_Cadastro.Model.Enum;
using Teste_Cadastro.Model;

namespace Teste_Cadastro.Models
{
    public class CreateDadosPessoalInputModel
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public EnumGeneros Genero { get; set; }
        public int Idade { get; set; }
        public int EnderecoId { get; set; }
        public bool IsActive { get; set; }

        public DadosPessoal ToEntityDadosPessoal()
            => new(Cpf, Nome, Genero, Idade, EnderecoId, IsActive);
    }
}
