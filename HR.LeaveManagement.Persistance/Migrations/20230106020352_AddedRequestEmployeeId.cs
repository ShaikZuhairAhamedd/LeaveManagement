using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.LeaveManagement.Persistance.Migrations
{
    public partial class AddedRequestEmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestingEmployeeId",
                table: "leaveRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestingEmployeeId",
                table: "leaveRequests");
        }
    }
}
