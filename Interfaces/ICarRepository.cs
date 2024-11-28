using CarRentalSystem.Models;

namespace CarRentalSystem.Interfaces
{
	public interface ICarRepository
    {
        void Add(Car car); // Add a new car to the repository
        Car FindById(Guid carId); // Retrieve a car by its unique identifier
        List<Car> FindAvailable(); // Get a list of all available cars
        void UpdateAvailability(Guid carId, bool isAvailable); // Update the availability status of a car
        void Remove(Guid carId); // Remove a car from the repository
    }

}
