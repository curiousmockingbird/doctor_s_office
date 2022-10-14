using System.Collections.Generic;
using System;

namespace DoctorsOffice.Models
{
  public class Doc
    {
        public Doc()
        {
          this.JoinEntities = new HashSet<DoctorPatient>();
        }

        public int DocId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public virtual ICollection<DoctorPatient> JoinEntities { get; set; }
    }
}