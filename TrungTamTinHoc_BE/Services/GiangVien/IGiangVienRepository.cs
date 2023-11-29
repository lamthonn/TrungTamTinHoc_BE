using TrungTamTinHoc_BE.Data.GiangVien_VM;

namespace TrungTamTinHoc_BE.Services.GiangVien
{
    public class GiangVienQuery
    {
        public string username { get; set; }
    }
    public interface IGiangVienRepository
    {
        public List<GiangVien_VM> GetAllGV();

        public GiangVien_VM GetDataGiangVien(GiangVienQuery maGV);
        //sửa giảng viên
        public void UpdateDataGiangVien(string magv, GiangVien_VM giangvien);
        //xóa giảng viên
        public void DeleteDataGiangVien(string magv);
    }
}
