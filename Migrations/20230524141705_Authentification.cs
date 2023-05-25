using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Objectives.Migrations
{
    /// <inheritdoc />
    public partial class Authentification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b86de9a-fef5-4cd3-883e-909224fd17a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98241ff5-f23f-47db-9bc9-ffec51fe0ad0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e920c08-ebb0-49f6-a3b9-730a6d300ce0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f409c2f8-23b6-48c2-aea0-a3282795aaad");

            migrationBuilder.AddColumn<string>(
                name: "Password",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b86de9a-fef5-4cd3-883e-909224fd17a1", null, "Performer", "PERFORMER" },
                    { "98241ff5-f23f-47db-9bc9-ffec51fe0ad0", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PerformerId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6e920c08-ebb0-49f6-a3b9-730a6d300ce0", 0, "25ae0e9c-fb31-4947-bb79-455c822f1358", "First@mail.ru", false, false, null, "First Name", null, null, null, 0, null, false, "6debabea-d896-404d-8990-8c65fca5d154", false, null },
                    { "f409c2f8-23b6-48c2-aea0-a3282795aaad", 0, "29704946-dba9-4def-a6b6-96919d355034", "Second@mail.ru", false, false, null, "Second Name", null, null, null, 0, null, false, "a449689e-a4e6-4fc9-bf70-9bb855d65bcd", false, null }
                });
        }
    }
}
