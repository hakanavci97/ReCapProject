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
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("BrandAdd")]
        public IActionResult BrandAdd(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);

        }
        [HttpPost("BrandDelete")]
        public IActionResult BrandDelete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);

        }
        [HttpPost("BrandUpdate")]
        public IActionResult BrandUpdate(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);

        }
        [HttpGet("GetBrandsAll")]
        public IActionResult GetBrandsAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpGet("GetBrandById")]
        public IActionResult GetBrandById(int brandId)
        {
            var result = _brandService.GetById(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
    }
}
