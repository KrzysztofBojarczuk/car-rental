using RentalCarWebApi.Models;
using Microsoft.EntityFrameworkCore;
using RentalCarWebApi.Data;
using RentalCarWebApi.InterafceRepository;

namespace RentalCarWebApi.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DataContext _context;

        public MemberRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Member>> GetAllMemebersAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member> GetMemeberByIdAsync(int id)
        {
            var member = await _context.Members.FirstOrDefaultAsync(c => c.MemberId == id);

            if (member == null)
            {
                return null;
            }
            return member;
        }

        public async Task<Member> CreateMemberAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<Member> DeleteMemberAsync(int id)
        {
            var memeber = await _context.Members.SingleOrDefaultAsync(c => c.MemberId == id);

            if (memeber == null)
            {
                return null;
            }
            _context.Members.Remove(memeber);
            return memeber;
        }     
        public async Task<Member> UpdateMemberAsync(Member updateMember)
        {
            _context.Members.Update(updateMember);
            await _context.SaveChangesAsync();
            return updateMember;
        }
    }
}
