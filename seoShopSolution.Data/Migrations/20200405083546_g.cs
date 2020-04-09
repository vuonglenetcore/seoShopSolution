using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace seoShopSolution.Data.Migrations
{
    public partial class g : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 15, 35, 46, 27, DateTimeKind.Local).AddTicks(6053),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 5, 15, 29, 49, 526, DateTimeKind.Local).AddTicks(279));

            migrationBuilder.RenameTable(name: "Roles", schema: "dbo", newName: "AppRoles", newSchema: "dbo");
            migrationBuilder.RenameTable(name: "Users", schema: "dbo", newName: "AppUsers", newSchema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 15, 29, 49, 526, DateTimeKind.Local).AddTicks(279),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 5, 15, 35, 46, 27, DateTimeKind.Local).AddTicks(6053));

            migrationBuilder.RenameTable(name: "AppRoles", schema: "dbo", newName: "Roles", newSchema: "dbo");
            migrationBuilder.RenameTable(name: "AppUsers", schema: "dbo", newName: "Users", newSchema: "dbo");
        }
    }
}