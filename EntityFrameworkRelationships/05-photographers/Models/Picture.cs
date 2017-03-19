namespace _05_photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Picture
    {
        public Picture()
        {
            this.Albums = new HashSet<Album>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
       
        public string Caption { get; set; }
        
        public string FilePath { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

    }
}
