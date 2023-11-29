using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrungTamTinHoc_BE.Data.KhoaHoc_VM;
using TrungTamTinHoc_BE.Services.GiangVien;
using TrungTamTinHoc_BE.Services.KhoaHocServices;

namespace TrungTamTinHoc_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaHocController : ControllerBase
    {
        public readonly IKhoaHocRepository _khoaHocRepository;
        public KhoaHocController(IKhoaHocRepository khoaHocRepository)
        {
            _khoaHocRepository = khoaHocRepository;
        }

        [HttpPost("getAllCourses")]
        public IActionResult getAllCourses(KhoaHocQuery request)
        {
            try
            {
                return Ok(_khoaHocRepository.getAllKhoaHoc(request));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{maKH}")]
        public IActionResult getCourseById([FromRoute] string maKH)
        {
            try
            {
                return Ok(_khoaHocRepository.getKhoaHocByMaKH(maKH));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("addCourses")]
        public IActionResult addCourses(KhoaHoc_VM khoahoc)
        {
            try
            {
                return Ok(_khoaHocRepository.addKhoaHoc(khoahoc));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{maKH}")]
        public IActionResult updateCourses(string maKH, KhoaHoc_VM khoahoc)
        {
            try
            {
                _khoaHocRepository.updateKhoaHoc(maKH, khoahoc);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{maKH}")]
        public IActionResult deleteCourses(string maKH)
        {
            try
            {
                _khoaHocRepository.deleteKhoaHoc(maKH);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
