using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesDBProject.Migrations
{
    /// <inheritdoc />
    public partial class CourseInstances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseInstance",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    courseId = table.Column<int>(type: "INTEGER", nullable: false),
                    startdatum = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInstance", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourseInstance_CoursesTable_courseId",
                        column: x => x.courseId,
                        principalTable: "CoursesTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstance_courseId",
                table: "CourseInstance",
                column: "courseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseInstance");
        }
    }
}
