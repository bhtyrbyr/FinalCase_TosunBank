using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalCase_TosunBank.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tablenameupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOpeningRequests_AspNetUsers_CustomerId",
                table: "AccountOpeningRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerAccountOpeningRequests",
                table: "CustomerAccountOpeningRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountOpeningRequests",
                table: "AccountOpeningRequests");

            migrationBuilder.RenameTable(
                name: "CustomerAccountOpeningRequests",
                newName: "NewCustomerAccountOpeningRequest");

            migrationBuilder.RenameTable(
                name: "AccountOpeningRequests",
                newName: "NewBankAccountOpeningRequest");

            migrationBuilder.RenameIndex(
                name: "IX_AccountOpeningRequests_CustomerId",
                table: "NewBankAccountOpeningRequest",
                newName: "IX_NewBankAccountOpeningRequest_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewCustomerAccountOpeningRequest",
                table: "NewCustomerAccountOpeningRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewBankAccountOpeningRequest",
                table: "NewBankAccountOpeningRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewBankAccountOpeningRequest_AspNetUsers_CustomerId",
                table: "NewBankAccountOpeningRequest",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewBankAccountOpeningRequest_AspNetUsers_CustomerId",
                table: "NewBankAccountOpeningRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewCustomerAccountOpeningRequest",
                table: "NewCustomerAccountOpeningRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewBankAccountOpeningRequest",
                table: "NewBankAccountOpeningRequest");

            migrationBuilder.RenameTable(
                name: "NewCustomerAccountOpeningRequest",
                newName: "CustomerAccountOpeningRequests");

            migrationBuilder.RenameTable(
                name: "NewBankAccountOpeningRequest",
                newName: "AccountOpeningRequests");

            migrationBuilder.RenameIndex(
                name: "IX_NewBankAccountOpeningRequest_CustomerId",
                table: "AccountOpeningRequests",
                newName: "IX_AccountOpeningRequests_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerAccountOpeningRequests",
                table: "CustomerAccountOpeningRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountOpeningRequests",
                table: "AccountOpeningRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOpeningRequests_AspNetUsers_CustomerId",
                table: "AccountOpeningRequests",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
