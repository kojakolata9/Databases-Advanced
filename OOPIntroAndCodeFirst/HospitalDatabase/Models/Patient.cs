using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalDatabase.Models;

namespace HospitalDatabase.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Visitations = new List<Visitation>();
            this.Diagnoses = new List<Diagnose>();
            this.Medicines = new List<Medicine>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PatientId { get; set; }

        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public byte[] Picture { get; set; }

        [Required]
        public bool IsInsured { get; set; }



        public virtual List<Visitation> Visitations { get; set; }

        public virtual List<Diagnose> Diagnoses { get; set; }

        public virtual List<Medicine> Medicines { get; set; }


    }
}