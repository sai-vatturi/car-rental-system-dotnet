using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtMiddleware
{
	private readonly RequestDelegate _next;
	private readonly IConfiguration _configuration;

	public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
	{
		_next = next;
		_configuration = configuration;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		// Extract token from Authorization header
		var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

		if (!string.IsNullOrEmpty(token))
		{
			ValidateAndAttachUser(context, token);
		}

		await _next(context);
	}

	private void ValidateAndAttachUser(HttpContext context, string token)
	{
		try
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]);

			// Validate token
			tokenHandler.ValidateToken(token, new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = false,
				ValidateAudience = false,
				ClockSkew = TimeSpan.Zero
			}, out SecurityToken validatedToken);

			var jwtToken = (JwtSecurityToken)validatedToken;
			var claims = jwtToken.Claims;

			// Output claims for inspection
			foreach (var claim in claims)
			{
				Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
			}

			// Set claims to HttpContext.User
			var identity = new ClaimsIdentity(claims, "Bearer");
			context.User = new ClaimsPrincipal(identity);
		}
		catch (Exception ex)
		{
			// Log validation error
			Console.WriteLine($"Error validating token: {ex.Message}");
		}
	}
}
