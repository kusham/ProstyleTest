using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABC.studentManagement.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class addnewpropertiestostudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Students",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Students",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Students");
        }
    }
}
