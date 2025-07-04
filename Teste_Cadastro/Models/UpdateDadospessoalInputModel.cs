using Teste_Cadastro.Model.Enum;

namespace Teste_Cadastro.Models
{
    public class UpdateDadospessoalInputModel
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public EnumGeneros Genero { get; set; }
        public int Idade { get; set; }
        public int EnderecoId { get; set; }
        public bool IsActive { get; set; }
    }
}
