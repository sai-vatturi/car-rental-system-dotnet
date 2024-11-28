using CarRentalSystem.Interfaces;
using CarRentalSystem.Repositories;

namespace CarRentalSystem.Services
{
	public class CarRentalService
	{
		private readonly ICarRepository _carRepository;

		// Constructor to initialize the car repository
		public CarRentalService(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}

		// Method to check if a car is available for rent
		public bool CheckCarAvailability(Guid carId)
		{
			var car = _carRepository.FindById(carId);
			return car != null && car.IsAvailable;
		}

		// Method to rent a car for a specified number of days
		public decimal? RentCar(Guid carId, int rentalDays)
		{
			var car = _carRepository.FindById(carId);
			if (car == null || !car.IsAvailable)
				return null;

			// Mark the car as not available
			car.IsAvailable = false;
			_carRepository.UpdateAvailability(car.Id, false);

			// Calculate the total rental cost
			return car.PricePerDay * rentalDays;
		}
	}
}
