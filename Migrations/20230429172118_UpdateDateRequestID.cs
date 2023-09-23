using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairNinjaMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDateRequestID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Requests",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Requests",
                newName: "Id");
        }
    }
}
