using Microsoft.AspNetCore.Mvc;
using TrungTamTinHoc_BE.Data;
using TrungTamTinHoc_BE.Data.Login;
using TrungTamTinHoc_BE.Models;

namespace TrungTamTinHoc_BE.Services.tài_khoản
{
    public class TaiKhoanRepository : ITaiKhoanRepository 
    {
        private AppDbContext _context;

        public TaiKhoanRepository(AppDbContext context) 
        { 
            _context = context;
        }

        //public TaiKhoan_VM Register(TaiKhoan_VM taikhoan, Role_VM role)
        //{
        //    var _taikhoan = new TaiKhoan
        //    {
        //        Account = taikhoan.Account,
        //        Password = taikhoan.Password,
        //        Email = taikhoan.Email,
        //    };
        //    _context.Add(_taikhoan);
        //    var _role = new Role_VM
        //    {
        //        RoleName = role.RoleName,
        //    };
        //    _context.Add(_role);
        //    var _phanquyen = new PhanQuyen_VM
        //    {
        //        Account = taikhoan.Account,
        //        RoleId = role.RoleId,
        //    };
        //    _context.Add(_phanquyen);
        //    _context.SaveChanges();

        //    return new TaiKhoan_VM
        //    {
        //        Account = _taikhoan.Account,
        //        Password = _taikhoan.Password,
        //        Email = _taikhoan.Email,
        //    };
        //}
        public RegisterViewModel Register([FromBody] RegisterViewModel model)
        {
                var _taikhoan = new TaiKhoan
                {
                    Account = model.Account,
                    Password = model.Password,
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

                    //if (_role.RoleId == 2)
                    //{
                    //    var _hocvien = new HocVien
                    //    {
                    //        maHV = model.Account,
                    //        tenHV = "User",
                    //        DiaChi = null,
                    //        Sdt = null,
                    //        Email = model.Email,
                    //        GioiTinh = null,
                    //    };
                    //    _context.HocViens.Add(_hocvien);
                    //    _context.SaveChanges();
                    //}
                    //if (_role.RoleId == 3)
                    //{
                    //    var _giangvien = new GiangVien
                    //    {
                    //        maGV = model.Account,
                    //        tenGV = "teacher",
                    //        DiaChi = null,
                    //        Sdt = null,
                    //        Email = model.Email,
                    //        GioiTinh = null,
                    //    };
                    //    _context.GiangViens.Add(_giangvien);
                    //    _context.SaveChanges();
                    //}
                }
                else
                {
                    Console.WriteLine("err");
                }

                
                return new RegisterViewModel
                {
                    Account = _taikhoan.Account,
                    Password = _taikhoan.Password,
                    Email = _taikhoan.Email,
                    RoleName = _role.RoleName,
                };
            }


        public LoginViewModel Login(Login_VM taikhoan)
        {
            var existingTaiKhoan = _context.TaiKhoans.SingleOrDefault(tk=> tk.Account == taikhoan.Account && tk.Password == taikhoan.Password);
            var role = _context.PhanQuyen.SingleOrDefault(r => r.Account == taikhoan.Account);

            if(existingTaiKhoan != null)
            {
                var loggedInTaiKhoan = new LoginViewModel
                {
                    Account = existingTaiKhoan.Account,
                    Password = existingTaiKhoan.Password,
                    RoleId = role.RoleId,
                };

                return loggedInTaiKhoan;
            }
            else
            {
                return null;
            }
        }
    }
}
