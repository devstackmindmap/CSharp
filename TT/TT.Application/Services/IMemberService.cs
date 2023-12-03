using TT.Domain.Entities;

namespace TT.Application.Services
{
    public interface IMemberService
    {
        Task<Member> GetMember(int id);
    }
}
