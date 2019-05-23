using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UruIT.GameOfDrones.Repository.Migrations
{
    public partial class DevUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecondHandSignalId",
                table: "Rounds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondPlayerId",
                table: "Rounds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Rounds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "HandSignals",
                columns: new[] { "Id", "DataRegister", "Description" },
                values: new object[] { 1L, new DateTime(2019, 5, 23, 7, 23, 15, 229, DateTimeKind.Local).AddTicks(7976), "Paper" });

            migrationBuilder.InsertData(
                table: "HandSignals",
                columns: new[] { "Id", "DataRegister", "Description" },
                values: new object[] { 2L, new DateTime(2019, 5, 23, 7, 23, 15, 235, DateTimeKind.Local).AddTicks(7170), "Rock" });

            migrationBuilder.InsertData(
                table: "HandSignals",
                columns: new[] { "Id", "DataRegister", "Description" },
                values: new object[] { 3L, new DateTime(2019, 5, 23, 7, 23, 15, 235, DateTimeKind.Local).AddTicks(7596), "Scissor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HandSignals",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "HandSignals",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "HandSignals",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "SecondHandSignalId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "SecondPlayerId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Rounds");
        }
    }
}
