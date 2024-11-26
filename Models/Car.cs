using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; } // Unique car ID

        [Required(ErrorMessage = "Car make is mandatory.")]
        [StringLength(100, ErrorMessage = "Make cannot exceed 100 characters.")]
        public string Make { get; set; } // Brand of the car

        [Required(ErrorMessage = "Car model is required.")]
        [StringLength(100, ErrorMessage = "Model cannot exceed 100 characters.")]
        public string Model { get; set; } // Model of the car

        [Range(1900, 2100, ErrorMessage = "Enter a valid year between 1900 and 2100.")]
        public int Year { get; set; } // Manufacturing year

        [Required(ErrorMessage = "Please specify the daily rental price.")]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal PricePerDay { get; set; } // Rental price per day

        [Required]
        public bool IsAvailable { get; set; } // Rental availability
    }
}
