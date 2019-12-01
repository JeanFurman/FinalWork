using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class webservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Clientes",
                newName: "Numero_de_Cpf");

            migrationBuilder.RenameColumn(
                name: "DataNasc",
                table: "Clientes",
                newName: "Data_Nascimento");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Clientes",
                newName: "Nome_da_Pf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numero_de_Cpf",
                table: "Clientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Nome_da_Pf",
                table: "Clientes",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "Data_Nascimento",
                table: "Clientes",
                newName: "DataNasc");
        }
    }
}
