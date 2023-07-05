using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace navPaginas.Migrations
{
    /// <inheritdoc />
    public partial class DataEntrega : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Entrega",
                table: "Tarefa",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entrega",
                table: "Tarefa");
        }
    }
}
