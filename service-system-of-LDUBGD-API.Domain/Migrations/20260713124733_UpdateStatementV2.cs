using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace service_system_of_LDUBGD_API.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatementV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "YearBirthday",
                table: "Statement",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "YearBirthday",
                table: "Statement",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
