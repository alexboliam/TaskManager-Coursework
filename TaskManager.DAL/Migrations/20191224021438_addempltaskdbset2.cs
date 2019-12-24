using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.DAL.Migrations
{
    public partial class addempltaskdbset2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Employees_TaskId",
                table: "EmployeeTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Tasks_TaskId1",
                table: "EmployeeTasks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTasks_TaskId1",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "TaskId1",
                table: "EmployeeTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Employees_EmployeeId",
                table: "EmployeeTasks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Tasks_TaskId",
                table: "EmployeeTasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Employees_EmployeeId",
                table: "EmployeeTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Tasks_TaskId",
                table: "EmployeeTasks");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskId1",
                table: "EmployeeTasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_TaskId1",
                table: "EmployeeTasks",
                column: "TaskId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Employees_TaskId",
                table: "EmployeeTasks",
                column: "TaskId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Tasks_TaskId1",
                table: "EmployeeTasks",
                column: "TaskId1",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
