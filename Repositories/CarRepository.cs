using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;


namespace CarRentalSystem.Repositories
{
	public class CarRepository : ICarRepository
	{
		private readonly ApplicationDbContext _context; // Database context

		public CarRepository(ApplicationDbContext context)
		{
			_context = context; // Initialize context
		}

		public void Add(Car car)
		{
			_context.Cars.Add(car); // Add car to database
			_context.SaveChanges(); // Save changes
		}

		public Car FindById(Guid carId)
		{
			return _context.Cars.Find(carId); // Find car by ID
		}

		public List<Car> FindAvailable()
		{
			return _context.Cars.Where(car => car.IsAvailable).ToList(); // Find available cars
		}

		public void UpdateAvailability(Guid carId, bool isAvailable)
		{
			var car = _context.Cars.Find(carId); // Find car by ID
			if (car != null)
			{
				car.IsAvailable = isAvailable; // Update availability
				_context.SaveChanges(); // Save changes
			}
		}

		public void Remove(Guid carId)
		{
			var car = _context.Cars.Find(carId); // Find car by ID
			if (car != null)
			{
				_context.Cars.Remove(car); // Remove car from database
				_context.SaveChanges(); // Save changes
			}
		}
	}
}
