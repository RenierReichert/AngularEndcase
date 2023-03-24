using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesDBProject.Migrations
{
    /// <inheritdoc />
    public partial class finalizeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CoursesTable_code",
                table: "CoursesTable",
                column: "code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CoursesTable_code",
                table: "CoursesTable");
        }
    }
}
