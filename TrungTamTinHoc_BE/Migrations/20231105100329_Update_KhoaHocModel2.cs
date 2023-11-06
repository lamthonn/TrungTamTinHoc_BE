using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrungTamTinHoc_BE.Migrations
{
    /// <inheritdoc />
    public partial class Update_KhoaHocModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pathImage",
                table: "KhoaHocs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pathImage",
                table: "KhoaHocs");
        }
    }
}
