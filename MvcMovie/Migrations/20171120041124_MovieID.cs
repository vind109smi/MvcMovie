using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MvcMovie.Migrations
{
    public partial class MovieID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MovieReview",
                table: "Review",
                type: "nvarchar(max)",
                maxLength: 100000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

            //migrationBuilder.CreateTable(
            //    name: "Review",
            //    columns: table => new
            //    {
            //        ReviewID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        MovieID = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Review", x => x.ReviewID);
            //        table.ForeignKey(
            //            name: "FK_Review_Movie_MovieID",
            //            column: x => x.MovieID,
            //            principalTable: "Movie",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Review_MovieID",
            //    table: "Review",
            //    column: "MovieID");
            // }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "MovieReview",
                table: "Review",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 100000);

        }
    }
}
