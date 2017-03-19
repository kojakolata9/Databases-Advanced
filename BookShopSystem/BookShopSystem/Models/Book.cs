
namespace BookShopSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        public Book()
        {
            this.Categories=new HashSet<Category>();
            this.RelatedBooks=new HashSet<Book>();
        }
        public enum EditionType { Normal, Promo, Gold }

        public enum AgeRestriction { Minor, Teen, Adult }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public EditionType Edition { get; set; }
        
        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int AuthorId { get; set; }

        [Required]
        [RegularExpression("^Minor|Teen|Adult$")]
        public AgeRestriction Restriction { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        public virtual ICollection<Book> RelatedBooks { get; set; }
    }
}
