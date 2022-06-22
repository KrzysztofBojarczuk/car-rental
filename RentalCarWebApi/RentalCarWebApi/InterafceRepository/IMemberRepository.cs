using RentalCarWebApi.Models;

namespace RentalCarWebApi.InterafceRepository
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAllMemebersAsync();
        Task<Member> GetMemeberByIdAsync(int id);
        Task<Member> CreateMemberAsync(Member member);
        Task<Member> UpdateMemberAsync(Member updateMember);
        Task<Member> DeleteMemberAsync(int id);
    }
}
