using Microsoft.AspNetCore.Mvc;
using Moviemanagement.Domain.Repository;

namespace Moviemanagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActorsController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var actorsFromRepo = _unitOfWork.Actor.GetAll();
            return Ok(actorsFromRepo);
        }

        [HttpGet("movies")]
        public ActionResult GetWithMovies()
        {
            var actorsFromRepo = _unitOfWork.Actor.GetActorsWithMovies();
            return Ok(actorsFromRepo);  
        }
    }
}
