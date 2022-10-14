namespace DoctorsOffice.Models
{
  public class DoctorPatient
    {       
        public int DoctorPatientId { get; set; }
        public int PatientId { get; set; }
        public int DocId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doc Doctor { get; set; }
    }
}