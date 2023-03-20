using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesDBProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedCourseInstanceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstance_CoursesTable_courseId",
                table: "CourseInstance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseInstance",
                table: "CourseInstance");

            migrationBuilder.RenameTable(
                name: "CourseInstance",
                newName: "CourseInstancesTable");

            migrationBuilder.RenameIndex(
                name: "IX_CourseInstance_courseId",
                table: "CourseInstancesTable",
                newName: "IX_CourseInstancesTable_courseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseInstancesTable",
                table: "CourseInstancesTable",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstancesTable_CoursesTable_courseId",
                table: "CourseInstancesTable",
                column: "courseId",
                principalTable: "CoursesTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstancesTable_CoursesTable_courseId",
                table: "CourseInstancesTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseInstancesTable",
                table: "CourseInstancesTable");

            migrationBuilder.RenameTable(
                name: "CourseInstancesTable",
                newName: "CourseInstance");

            migrationBuilder.RenameIndex(
                name: "IX_CourseInstancesTable_courseId",
                table: "CourseInstance",
                newName: "IX_CourseInstance_courseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseInstance",
                table: "CourseInstance",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstance_CoursesTable_courseId",
                table: "CourseInstance",
                column: "courseId",
                principalTable: "CoursesTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
