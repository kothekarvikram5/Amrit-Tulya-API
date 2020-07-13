using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amrit.Tulya.Migrations
{
    public partial class AmritTulyaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tea_Inventory",
                columns: table => new
                {
                    Tea_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tea_Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Tea_Description = table.Column<string>(nullable: true),
                    Tea_Price = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Tea_Image_Path = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tea_Inve__16876EE263C641E4", x => x.Tea_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tea_Inventory");
        }
    }
}
