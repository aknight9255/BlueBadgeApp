namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Artist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        ShopID = c.Int(nullable: false),
                        ArtistURL = c.String(),
                    })
                .PrimaryKey(t => t.ArtistID)
                .ForeignKey("dbo.Shop", t => t.ShopID, cascadeDelete: true)
                .Index(t => t.ShopID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ArtistID = c.Int(nullable: false),
                        TattooDetails = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Artist", t => t.ArtistID, cascadeDelete: true)
                .Index(t => t.ArtistID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "ArtistID", "dbo.Artist");
            DropForeignKey("dbo.Artist", "ShopID", "dbo.Shop");
            DropIndex("dbo.Post", new[] { "ArtistID" });
            DropIndex("dbo.Artist", new[] { "ShopID" });
            DropTable("dbo.Post");
            DropTable("dbo.Artist");
        }
    }
}
