
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
        public void UpdateThongBaos(string title, ThongBao_VM thongbao);
        public void DeleteThongBaos(string title);
    }
}
