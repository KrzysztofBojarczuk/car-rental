using Microsoft.EntityFrameworkCore;
using RentalCarWebApi.Data;
using RentalCarWebApi.InterafceRepository;
using RentalCarWebApi.Models;

namespace RentalCarWebApi.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Car> CreateCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> DeleteCarAsync(int id)
        {
            var car = await _context.Cars.SingleOrDefaultAsync(c => c.CarId == id);
            if (car == null)
            {
                return null;
                
            }
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return car;

        }

        public async Task<List<Car>> GetAllCarAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.CarId == id);

            if (car == null)
            {
                return null;
            }
            return car;
        }

        public async Task<Car> UpdateCarAsync(Car updateCar)
        {
            _context.Cars.Update(updateCar);
            await _context.SaveChangesAsync();
            return updateCar;
        }
    }
}
