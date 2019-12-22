using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.DAL.Migrations
{
    public partial class subtaskfixmigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subtasks_Tasks_PanentTaskTaskId",
                table: "Subtasks");

            migrationBuilder.DropIndex(
                name: "IX_Subtasks_PanentTaskTaskId",
                table: "Subtasks");

            migrationBuilder.DropColumn(
                name: "PanentTaskTaskId",
                table: "Subtasks");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentTaskTaskId",
                table: "Subtasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subtasks_ParentTaskTaskId",
                table: "Subtasks",
                column: "ParentTaskTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subtasks_Tasks_ParentTaskTaskId",
                table: "Subtasks",
                column: "ParentTaskTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subtasks_Tasks_ParentTaskTaskId",
                table: "Subtasks");

            migrationBuilder.DropIndex(
                name: "IX_Subtasks_ParentTaskTaskId",
                table: "Subtasks");

            migrationBuilder.DropColumn(
                name: "ParentTaskTaskId",
                table: "Subtasks");

            migrationBuilder.AddColumn<Guid>(
                name: "PanentTaskTaskId",
                table: "Subtasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subtasks_PanentTaskTaskId",
                table: "Subtasks",
                column: "PanentTaskTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subtasks_Tasks_PanentTaskTaskId",
                table: "Subtasks",
                column: "PanentTaskTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
