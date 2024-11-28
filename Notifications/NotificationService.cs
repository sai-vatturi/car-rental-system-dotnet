using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CarRentalSystem.Notifications
{
    public class NotificationService
    {
        private readonly string _email;
        private readonly string _appPassword;
        private readonly string _smtpHost = "smtp.gmail.com";  // Gmail SMTP server
        private readonly int _smtpPort = 587;  // SMTP port for Gmail (587 for TLS)

        // Constructor to initialize email settings via dependency injection
        public NotificationService(IConfiguration configuration)
        {
            _email = configuration["EmailSettings:Email"];
            _appPassword = configuration["EmailSettings:AppPassword"];
        }

        // Method to send booking confirmation email
        public async Task SendBookingConfirmation(string userEmail, string userName, string carDetails, int rentalDays)
        {
            // Calculate the total price for the rental
            decimal pricePerDay = 50m;  // Example: Set price per day (this could come from a database or input)
            decimal totalPrice = rentalDays * pricePerDay;

            // Create the email content
            var fromAddress = new MailAddress(_email, "Car Rental System");
            var toAddress = new MailAddress(userEmail, userName);
            var subject = "Your Car Rental Booking is Confirmed!";
            var body = $@"
Dear {userName},

We are pleased to inform you that your booking for the car: {carDetails} for {rentalDays} days has been successfully confirmed.

Total Price: ${totalPrice}

Thank you for choosing Car Rental System!
";

            using (var smtpClient = new SmtpClient(_smtpHost, _smtpPort))
            {
                // Set SMTP client properties
                smtpClient.EnableSsl = true;  // Enable SSL for secure connection
                smtpClient.Credentials = new NetworkCredential(_email, _appPassword);  // Gmail login credentials

                // Create the email message
                var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false  // Plain text email, set this to 'true' if you want HTML content
                };

                try
                {
                    // Send the email asynchronously
                    await smtpClient.SendMailAsync(message);
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during email sending
                    Console.WriteLine($"Error sending email: {ex.Message}");
                    throw new Exception("Failed to send email", ex);
                }
            }
        }
    }
}
