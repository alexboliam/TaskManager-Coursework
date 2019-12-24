using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.DAL.Migrations
{
    public partial class addempltaskdbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTask_Employees_TaskId",
                table: "EmployeeTask");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTask_Tasks_TaskId1",
                table: "EmployeeTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTask",
                table: "EmployeeTask");

            migrationBuilder.RenameTable(
                name: "EmployeeTask",
                newName: "EmployeeTasks");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTask_TaskId1",
                table: "EmployeeTasks",
                newName: "IX_EmployeeTasks_TaskId1");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTask_TaskId",
                table: "EmployeeTasks",
                newName: "IX_EmployeeTasks_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTasks",
                table: "EmployeeTasks",
                columns: new[] { "EmployeeId", "TaskId" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Employees_TaskId",
                table: "EmployeeTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Tasks_TaskId1",
                table: "EmployeeTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTasks",
                table: "EmployeeTasks");

            migrationBuilder.RenameTable(
                name: "EmployeeTasks",
                newName: "EmployeeTask");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTasks_TaskId1",
                table: "EmployeeTask",
                newName: "IX_EmployeeTask_TaskId1");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTasks_TaskId",
                table: "EmployeeTask",
                newName: "IX_EmployeeTask_TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTask",
                table: "EmployeeTask",
                columns: new[] { "EmployeeId", "TaskId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTask_Employees_TaskId",
                table: "EmployeeTask",
                column: "TaskId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTask_Tasks_TaskId1",
                table: "EmployeeTask",
                column: "TaskId1",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
