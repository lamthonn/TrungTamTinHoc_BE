using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrungTamTinHoc_BE.Migrations
{
    /// <inheritdoc />
    public partial class initCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiangViens",
                columns: table => new
                {
                    maGV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tenGV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangViens", x => x.maGV);
                });

            migrationBuilder.CreateTable(
                name: "HocViens",
                columns: table => new
                {
                    maHV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tenHV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocViens", x => x.maHV);
                });

            migrationBuilder.CreateTable(
                name: "LichHocs",
                columns: table => new
                {
                    ngay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaDiem = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    maKH = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichHocs", x => new { x.maKH, x.ngay, x.DiaDiem });
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    Account = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.Account);
                });

            migrationBuilder.CreateTable(
                name: "KhoaHocs",
                columns: table => new
                {
                    maKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tenKH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maGV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiangVienmaGV = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHocs", x => x.maKH);
                    table.ForeignKey(
                        name: "FK_KhoaHocs_GiangViens_GiangVienmaGV",
                        column: x => x.GiangVienmaGV,
                        principalTable: "GiangViens",
                        principalColumn: "maGV");
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyen",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaiKhoanAccount = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyen", x => new { x.RoleId, x.Account });
                    table.ForeignKey(
                        name: "FK_PhanQuyen_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanQuyen_TaiKhoans_TaiKhoanAccount",
                        column: x => x.TaiKhoanAccount,
                        principalTable: "TaiKhoans",
                        principalColumn: "Account");
                });

            migrationBuilder.CreateTable(
                name: "CTKhoaHocs",
                columns: table => new
                {
                    maHV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    maKH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HocVienmaHV = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KhoaHocmaKH = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTKhoaHocs", x => new { x.maKH, x.maHV });
                    table.ForeignKey(
                        name: "FK_CTKhoaHocs_HocViens_HocVienmaHV",
                        column: x => x.HocVienmaHV,
                        principalTable: "HocViens",
                        principalColumn: "maHV");
                    table.ForeignKey(
                        name: "FK_CTKhoaHocs_KhoaHocs_KhoaHocmaKH",
                        column: x => x.KhoaHocmaKH,
                        principalTable: "KhoaHocs",
                        principalColumn: "maKH");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CTKhoaHocs_HocVienmaHV",
                table: "CTKhoaHocs",
                column: "HocVienmaHV");

            migrationBuilder.CreateIndex(
                name: "IX_CTKhoaHocs_KhoaHocmaKH",
                table: "CTKhoaHocs",
                column: "KhoaHocmaKH");

            migrationBuilder.CreateIndex(
                name: "IX_KhoaHocs_GiangVienmaGV",
                table: "KhoaHocs",
                column: "GiangVienmaGV");

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyen_TaiKhoanAccount",
                table: "PhanQuyen",
                column: "TaiKhoanAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "CTKhoaHocs");

            migrationBuilder.DropTable(
                name: "LichHocs");

            migrationBuilder.DropTable(
                name: "PhanQuyen");

            migrationBuilder.DropTable(
                name: "HocViens");

            migrationBuilder.DropTable(
                name: "KhoaHocs");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "GiangViens");
        }
    }
}
