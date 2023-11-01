using TrungTamTinHoc_BE.Data;
using TrungTamTinHoc_BE.Data.GiangVien_VM;

namespace TrungTamTinHoc_BE.Services.GiangVien
{
    public class GiangVienRepository : IGiangVienRepository
    {
        public readonly AppDbContext _context;
        public GiangVienRepository(AppDbContext context)
        {
            _context = context;
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
    }
}
