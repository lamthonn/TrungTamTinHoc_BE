using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrungTamTinHoc_BE.Services.GiangVien;

namespace TrungTamTinHoc_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        public readonly IGiangVienRepository _giangVienRepository;
        public GiangVienController(IGiangVienRepository giangVienRepository) 
        {
            _giangVienRepository = giangVienRepository;
        }

        [HttpPost("GetGiangVien")]
        public IActionResult GetGiangVien(GiangVienQuery maGV)
        {
            try
            {
                return Ok(_giangVienRepository.GetDataGiangVien(maGV));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
