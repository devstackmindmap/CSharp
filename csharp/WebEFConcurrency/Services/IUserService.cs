using EFConcurrency.Models;

namespace WebEFConcurrency.Services
{
    public interface IUserService
    {
        User GetUser(long id);
        void PostUser(long id);
    }
}
