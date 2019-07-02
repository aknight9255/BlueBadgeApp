namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Artist", "ShopID", "dbo.Shop");
            DropForeignKey("dbo.Post", "ArtistID", "dbo.Artist");
            DropIndex("dbo.Post", new[] { "ArtistID" });
            DropIndex("dbo.Artist", new[] { "ShopID" });
            DropTable("dbo.Post");
            DropTable("dbo.Artist");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        AritstID = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        ShopID = c.Int(nullable: false),
                        ArtistURL = c.String(),
                    })
                .PrimaryKey(t => t.AritstID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ArtistID = c.Int(nullable: false),
                        TattooDetails = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PostID);
            
            CreateIndex("dbo.Artist", "ShopID");
            CreateIndex("dbo.Post", "ArtistID");
            AddForeignKey("dbo.Post", "ArtistID", "dbo.Artist", "AritstID", cascadeDelete: true);
            AddForeignKey("dbo.Artist", "ShopID", "dbo.Shop", "ShopID", cascadeDelete: true);
        }
    }
}
