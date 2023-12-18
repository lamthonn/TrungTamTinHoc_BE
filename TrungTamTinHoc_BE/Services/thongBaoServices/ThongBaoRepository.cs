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

        public ThongBao_VM AddThongBao(ThongBao_VM thongbao)
        {
            var _thongbao = new Models.ThongBao
            {
                Id = thongbao.Id,
                Description = thongbao.Description,
                DoiTuong = thongbao.DoiTuong,
                Title = thongbao.Title,
                NgayDang = DateTime.Now,
            };
            _context.ThongBaos.Add(_thongbao);
            _context.SaveChanges();
            return new ThongBao_VM
            {
                Id = _thongbao.Id,
                Description = _thongbao.Description,
                DoiTuong = _thongbao.DoiTuong,
                Title = _thongbao.Title,
                NgayDang = _thongbao.NgayDang.ToString(),
            };
        }

        public void UpdateThongBaos(int id, ThongBao_VM thongbao)
        {
            var _thongbao = _context.ThongBaos.SingleOrDefault(tb =>  tb.Id == id);
            if (_thongbao != null)
            {
                _thongbao.Id = id;
                _thongbao.Description = thongbao.Description;
                _thongbao.NgayDang = _thongbao.NgayDang;
                _thongbao.DoiTuong = _thongbao.DoiTuong;
                _context.ThongBaos.Update(_thongbao);
                _context.SaveChanges();

            }
            
        }

        public void DeleteThongBaos(int id)
        {
            var _thongbao = _context.ThongBaos.SingleOrDefault(tb => tb.Id == id);
            if (_thongbao != null)
            {
                _context.Remove(_thongbao);
            }
            _context.SaveChanges();
        }
    }
}
