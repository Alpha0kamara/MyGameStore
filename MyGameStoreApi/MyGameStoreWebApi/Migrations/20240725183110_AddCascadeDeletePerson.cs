using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGameStoreWebApi.Migrations
{
    public partial class AddCascadeDeletePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Stores_StoreId",
                table: "Persons");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Stores_StoreId",
                table: "Persons",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Stores_StoreId",
                table: "Persons");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Stores_StoreId",
                table: "Persons",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
