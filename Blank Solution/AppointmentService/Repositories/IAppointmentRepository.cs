using AppointmentService.Models;

namespace AppointmentService.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment> AddAppointment(Appointment appointment);

        Task<List<Appointment>> GetAllAppointments();

        Task<Appointment?> GetById(int id);

        Task SaveChanges();
    }
}