

using BookShopSystem.Migrations;
using BookShopSystem.Models;

namespace BookShopSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;    

    public class BookShopContext : DbContext
    {        
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext,Configuration>());
        }

        public virtual IDbSet<Book> Books { get; set; }
        public virtual IDbSet<Author> Authors { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder){
            modelBuilder.Entity<Book>().HasMany(b => b.RelatedBooks).WithMany().Map(m=>
            {
                m.MapLeftKey("Book_Id");
                m.MapRightKey("RelatedBook_Id");
                m.ToTable("RelatedBooks");
            });
            base.OnModelCreating(modelBuilder);
        }

    }

    
}