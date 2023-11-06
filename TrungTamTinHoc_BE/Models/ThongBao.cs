namespace TrungTamTinHoc_BE.Models
{
    public class ThongBao
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime NgayDang { get; set; }
        public string DoiTuong { get; set; }
    }
}
