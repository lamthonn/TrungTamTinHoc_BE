using TrungTamTinHoc_BE.Data.GiangVien_VM;

namespace TrungTamTinHoc_BE.Services.GiangVien
{
    public class GiangVienQuery
    {
        public string username { get; set; }
    }
    public interface IGiangVienRepository
    {
        public GiangVienResult GetAllGV(int currentPage = 1, int PAGE_SIZE = 10);

        public GiangVien_VM GetDataGiangVien(GiangVienQuery maGV);
        //sửa giảng viên
        public void UpdateDataGiangVien(string magv, GiangVien_VM giangvien);
        //xóa giảng viên
        public void DeleteDataGiangVien(string magv);
    }
}
