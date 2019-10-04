using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BEMS.DAL.Migrations
{
    public partial class updateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BEMSUsers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AccountName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEMSUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FlowNewEqRequest",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    FlowIndex = table.Column<int>(nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    IsComplete = table.Column<short>(nullable: false),
                    RequestTime = table.Column<DateTime>(nullable: false),
                    Requester = table.Column<string>(nullable: true),
                    EquipmentType = table.Column<string>(nullable: true),
                    EquipmentNO = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowNewEqRequest", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BEMSUsers");

            migrationBuilder.DropTable(
                name: "FlowNewEqRequest");
        }
    }
}
