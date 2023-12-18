
using TrungTamTinHoc_BE.Data.ThongBaoViewModel;

namespace TrungTamTinHoc_BE.Services.thongBaoServices
{
    public record ThongBaoQuery 
    { 
        public string DoiTuong { get; set; }
    }
    public interface IThongBaoRepository
    {
        public List<ThongBao_VM> GetThongBaos(ThongBaoQuery request);
        public ThongBao_VM AddThongBao(ThongBao_VM thongbao);
        public void UpdateThongBaos(int id, ThongBao_VM thongbao);
        public void DeleteThongBaos(int id);
    }
}
