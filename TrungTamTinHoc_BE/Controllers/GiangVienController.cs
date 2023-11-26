using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrungTamTinHoc_BE.Data.GiangVien_VM;
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
        [HttpGet("getAllGV")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_giangVienRepository.GetAllGV());
            }
            catch
            {
                return BadRequest();
            }
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

        [HttpPut("updateDataGV")]
        public IActionResult UpdateGiangVien(string magv, GiangVien_VM giangvien)
        {
            try
            {
                _giangVienRepository.UpdateDataGiangVien(magv,giangvien);
                return NoContent(); 
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteDataGV")]
        public IActionResult DeleteGiangVien(string magv, GiangVien_VM giangvien)
        {
            try
            {
                _giangVienRepository.DeleteDataGiangVien(magv);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
