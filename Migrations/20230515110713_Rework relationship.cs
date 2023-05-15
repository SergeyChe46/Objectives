using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Objectives.Migrations
{
    /// <inheritdoc />
    public partial class Reworkrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objectives_Performers_PerformerId",
                table: "Objectives");

            migrationBuilder.DropIndex(
                name: "IX_Objectives_PerformerId",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "PerformersId",
                table: "Objectives");

            migrationBuilder.AlterColumn<int>(
                name: "PerformerId",
                table: "Objectives",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ObjectivePerformer",
                columns: table => new
                {
                    ObjectivesObjectiveId = table.Column<int>(type: "integer", nullable: false),
                    PerformersPerformerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectivePerformer", x => new { x.ObjectivesObjectiveId, x.PerformersPerformerId });
                    table.ForeignKey(
                        name: "FK_ObjectivePerformer_Objectives_ObjectivesObjectiveId",
                        column: x => x.ObjectivesObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "ObjectiveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectivePerformer_Performers_PerformersPerformerId",
                        column: x => x.PerformersPerformerId,
                        principalTable: "Performers",
                        principalColumn: "PerformerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectivePerformer_PerformersPerformerId",
                table: "ObjectivePerformer",
                column: "PerformersPerformerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectivePerformer");

            migrationBuilder.AlterColumn<int>(
                name: "PerformerId",
                table: "Objectives",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<List<int>>(
                name: "PerformersId",
                table: "Objectives",
                type: "integer[]",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_PerformerId",
                table: "Objectives",
                column: "PerformerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Objectives_Performers_PerformerId",
                table: "Objectives",
                column: "PerformerId",
                principalTable: "Performers",
                principalColumn: "PerformerId");
        }
    }
}
