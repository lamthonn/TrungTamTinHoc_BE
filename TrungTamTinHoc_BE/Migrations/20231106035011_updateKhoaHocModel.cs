using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrungTamTinHoc_BE.Migrations
{
    /// <inheritdoc />
    public partial class updateKhoaHocModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Loai",
                table: "KhoaHocs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Loai",
                table: "KhoaHocs");
        }
    }
}
