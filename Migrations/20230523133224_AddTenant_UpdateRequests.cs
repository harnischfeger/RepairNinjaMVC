using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairNinjaMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddTenant_UpdateRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "zipcode",
                table: "Requests",
                newName: "time_3");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Requests",
                newName: "time_2");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Requests",
                newName: "time_1");

            migrationBuilder.RenameColumn(
                name: "landlord_id",
                table: "Requests",
                newName: "property_id");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Requests",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Requests",
                newName: "email");

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    property_id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    landlord_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.RenameColumn(
                name: "time_3",
                table: "Requests",
                newName: "zipcode");

            migrationBuilder.RenameColumn(
                name: "time_2",
                table: "Requests",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "time_1",
                table: "Requests",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "property_id",
                table: "Requests",
                newName: "landlord_id");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Requests",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Requests",
                newName: "city");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
