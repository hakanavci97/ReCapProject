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
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerservice;

        public CustomersController(ICustomerService customerService)
        {
            _customerservice = customerService;
        }

        [HttpPost("CustomerAdd")]
        public IActionResult CustomerAdd(Customer customer)
        {
            var result = _customerservice.Add(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

        [HttpPost("CustomerDelete")]
        public IActionResult CustomerDelete(Customer customer)
        {
            var result = _customerservice.Delete(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpPost("CustomerUpdate")]
        public IActionResult CustomerUpdate(Customer customer)
        {
            var result = _customerservice.Update(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpGet("GetCustomersAll")]
        public IActionResult GetCustomersAll()
        {
            var result = _customerservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

    }
}
