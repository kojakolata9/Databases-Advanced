namespace CodeFirstSudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Course
    {
        public Course()
        {
            this.Homeworks = new HashSet<Homework>();
            this.Resources = new HashSet<Resource>();
            this.Students = new HashSet<Student>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
