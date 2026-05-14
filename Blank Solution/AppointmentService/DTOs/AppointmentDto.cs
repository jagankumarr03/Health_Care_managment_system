namespace AppointmentService.DTOs
{
    public class AppointmentDto
    {
        public string PatientName { get; set; }

        public string DoctorName { get; set; }

        public DateTime AppointmentDate { get; set; }
    }
}