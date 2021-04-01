using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {

        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost("ColorAdd")]
        public IActionResult ColorAdd(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);

        }
        [HttpPost("ColorDelete")]
        public IActionResult ColorDelete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);

        }
        [HttpPost("ColorUpdate")]
        public IActionResult ColorUpdate(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);

        }
        [HttpGet("GetColorsAll")]
        public IActionResult GetColorsAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpGet("GetColorById")]
        public IActionResult GetColorById(int colorId)
        {
            var result = _colorService.GetById(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
    }
}
