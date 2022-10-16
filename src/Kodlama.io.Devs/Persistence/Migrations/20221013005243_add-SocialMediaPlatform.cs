using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addSocialMediaPlatform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "SocialMediaAddresses");

            migrationBuilder.AddColumn<int>(
                name: "SocialMediaPlatform",
                table: "SocialMediaAddresses",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialMediaPlatform",
                table: "SocialMediaAddresses");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SocialMediaAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
