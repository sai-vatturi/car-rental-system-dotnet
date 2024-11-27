using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		// Retrieve user by email
		public User GetUserByEmail(string email)
		{
			return _context.Users.FirstOrDefault(u => u.Email == email);
		}

		// Add a new user to the database
		public void AddUser(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
		}

		// Fetch user by unique identifier
		public User GetUserById(Guid id)
		{
			return _context.Users.Find(id);
		}
	}
}
