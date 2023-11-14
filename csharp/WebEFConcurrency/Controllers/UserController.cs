using EFConcurrency.Models;
using Microsoft.AspNetCore.Mvc;
using WebEFConcurrency.Services;

namespace WebEFConcurrency.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<WeatherForecastController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        //[HttpGet(Name = "go")]
        //[HttpGet("go")]
        //[HttpGet]
        //public string Get()
        //{
        //    return "Hello";
        //}


        //[HttpGet("go")]
        [HttpGet]
        public User Get()
        {
            return _userService.GetUser(1);
        }

        [HttpPost]
        public void Post()
        {
            _userService.PostUser(1);
        }
    }
}