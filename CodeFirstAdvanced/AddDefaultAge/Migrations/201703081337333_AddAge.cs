namespace AddDefaultAge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAge : DbMigration
    {
        public override void Up()
        {
            AddColumn("Customers","Age",c => c.Int(nullable: false,defaultValue: 20));

        }
        
        public override void Down()
        {
            DropColumn("Customers", "Age");
        }
    }
}
