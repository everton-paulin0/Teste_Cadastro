using Teste_Cadastro.Model.Enum;

namespace Teste_Cadastro.Model
{
    public class DadosPessoal : BaseEntities
    {
        public DadosPessoal(string cpf, string nome, EnumGeneros genero, int idade, int enderecoId, bool IsActive)
        {
            Cpf = cpf;
            Nome = nome;
            Genero = genero;
            Idade = idade;
            EnderecoId = enderecoId;
            IsActive = true;

        }

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public EnumGeneros Genero { get; set; }
        public int Idade { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public bool IsActive { get; set; }

        public void UpdateDados(string cpf, string nome, EnumGeneros genero, int idade, int enderecoId, bool IsActive)
        {
            Cpf = cpf;
            Nome = nome;
            Genero = genero;
            Idade = idade;
            EnderecoId = enderecoId;
            IsActive = IsActive;

        }
    }
}
