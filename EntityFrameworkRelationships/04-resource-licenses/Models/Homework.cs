namespace _04_resource_licenses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Homework
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ContentType { get; set; }

        public DateTime SubmissionDate { get; set; }

        public int Course_Id { get; set; }

        public int Student_Id { get; set; }

        public virtual Cours Cours { get; set; }

        public virtual Student Student { get; set; }
    }
}
