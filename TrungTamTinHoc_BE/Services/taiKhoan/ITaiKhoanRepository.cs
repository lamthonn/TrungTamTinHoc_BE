using TrungTamTinHoc_BE.Data.Login;

namespace TrungTamTinHoc_BE.Services
{
    public interface ITaiKhoanRepository
    {
        RegisterViewModel Register(RegisterViewModel model);
        LoginViewModel Login(Login_VM taikhoan);
    }
}
