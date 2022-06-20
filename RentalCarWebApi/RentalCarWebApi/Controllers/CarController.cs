using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCarWebApi.Dtos;
using RentalCarWebApi.InterafceRepository;
using RentalCarWebApi.Models;

namespace RentalCarWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarController(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carRepository.GetAllCarAsync();
            var carsGet = _mapper.Map<List<CarGetDto>>(cars);
            return Ok(carsGet);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carRepository.GetCarByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }
            var carDto = _mapper.Map<CarGetDto>(car);
            return Ok(carDto);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> CreateCar([FromBody] CarCreateDto carPostDto)
        {

            var car = _mapper.Map<Car>(carPostDto);
            await _carRepository.CreateCarAsync(car);
            var carGet = _mapper.Map<CarGetDto>(car);
            return CreatedAtAction(nameof(GetCarById), new { id = car.CarId }, carGet);
        }
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> UpdateCar([FromBody] CarCreateDto carUpdateDto, int id)
        {
            var toUpdate = _mapper.Map<Car>(carUpdateDto);
            toUpdate.CarId = id;

            await _carRepository.UpdateCarAsync(toUpdate);
            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carRepository.DeleteCarAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
