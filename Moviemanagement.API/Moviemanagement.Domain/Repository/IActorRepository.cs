using Moviemanagement.Domain.Entities;

namespace Moviemanagement.Domain.Repository
{
    public interface IActorRepository : IGenericRepository<Actor>
    {
        IEnumerable<Actor> GetActorsWithMovies();
    }
}
