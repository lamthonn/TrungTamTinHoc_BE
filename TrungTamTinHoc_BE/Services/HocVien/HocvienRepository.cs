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

        public HocVien_VM GetDataHocVien(HocVienQuery maHV)
        {
            var result = _context.HocViens.SingleOrDefault(gv => gv.maHV == maHV.username);
            return new HocVien_VM
            {
                tenHV = result.tenHV,
                DiaChi = result.DiaChi,
                Email = result.Email,
                GioiTinh = result.GioiTinh,
                NgaySinh = result.NgaySinh.Date.ToString("dd-MM-yyyy"),
                Sdt = result.Sdt,
            };
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
            if (result != null)
            {
                _context.HocViens.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
