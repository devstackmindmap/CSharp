using Microsoft.EntityFrameworkCore;
using Moviemanagement.DataAccess.Context;
using Moviemanagement.Domain.Entities;
using Moviemanagement.Domain.Repository;

namespace Moviemanagement.DataAccess.Implementation
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(MovieManagementDbContext context) : base(context)
        {
            
        }

        public IEnumerable<Actor> GetActorsWithMovies() 
        {
            var actorsWithMovies = _context.Actors.Include(u => u.Movies).ToList();
            return actorsWithMovies;
        }
    }
}
