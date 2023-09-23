using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairNinjaMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "landlord_id",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "landlord_id",
                table: "Requests");
        }
    }
}
