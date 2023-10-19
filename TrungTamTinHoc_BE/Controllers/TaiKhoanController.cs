using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrungTamTinHoc_BE.Data.Login;
using TrungTamTinHoc_BE.Services;
using TrungTamTinHoc_BE.Services.tài_khoản;

namespace TrungTamTinHoc_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private ITaiKhoanRepository _taiKhoanRepository;

        public TaiKhoanController(ITaiKhoanRepository taiKhoanRepository)
        {
            _taiKhoanRepository = taiKhoanRepository;
        }

        [HttpPost("register")]
        public IActionResult Register (RegisterViewModel model)
        {
            try
            {
                return Ok(_taiKhoanRepository.Register(model));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //[Authorize(Roles = "")] => phân quyền
        [HttpPost("login")]
        public IActionResult Login(Login_VM taikhoan)
        {
            try
            {
                return Ok(_taiKhoanRepository.Login(taikhoan));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
