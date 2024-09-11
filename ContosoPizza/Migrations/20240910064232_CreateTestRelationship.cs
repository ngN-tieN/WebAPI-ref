using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoPizza.Migrations
{
    /// <inheritdoc />
    public partial class CreateTestRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Pizzas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_UserId",
                table: "Pizzas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_AspNetUsers_UserId",
                table: "Pizzas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_AspNetUsers_UserId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_UserId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pizzas");
        }
    }
}
