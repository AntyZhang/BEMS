using Microsoft.EntityFrameworkCore.Migrations;

namespace BEMS.DAL.Migrations
{
    public partial class updatecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CurrentFlowIndex",
                table: "FlowNewEqRequest",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CurrentFlowIndex",
                table: "FlowNewEqRequest",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
