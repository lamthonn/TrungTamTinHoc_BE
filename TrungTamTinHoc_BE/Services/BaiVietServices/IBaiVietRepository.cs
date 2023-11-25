using Microsoft.AspNetCore.Mvc;
using TrungTamTinHoc_BE.Data.SocialMedia;
using TrungTamTinHoc_BE.Models;

namespace TrungTamTinHoc_BE.Services.BaiVietServices
{
    public interface IBaiVietRepository
    {
        public List<BaiViet_VM> GetAllPosts();
        public BaiViet_VM AddPost([FromForm] BaiViet_VM baiviet);
    }
}
