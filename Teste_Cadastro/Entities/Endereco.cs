using Teste_Cadastro.Model.Enum;

namespace Teste_Cadastro.Model
{
    public class Endereco : BaseEntities
    {
        public Endereco(string logradouro, string municipio, EnumEstados estados)
        {
            Logradouro = logradouro;
            Municipio = municipio;
            Estados = estados;
        }

        public string Logradouro { get; set; }
        public string Municipio { get; set; }
        public EnumEstados Estados { get; set; }

        public void UpdateEnderecos(string logradouro, string municipio, EnumEstados estados)
        {
            Logradouro = logradouro;
            Municipio = municipio;
            Estados = estados;
        }
    }
}
