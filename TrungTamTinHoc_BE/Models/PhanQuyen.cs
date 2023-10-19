namespace TrungTamTinHoc_BE.Models
{
    public class PhanQuyen
    {
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public string Account { get; set; }
        public TaiKhoan? TaiKhoan { get; set; }
    }
}
