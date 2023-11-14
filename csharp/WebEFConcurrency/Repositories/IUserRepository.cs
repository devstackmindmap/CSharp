using EFConcurrency.Models;

namespace WebEFConcurrency.Repositories
{
    public interface IUserRepository
    {
        User GetUser(long userId);
        void PostUser(long userId);
    }
}
