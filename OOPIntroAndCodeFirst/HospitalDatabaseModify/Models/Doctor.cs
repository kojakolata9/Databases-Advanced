namespace HospitalDatabaseModify.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public class Doctor
    {
        public Doctor() {
            this.Visitations = new List<Visitation>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Speciality { get; set; }

        public virtual List<Visitation> Visitations { get; set; }
    }
}
