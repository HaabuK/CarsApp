using System;
namespace CarsApp.Domain
{
	public class Car
	{
        public Guid? Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateOnly Year { get; set; }
        public string Color { get; set; }
        public int Power { get; set; }
        public string Fuel { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

