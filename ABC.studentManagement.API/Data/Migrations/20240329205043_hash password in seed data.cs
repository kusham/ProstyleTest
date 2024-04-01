using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ABC.studentManagement.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class hashpasswordinseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: new Guid("32b7e72c-a588-476a-92e5-48662d11e280"));

            migrationBuilder.DeleteData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: new Guid("a3270d2b-1191-46e2-b7e9-46952a205ef2"));

            migrationBuilder.InsertData(
                table: "StaffMembers",
                columns: new[] { "Id", "Email", "FullName", "Password", "Phone" },
                values: new object[,]
                {
                    { new Guid("8e05f1e3-5896-417d-9a14-2ba6018785eb"), "admin1@example.com", "Admin 1", "AQAAAAIAAYagAAAAEKfFLo+U54DPUUQhkTT/WNz4wMEX6iB/qrXfR1XkATpbmBF3coKJ6QY/WzbGFThBTg==", "1234567890" },
                    { new Guid("a6e5ea67-0a7b-4bbc-9580-1f3aa52ce149"), "admin2@example.com", "Admin 2", "AQAAAAIAAYagAAAAELKOrh+u+GnDLhgIr6sHphInDnfhN8PWkbzeux2xpz8YcWuqxsf//WbP/WzN63yiSg==", "0987654321" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: new Guid("8e05f1e3-5896-417d-9a14-2ba6018785eb"));

            migrationBuilder.DeleteData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: new Guid("a6e5ea67-0a7b-4bbc-9580-1f3aa52ce149"));

            migrationBuilder.InsertData(
                table: "StaffMembers",
                columns: new[] { "Id", "Email", "FullName", "Password", "Phone" },
                values: new object[,]
                {
                    { new Guid("32b7e72c-a588-476a-92e5-48662d11e280"), "admin2@example.com", "Admin 2", "admin1password", "0987654321" },
                    { new Guid("a3270d2b-1191-46e2-b7e9-46952a205ef2"), "admin1@example.com", "Admin 1", "admin1password", "1234567890" }
                });
        }
    }
}
