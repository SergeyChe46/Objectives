using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Objectives.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectivePerformer_Objectives_ObjectivesObjectiveId",
                table: "ObjectivePerformer");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectivePerformer_Performers_PerformersPerformerId",
                table: "ObjectivePerformer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Performers",
                table: "Performers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Objectives",
                table: "Objectives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObjectivePerformer",
                table: "ObjectivePerformer");

            migrationBuilder.DropIndex(
                name: "IX_ObjectivePerformer_PerformersPerformerId",
                table: "ObjectivePerformer");

            migrationBuilder.DropColumn(
                name: "PerformerId",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "ObjectiveId",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "ObjectivesObjectiveId",
                table: "ObjectivePerformer");

            migrationBuilder.DropColumn(
                name: "PerformersPerformerId",
                table: "ObjectivePerformer");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Performers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Objectives",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ObjectivesId",
                table: "ObjectivePerformer",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PerformersId",
                table: "ObjectivePerformer",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Performers",
                table: "Performers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objectives",
                table: "Objectives",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObjectivePerformer",
                table: "ObjectivePerformer",
                columns: new[] { "ObjectivesId", "PerformersId" });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectivePerformer_PerformersId",
                table: "ObjectivePerformer",
                column: "PerformersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectivePerformer_Objectives_ObjectivesId",
                table: "ObjectivePerformer",
                column: "ObjectivesId",
                principalTable: "Objectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectivePerformer_Performers_PerformersId",
                table: "ObjectivePerformer",
                column: "PerformersId",
                principalTable: "Performers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectivePerformer_Objectives_ObjectivesId",
                table: "ObjectivePerformer");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectivePerformer_Performers_PerformersId",
                table: "ObjectivePerformer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Performers",
                table: "Performers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Objectives",
                table: "Objectives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObjectivePerformer",
                table: "ObjectivePerformer");

            migrationBuilder.DropIndex(
                name: "IX_ObjectivePerformer_PerformersId",
                table: "ObjectivePerformer");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "ObjectivesId",
                table: "ObjectivePerformer");

            migrationBuilder.DropColumn(
                name: "PerformersId",
                table: "ObjectivePerformer");

            migrationBuilder.AddColumn<int>(
                name: "PerformerId",
                table: "Performers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ObjectiveId",
                table: "Objectives",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ObjectivesObjectiveId",
                table: "ObjectivePerformer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PerformersPerformerId",
                table: "ObjectivePerformer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Performers",
                table: "Performers",
                column: "PerformerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objectives",
                table: "Objectives",
                column: "ObjectiveId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObjectivePerformer",
                table: "ObjectivePerformer",
                columns: new[] { "ObjectivesObjectiveId", "PerformersPerformerId" });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectivePerformer_PerformersPerformerId",
                table: "ObjectivePerformer",
                column: "PerformersPerformerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectivePerformer_Objectives_ObjectivesObjectiveId",
                table: "ObjectivePerformer",
                column: "ObjectivesObjectiveId",
                principalTable: "Objectives",
                principalColumn: "ObjectiveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectivePerformer_Performers_PerformersPerformerId",
                table: "ObjectivePerformer",
                column: "PerformersPerformerId",
                principalTable: "Performers",
                principalColumn: "PerformerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
