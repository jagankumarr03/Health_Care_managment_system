using PatientService.Models;

namespace PatientService.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> AddPatient(Patient patient);

        Task<List<Patient>> GetAllPatients();
    }
}
