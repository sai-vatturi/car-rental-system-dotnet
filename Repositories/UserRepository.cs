using System;
using CarRentalSystem.Models;
using CarRentalSystem.Interfaces;

namespace CarRentalSystem.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context; // Database context

		public UserRepository(ApplicationDbContext context)
		{
			_context = context; // Initialize context
		}

		public void Add(User user)
		{
			_context.Users.Add(user); // Add user to context
			_context.SaveChanges(); // Save changes to database
		}

		public User FindById(Guid userId)
		{
			return _context.Users.Find(userId); // Find user by ID
		}

		public User FindByEmail(string email)
		{
			return _context.Users.FirstOrDefault(u => u.Email == email); // Find user by email
		}
	}
}
