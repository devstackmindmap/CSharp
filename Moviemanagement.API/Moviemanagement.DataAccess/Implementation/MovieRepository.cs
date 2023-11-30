using Moviemanagement.DataAccess.Context;
using Moviemanagement.Domain.Entities;
using Moviemanagement.Domain.Repository;

namespace Moviemanagement.DataAccess.Implementation
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieManagementDbContext context) : base(context)
        {
            
        }
    }
}
