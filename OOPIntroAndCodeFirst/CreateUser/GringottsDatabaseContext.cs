namespace CreateUser
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class GringottsDatabaseContext : DbContext
    {
        public GringottsDatabaseContext()
            : base("name=GringottsDatabaseContext")
        {
        }
       
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
