using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSService.SoftTech.Infrastructure.Migrations
{
    public partial class AddIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SmsStates_SetDate",
                table: "SmsStates",
                column: "SetDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SmsStates_SetDate",
                table: "SmsStates");
        }
    }
}
