using Teste_Cadastro.Model;
using Teste_Cadastro.Model.Enum;

namespace Teste_Cadastro.Models
{
    public class EnderecoItemViewModel
    {
        public EnderecoItemViewModel(int id, string logradouro, string municipio, EnumEstados estados)
        {
            Id = id;
            Logradouro = logradouro;
            Municipio = municipio;
            Estados = estados;
        }

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Municipio { get; set; }
        public EnumEstados Estados { get; set; }

        public static EnderecoItemViewModel FromEntityEndereco(Endereco endereco)
           => new(endereco.Id, endereco.Logradouro, endereco.Municipio, endereco.Estados);
    }
}
