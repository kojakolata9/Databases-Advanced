namespace BookshopSystemProblems
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookshopSystemContext : DbContext
    {
        public BookshopSystemContext()
            : base("name=BookshopSystemContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Categories)
                .WithMany(e => e.Books)
                .Map(m => m.ToTable("CategoryBooks"));

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Books1)
                .WithMany(e => e.Books)
                .Map(m => m.ToTable("RelatedBooks").MapRightKey("RelatedBook_Id"));
        }
    }
}
