using EFConcurrency.Data;
using EFConcurrency.Models;
using Microsoft.EntityFrameworkCore;

namespace WebEFConcurrency.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public User GetUser(long userId)
        {
            return _userContext.Users.Find(userId);
        }

        public void PostUser(long userId)
        {
            using (var transaction = _userContext.Database.BeginTransaction())
            {
                //var user = _userContext.Users.Find(userId);
                var user = _userContext.Users.FromSqlRaw($"SELECT * FROM `user` WHERE Id = {userId} FOR UPDATE").FirstOrDefault();
                user.Gold += 1;
                try
                {
                    _userContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine($"Concurrency Exception: {ex.Message}");
                }
                transaction.Commit();
            }
        }
    }
}
