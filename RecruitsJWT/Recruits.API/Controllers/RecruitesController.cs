using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recruits.API.Models;
using Recruits.API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recruits.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitesController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository;

        public RecruitesController(ITokenRepository tokenRepository) 
        {
            _tokenRepository = tokenRepository;
        }

        [HttpGet]
        [Route("hello")]
        public IActionResult Get()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users usersdata)
        {
            var token = _tokenRepository.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
