using System.ComponentModel.DataAnnotations;

namespace TrungTamTinHoc_BE.Models
{
    public class CTKhoaHoc
    {
        public string maHV { get; set; }
        public HocVien? HocVien { get; set; }
        public string maKH { get; set; }
        public KhoaHoc? KhoaHoc { get; set; }
    }
}
