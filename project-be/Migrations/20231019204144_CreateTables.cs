using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace project_be.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectName = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Address_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "CountryName" },
                values: new object[,]
                {
                    { 1, "Argentina" },
                    { 2, "Denmark" },
                    { 3, "Brazil" },
                    { 4, "England" },
                    { 5, "Croatia" },
                    { 6, "France" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CountryId", "ProjectName" },
                values: new object[,]
                {
                    { 1, 1, "Project 1" },
                    { 2, 2, "Project 2" },
                    { 3, 1, "Project 3" },
                    { 4, 1, "Project 4" },
                    { 5, 2, "Project 5" },
                    { 6, 6, "Project 6" },
                    { 7, 4, "Project 8" },
                    { 8, 2, "Project 9" },
                    { 9, 5, "Project 10" },
                    { 10, 3, "Project 11" },
                    { 11, 4, "Project 12" },
                    { 12, 5, "Project 13" },
                    { 13, 5, "Project 14" },
                    { 14, 3, "Project 15" },
                    { 15, 6, "Project 16" },
                    { 16, 4, "Project 7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_CountryId",
                table: "Project",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
