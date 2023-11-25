using Microsoft.AspNetCore.Mvc;
using TrungTamTinHoc_BE.Data;
using TrungTamTinHoc_BE.Data.SocialMedia;
using TrungTamTinHoc_BE.Models;

namespace TrungTamTinHoc_BE.Services.BaiVietServices
{
    public class BaiVietRepository : IBaiVietRepository
    {
        private IConfiguration _config;
        public readonly AppDbContext _context;
        public readonly IWebHostEnvironment _webHostEnvironment;
        public BaiVietRepository(AppDbContext context, IWebHostEnvironment webHostEnvironment, IConfiguration config)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
        }

        public List<BaiViet_VM> GetAllPosts()
        {
            var result = _context.BaiViets
                .OrderBy(x => Guid.NewGuid())
                .Select(p => new BaiViet_VM
            {
                maHV = p.maHV,
                Title = p.Title,
                PathImage = p.PathImage,
            }).ToList();
            return result;
        }

        public BaiViet_VM AddPost([FromForm] BaiViet_VM baiviet)
        {
            var newPost = new BaiViet_VM
            {
                maHV = baiviet.maHV,
                Title = baiviet.Title,
                PathImage = baiviet.PathImage,
            };
            _context.Add(newPost);
            _context.SaveChanges();
            return newPost;
        }
    }
}
