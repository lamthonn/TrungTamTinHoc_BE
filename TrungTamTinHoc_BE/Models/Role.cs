namespace TrungTamTinHoc_BE.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<PhanQuyen>? phanQuyens { get; set; }
    }
}
