using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrungTamTinHoc_BE.Data.SocialMedia;
using TrungTamTinHoc_BE.Services.BaiVietServices;

namespace TrungTamTinHoc_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        public readonly IBaiVietRepository _baiVietRepository;
        public SocialMediaController(IBaiVietRepository baiVietRepository) 
        { 
            _baiVietRepository = baiVietRepository;
        }

        [HttpGet]
        public IActionResult GetAllBaiViet()
        {
            try
            {
                return Ok(_baiVietRepository.GetAllPosts());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("newPost")]
        public IActionResult AddBaiViet([FromForm] BaiViet_VM baiviet)
        {
            try
            {
                return Ok(_baiVietRepository.AddPost(baiviet));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
