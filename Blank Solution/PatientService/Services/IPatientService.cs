using PatientService.DTOs;

namespace PatientService.Services
{
    public interface IPatientService
    {
        Task<PatientDto> AddPatient(PatientDto patientDto);

        Task<List<PatientDto>> GetAllPatients();
    }
}