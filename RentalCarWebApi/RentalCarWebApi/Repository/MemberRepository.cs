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
    }
}
