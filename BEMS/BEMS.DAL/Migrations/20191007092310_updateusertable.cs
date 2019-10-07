using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BEMS.DAL.Migrations
{
    public partial class updateusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "State",
                table: "Users",
                type: "bit(1)",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifyTime",
                table: "Users",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "State",
                table: "Users",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "bit(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifyTime",
                table: "Users",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
