using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.LeaveManagement.Persistance.Migrations
{
    public partial class EmployeeIdAddedToLeaveAllcoation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "leaveAllocations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "leaveAllocations");
        }
    }
}
