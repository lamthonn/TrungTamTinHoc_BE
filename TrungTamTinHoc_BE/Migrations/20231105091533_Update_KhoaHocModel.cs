using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrungTamTinHoc_BE.Migrations
{
    /// <inheritdoc />
    public partial class Update_KhoaHocModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "KhoaHocs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "luaTuoi",
                table: "KhoaHocs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "KhoaHocs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "rate",
                table: "KhoaHocs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "KhoaHocs");

            migrationBuilder.DropColumn(
                name: "luaTuoi",
                table: "KhoaHocs");

            migrationBuilder.DropColumn(
                name: "price",
                table: "KhoaHocs");

            migrationBuilder.DropColumn(
                name: "rate",
                table: "KhoaHocs");
        }
    }
}
