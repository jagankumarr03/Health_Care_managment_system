using DoctorService.DTOs;

namespace DoctorService.Services
{
    public interface IDoctorService
    {
        Task<DoctorDto> AddDoctor(DoctorDto doctorDto);

        Task<List<DoctorDto>> GetAllDoctors();
    }
}