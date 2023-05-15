using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Objectives.Migrations
{
    /// <inheritdoc />
    public partial class Reworkrelationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObjectiveId",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "PerformerId",
                table: "Objectives");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObjectiveId",
                table: "Performers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PerformerId",
                table: "Objectives",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
