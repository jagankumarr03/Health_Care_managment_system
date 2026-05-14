using Microsoft.AspNetCore.Mvc;
using PatientService.DTOs;
using PatientService.Services;

namespace PatientService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(PatientDto patientDto)
        {
            var result = await _service.AddPatient(patientDto);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var result = await _service.GetAllPatients();

            return Ok(result);
        }
    }
}