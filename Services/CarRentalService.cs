using CarRentalSystem.Repositories;

namespace CarRentalSystem.Services
{
	public class CarRentalService
	{
		private readonly ICarRepository _carRepository;

		public CarRentalService(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}

		public bool CheckCarAvailability(Guid carId)
		{
			var car = _carRepository.GetCarById(carId);
			return car != null && car.IsAvailable;
		}

		public decimal? RentCar(Guid carId, int rentalDays)
		{
			var car = _carRepository.GetCarById(carId);
			if (car == null || !car.IsAvailable)
				return null;

			car.IsAvailable = false;
			_carRepository.UpdateCarAvailability(car.Id, false);

			return car.PricePerDay * rentalDays;
		}
	}
}
