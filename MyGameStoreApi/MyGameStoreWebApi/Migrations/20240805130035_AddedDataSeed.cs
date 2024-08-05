using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGameStoreWebApi.Migrations
{
    public partial class AddedDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Stores_StoreId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Numbers",
                table: "Stores");

            migrationBuilder.EnsureSchema(
                name: "Person");

            migrationBuilder.EnsureSchema(
                name: "Store");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "tblStores",
                newSchema: "Store");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "tblPeople",
                newSchema: "Person");

            migrationBuilder.RenameColumn(
                name: "City",
                schema: "Store",
                table: "tblStores",
                newName: "Place");

            migrationBuilder.RenameColumn(
                name: "Email",
                schema: "Person",
                table: "tblPeople",
                newName: "EmailAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_StoreId",
                schema: "Person",
                table: "tblPeople",
                newName: "IX_tblPeople_StoreId");

            migrationBuilder.AlterColumn<string>(
                name: "Zipcode",
                schema: "Store",
                table: "tblStores",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                schema: "Store",
                table: "tblStores",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Store",
                table: "tblStores",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Addition",
                schema: "Store",
                table: "tblStores",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                schema: "Store",
                table: "tblStores",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                schema: "Store",
                table: "tblStores",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Person",
                table: "tblPeople",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "Person",
                table: "tblPeople",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                schema: "Person",
                table: "tblPeople",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblStores",
                schema: "Store",
                table: "tblStores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPeople",
                schema: "Person",
                table: "tblPeople",
                column: "Id");

            migrationBuilder.InsertData(
                schema: "Store",
                table: "tblStores",
                columns: new[] { "Id", "Addition", "Place", "IsFranchiseStore", "Name", "Number", "Street", "Zipcode" },
                values: new object[] { 1, null, "GameCity", false, "GameStore", "1", "GameStreet", "1234AB" });

            migrationBuilder.InsertData(
                schema: "Store",
                table: "tblStores",
                columns: new[] { "Id", "Addition", "Place", "IsFranchiseStore", "Name", "Number", "Street", "Zipcode" },
                values: new object[] { 2, null, "GymeCity", true, "GymeStore", "2", "GymeStreet", "1234AB" });

            migrationBuilder.InsertData(
                schema: "Person",
                table: "tblPeople",
                columns: new[] { "Id", "EmailAddress", "FirstName", "Gender", "LastName", "StoreId" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", 1, "Doe", 1 },
                    { 2, "jane.smith@example.com", "Jane", 2, "Smith", 1 },
                    { 3, "mike.johnson@example.com", "Mike", 1, "Johnson", 2 },
                    { 4, "emily.brown@example.com", "Emily", 2, "Brown", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblStores_Name",
                schema: "Store",
                table: "tblStores",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblPeople_EmailAddress",
                schema: "Person",
                table: "tblPeople",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblPeople_tblStores_StoreId",
                schema: "Person",
                table: "tblPeople",
                column: "StoreId",
                principalSchema: "Store",
                principalTable: "tblStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblPeople_tblStores_StoreId",
                schema: "Person",
                table: "tblPeople");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblStores",
                schema: "Store",
                table: "tblStores");

            migrationBuilder.DropIndex(
                name: "IX_tblStores_Name",
                schema: "Store",
                table: "tblStores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPeople",
                schema: "Person",
                table: "tblPeople");

            migrationBuilder.DropIndex(
                name: "IX_tblPeople_EmailAddress",
                schema: "Person",
                table: "tblPeople");

            migrationBuilder.DeleteData(
                schema: "Person",
                table: "tblPeople",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Person",
                table: "tblPeople",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Person",
                table: "tblPeople",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Person",
                table: "tblPeople",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Store",
                table: "tblStores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Store",
                table: "tblStores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Number",
                schema: "Store",
                table: "tblStores");

            migrationBuilder.RenameTable(
                name: "tblStores",
                schema: "Store",
                newName: "Stores");

            migrationBuilder.RenameTable(
                name: "tblPeople",
                schema: "Person",
                newName: "Persons");

            migrationBuilder.RenameColumn(
                name: "Place",
                table: "Stores",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Persons",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_tblPeople_StoreId",
                table: "Persons",
                newName: "IX_Persons_StoreId");

            migrationBuilder.AlterColumn<string>(
                name: "Zipcode",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Addition",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numbers",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Stores_StoreId",
                table: "Persons",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
