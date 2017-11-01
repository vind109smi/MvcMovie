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

                ID = table.Column<int>(nullable: false),
                Genre = table.Column<string>(nullable: true),
                Price = table.Column<decimal>(nullable: false),
                ReleaseDate = table.Column<DateTime>(nullable: true), // could have tba release date that might indicate null. 
                Title = table.Column<string>(nullable: true)
                 },
                constraints: table =>
                {
                table.PrimaryKey("PK_Movie", x => x.ID);
                });
            }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Selections");
        }
    }
}
