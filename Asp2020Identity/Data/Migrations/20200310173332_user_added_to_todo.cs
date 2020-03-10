using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp2020Identity.Data.Migrations
{
    public partial class user_added_to_todo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Todos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_CreatorId",
                table: "Todos",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_CreatorId",
                table: "Todos",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_CreatorId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_CreatorId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Todos");
        }
    }
}
