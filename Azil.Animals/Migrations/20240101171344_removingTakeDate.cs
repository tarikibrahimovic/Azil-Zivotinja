using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Azil.Animals.Migrations
{
    /// <inheritdoc />
    public partial class removingTakeDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExitDate",
                table: "Animals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExitDate",
                table: "Animals",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
