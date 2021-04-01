using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("UserAdd")]
        public IActionResult UserAdd(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

        [HttpPost("UserDelete")]
        public IActionResult UserDelete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpPost("UserUpdate")]
        public IActionResult UserUpdate(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpGet("GetUsersAll")]
        public IActionResult GetUsersAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
    }
}
