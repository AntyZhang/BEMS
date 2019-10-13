using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BEMS.DAL.Migrations
{
    public partial class updateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assignee",
                table: "FlowNewEqRequest");

            migrationBuilder.DropColumn(
                name: "CurrentFlowIndex",
                table: "FlowNewEqRequest");

            migrationBuilder.CreateTable(
                name: "FlowProgress",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    TicketID = table.Column<string>(nullable: true),
                    CurrentFlowStep = table.Column<int>(nullable: false),
                    Assignee = table.Column<string>(nullable: true),
                    AssignTime = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowProgress", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FlowProgressHistory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    TicketID = table.Column<string>(nullable: true),
                    Step = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    ApproveBy = table.Column<string>(nullable: true),
                    ApproveTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowProgressHistory", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowProgress");

            migrationBuilder.DropTable(
                name: "FlowProgressHistory");

            migrationBuilder.AddColumn<string>(
                name: "Assignee",
                table: "FlowNewEqRequest",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentFlowIndex",
                table: "FlowNewEqRequest",
                nullable: true);
        }
    }
}
