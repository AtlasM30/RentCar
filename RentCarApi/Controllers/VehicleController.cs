using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.DTOs.Vehicle;
using RentCar.Application.Services.Interfaces;

namespace RentCarApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleDTO dto)
        {
            var vehicle = await _vehicleService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = vehicle.id }, vehicle);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _vehicleService.GetAllAsync();
            return Ok(vehicles);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);
            if (vehicle == null)
                return NotFound();
            return Ok(vehicle);
        }

        [HttpGet("placa/{placa}")]
        public async Task<IActionResult> GetByPlaca(string placa)
        {
            var vehicle = await _vehicleService.GetByPlacaAsync(placa);
            if (vehicle == null)
                return NotFound();
            return Ok(vehicle);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateVehicleDTO dto)
        {
            var vehicle = await _vehicleService.UpdateAsync(id, dto);
            if (vehicle == null)
                return NotFound();

            return Ok(vehicle);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await _vehicleService.DeleteAsync(id);
            if(!vehicle)
                return NotFound();

            return NoContent();
        }
    }
}
