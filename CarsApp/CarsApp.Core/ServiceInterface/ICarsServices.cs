using System;
using CarsApp.Dto;
using CarsApp.Domain;

namespace CarsApp.ServiceInterface
{
	public interface ICarsServices
	{
        Task<Car> Create(CarDto dto);
        Task<Car> DetailsAsync(Guid id);
        Task<Car> Delete(Guid id);
        Task<Car> Update(CarDto dto);
    }
}

