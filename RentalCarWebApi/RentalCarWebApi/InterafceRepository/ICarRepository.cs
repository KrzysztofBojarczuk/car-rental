using RentalCarWebApi.Models;

namespace RentalCarWebApi.InterafceRepository
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCarAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task<Car> CreateCarAsync(Car car);
        Task<Car> UpdateCarAsync(Car updateCar);
        Task<Car> DeleteCarAsync(int id);
    }
}
