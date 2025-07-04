using Teste_Cadastro.Model.Enum;

namespace Teste_Cadastro.Models
{
    public class UpdateEnderecoInputModel
    {
        public string Logradouro { get; set; }
        public string Municipio { get; set; }
        public EnumEstados Estados { get; set; }
    }
}
