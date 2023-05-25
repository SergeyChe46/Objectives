using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Objectives.Migrations
{
    /// <inheritdoc />
    public partial class Authentification2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1628798d-fd08-4d4c-ab11-27dd1f897336");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cff6f892-2536-4eee-9aa7-031944abd697");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "63987fe6-de07-47e2-ac6f-ba30e8fb4e87");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c639caaf-057f-4148-b2d9-18915fad8292");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "115556be-0374-481c-badc-0d4747cc7053", null, "Performer", "PERFORMER" },
                    { "99adf633-4af2-44db-890d-f73e8e68b680", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PerformerId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "04e51ae3-1b3a-4b93-8721-59e34df26f23", 0, "67d18e93-3967-4626-9dc2-8438ae4275b3", "Second@mail.ru", false, false, null, null, null, null, null, 0, null, false, "4a8447b9-f4aa-4d2f-b5dd-38720f986c1d", false, "Second Name" },
                    { "0f8479d1-7da2-47b3-8d94-3a4f461cb7b8", 0, "9d7109f5-884b-454a-ab08-cbb655396c3f", "First@mail.ru", false, false, null, null, null, null, null, 0, null, false, "38bc68eb-51ec-49f8-9edb-9b4af803f0db", false, "First Name" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115556be-0374-481c-badc-0d4747cc7053");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99adf633-4af2-44db-890d-f73e8e68b680");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04e51ae3-1b3a-4b93-8721-59e34df26f23");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f8479d1-7da2-47b3-8d94-3a4f461cb7b8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1628798d-fd08-4d4c-ab11-27dd1f897336", null, "Performer", "PERFORMER" },
                    { "cff6f892-2536-4eee-9aa7-031944abd697", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PerformerId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "63987fe6-de07-47e2-ac6f-ba30e8fb4e87", 0, "a86b7c63-13f5-4f88-abf1-6650673c7bd3", "Second@mail.ru", false, false, null, null, null, null, null, 0, null, false, "f6bc8fb3-b1b6-437e-a1b8-0103b0163ce3", false, "Second Name" },
                    { "c639caaf-057f-4148-b2d9-18915fad8292", 0, "1ef704e8-5731-4bc1-960c-51de73cb3862", "First@mail.ru", false, false, null, null, null, null, null, 0, null, false, "fd3b0f87-f62c-4e7c-b92e-51697667443a", false, "First Name" }
                });
        }
    }
}
