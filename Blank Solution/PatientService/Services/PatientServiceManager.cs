using PatientService.DTOs;
using PatientService.Models;
using PatientService.Repositories;

namespace PatientService.Services
{
    public class PatientServiceManager : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientServiceManager(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<PatientDto> AddPatient(PatientDto patientDto)
        {
            var patient = new Patient
            {
                Name = patientDto.Name,
                Age = patientDto.Age
            };

            var result = await _repository.AddPatient(patient);

            return new PatientDto
            {
                Name = result.Name,
                Age = result.Age
            };
        }

        public async Task<List<PatientDto>> GetAllPatients()
        {
            var patients = await _repository.GetAllPatients();

            return patients.Select(x => new PatientDto
            {
                Name = x.Name,
                Age = x.Age
            }).ToList();
        }
    }
}