using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagerApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "IdentificationNumber",
                table: "Persons",
                newName: "Identification");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPerson",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "IdPerson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IdPerson",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "Identification",
                table: "Persons",
                newName: "IdentificationNumber");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "PersonId");
        }
    }
}
