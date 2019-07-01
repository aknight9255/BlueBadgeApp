namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Shop", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shop", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
