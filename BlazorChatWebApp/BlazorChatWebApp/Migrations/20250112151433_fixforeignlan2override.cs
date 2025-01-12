using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorChatWebApp.Migrations
{
    /// <inheritdoc />
    public partial class fixforeignlan2override : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_FromId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_ToId",
                table: "Message");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_FromId",
                table: "Message",
                column: "FromId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_ToId",
                table: "Message",
                column: "ToId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_FromId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_ToId",
                table: "Message");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_FromId",
                table: "Message",
                column: "FromId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_ToId",
                table: "Message",
                column: "ToId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
