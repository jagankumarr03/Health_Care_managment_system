using DoctorService.DTOs;
using DoctorService.Models;
using DoctorService.Repositories;

namespace DoctorService.Services
{
    public class DoctorServiceManager : IDoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorServiceManager(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public async Task<DoctorDto> AddDoctor(DoctorDto doctorDto)
        {
            var doctor = new Doctor
            {
                Name = doctorDto.Name,
                Specialization = doctorDto.Specialization
            };

            var result = await _repository.AddDoctor(doctor);

            return new DoctorDto
            {
                Name = result.Name,
                Specialization = result.Specialization
            };
        }

        public async Task<List<DoctorDto>> GetAllDoctors()
        {
            var doctors = await _repository.GetAllDoctors();

            return doctors.Select(x => new DoctorDto
            {
                Name = x.Name,
                Specialization = x.Specialization
            }).ToList();
        }
    }
}