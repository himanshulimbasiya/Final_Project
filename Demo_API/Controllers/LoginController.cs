using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_API.Interfaces;
using Demo_API.Models.ViewModels;

namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticateService)
        {
            _authenticationService = authenticateService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserViewModel model)
        {
            var user = _authenticationService.Login(model.Username, model.Password);
            if (user == null)
            {
                return BadRequest(new { Message = "Invalid username or password" });
            }
            else
                return Ok(user);
        }
    }
}
