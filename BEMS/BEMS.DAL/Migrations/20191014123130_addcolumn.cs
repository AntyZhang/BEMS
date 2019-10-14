using Microsoft.EntityFrameworkCore.Migrations;

namespace BEMS.DAL.Migrations
{
    public partial class addcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlowType",
                table: "FlowProgressHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlowType",
                table: "FlowProgress",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlowType",
                table: "FlowProgressHistory");

            migrationBuilder.DropColumn(
                name: "FlowType",
                table: "FlowProgress");
        }
    }
}
