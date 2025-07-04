using Teste_Cadastro.Model;
using Teste_Cadastro.Model.Enum;

namespace Teste_Cadastro.Models
{
    public class DadosPessoalItemViewModel
    {
        public DadosPessoalItemViewModel(int id, string cpf, string nome, EnumGeneros genero, int idade, int enderecoId)
        {
            Id = id;
            Cpf = cpf;
            Nome = nome;
            Genero = genero;
            Idade = idade;
            EnderecoId = enderecoId;
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public EnumGeneros Genero { get; set; }
        public int Idade { get; set; }
        public int EnderecoId { get; set; }

        public static DadosPessoalItemViewModel FromEntityDados(DadosPessoal dadosPessoal)
            => new(dadosPessoal.Id, dadosPessoal.Cpf, dadosPessoal.Nome, dadosPessoal.Genero, dadosPessoal.Idade, dadosPessoal.EnderecoId);
    }
}
