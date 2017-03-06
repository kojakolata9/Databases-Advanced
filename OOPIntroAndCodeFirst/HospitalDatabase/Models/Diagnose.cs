namespace HospitalDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Diagnose
    {
        public Diagnose()
        {
            this.Patients = new List<Patient>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiagnoseId { get; set; }

        [Required]
        [StringLength(50)]
        public string DiagnoseName { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }

        public virtual List<Patient> Patients { get; set; }
    }
}
