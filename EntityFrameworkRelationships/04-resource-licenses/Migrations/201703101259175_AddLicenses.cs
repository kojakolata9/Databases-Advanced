namespace _04_resource_licenses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLicenses : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Resourse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.Resourse_Id)
                .Index(t => t.Resourse_Id);
        }
        
        public override void Down()
        {
            
            DropForeignKey("dbo.Licenses", "Resourse_Id", "dbo.Resources");           
            DropIndex("dbo.Licenses", new[] { "Resourse_Id" });          
            DropTable("dbo.Licenses");
            
        }
    }
}
