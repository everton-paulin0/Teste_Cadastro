using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste_Cadastro.Migrations
{
    /// <inheritdoc />
    public partial class addIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "DadosPessoais",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "DadosPessoais");
        }
    }
}
