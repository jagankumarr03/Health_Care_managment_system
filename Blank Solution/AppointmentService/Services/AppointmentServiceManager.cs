using AppointmentService.DTOs;
using AppointmentService.Models;
using AppointmentService.Repositories;

namespace AppointmentService.Services
{
    public class AppointmentServiceManager : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentServiceManager(
            IAppointmentRepository repository)
        {
            _repository = repository;
        }

        // BOOK

        public async Task<Appointment> BookAppointment(
    AppointmentDto appointmentDto)
        {
            var appointment = new Appointment
            {
                PatientName = appointmentDto.PatientName,

                DoctorName = appointmentDto.DoctorName,

                AppointmentDate = appointmentDto.AppointmentDate,

                Status = AppointmentStatus.Booked
            };

            return await _repository.AddAppointment(
                appointment
            );
        }

        // GET

        public async Task<List<Appointment>>
            GetAllAppointments()
        {
            return await _repository
                .GetAllAppointments();
        }

        // COMPLETE

        public async Task<string>
            CompleteAppointment(int id)
        {
            var appointment =
                await _repository.GetById(id);

            if (appointment == null)
            {
                return "Appointment Not Found";
            }

            if (appointment.Status ==
                AppointmentStatus.Cancelled)
            {
                return
                    "Cancelled appointment cannot be completed";
            }

            appointment.Status =
                AppointmentStatus.Completed;

            await _repository.SaveChanges();

            return "Appointment Completed";
        }

        // CANCEL

        public async Task<string>
            CancelAppointment(int id)
        {
            var appointment =
                await _repository.GetById(id);

            if (appointment == null)
            {
                return "Appointment Not Found";
            }

            if (appointment.Status ==
                AppointmentStatus.Completed)
            {
                return
                    "Completed appointment cannot be cancelled";
            }

            appointment.Status =
                AppointmentStatus.Cancelled;

            await _repository.SaveChanges();

            return "Appointment Cancelled";
        }
    }
}