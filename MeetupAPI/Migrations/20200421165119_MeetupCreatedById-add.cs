using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetupAPI.Migrations
{
    public partial class MeetupCreatedByIdadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Meetups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meetups_CreatedById",
                table: "Meetups",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetups_Users_CreatedById",
                table: "Meetups",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetups_Users_CreatedById",
                table: "Meetups");

            migrationBuilder.DropIndex(
                name: "IX_Meetups_CreatedById",
                table: "Meetups");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Meetups");
        }
    }
}
