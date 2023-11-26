using Microsoft.AspNetCore.Mvc;
using TrungTamTinHoc_BE.Data.Login;

namespace TrungTamTinHoc_BE.Services
{
    public interface ITaiKhoanRepository
    {
        public RegisterViewModel Register(RegisterViewModel model);
        //string Login(Login_VM taikhoan);
    }
}
