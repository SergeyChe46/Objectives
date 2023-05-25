using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Objectives.Migrations
{
    /// <inheritdoc />
    public partial class Authentification3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "71acf422-79d1-4ee1-ad09-d81b8a0d0c74", null, "Performer", "PERFORMER" },
                    { "9fd624a2-ce67-4587-a4c4-7cdfca158e3e", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PerformerId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "47503d39-8edd-45c3-965d-92d87e510039", 0, "65128738-8fd4-427f-b17b-12c2e53f8b24", "First@mail.ru", false, false, null, null, null, null, null, 0, null, false, "5f0f07ba-eb36-4de6-8eb9-d37d761bcd5a", false, "First Name" },
                    { "5fd0a15e-a53c-41f4-a2f3-7a6a980e506d", 0, "58c07035-7c8c-41e6-a949-89a93847d31b", "Second@mail.ru", false, false, null, null, null, null, null, 0, null, false, "5dbd9e61-5d43-4ddc-a162-814e9e758de2", false, "Second Name" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71acf422-79d1-4ee1-ad09-d81b8a0d0c74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fd624a2-ce67-4587-a4c4-7cdfca158e3e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47503d39-8edd-45c3-965d-92d87e510039");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fd0a15e-a53c-41f4-a2f3-7a6a980e506d");

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
    }
}
