using Azure.Messaging;
using TrungTamTinHoc_BE.Data;
using TrungTamTinHoc_BE.Data.GiangVien_VM;
using TrungTamTinHoc_BE.Data.HocVien_VM;
using TrungTamTinHoc_BE.Models;
using static TrungTamTinHoc_BE.Services.HocVien.IHocvienRepository;

namespace TrungTamTinHoc_BE.Services.HocVien
{
    public class HocvienRepository : IHocvienRepository
    {
        public readonly AppDbContext _context;
        public HocvienRepository(AppDbContext context)
        {
            _context = context;
        }

        public HocVienResult GetAllHocVien(int currentPage = 1, int PAGE_SIZE = 10)
        {
            var result = PaginatedList<Models.HocVien>.Create(_context.HocViens, currentPage, PAGE_SIZE);


            return new HocVienResult
            {
                HocViens = result.Select(x => new HocVien_VM
                {
                    maHV = x.maHV,
                    tenHV = x.tenHV,
                    NgaySinh = x.NgaySinh.ToString("yyyy-MM-dd"),
                    Email = x.Email,
                    DiaChi = x.DiaChi,
                    GioiTinh = x.GioiTinh,
                    Sdt = x.Sdt,
                }).ToList(),
                TotalCount = _context.HocViens.Count()
            };
        }

        public HocVien_VM GetDataHocVien(HocVienQuery maHV)
        {
            var result = _context.HocViens.SingleOrDefault(gv => gv.maHV == maHV.username);
            if(result != null)
            {
                return new HocVien_VM
                {
                    tenHV = result.tenHV,
                    DiaChi = result.DiaChi,
                    Email = result.Email,
                    GioiTinh = result.GioiTinh,
                    NgaySinh = result.NgaySinh.Date.ToString("yyyy-MM-dd"),
                    Sdt = result.Sdt,
                };
            }
            else
            {
                return null;
            }
        }

        public void UpdateHocvien(string mahv,HocVien_VM hocvien)
        {
            
                var result = _context.HocViens.SingleOrDefault(hv => hv.maHV == mahv);
                 if(result != null)
                {
                    result.tenHV = hocvien.tenHV;
                    result.DiaChi = hocvien.DiaChi;
                    result.Email = hocvien.Email;
                    result.GioiTinh = hocvien.GioiTinh;
                    result.NgaySinh = DateTime.Parse(hocvien.NgaySinh);
                    result.Sdt = hocvien.Sdt;
                    _context.HocViens.Update(result);
                    _context.SaveChanges();
                 }
            
        }

        public void DeleteHocvien(string mahv)
        {
            var result = _context.HocViens.SingleOrDefault(hv => hv.maHV == mahv);
            var phanquyen = _context.PhanQuyen.SingleOrDefault(hv => hv.Account == mahv);
            var taikhoan = _context.TaiKhoans.SingleOrDefault(hv => hv.Account == mahv);
            if (result != null)
            {
                _context.HocViens.Remove(result);
                _context.TaiKhoans.Remove(taikhoan);
                _context.PhanQuyen.Remove(phanquyen);
                _context.SaveChanges();
            }
        }
    }
}
