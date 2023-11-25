using TrungTamTinHoc_BE.Data.GiangVien_VM;

namespace TrungTamTinHoc_BE.Services.GiangVien
{
    public class GiangVienQuery
    {
        public string username { get; set; }
    }
    public interface IGiangVienRepository
    {
        GiangVien_VM GetDataGiangVien(GiangVienQuery maGV);
        //sửa giảng viên
        //xóa giảng viên
    }
}
