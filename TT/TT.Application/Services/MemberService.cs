using TT.Application.Repository;
using TT.Domain.Entities;

namespace TT.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Member> GetMember(int id)
        {
            return await _memberRepository.GetByIdAsync(id);
        }
    }
}
