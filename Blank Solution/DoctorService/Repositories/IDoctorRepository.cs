using DoctorService.Models;

namespace DoctorService.Repositories
{
    public interface IDoctorRepository
    {
        Task<Doctor> AddDoctor(Doctor doctor);

        Task<List<Doctor>> GetAllDoctors();
    }
}