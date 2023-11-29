using TrungTamTinHoc_BE.Data;
using TrungTamTinHoc_BE.Data.ThongBaoViewModel;
using TrungTamTinHoc_BE.Models;
using TrungTamTinHoc_BE.Services.thongBaoServices;

namespace TrungTamTinHoc_BE.Services.ThongBao
{
    public class ThongBaoRepository : IThongBaoRepository
    {
        public readonly AppDbContext _context;
        public ThongBaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<ThongBao_VM> GetThongBaos(ThongBaoQuery request)
        { 
            var results = _context.ThongBaos.Where(r => r.DoiTuong == request.DoiTuong);
            return results.Select(r => new ThongBao_VM
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                NgayDang = r.NgayDang.ToString(),
                DoiTuong = r.DoiTuong,
            }).ToList();
        }

        public void UpdateThongBaos(string title, ThongBao_VM thongbao)
        {
            var _thongbao = _context.ThongBaos.SingleOrDefault(tb =>  tb.Title == title);
            if (_thongbao != null)
            {
                _thongbao.Title = title;
                _thongbao.Description = thongbao.Description;
                _thongbao.NgayDang = _thongbao.NgayDang;
                _thongbao.DoiTuong = _thongbao.DoiTuong;
            }
            _context.SaveChanges(); 
        }

        public void DeleteThongBaos(string title)
        {
            var _thongbao = _context.ThongBaos.SingleOrDefault(tb => tb.Title == title);
            if (_thongbao != null)
            {
                _context.Remove(_thongbao);
            }
            _context.SaveChanges();
        }
    }
}
