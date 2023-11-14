using EFConcurrency.Models;
using WebEFConcurrency.Repositories;

namespace WebEFConcurrency.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(long id)
        {
            return _userRepository.GetUser(id);
        }

        public void PostUser(long id)
        {
            _userRepository.PostUser(id);
        }
        
    }
}
