using TrungTamTinHoc_BE.Data.HocVien_VM;

namespace TrungTamTinHoc_BE.Services.HocVien
{
    public interface IHocvienRepository
    {
        public class HocVienQuery
        {
            public string username { get; set; }
        }
        HocVien_VM GetDataHocVien(HocVienQuery vm);
    }
}
