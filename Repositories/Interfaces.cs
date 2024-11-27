using CarRentalSystem.Models;

namespace CarRentalSystem.Repositories
{
	public interface IUserRepository
	{
		// Retrieve a user by their unique identifier
		User GetUserById(Guid id);

		// Add a new user to the repository
		void AddUser(User user);

		// Find a user by their email address
		User GetUserByEmail(string email);
	}

	public interface ICarRepository
	{
		// Add a new car to the repository
		void AddCar(Car car);

		// Retrieve a car by its unique identifier
		Car GetCarById(Guid carId);

		// Get a list of all available cars
		List<Car> GetAvailableCars();

		// Update the availability status of a car
		void UpdateCarAvailability(Guid carId, bool isAvailable);

		// Remove a car from the repository
		void DeleteCar(Guid carId);
	}
}
