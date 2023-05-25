using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Objectives.Migrations
{
    /// <inheritdoc />
    public partial class Authentification1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65756230-58d8-4769-b29f-3c6307e6dcf0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df3d73cb-1036-47f6-aa18-3d4be8b4e09a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d79b1334-a17e-4225-9b37-70d1b572dade");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee70545c-b88e-441f-889e-24ca89e942e5");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65756230-58d8-4769-b29f-3c6307e6dcf0", null, "Performer", "PERFORMER" },
                    { "df3d73cb-1036-47f6-aa18-3d4be8b4e09a", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PerformerId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d79b1334-a17e-4225-9b37-70d1b572dade", 0, "9227763e-5ce4-4c8c-98b0-3c064898ba87", "Second@mail.ru", false, false, null, "Second Name", null, null, null, null, 0, null, false, "71d089b8-ea84-43dd-a097-17814851440d", false, null },
                    { "ee70545c-b88e-441f-889e-24ca89e942e5", 0, "e36eb816-313e-4c1e-a5dd-bd89ba53236a", "First@mail.ru", false, false, null, "First Name", null, null, null, null, 0, null, false, "29d438bd-3a66-4703-9792-549fb6170f75", false, null }
                });
        }
    }
}
