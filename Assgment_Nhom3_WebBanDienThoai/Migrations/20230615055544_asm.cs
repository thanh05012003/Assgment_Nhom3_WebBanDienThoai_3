using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assgment_Nhom3_WebBanDienThoai.Migrations
{
    /// <inheritdoc />
    public partial class asm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoNhoTrongs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoNhoTrongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatLieus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLieus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChipCPUs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChipCPUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChipGPUs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChipGPUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CongSacs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongSacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiamGias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoPhanTramGiam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamGias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeDieuHanhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeDieuHanhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MauSacs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhaSanXuats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaSanXuats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenQuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThanhToans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenPhuongThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSoThe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaCvv = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinTucs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTucs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdHsx = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhams_NhaSanXuats_IdHsx",
                        column: x => x.IdHsx,
                        principalTable: "NhaSanXuats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenDN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    IdCv = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiKhoans_PhanQuyens_IdCv",
                        column: x => x.IdCv,
                        principalTable: "PhanQuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdGiamGia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChatLieu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdBoNhoTrong = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHeDieuHanh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCongSac = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPin = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSim = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRam = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChipCPU = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChipGPU = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMauSac = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrongLuong = table.Column<double>(type: "float", nullable: false),
                    CameraTruoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CameraSau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoPhanGiaiManHinh = table.Column<int>(type: "int", nullable: false),
                    KichThuoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_BoNhoTrongs_IdBoNhoTrong",
                        column: x => x.IdBoNhoTrong,
                        principalTable: "BoNhoTrongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_ChatLieus_IdChatLieu",
                        column: x => x.IdChatLieu,
                        principalTable: "ChatLieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_ChipCPUs_IdChipCPU",
                        column: x => x.IdChipCPU,
                        principalTable: "ChipCPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_ChipGPUs_IdChipGPU",
                        column: x => x.IdChipGPU,
                        principalTable: "ChipGPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_CongSacs_IdCongSac",
                        column: x => x.IdCongSac,
                        principalTable: "CongSacs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_GiamGias_IdGiamGia",
                        column: x => x.IdGiamGia,
                        principalTable: "GiamGias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_HeDieuHanhs_IdHeDieuHanh",
                        column: x => x.IdHeDieuHanh,
                        principalTable: "HeDieuHanhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_MauSacs_IdMauSac",
                        column: x => x.IdMauSac,
                        principalTable: "MauSacs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_Pins_IdPin",
                        column: x => x.IdPin,
                        principalTable: "Pins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_Rams_IdRam",
                        column: x => x.IdRam,
                        principalTable: "Rams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_SanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPhams_Sims_IdSim",
                        column: x => x.IdSim,
                        principalTable: "Sims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    IdTaiKhoan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.IdTaiKhoan);
                    table.ForeignKey(
                        name: "FK_GioHangs_TaiKhoans_IdTaiKhoan",
                        column: x => x.IdTaiKhoan,
                        principalTable: "TaiKhoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    IdThanhToan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTaiKhoan = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDons_TaiKhoans_IdTaiKhoan",
                        column: x => x.IdTaiKhoan,
                        principalTable: "TaiKhoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhGias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayDanhGia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSpct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTaiKhoan = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhGias_ChiTietSanPhams_IdSpct",
                        column: x => x.IdSpct,
                        principalTable: "ChiTietSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhGias_TaiKhoans_IdTaiKhoan",
                        column: x => x.IdTaiKhoan,
                        principalTable: "TaiKhoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imeis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    imei = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    IdCtsp = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imeis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imeis_ChiTietSanPhams_IdCtsp",
                        column: x => x.IdCtsp,
                        principalTable: "ChiTietSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListAnhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCtsp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anh1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anh2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anh3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListAnhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListAnhs_ChiTietSanPhams_IdCtsp",
                        column: x => x.IdCtsp,
                        principalTable: "ChiTietSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTaiKhoan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChiTietSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_ChiTietSanPhams_IdChiTietSp",
                        column: x => x.IdChiTietSp,
                        principalTable: "ChiTietSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiets_GioHangs_IdTaiKhoan",
                        column: x => x.IdTaiKhoan,
                        principalTable: "GioHangs",
                        principalColumn: "IdTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HinhThucThanhToans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenPhuongThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    IdThanhToan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHd = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucThanhToans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HinhThucThanhToans_HoaDons_IdHd",
                        column: x => x.IdHd,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HinhThucThanhToans_ThanhToans_IdThanhToan",
                        column: x => x.IdThanhToan,
                        principalTable: "ThanhToans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChiTietSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_ChiTietSanPhams_IdChiTietSp",
                        column: x => x.IdChiTietSp,
                        principalTable: "ChiTietSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiets_HoaDons_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_IdBoNhoTrong",
                table: "ChiTietSanPhams",
                column: "IdBoNhoTrong");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_IdChatLieu",
                table: "ChiTietSanPhams",
                column: "IdChatLieu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_IdChipCPU",
                table: "ChiTietSanPhams",
                column: "IdChipCPU");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_IdChipGPU",
                table: "ChiTietSanPhams",
                column: "IdChipGPU");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_IdCongSac",
                table: "ChiTietSanPhams",
                column: "IdCongSac");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_IdGiamGia",
                table: "ChiTietSanPhams",
                column: "IdGiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_IdHeDieuHanh",
                table: "ChiTietSanPhams",
                column: "IdHeDieuHanh");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_IdMauSac",
                table: "ChiTietSanPhams",
                column: "IdMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_IdPin",
                table: "ChiTietSanPhams",
                column: "IdPin");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_IdRam",
                table: "ChiTietSanPhams",
                column: "IdRam");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_IdSanPham",
                table: "ChiTietSanPhams",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPhams_IdSim",
                table: "ChiTietSanPhams",
                column: "IdSim");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGias_IdSpct",
                table: "DanhGias",
                column: "IdSpct");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGias_IdTaiKhoan",
                table: "DanhGias",
                column: "IdTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_IdChiTietSp",
                table: "GioHangChiTiets",
                column: "IdChiTietSp");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiets_IdTaiKhoan",
                table: "GioHangChiTiets",
                column: "IdTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucThanhToans_IdHd",
                table: "HinhThucThanhToans",
                column: "IdHd");

            migrationBuilder.CreateIndex(
                name: "IX_HinhThucThanhToans_IdThanhToan",
                table: "HinhThucThanhToans",
                column: "IdThanhToan");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_IdChiTietSp",
                table: "HoaDonChiTiets",
                column: "IdChiTietSp");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiets_IdHoaDon",
                table: "HoaDonChiTiets",
                column: "IdHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IdTaiKhoan",
                table: "HoaDons",
                column: "IdTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_Imeis_IdCtsp",
                table: "Imeis",
                column: "IdCtsp");

            migrationBuilder.CreateIndex(
                name: "IX_ListAnhs_IdCtsp",
                table: "ListAnhs",
                column: "IdCtsp");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_IdHsx",
                table: "SanPhams",
                column: "IdHsx");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_IdCv",
                table: "TaiKhoans",
                column: "IdCv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhGias");

            migrationBuilder.DropTable(
                name: "GioHangChiTiets");

            migrationBuilder.DropTable(
                name: "HinhThucThanhToans");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiets");

            migrationBuilder.DropTable(
                name: "Imeis");

            migrationBuilder.DropTable(
                name: "ListAnhs");

            migrationBuilder.DropTable(
                name: "TinTucs");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "ThanhToans");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "ChiTietSanPhams");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "BoNhoTrongs");

            migrationBuilder.DropTable(
                name: "ChatLieus");

            migrationBuilder.DropTable(
                name: "ChipCPUs");

            migrationBuilder.DropTable(
                name: "ChipGPUs");

            migrationBuilder.DropTable(
                name: "CongSacs");

            migrationBuilder.DropTable(
                name: "GiamGias");

            migrationBuilder.DropTable(
                name: "HeDieuHanhs");

            migrationBuilder.DropTable(
                name: "MauSacs");

            migrationBuilder.DropTable(
                name: "Pins");

            migrationBuilder.DropTable(
                name: "Rams");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "Sims");

            migrationBuilder.DropTable(
                name: "PhanQuyens");

            migrationBuilder.DropTable(
                name: "NhaSanXuats");
        }
    }
}
