namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtistTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artist", "ArtistContact", c => c.String(nullable: false));
            DropColumn("dbo.Artist", "PhoneNumber");
            DropColumn("dbo.Artist", "ArtistURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artist", "ArtistURL", c => c.String());
            AddColumn("dbo.Artist", "PhoneNumber", c => c.String(nullable: false));
            DropColumn("dbo.Artist", "ArtistContact");
        }
    }
}
