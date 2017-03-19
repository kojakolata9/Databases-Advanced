namespace _04_resource_licenses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Models;

    public partial class Resource
    {
        public Resource()
        {
            this.Licenses = new HashSet<License>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string ResourceType { get; set; }

        [Required]
        public string Url { get; set; }

        public int Course_Id { get; set; }

        public virtual Cours Cours { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}
