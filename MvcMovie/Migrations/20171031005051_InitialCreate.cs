using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MvcMovie.Migrations
{
    public partial class InitialCreate : Migration
    {
        private object migrationBuilder;

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Movie",
            columns: table => new
            {

                id = table.Column<int>(nullable: false),
                genre = table.Column<string>(nullable: true),
                price = table.Column<decimal>(nullable: false),
                releasedate = table.Column<DateTime>(nullable: true), // could have tba release date that might indicate null. 
                title = table.Column<string>(nullable: true)
                 },
                constraints: table =>
                {
                table.PrimaryKey("pk_movie", x => x.id);
                });
            }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Selections");
        }
    }
}
