using System.Diagnostics.CodeAnalysis;

namespace CarRentalSystem.Services
{
    public class JwtSettings
    {
        public required string Secret { get; set; }
        public string? ExpiryMinutes { get; set; }
    }
}
