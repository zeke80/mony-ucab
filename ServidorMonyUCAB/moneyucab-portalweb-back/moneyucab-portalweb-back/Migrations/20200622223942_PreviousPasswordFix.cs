using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace moneyucab_portalweb_back.Migrations
{
    public partial class PreviousPasswordFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PreviousPasswords",
                table: "PreviousPasswords");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "PreviousPasswords",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "PasswordID",
                table: "PreviousPasswords",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SignupDate",
                table: "AspNetUsers",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreviousPasswords",
                table: "PreviousPasswords",
                column: "PasswordID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PreviousPasswords",
                table: "PreviousPasswords");

            migrationBuilder.DropColumn(
                name: "PasswordID",
                table: "PreviousPasswords");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "PreviousPasswords",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SignupDate",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreviousPasswords",
                table: "PreviousPasswords",
                column: "PasswordHash");
        }
    }
}
