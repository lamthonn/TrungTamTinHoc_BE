namespace TrungTamTinHoc_BE.Models
{
    public class KhoaHoc
    {
        public string maKH { get; set; }
        public string tenKH { get; set; }
        public string maGV { get; set; }
        public GiangVien? GiangVien { get; set; }
        public List<CTKhoaHoc>? CTKhoaHocs { get; set; }
    }
}
