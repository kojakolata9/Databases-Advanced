namespace _05_photographers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedColumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BackgroundColour = c.String(),
                        PublicOrNot = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Caption = c.String(),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PictureAlbums",
                c => new
                    {
                        Picture_Id = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Picture_Id, t.Album_Id })
                .ForeignKey("dbo.Pictures", t => t.Picture_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_Id, cascadeDelete: true)
                .Index(t => t.Picture_Id)
                .Index(t => t.Album_Id);
            AddColumn("dbo.Albums", "Photographer_Id", c => c.Int());
            CreateIndex("dbo.Albums", "Photographer_Id");
            AddForeignKey("dbo.Albums", "Photographer_Id", "dbo.Photographers", "Id");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PictureAlbums", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.PictureAlbums", "Picture_Id", "dbo.Pictures");
            DropIndex("dbo.PictureAlbums", new[] { "Album_Id" });
            DropIndex("dbo.PictureAlbums", new[] { "Picture_Id" });
            DropTable("dbo.PictureAlbums");
            DropTable("dbo.Pictures");
            DropTable("dbo.Albums");
            DropForeignKey("dbo.Albums", "Photographer_Id", "dbo.Photographers");
            DropIndex("dbo.Albums", new[] { "Photographer_Id" });
            DropColumn("dbo.Albums", "Photographer_Id");
        }
    }
}
