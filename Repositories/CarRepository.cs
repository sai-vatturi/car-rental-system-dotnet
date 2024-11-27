using System.Collections.Generic;
using System.Linq;
using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Repositories
{
	public class CarRepository : ICarRepository
	{
		private readonly ApplicationDbContext _context;

		public CarRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		// Add a new car to the database
		public void AddCar(Car car)
		{
			_context.Cars.Add(car);
			_context.SaveChanges();
		}

		// Retrieve a car by its unique identifier
		public Car GetCarById(Guid carId)
		{
			return _context.Cars.Find(carId);
		}

		// Get a list of all available cars
		public List<Car> GetAvailableCars()
		{
			return _context.Cars.Where(car => car.IsAvailable).ToList();
		}

		// Update the availability status of a car
		public void UpdateCarAvailability(Guid carId, bool isAvailable)
		{
			var car = _context.Cars.Find(carId);
			if (car != null)
			{
				car.IsAvailable = isAvailable;
				_context.SaveChanges();
			}
		}

		// Remove a car from the database
		public void DeleteCar(Guid carId)
		{
			var car = _context.Cars.Find(carId);
			if (car != null)
			{
				_context.Cars.Remove(car);
				_context.SaveChanges();
			}
		}
	}
}
