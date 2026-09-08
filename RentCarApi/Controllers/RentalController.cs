using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.DTOs.Rental;
using RentCar.Application.Services.Interfaces;

namespace RentCarApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateRentalDto dto)
        {
            var rental = await _rentalService.CreateRentalAsync(dto);
            if (rental == null)
                return BadRequest("Não foi possível realizar o aluguel.");

            return CreatedAtAction(nameof(GetById), new { id = rental.id }, rental);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rentals = await _rentalService.GetAllRentalsAsync();
            return Ok(rentals);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rental = await _rentalService.GetRentalByIdAsync(id);
            if (rental == null)
                return NotFound();
            return Ok(rental);
        }
    }
}