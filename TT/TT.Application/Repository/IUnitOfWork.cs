namespace TT.Application.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IMemberRepository Member { get; }

        Task<int> Save();
    }
}
