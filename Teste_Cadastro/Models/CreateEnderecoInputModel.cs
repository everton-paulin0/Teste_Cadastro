using Teste_Cadastro.Model.Enum;
using Teste_Cadastro.Model;

namespace Teste_Cadastro.Models
{
    public class CreateEnderecoInputModel
    {
        public string Logradouro { get; set; }
        public string Municipio { get; set; }
        public EnumEstados Estados { get; set; }
        public Endereco ToEntityEndereco()
            => new(Logradouro, Municipio, Estados);
    }
}
