using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Status1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Appointed",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "IsDoing",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "Stoped",
                table: "TodoItems");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "TodoItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "TodoItems");

            migrationBuilder.AddColumn<bool>(
                name: "Appointed",
                table: "TodoItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDoing",
                table: "TodoItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Stoped",
                table: "TodoItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
