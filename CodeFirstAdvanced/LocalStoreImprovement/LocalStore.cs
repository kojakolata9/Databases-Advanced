namespace LocalStoreImprovement
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LocalStore : DbContext
    {
        public LocalStore()
            : base("name=LocalStore")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LocalStore>());
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
