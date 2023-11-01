using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TrungTamTinHoc_BE.Data;
using TrungTamTinHoc_BE.Data.Login;
using TrungTamTinHoc_BE.Models;
using TrungTamTinHoc_BE.Services;
using TrungTamTinHoc_BE.Services.tài_khoản;

namespace TrungTamTinHoc_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private ITaiKhoanRepository _taiKhoanRepository;
        private readonly IConfiguration _config;
        private AppDbContext _context;

        public TaiKhoanController(ITaiKhoanRepository taiKhoanRepository, AppDbContext context, IConfiguration config)
        {
            _taiKhoanRepository = taiKhoanRepository;
            _context = context;
            _config = config;
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
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login_VM taikhoan)
        {

            var user = Authenticate(taikhoan);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(new { Token = token });
            }
            else
            {
                return null; // Trả về lỗi 401 Unauthorized nếu xác thực không thành công
            }

        }
        private string Generate(TaiKhoan user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userRole = _context.PhanQuyen.SingleOrDefault((r => r.Account == user.Account));
            var claims = new[]
            {
                    new Claim("Account", user.Account),
                    new Claim("RoleId", userRole.RoleId.ToString()),
                };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private TaiKhoan Authenticate(Login_VM user)
        {
            var currentUser = _context.TaiKhoans.FirstOrDefault(o => o.Account.ToLower() == user.Account.ToLower() && o.Password == GetMD5(user.Password));

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}
