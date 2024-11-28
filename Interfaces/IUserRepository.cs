using CarRentalSystem.Models;

namespace CarRentalSystem.Interfaces
{

	 public interface IUserRepository
    {
        User FindById(Guid id); // Retrieve a user by their unique identifier
        void Add(User user); // Add a new user to the repository
        User FindByEmail(string email); // Find a user by their email address
    }
}
