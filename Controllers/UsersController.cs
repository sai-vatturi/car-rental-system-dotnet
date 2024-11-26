using Microsoft.AspNetCore.Mvc;
using CarRentalSystem.Models;
using CarRentalSystem.Services;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Controllers
{
	/// Controller for user-related actions.
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly UserService _userService;

		/// Initializes a new instance of the <see cref="UsersController"/> class.
		/// <param name="userService">The user service.</param>
		public UsersController(UserService userService)
		{
			_userService = userService;
		}

		/// Registers a new user.
		/// <param name="user">The user to register.</param>
		/// <returns>Action result.</returns>
		[HttpPost("register")]
		public IActionResult RegisterUser([FromBody] User user)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var success = _userService.RegisterUser(user);
			if (!success)
				return BadRequest("User with this email already exists.");

			return Ok("User registered successfully.");
		}

		/// Authenticates a user and returns a token.
		/// <param name="request">The login request.</param>
		/// <returns>Action result.</returns>
		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginRequest request)
		{
			var token = _userService.AuthenticateUser(request.Email, request.Password);
			if (token == null)
				return Unauthorized("Invalid credentials.");

			return Ok(new { Token = token });
		}
	}

	/// Represents a login request.
	public class LoginRequest
	{
		[EmailAddress]
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
