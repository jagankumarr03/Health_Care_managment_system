using AppointmentService.DTOs;
using AppointmentService.Models;

namespace AppointmentService.Services
{
    public interface IAppointmentService
    {
        Task<Appointment> BookAppointment(
            AppointmentDto appointmentDto);

        Task<List<Appointment>> GetAllAppointments();

        Task<string> CompleteAppointment(int id);

        Task<string> CancelAppointment(int id);
    }
}