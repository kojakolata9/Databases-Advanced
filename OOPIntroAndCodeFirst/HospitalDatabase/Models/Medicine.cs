namespace HospitalDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;    
    public class Medicine
    {
        public Medicine()
        {
            this.Patients = new List<Patient>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineId { get; set; }

        [Required]
        [StringLength(50)]
        public string MedicineName { get; set; }

        public virtual List<Patient> Patients { get; set; }
    }
}
