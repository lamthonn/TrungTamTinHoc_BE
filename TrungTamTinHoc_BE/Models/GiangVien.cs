namespace TrungTamTinHoc_BE.Models
{
    public class GiangVien
    {
        public string maGV { get; set; }
        public string tenGV { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public List<KhoaHoc>? khoaHocs { get; set; }
    }
}
