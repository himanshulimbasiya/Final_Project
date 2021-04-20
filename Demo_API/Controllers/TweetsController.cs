using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_API.Interfaces;
using Demo_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TweetsController : ControllerBase
    {
        private readonly ITweetService _tweetService;

        public TweetsController(ITweetService tweetService)
        {
            _tweetService = tweetService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tweets = _tweetService.GetAll();
            return Ok(tweets);
        }

        [HttpGet("{userName}")]
        public IActionResult GetOne(string userName)
        {
            var tweets = _tweetService.GetOne(userName);
            return Ok(tweets);
        }
    }
}
