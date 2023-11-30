using Moviemanagement.DataAccess.Context;
using Moviemanagement.Domain.Entities;
using Moviemanagement.Domain.Repository;

namespace Moviemanagement.DataAccess.Implementation
{
    public class BiographyRepository : GenericRepository<Biography>, IBiographyRepository
    {
        public BiographyRepository(MovieManagementDbContext context) : base(context)
        {
            
        }
    }
}
