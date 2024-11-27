using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace CarRentalSystem.Services
{
	public class EmailService
	{
		private readonly string _sendGridApiKey;

		public EmailService(string apiKey)
		{
			_sendGridApiKey = apiKey ?? throw new Exception("SendGrid API key is required.");
		}

		public async Task SendBookingConfirmation(string userEmail, string userName, string carDetails, int rentalDays)
		{
			var client = new SendGridClient(_sendGridApiKey);
			var from = new EmailAddress("sainadhvatturi@gmail.com", "Car Rental System");
			var to = new EmailAddress(userEmail, userName);
			var subject = "Your Car Rental Booking is Confirmed!";
			var plainTextContent = $"Dear {userName},\n\nWe are pleased to inform you that your booking for the car: {carDetails} for {rentalDays} days has been successfully confirmed.";
			var htmlContent = $"<strong>Dear {userName},</strong><br><br>We are pleased to inform you that your booking for the car: <strong>{carDetails}</strong> for <strong>{rentalDays}</strong> days has been successfully confirmed.";

			var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
			await client.SendEmailAsync(msg);
		}
	}
}
