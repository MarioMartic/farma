using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication2.Migrations
{
    public partial class UserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "korisnickoIme",
                table: "vlasnik",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lozinka",
                table: "vlasnik",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "korisnickoIme",
                table: "vlasnik");

            migrationBuilder.DropColumn(
                name: "lozinka",
                table: "vlasnik");
        }
    }
}
