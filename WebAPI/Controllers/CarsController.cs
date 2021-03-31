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

        [HttpGet("GetAll")]
        public IActionResult CarGetAll()
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
    }
}
