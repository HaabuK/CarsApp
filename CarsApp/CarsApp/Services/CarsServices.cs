using System;
using CarsApp.Data;
using CarsApp.Domain;
using CarsApp.Dto;
using CarsApp.Models.Cars;
using CarsApp.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using static CarsApp.Domain.Car;

namespace CarsApp.Services
{
	public class CarsServices : ICarsServices
	{
        private readonly CarsAppContext _context;

        public CarsServices
            (
                CarsAppContext context
            )
        {
            _context = context;
        }


        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car
            {
                Id = Guid.NewGuid(),
                Make = dto.Make,
                Model = dto.Model,
                Year = dto.Year,
                Color = dto.Color,
                Power = dto.Power,
                Fuel = dto.Fuel,
            };

            car.CreatedAt = DateTime.Now;
            car.UpdatedAt = DateTime.Now;


            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> DetailsAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Car> Update(CarDto dto)
        {
            Car car = new();

            car.Id = dto.Id;
            car.Make = dto.Make;
            car.Model = dto.Model;
            car.Year = dto.Year;
            car.Color = dto.Color;
            car.Power = dto.Power;
            car.Fuel = dto.Fuel;

            car.CreatedAt = DateTime.Now;
            car.UpdatedAt = DateTime.Now;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();


            return carId;
        }
    }
}

