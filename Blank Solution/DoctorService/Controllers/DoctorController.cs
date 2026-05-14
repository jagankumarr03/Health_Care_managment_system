using DoctorService.DTOs;
using DoctorService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorDto doctorDto)
        {
            var result = await _service.AddDoctor(doctorDto);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var result = await _service.GetAllDoctors();

            return Ok(result);
        }
    }

}