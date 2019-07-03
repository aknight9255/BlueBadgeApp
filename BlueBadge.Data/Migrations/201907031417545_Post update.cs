namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Postupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "OwnerID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "OwnerID");
        }
    }
}
