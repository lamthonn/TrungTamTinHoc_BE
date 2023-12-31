﻿using Microsoft.AspNetCore.Http;
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

        [HttpPost("AddThongBao")]
        public IActionResult AddThongBao(ThongBao_VM thongbao)
        {
            try
            {
                return Ok(_thongBaoRepository.AddThongBao(thongbao));
            }
            catch
            {
                return BadRequest();
            }
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

        [HttpPut("{id}")]
        public IActionResult UpdateThongBao (int id,ThongBao_VM thongbao)
        {
            try
            {
                _thongBaoRepository.UpdateThongBaos(id,thongbao);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteThongBao(int id)
        {
            try
            {
                _thongBaoRepository.DeleteThongBaos(id);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
