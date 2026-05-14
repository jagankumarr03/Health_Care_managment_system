using Microsoft.AspNetCore.Mvc;
using AppointmentService.DTOs;
using AppointmentService.Services;

namespace AppointmentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(
            IAppointmentService service)
        {
            _service = service;
        }

        // BOOK

        [HttpPost]
        public async Task<IActionResult> BookAppointment(
            AppointmentDto appointmentDto)
        {
            var result = await _service.BookAppointment(
                appointmentDto);

            return Ok(result);
        }

        // VIEW

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var result = await _service.GetAllAppointments();

            return Ok(result);
        }

        // COMPLETE

        [HttpPut("complete/{id}")]
        public async Task<IActionResult> CompleteAppointment(
            int id)
        {
            var result = await _service.CompleteAppointment(id);

            return Ok(result);
        }

        // CANCEL

        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> CancelAppointment(
            int id)
        {
            var result = await _service.CancelAppointment(id);

            return Ok(result);
        }
    }
}