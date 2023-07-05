using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace navPaginas.Migrations
{
    /// <inheritdoc />
    public partial class RelTarefaLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Entrega",
                table: "Tarefa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "Tarefa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_LoginId",
                table: "Tarefa",
                column: "LoginId", 
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Login_LoginId",
                table: "Tarefa",
                column: "LoginId",
                principalTable: "Login",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Login_LoginId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_LoginId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Tarefa");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Entrega",
                table: "Tarefa",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
