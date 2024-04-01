using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ABC.studentManagement.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class addnewpropertiestoStaffmember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Department",
                table: "StaffMembers");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StaffMembers",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "StaffMembers",
                type: "longtext",
                nullable: false);

            migrationBuilder.InsertData(
                table: "StaffMembers",
                columns: new[] { "Id", "Email", "FullName", "Password", "Phone" },
                values: new object[,]
                {
                    { new Guid("32b7e72c-a588-476a-92e5-48662d11e280"), "admin2@example.com", "Admin 2", "admin1password", "0987654321" },
                    { new Guid("a3270d2b-1191-46e2-b7e9-46952a205ef2"), "admin1@example.com", "Admin 1", "admin1password", "1234567890" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: new Guid("32b7e72c-a588-476a-92e5-48662d11e280"));

            migrationBuilder.DeleteData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: new Guid("a3270d2b-1191-46e2-b7e9-46952a205ef2"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "StaffMembers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StaffMembers",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "StaffMembers",
                type: "longtext",
                nullable: true);

            migrationBuilder.InsertData(
                table: "StaffMembers",
                columns: new[] { "Id", "Department", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "Administration", "admin1@example.com", "Admin 1", "1234567890" },
                    { 2, "Administration", "admin2@example.com", "Admin 2", "0987654321" }
                });
        }
    }
}
