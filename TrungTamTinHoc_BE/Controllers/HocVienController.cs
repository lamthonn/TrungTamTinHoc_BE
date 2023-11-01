using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrungTamTinHoc_BE.Services.HocVien;
using static TrungTamTinHoc_BE.Services.HocVien.IHocvienRepository;

namespace TrungTamTinHoc_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocVienController : ControllerBase
    {
        public readonly IHocvienRepository _hocvienRepository;
        public HocVienController(IHocvienRepository hocvienRepository) 
        { 
            _hocvienRepository = hocvienRepository;
        }

        [HttpPost("GetHocVien")]
        public IActionResult GetHocVien (HocVienQuery hv)
        {
            try
            {
                return Ok(_hocvienRepository.GetDataHocVien(hv));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
