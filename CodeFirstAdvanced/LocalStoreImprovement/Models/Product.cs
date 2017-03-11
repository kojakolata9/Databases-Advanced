namespace LocalStoreImprovement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string DistributorName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required]
        public decimal Weight { get; set; }

        public decimal Quantity { get; set; }
    }
}
