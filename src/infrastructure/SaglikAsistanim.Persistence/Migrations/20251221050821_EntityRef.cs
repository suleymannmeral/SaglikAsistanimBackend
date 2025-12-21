using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaglikAsistanim.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EntityRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserHealthProfileId",
                table: "Measurements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserHealthProfileId",
                table: "Measurements",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
