using RentalCarWebApi.Models;

namespace RentalCarWebApi.InterafceRepository
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAllMemebersAsync();
    }
}
