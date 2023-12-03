using TT.Application.Repository;
using TT.Domain.Entities;
using TT.Infrastructure.Context;

namespace TT.Infrastructure.Repository
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(TTDbContext context) : base(context)
        {
        }
    }
}
