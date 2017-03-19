namespace _05_photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Album
    {
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
            this.Photographers=new HashSet<Photographer>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string BackgroundColour { get; set; }

        public bool PublicOrNot { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Photographer> Photographers { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
