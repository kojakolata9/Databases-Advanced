using System.Data;

namespace _05_photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Tag
    {
        public Tag()
        {
            this.Albums = new HashSet<Album>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
         
               
        [RegularExpression("[^ ]+")]       
        public string TagName { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
