namespace SalesDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class StoreLocation
    {
        public StoreLocation() {
            this.Sales = new HashSet<Sale>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string LocationName { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
