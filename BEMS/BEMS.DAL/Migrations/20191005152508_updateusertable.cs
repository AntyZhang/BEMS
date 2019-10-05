using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BEMS.DAL.Migrations
{
    public partial class updateusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "BEMSUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifyBy",
                table: "BEMSUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifyTime",
                table: "BEMSUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Memo",
                table: "BEMSUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "BEMSUsers");

            migrationBuilder.DropColumn(
                name: "LastModifyBy",
                table: "BEMSUsers");

            migrationBuilder.DropColumn(
                name: "LastModifyTime",
                table: "BEMSUsers");

            migrationBuilder.DropColumn(
                name: "Memo",
                table: "BEMSUsers");
        }
    }
}
