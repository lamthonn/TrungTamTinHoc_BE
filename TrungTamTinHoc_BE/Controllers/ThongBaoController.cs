using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrungTamTinHoc_BE.Data.ThongBaoViewModel;
using TrungTamTinHoc_BE.Services.thongBaoServices;

namespace TrungTamTinHoc_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongBaoController : ControllerBase
    {
        public readonly IThongBaoRepository _thongBaoRepository; 
        public ThongBaoController(IThongBaoRepository thongBaoRepository) 
        { 
            _thongBaoRepository = thongBaoRepository;
        }

        [HttpPost("GetThongBao")]
        public IActionResult GetThongBao(ThongBaoQuery request)
        {
            try
            {
                return Ok(_thongBaoRepository.GetThongBaos(request));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{title}")]
        public IActionResult UpdateThongBao (string title,ThongBao_VM thongbao)
        {
            try
            {
                _thongBaoRepository.UpdateThongBaos(title,thongbao);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{title}")]
        public IActionResult DeleteThongBao(string title)
        {
            try
            {
                _thongBaoRepository.DeleteThongBaos(title);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
