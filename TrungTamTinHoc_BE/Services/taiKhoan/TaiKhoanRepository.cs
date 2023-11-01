using Microsoft.AspNetCore.Http.HttpResults;
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

namespace TrungTamTinHoc_BE.Services.tài_khoản
{
    public class TaiKhoanRepository : ITaiKhoanRepository 
    {
        private readonly IConfiguration _config;
        private AppDbContext _context;

        public TaiKhoanRepository(AppDbContext context, IConfiguration config) 
        { 
            _context = context;
            _config = config;
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

        public RegisterViewModel Register([FromBody] RegisterViewModel model)
        {
            string hashPassword = GetMD5(model.Password);
            var _taikhoan = new TaiKhoan
                {
                    Account = model.Account,
                    Password = hashPassword,
                    Email = model.Email,
                };

                // Lưu thông tin Tài Khoản
                _context.TaiKhoans.Add(_taikhoan);
                _context.SaveChanges();

                var _role = _context.Roles.SingleOrDefault(r => r.RoleName == model.RoleName);
                            
                if(_role != null)
                {
                    var _phanquyen = new PhanQuyen
                    {
                        Account = model.Account,
                        RoleId = _role.RoleId, // Lấy RoleId sau khi đã lưu Role
                    };

                    // Lưu thông tin Phân Quyền
                    _context.PhanQuyen.Add(_phanquyen);
                    _context.SaveChanges();

                }
                else
                {
                    Console.WriteLine("err");
                }

                
                return new RegisterViewModel
                {
                    Account = _taikhoan.Account,
                    Email = _taikhoan.Email,
                    RoleName = _role.RoleName,
                };
            }

        //private string Generate(TaiKhoan user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var userRole = _context.PhanQuyen.SingleOrDefault((r => r.Account == user.Account));
        //    var claims = new[]
        //    {
        //            new Claim(ClaimTypes.NameIdentifier, user.Account),
        //            new Claim(ClaimTypes.Role, userRole.RoleId.ToString()),
        //        };

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //      _config["Jwt:Audience"],
        //      claims,
        //      expires: DateTime.Now.AddMinutes(15),
        //      signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        //private TaiKhoan Authenticate(Login_VM user)
        //{
        //    var currentUser = _context.TaiKhoans.FirstOrDefault(o => o.Account.ToLower() == user.Account.ToLower() && o.Password == GetMD5(user.Password));

        //    if (currentUser != null)
        //    {
        //        return currentUser;
        //    }

        //    return null;
        //}


        //public string Login([FromBody] Login_VM taikhoan)
        //{
        //    var user = Authenticate(taikhoan);
        //    if (user != null)
        //    {
        //        var token = Generate(user);
        //        return token.ToString();
        //    }
        //    else
        //    {
        //        return null; // Trả về lỗi 401 Unauthorized nếu xác thực không thành công
        //    }
        //}
    }
}
