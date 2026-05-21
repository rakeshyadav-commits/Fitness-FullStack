using FitnessAPI.DTOs;
using FitnessAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BMIController : ControllerBase
    {
        private readonly IBMIService _bmiService;

        public BMIController(IBMIService bmiService)
        {
            _bmiService = bmiService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBMI(BMIRecordDTO dto)
        {
            var result =
                await _bmiService.AddBMIAsync(dto);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBMI()
        {
            var result =
                await _bmiService.GetAllBMIAsync();

            return Ok(result);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBMI(
    int id,
    BMIRecordDTO dto)
        {
            var result =
                await _bmiService
                .UpdateBMIAsync(id, dto);

            return Ok(result);
        }
    }
}