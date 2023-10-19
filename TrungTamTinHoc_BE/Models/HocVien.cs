using System.ComponentModel.DataAnnotations;

namespace TrungTamTinHoc_BE.Models
{
    public class HocVien
    {
        public string maHV { get; set; }
        public string tenHV { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set;}
        public List<CTKhoaHoc>? CTKhoaHocs { get; set; }
    }
}
