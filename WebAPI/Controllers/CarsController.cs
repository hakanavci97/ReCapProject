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
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetCarsAll")]
        public IActionResult GetCarsAll()
        {
            var result = _carService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            else
            return BadRequest(result);
        }

        [HttpPost("CarAdd")]
        public IActionResult CarAdd(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);

            }
            else
                return BadRequest(result);
        }

        [HttpPost("CarDelete")]
        public IActionResult CarDelete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);

            }
            else
                return BadRequest(result);
        }

        [HttpPost("CarUpdate")]
        public IActionResult CarUpdate(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);

            }
            else
                return BadRequest(result);
        }



        [HttpPost("GetCarById")]
        
        public IActionResult GetCarById(int Id)
        {
            var result = _carService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

        [HttpGet("GetCarsByBrandId")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

        [HttpGet("GetCarsByColorId")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
    }
}
