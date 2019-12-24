using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.DAL.Migrations
{
    public partial class empteams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTeam_Employees_EmployeeId",
                table: "EmployeeTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTeam_Teams_TeamId",
                table: "EmployeeTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTeam",
                table: "EmployeeTeam");

            migrationBuilder.RenameTable(
                name: "EmployeeTeam",
                newName: "EmployeeTeams");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTeam_TeamId",
                table: "EmployeeTeams",
                newName: "IX_EmployeeTeams_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTeams",
                table: "EmployeeTeams",
                columns: new[] { "EmployeeId", "TeamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTeams_Employees_EmployeeId",
                table: "EmployeeTeams",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTeams_Teams_TeamId",
                table: "EmployeeTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTeams_Employees_EmployeeId",
                table: "EmployeeTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTeams_Teams_TeamId",
                table: "EmployeeTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTeams",
                table: "EmployeeTeams");

            migrationBuilder.RenameTable(
                name: "EmployeeTeams",
                newName: "EmployeeTeam");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTeams_TeamId",
                table: "EmployeeTeam",
                newName: "IX_EmployeeTeam_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTeam",
                table: "EmployeeTeam",
                columns: new[] { "EmployeeId", "TeamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTeam_Employees_EmployeeId",
                table: "EmployeeTeam",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTeam_Teams_TeamId",
                table: "EmployeeTeam",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
