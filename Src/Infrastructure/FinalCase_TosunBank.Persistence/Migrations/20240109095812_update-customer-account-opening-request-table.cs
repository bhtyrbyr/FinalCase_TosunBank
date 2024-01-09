using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalCase_TosunBank.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatecustomeraccountopeningrequesttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isConfirmed",
                table: "CustomerAccountOpeningRequests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isConfirmed",
                table: "CustomerAccountOpeningRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
