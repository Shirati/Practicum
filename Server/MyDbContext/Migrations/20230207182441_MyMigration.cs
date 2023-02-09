using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDbContext.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    NumUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    FirstName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    LastName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    MaleOrFemale = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    HMO = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.NumUser);
                });

            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    NumChild = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdChild = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.NumChild);
                    table.ForeignKey(
                        name: "FK_Child_User",
                        column: x => x.ParentId,
                        principalTable: "User",
                        principalColumn: "NumUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Child_ParentId",
                table: "Child",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Child");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
