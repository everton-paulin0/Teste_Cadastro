using Microsoft.EntityFrameworkCore;
using Teste_Cadastro.Model;

namespace Teste_Cadastro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<DadosPessoal> DadosPessoais { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)        
            =>optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");        
    }
}
