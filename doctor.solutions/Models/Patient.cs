using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorsOffice.Models
{
    public class Patient
    {
        public Patient()
        {
            this.JoinEntities = new HashSet<DoctorPatient>();
        }

        public int PatientId { get; set; }
        public string Name { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public virtual ICollection<DoctorPatient> JoinEntities { get;}
    }
}