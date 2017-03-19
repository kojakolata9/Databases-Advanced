namespace CodeFirstSudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Homework
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        [Required]
        public virtual Course Course { get; set; }

        [Required]
        public virtual Student Student { get; set; }
    }
}
