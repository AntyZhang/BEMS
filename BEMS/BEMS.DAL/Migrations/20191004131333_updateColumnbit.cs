using Microsoft.EntityFrameworkCore.Migrations;

namespace BEMS.DAL.Migrations
{
    public partial class updateColumnbit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "IsComplete",
                table: "FlowNewEqRequest",
                type: "bit(1)",
                nullable: false,
                oldClrType: typeof(short));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "IsComplete",
                table: "FlowNewEqRequest",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "bit(1)");
        }
    }
}
