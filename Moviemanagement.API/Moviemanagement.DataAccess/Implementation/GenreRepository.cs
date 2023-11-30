using Moviemanagement.DataAccess.Context;
using Moviemanagement.Domain.Entities;
using Moviemanagement.Domain.Repository;

namespace Moviemanagement.DataAccess.Implementation
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieManagementDbContext context) : base(context)
        {
            
        }
    }
}
