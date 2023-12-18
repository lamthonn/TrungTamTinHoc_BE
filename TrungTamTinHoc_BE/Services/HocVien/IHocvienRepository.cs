using TrungTamTinHoc_BE.Data.HocVien_VM;
using TrungTamTinHoc_BE.Models;

namespace TrungTamTinHoc_BE.Services.HocVien
{
    public interface IHocvienRepository
    {
        public class HocVienQuery
        {
            public string username { get; set; }
        }
        public HocVienResult GetAllHocVien(int currentPage = 1, int PAGE_SIZE = 10);
        public HocVien_VM GetDataHocVien(HocVienQuery vm);

        //sửa học viên
        public void UpdateHocvien (string mahv, HocVien_VM hocvien);
        //xóa học viên
        public void DeleteHocvien (string mahv);
    }
}
