using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalCase_TosunBank.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PhoneNumberColumndAddToPreRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "PreRegistrations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "PreRegistrations");
        }
    }
}
