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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpPost("RentalAdd")]
        public IActionResult RentalAdd(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpPost("RentalDelete")]
        public IActionResult RentalDelete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

        [HttpPost("RentalUpdate")]
        public IActionResult RentalUpdate(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

        [HttpGet("GetByRentalCarId")]
        public IActionResult GetByRentalCarId(int Id)
        {
            var result = _rentalService.GetByRentalCarId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

    }
}
