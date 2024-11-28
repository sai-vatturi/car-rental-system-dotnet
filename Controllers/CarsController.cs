using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRentalSystem.Models;
using CarRentalSystem.Repositories;
using CarRentalSystem.Services;
using CarRentalSystem.Interfaces;
using CarRentalSystem.Notifications;

namespace CarRentalSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly NotificationService _emailService;

		public CarsController(ICarRepository carRepository, NotificationService emailService)
		{
			_carRepository = carRepository;
			_emailService = emailService;
		}


        // GET /cars
        [HttpGet]
        public IActionResult GetAvailableCars()
        {
            var cars = _carRepository.FindAvailable();
            return Ok(cars);
        }

        // POST /cars (Admin only)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddCar([FromBody] Car car)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _carRepository.Add(car);
            return CreatedAtAction(nameof(GetAvailableCars), new { id = car.Id }, car);
        }

        // PUT /cars/{id}
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateCar(Guid id, [FromBody] Car car)
        {
            var existingCar = _carRepository.FindById(id);
            if (existingCar == null)
                return NotFound();

            existingCar.Make = car.Make;
            existingCar.Model = car.Model;
            existingCar.Year = car.Year;
            existingCar.PricePerDay = car.PricePerDay;
            existingCar.IsAvailable = car.IsAvailable;

            _carRepository.UpdateAvailability(existingCar.Id, car.IsAvailable);
            return NoContent();
        }

        // DELETE /cars/{id}
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(Guid id)
        {
            var car = _carRepository.FindById(id);
            if (car == null)
                return NotFound();

            _carRepository.Remove(id);
            return NoContent();
        }

        // POST /cars/book
        [Authorize(Roles = "User,Admin")]
        [HttpPost("book")]
        public async Task<IActionResult> BookCar([FromBody] BookingRequest bookingRequest)
        {
            var car = _carRepository.FindById(bookingRequest.CarId);
            if (car == null || !car.IsAvailable)
                return BadRequest("The car is not available for booking.");

            _carRepository.UpdateAvailability(car.Id, false);

            await _emailService.SendBookingConfirmation(
                bookingRequest.UserEmail,
                bookingRequest.UserName,
                $"{car.Make} {car.Model} ({car.Year})",
                1
            );

            // Booking can be done for 1 day at a time.
            _ = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromDays(1));
                _carRepository.UpdateAvailability(car.Id, true);
            });

            return Ok(new { message = "Car booked successfully. A confirmation email has been sent." });
        }
    }

    public class BookingRequest
    {
        public Guid CarId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
    }
}
