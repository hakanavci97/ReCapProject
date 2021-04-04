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
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpPost("CarImageAdd")]
        public IActionResult CarImageAdd([FromForm(Name =("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(carImage, file);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("CarImageDelete")]
        public IActionResult CarImageDelete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CarImageUpdate")]
        public IActionResult CarImageUpdate([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(carImage,file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetCarImagesAll")]

        public IActionResult GetCarImagesAll()
        {
            var result = _carImageService.GetAll();
            if(result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("GetImagesByCarId")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
