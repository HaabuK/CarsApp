using CarsApp.Dto;
using CarsApp.ServiceInterface;

namespace CarsAppTest
{
	public class CarsAppTest : TestBase
	{
        private CarDto MockCarData()
        {
            CarDto car = new()
            {
                Make = "BMW",
                Model = "X6",
                Year = DateTime.Now.AddYears(-2),
                Color = "Brown",
                Power = 251,
                Fuel = "Diesel",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return car;
        }

        private CarDto UpdateCarData()
        {
            CarDto car = new()
            {
                Make = "Jeep",
                Model = "Rubicon",
                Year = DateTime.Now.AddYears(-18),
                Color = "Teal",
                Power = 91,
                Fuel = "Diesel",
                UpdatedAt = DateTime.Now.AddYears(5)
            };
            return car;
        }

        [Fact]
        public async Task ShouldNot_CreateEmpty_WhenCreated()
        {
            CarDto car = new();

            car.Make = "Ford";
            car.Model = "Escort";
            car.Year = DateTime.Now.AddYears(-8);
            car.Color = "Gold";
            car.Power = 555;
            car.Fuel = "Diesel";
            car.CreatedAt = DateTime.Now;
            car.UpdatedAt = DateTime.Now;

            var result = await Svc<ICarsServices>().Create(car);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_UpdateData_WhenUpdated()
        {
            CarDto dto = MockCarData();

            var createCar = await Svc<ICarsServices>().Create(dto);

            CarDto update = UpdateCarData();

            var result = await Svc<ICarsServices>().Update(update);

            Assert.DoesNotMatch(result.Make, createCar.Make);
            Assert.NotEqual(result.Power, createCar.Power);
            Assert.Matches(result.Fuel, createCar.Fuel);
            Assert.NotEqual(result.UpdatedAt, createCar.UpdatedAt);
            Assert.NotEqual(result.CreatedAt, createCar.CreatedAt);
        }

        [Fact]
        public async Task Should_DeleteById_WhenDeleted()
        {
            CarDto car = MockCarData();

            var addCar = await Svc<ICarsServices>().Create(car);

            var result = await Svc<ICarsServices>().Delete((Guid)addCar.Id);

            Assert.Equal(addCar, result);
        }

        [Fact]
        public async Task ShouldNot_DeleteById_WhenNotDeleted()
        {
            CarDto car = MockCarData();

            var Car1 = await Svc<ICarsServices>().Create(car);
            var Car2 = await Svc<ICarsServices>().Create(car);

            var result = await Svc<ICarsServices>().Delete((Guid)Car1.Id);

            Assert.NotEqual(Car2.Id, result.Id);
        }
    }
}

