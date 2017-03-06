namespace HospitalDatabaseModify
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Models;

    public partial class Visitation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Visitation()
        {
            this.Patients = new List<Patient>();
            this.Doctors = new List<Doctor>();
        }

        public int VisitationId { get; set; }

        public DateTime VisitationDate { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Patient> Patients { get; set; }

        public virtual List<Doctor> Doctors { get; set; }
    }
}
