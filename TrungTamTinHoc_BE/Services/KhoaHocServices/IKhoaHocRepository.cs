using TrungTamTinHoc_BE.Data;
using TrungTamTinHoc_BE.Data.KhoaHoc_VM;

namespace TrungTamTinHoc_BE.Services.KhoaHocServices
{
    public record KhoaHocQuery
    {
        public string Loai { get; set; }
    }
    public interface IKhoaHocRepository
    {
        public List<KhoaHoc_VM> getAllKhoaHoc(KhoaHocQuery request);
        public KhoaHoc_VM addKhoaHoc(KhoaHoc_VM khoahoc);
        public void updateKhoaHoc(string maKH, KhoaHoc_VM khoahoc);
        public void deleteKhoaHoc(string maKH);
    }
}
