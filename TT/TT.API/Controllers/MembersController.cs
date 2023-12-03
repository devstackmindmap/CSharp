using Microsoft.AspNetCore.Mvc;
using TT.Application.Services;
using TT.Domain.Entities;

namespace TT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public ActionResult<Member> Get(int id)
        {
            var member = _memberService.GetMember(id);
            return Ok(member);
        }
    }
}
