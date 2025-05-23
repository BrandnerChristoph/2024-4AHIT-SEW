using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstereiVerwaltungMVVM.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ostereier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Farbe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Muster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerstecktAm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerstecktOrt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ostereier", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ostereier");
        }
    }
}
