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
                    Id = table.Column<string>(type: "text", nullable: false),
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
                    CountryId = table.Column<string>(type: "text", nullable: false)
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
                    { "AR", "Argentina" },
                    { "AU", "Australia" },
                    { "BR", "Brazil" },
                    { "FR", "France" },
                    { "HR", "Croatia" },
                    { "MX", "Mexico" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CountryId", "ProjectName" },
                values: new object[,]
                {
                    { 1, "AR", "Project 1" },
                    { 2, "MX", "Project 2" },
                    { 3, "BR", "Project 3" },
                    { 4, "AU", "Project 4" },
                    { 5, "HR", "Project 5" },
                    { 6, "FR", "Project 6" },
                    { 7, "MX", "Project 8" },
                    { 8, "BR", "Project 9" },
                    { 9, "AU", "Project 10" },
                    { 10, "HR", "Project 11" },
                    { 11, "FR", "Project 12" },
                    { 12, "AR", "Project 13" },
                    { 13, "MX", "Project 14" },
                    { 14, "BR", "Project 15" },
                    { 15, "AU", "Project 16" },
                    { 16, "AR", "Project 7" }
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
