using TT.Application.Repository;
using TT.Domain.Entities;
using TT.Infrastructure.Context;

namespace TT.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TTDbContext _context;
        public IMemberRepository Member { get; private set; }

        public UnitOfWork(TTDbContext context)
        {
            _context = context;
            Member = new MemberRepository(_context);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
