using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BEMS.DAL.Migrations
{
    public partial class ininital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlowDefines",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    FlowType = table.Column<string>(nullable: true),
                    FlowStepDefine = table.Column<string>(nullable: true),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    Creator = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowDefines", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FlowNewEqRequest",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    IsComplete = table.Column<short>(type: "bit(1)", nullable: false),
                    RequestTime = table.Column<DateTime>(nullable: false),
                    Requester = table.Column<string>(nullable: true),
                    EType = table.Column<string>(nullable: true),
                    EModel = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowNewEqRequest", x => x.ID);
                });

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
                    Comments = table.Column<string>(nullable: true),
                    LastUpdateBy = table.Column<string>(nullable: true),
                    LastUpdateTime = table.Column<DateTime>(nullable: false)
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
                    ActionBy = table.Column<string>(nullable: true),
                    ActionTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowProgressHistory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ParentID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AccountName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: false),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    LastModifyBy = table.Column<string>(nullable: true),
                    State = table.Column<short>(type: "bit(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentID",
                table: "Menus",
                column: "ParentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowDefines");

            migrationBuilder.DropTable(
                name: "FlowNewEqRequest");

            migrationBuilder.DropTable(
                name: "FlowProgress");

            migrationBuilder.DropTable(
                name: "FlowProgressHistory");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
