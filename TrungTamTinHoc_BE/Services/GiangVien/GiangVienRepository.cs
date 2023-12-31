﻿using TrungTamTinHoc_BE.Data;
using TrungTamTinHoc_BE.Data.GiangVien_VM;
using TrungTamTinHoc_BE.Models;

namespace TrungTamTinHoc_BE.Services.GiangVien
{
    public class GiangVienRepository : IGiangVienRepository
    {
        public readonly AppDbContext _context;
        public GiangVienRepository(AppDbContext context)
        {
            _context = context;
        }
        public GiangVienResult GetAllGV(int currentPage = 1, int PAGE_SIZE = 10)
        {
            var result = PaginatedList<Models.GiangVien>.Create(_context.GiangViens, currentPage, PAGE_SIZE);
            //var result = _context.GiangViens.Select(x => new GiangVien_VM
            //{
            //    maGV = x.maGV,
            //    tenGV = x.tenGV,
            //    DiaChi = x.DiaChi,
            //    Email = x.Email,
            //    GioiTinh = x.GioiTinh,
            //    NgaySinh = x.NgaySinh.ToString("dd-MM-yyyy"),
            //    Sdt = x.Sdt
            //})
            //.ToList();
            return new GiangVienResult
            {
                GiangViens = result.Select(x => new GiangVien_VM
                {
                    maGV = x.maGV,
                    tenGV = x.tenGV,
                    DiaChi = x.DiaChi,
                    Email = x.Email,
                    GioiTinh = x.GioiTinh,
                    NgaySinh = x.NgaySinh.ToString("yyyy-MM-dd"),
                    Sdt = x.Sdt
                }).ToList(),
                TotalCount = _context.GiangViens.Count(),
            };
        }
        public GiangVien_VM GetDataGiangVien(GiangVienQuery maGV)
        {
            var result = _context.GiangViens.SingleOrDefault(gv => gv.maGV == maGV.username);
            return new GiangVien_VM
            {
                maGV = result.maGV,
                tenGV = result.tenGV,
                DiaChi = result.DiaChi,
                Email = result.Email,
                GioiTinh = result.GioiTinh,
                NgaySinh = result.NgaySinh.Date.ToString("dd-MM-yyyy"),
                Sdt = result.Sdt,
            };
        }

        public void UpdateDataGiangVien(string magv, GiangVien_VM giangvien)
        {
            var result = _context.GiangViens.SingleOrDefault(gv => gv.maGV == magv);
            if(result != null)
            {
                result.tenGV = giangvien.tenGV;
                result.Email = giangvien.Email;
                result.DiaChi = giangvien.DiaChi;
                result.NgaySinh = DateTime.Parse(giangvien.NgaySinh);
                result.GioiTinh = giangvien.GioiTinh;
                result.Sdt = giangvien.Sdt;

                _context.GiangViens.Update(result);
                _context.SaveChanges();
            }
        }
        public void DeleteDataGiangVien(string magv)
        {
            var result = _context.GiangViens.SingleOrDefault(gv => gv.maGV == magv);
            var phanquyen = _context.PhanQuyen.SingleOrDefault(gv => gv.Account == magv);
            var taikhoan = _context.TaiKhoans.SingleOrDefault(gv => gv.Account == magv);
            if (result != null)
            {
                _context.GiangViens.Remove(result);
                _context.TaiKhoans.Remove(taikhoan);
                _context.PhanQuyen.Remove(phanquyen);
                _context.SaveChanges();
            }
        }
    }
}
