using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class User
    {
        // Unique user ID
        [Key]
        public Guid Id { get; set; }

        // User's name
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Max 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters allowed.")]
        public required string Name { get; set; }

        // Email address
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email.")]
        [StringLength(100, ErrorMessage = "Max 100 characters.")]
        public required string Email { get; set; }

        // Password
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Min 8 characters.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])(?=.*^\S+$)[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password should contain 1 letter, 1 number.")]
        public required string Password { get; set; }

        // User role
        [Required(ErrorMessage = "Role is required.")]
        [RegularExpression("^(Admin|User)$", ErrorMessage = "Invalid role.")]
        public required string Role { get; set; }
    }
}
