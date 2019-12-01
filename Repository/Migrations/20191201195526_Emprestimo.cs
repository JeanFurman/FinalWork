using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Emprestimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDivida",
                table: "Contas",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Divida",
                table: "Contas",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDivida",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Divida",
                table: "Contas");
        }
    }
}
