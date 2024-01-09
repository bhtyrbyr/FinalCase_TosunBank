using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalCase_TosunBank.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class transactiontypeinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "AccountStatements");

            migrationBuilder.AddColumn<byte>(
                name: "TransactionTypeId",
                table: "AccountStatements",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountStatements_TransactionTypeId",
                table: "AccountStatements",
                column: "TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountStatements_TransactionTypes_TransactionTypeId",
                table: "AccountStatements",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountStatements_TransactionTypes_TransactionTypeId",
                table: "AccountStatements");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropIndex(
                name: "IX_AccountStatements_TransactionTypeId",
                table: "AccountStatements");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "AccountStatements");

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "AccountStatements",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
