namespace _05_photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Photographer
    {
        public Photographer()
        {
            this.Albums = new HashSet<Album>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        public DateTime RegisterdOn { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

    }
}
