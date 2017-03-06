namespace HospitalDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Visitation
    {
        public Visitation() {
            this.Patients = new List<Patient>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitationId { get; set; }

        public DateTime VisitationDate { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }

        public virtual List<Patient> Patients { get; set; }

        public virtual List<Doctor> Doctors { get; set; }
    }
}
