namespace TrungTamTinHoc_BE.Models
{
    public class TaiKhoan
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<PhanQuyen>? phanQuyens { get; set; }
    }
}
