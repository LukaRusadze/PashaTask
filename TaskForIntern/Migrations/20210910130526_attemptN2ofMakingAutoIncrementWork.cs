using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskForIntern.Migrations
{
    public partial class attemptN2ofMakingAutoIncrementWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "toDoItems",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "toDoItems",
                newName: "Id");
        }
    }
}
