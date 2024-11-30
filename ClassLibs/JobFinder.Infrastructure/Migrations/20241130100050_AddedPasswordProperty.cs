using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedPasswordProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employers");
        }
    }
}
