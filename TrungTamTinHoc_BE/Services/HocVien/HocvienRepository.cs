using TrungTamTinHoc_BE.Data;
using TrungTamTinHoc_BE.Data.GiangVien_VM;
using TrungTamTinHoc_BE.Data.HocVien_VM;
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
                maHV = result.maHV,
                tenHV = result.tenHV,
                DiaChi = result.DiaChi,
                Email = result.Email,
                GioiTinh = result.GioiTinh,
                NgaySinh = result.NgaySinh.Date.ToString("dd-MM-yyyy"),
                Sdt = result.Sdt,
            };
        }
    }
}
